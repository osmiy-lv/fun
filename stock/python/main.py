#!/usr/bin/env python3

from argparse import ArgumentParser
from logging import basicConfig as logConfig
from logging import debug, info, warning, error, critical, exception
from logging import DEBUG, INFO, WARNING, ERROR, CRITICAL

parser = ArgumentParser(description='Profit calculator')
parser.add_argument(
        'price',
        nargs='+',
        metavar='<price>',
        help='price for the single day'
        )
parser.add_argument(
        '-v', '--verbose',
        action="count",
        default=0,
        help="verbose level"
        )


def find_profit(prices):
    info("handle: '{}'".format(prices))

    d = [b - a for a, b in zip(prices, prices[1:])]
    debug("diff: {}".format(d))

    max_profit = profit = 0
    day = buy_day = sell_day = 0
    for p in d:
        day += 1
        profit += p

        debug("profit on day {0}: {1}".format(day, profit))

        if profit < 0:
            profit = 0
            buy_day = day

        if profit > max_profit:
            max_profit = profit
            sell_day = day

        debug("maximal profit: {0}, "
              "buy on day {1} (price = {2}) "
              "and sell on day {3} (price = {4})".format(
                max_profit,
                buy_day, prices[buy_day],
                sell_day, prices[sell_day]))

    return max_profit


def get_log_level(verbose=0):
    v2l_map = {
            0: ERROR,
            1: WARNING,
            2: INFO,
            3: DEBUG
            }
    return v2l_map.get(min(int(verbose), 3), ERROR)


def main(prog, args):
    logConfig(
            level=get_log_level(args.verbose),
            format='{}: %(levelname)s: %(message)s'.format(prog)
            )

    try:
        debug("start")

        prices = [int(p) for p in args.price]

        profit = find_profit(prices)
        print("Input: {}".format(prices))
        print("Output: {}".format(profit))
        print()

        debug("done")
    except ValueError as e:
        error("invalid price provided -> {}".format(e))
    except Exception as e:
        exception(e)


if __name__ == "__main__":
    main(
        args=parser.parse_args(),
        prog=parser.prog
        )

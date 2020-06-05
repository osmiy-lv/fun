#!/usr/bin/env python3

from argparse import ArgumentParser
from logging import basicConfig as logConfig
from logging import debug, info, warning, error, critical, exception
from logging import DEBUG, INFO, WARNING, ERROR, CRITICAL

parser = ArgumentParser(description='Subarray maximizator')
parser.add_argument(
        'number',
        nargs='+',
        metavar='<number>',
        help='a positive or negative natural number within array'
        )
parser.add_argument(
        '-v', '--verbose',
        action="count",
        default=0,
        help="verbose level"
        )


def find_max(numbers):
    info("handle: '{}'".format(numbers))

    max_sum = numbers[0]
    curr_sum = 0
    pos = first_pos = last_pos = 0
    for n in numbers:
        if n > (n + curr_sum):
            curr_sum = n
            first_pos = pos
        else:
            curr_sum += n

        debug("sum on position {0}: {1}".format(pos, curr_sum))

        if curr_sum > max_sum:
            max_sum = curr_sum
            last_pos = pos

        pos += 1

        debug("maximal sum: {0}, numbers: {1}".format(
                max_sum, numbers[first_pos:(last_pos + 1)]))

    return max_sum


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

        numbers = [int(n) for n in args.number]

        max_sum = find_max(numbers)
        print("Input: {}".format(numbers))
        print("Output: {}".format(max_sum))
        print()

        debug("done")
    except ValueError as e:
        error("invalid number provided -> {}".format(e))
    except Exception as e:
        exception(e)


if __name__ == "__main__":
    main(
        args=parser.parse_args(),
        prog=parser.prog
        )

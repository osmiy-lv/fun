#!/usr/bin/env python3

from argparse import ArgumentParser
from logging import basicConfig as logConfig
from logging import debug, info, warning, error, critical, exception
from logging import DEBUG, INFO, WARNING, ERROR, CRITICAL

parser = ArgumentParser(description='The longest substring identifier')
parser.add_argument(
        'string',
        nargs='+',
        metavar='<string>',
        help='string to be parsed'
        )
parser.add_argument(
        '-v', '--verbose',
        action="count",
        default=0,
        help="verbose level"
        )


def handle_string(s):
    info("handle: '{}'".format(s))

    pos = start_pos = 0
    s_len = len(s)
    max_len = 0

    while pos < s_len:
        current_c = s[pos]
        left_s = s[start_pos:pos]
        c_at_left = left_s.find(current_c)
        debug("'{0}' located at the '{1}' within substring '{2}'".format(
            current_c, c_at_left, left_s
        ))

        if c_at_left >= 0:
            substr_len = pos - start_pos
            debug('substring detected ({0}): {1}'.format(
                substr_len, s[start_pos:pos]))

            if substr_len > max_len:
                max_len = substr_len

            start_pos += c_at_left+1

        pos += 1

    # handle last character
    substr_len = pos - start_pos
    debug('substring detected ({0}): {1}'.format(substr_len, s[start_pos:pos]))
    if substr_len > max_len:
        max_len = substr_len

    return max_len


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
        for s in args.string:
            s_l = handle_string(s.strip())
            print("Input: '{}'".format(s))
            print("Output: {}".format(s_l))
            print()

        debug("done")
    except Exception as e:
        exception(e)


if __name__ == "__main__":
    main(
        args=parser.parse_args(),
        prog=parser.prog
        )

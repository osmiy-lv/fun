#!/usr/bin/env python3

from argparse import ArgumentParser
from logging import basicConfig as logConfig
from logging import debug, info, warning, error, critical, exception
from logging import DEBUG, INFO, WARNING, ERROR, CRITICAL

parser = ArgumentParser(description='Phone to String translator')
parser.add_argument(
        'phone',
        nargs='+',
        metavar='<phone number>',
        help='Phone number to be translated'
        )
parser.add_argument(
        '-v', '--verbose',
        action="count",
        default=0,
        help="verbose level"
        )

num2char = {
    "1": "1",
    "2": "abc",
    "3": "def",
    "4": "ghi",
    "5": "jkl",
    "6": "mno",
    "7": "pqrs",
    "8": "tuv",
    "9": "wxyz",
    "0": " "
}


class UnsupportedCharacterError(Exception):
    def __init__(self, val, allowed):
        self.wrong_val = val
        self.allowed_vals = list(allowed)
        self.message = "unsupported character"
        super().__init__(self.message)

    def __str__(self):
        return "'{0}' is out of allowed character set {1}".format(
            self.wrong_val, self.allowed_vals)


class LengthOutOfRangeError(Exception):
    def __init__(self, val, min_len, max_len):
        self.wrong_val = val
        self.min_len = min_len
        self.max_len = max_len
        self.message = "out of range"
        super().__init__(self.message)

    def __str__(self):
        return "len('{0}') = {1} is out of range [{2}, {3}]".format(
            self.wrong_val, len(self.wrong_val), self.min_len, self.max_len)


def handle_phone(phone, min_len=2, max_len=9):
    info("handle: '{}'".format(phone))

    p_len = len(phone)
    debug("len('{0}') = {1}, range [{2}, {3}]".format(
        phone, p_len, min_len, max_len))

    if p_len < min_len or p_len > max_len:
        raise LengthOutOfRangeError(
            phone, min_len=min_len, max_len=max_len)

    out = ['']
    for n in phone:
        n_chars = num2char.get(n, None)
        if not n_chars:
            raise UnsupportedCharacterError(n, num2char.keys())

        info("characters for '{0}': '{1}'".format(n, n_chars))

        out = [o + c for c in n_chars for o in out]
        debug("{0}: {1}".format(n, out))

    return out


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
        for p in args.phone:
            try:
                s = handle_phone(p.strip())
                print("Input: '{}'".format(p))
                print("Output ({0}): {1}".format(len(s), s))
                print()

            except (UnsupportedCharacterError, LengthOutOfRangeError) as e:
                error("'{0}' ignored, error: {1}".format(p, e))

        debug("done")
    except Exception as e:
        exception(e)


if __name__ == "__main__":
    main(
        args=parser.parse_args(),
        prog=parser.prog
        )

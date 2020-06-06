#!/usr/bin/env python3

from argparse import ArgumentParser
from logging import basicConfig as logConfig
from logging import debug, info, warning, error, critical, exception
from logging import DEBUG, INFO, WARNING, ERROR, CRITICAL
from random import randint
from json import dumps as json_dump

parser = ArgumentParser(description='Tree Inorder Traversal')
parser.add_argument(
        '-v', '--verbose',
        action="count",
        default=0,
        help="verbose level"
        )


class Leaf:

    def __init__(self, value):
        self._left = None
        self._right = None

        self._value = value

    @property
    def value(self):
        return self._value

    @property
    def left(self):
        return self._left

    @left.setter
    def left(self, value):
        if isinstance(value, Leaf):
            self._left = value
        else:
            self._left = Leaf(value)

    @property
    def right(self):
        return self._right

    @right.setter
    def right(self, value):
        if isinstance(value, Leaf):
            self._right = value
        else:
            self._right = Leaf(value)

    def __str__(self, lvl=0, note=" (root)"):
        out = list()
        out.append("{0}{1}{2}".format("  "*lvl, self.value, note))
        out.append(self.left.__str__(lvl + 1, " (L)")) if self.left else None,
        out.append(self.right.__str__(lvl + 1, " (R)")) if self.right else None,
        return "\n".join(out)

    def to_dict(self):
        return {
            self.value: [
                self.left.to_dict() if self.left else None,
                self.right.to_dict() if self.right else None
            ]
        } if self.left or self.right else self.value


def get_random_tree(val):
    """
    Generate a random binary tree by the split of the integer value

    :param int val: integer value to be split on terms
    :return: binary tree object Leaf
    """

    if val <= 1:
        return Leaf(val)

    leaf = Leaf(val)

    l_val = randint(0, val)
    r_val = val - l_val

    leaf.left = get_random_tree(l_val)
    leaf.right = get_random_tree(r_val)

    return leaf


def recursive_inorder_dump(tree):
    out = list()
    out.append(recursive_inorder_dump(tree.left)) if tree.left else None,
    out.append(str(tree.value))
    out.append(recursive_inorder_dump(tree.right)) if tree.left else None,

    return ", ".join(out)


def iterative_inorder_dump(tree):
    out = list()
    left_nodes = list()

    pos = tree

    while True:
        if pos:
            left_nodes.append(pos)
            pos = pos.left
        elif left_nodes:
            pos = left_nodes.pop()
            out.append(str(pos.value))
            pos = pos.right
        else:
            break

    return ", ".join(out)


def handle_tree():
    tree = get_random_tree(randint(2, 5))
    info("handle: '{}'".format(json_dump(tree.to_dict())))

    print("Input:\n{}".format(tree))
    print("Output (recursive): {}".format(recursive_inorder_dump(tree)))
    print("Output (iterative): {}".format(iterative_inorder_dump(tree)))
    return


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
        handle_tree()
        debug("done")
    except Exception as e:
        exception(e)


if __name__ == "__main__":
    main(
        args=parser.parse_args(),
        prog=parser.prog
        )

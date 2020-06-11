# Binary Tree Inorder Traversal

* Solution 1: recursive
* Solution 2: iterative

```
Input:
       10
    /      \
 4            6
/ \         /   \
1  3       5     0

Output: 1 4 3 10 5 6 0
```

## Solution
### Python

#### Realization
* Recursive algorithm [main.py::recursive_inorder_dump](./python/main.py)
* Iterative algorithm [main.py::iterative_inorder_dump](./python/main.py)

#### Usage
Each run generates a random tree.

![usage](screenshots/py-tree.JPG)

### C#

#### Realization
* Recursive algorithm [CGlobals.cs::CGlobals::RecursiveInorderDump](./c-sharp/CGlobals.cs)
* Iterative algorithm [CGlobals.cs::CGlobals::IterativeInorderDump](./c-sharp/CGlobals.cs)

#### Usage
Tree hardcoded within program.

![initial](screenshots/cs-tree.JPG)


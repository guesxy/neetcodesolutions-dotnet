using BST_validation;
using static System.Console;

WriteLine("Validating a Binary Search Tree");
var root = new TreeNode(2, new TreeNode(1), new TreeNode(3));
WriteLine(IsValidBST(root)); // True

root = new TreeNode(2, new TreeNode(2), new TreeNode(2));
WriteLine(IsValidBST(root)); // False

bool IsValidBST(TreeNode root)
{
    return Validate(root, long.MinValue, long.MaxValue);
}

bool Validate(TreeNode root, long minValue, long maxValue)
{
    if (root == null)
    {
        return true;
    }

    if (root.val <= minValue || root.val >= maxValue)
    {
        return false;
    }

    return Validate(root.left, minValue, root.val) && Validate(root.right, root.val, maxValue);
}

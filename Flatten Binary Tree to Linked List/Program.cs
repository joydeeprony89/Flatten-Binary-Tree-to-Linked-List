namespace Flatten_Binary_Tree_to_Linked_List
{
  class Program
  {
    static void Main(string[] args)
    {
      TreeNode root = new TreeNode(1);
      root.left = new TreeNode(2);
      root.right = new TreeNode(5);
      root.right.left = new TreeNode(6);
      root.left.left = new TreeNode(3);
      root.left.right = new TreeNode(4);

      Solution s = new Solution();
      s.Flatten_Iterative(root);
    }
  }


  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }


  public class Solution
  {
    public void Flatten(TreeNode root)
    {
      TreeNode DFS(TreeNode root)
      {
        if (root == null) return null;
        // example - 2
        //          3  4
        // above one flattern to 2->3->4
        var left = DFS(root.left); // will get 3 as left
        var right = DFS(root.right);// will get 4 as right
                                    // why only left != null, we are not modifying the right side , in case in pur example if we would not have 3 as left child, then our answer would be as it is given input
        if (left != null)
        {
          // 3 of right we want to link with root(2) of right i.e 4
          // 3 -> 4
          left.right = root.right;
          // root(2) of right link with root(2) of left i.e 3
          // 2 -> 3
          root.right = root.left;
          // as per the question requiremnt we want laft as null always
          // root(2).left -> null 
          root.left = null;
        }
        // 2->3->4
        // we want to have the last node reference, coz last node of right will be linked with root.right
        var last = right ?? left ?? root;
        return last;
      }
      DFS(root);
    }
    // Easy to understand 
    public void Flatten_Iterative(TreeNode root)
    {
      TreeNode cur = root;
      while (cur != null) 
      {
        if(cur.left != null)
        {
          var last = cur.left;
          while (last.right != null)
          {
            last.right = cur.right;
            cur.right = cur.left;
            cur.left = null;
          }
        }
        else
        {
          cur = cur.right;
        }
      }
    }
  }
}

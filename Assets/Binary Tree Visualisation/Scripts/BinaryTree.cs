using NodeFramework;

public class BinaryTree
{
    public Node Root;

    public Node Insert(Node _root,Node _inserting)
    {
        // If the root node isn't set, make the root node the inserting one.
        if(_root == null)
        {
            _root = _inserting;
            _root.Value = _inserting.Value;
            // Setup the root as if it was a root node, even if it isn't
            _root.Setup(null, NodeType.Root);
        }
        // Should this be the left node?
        else if(_inserting < _root)
        {
            //It should, so insert it and setup the node
            _root.Left = Insert(_root.Left, _inserting);
            _root.Left.Setup(_root, NodeType.Left);
        }
        else
        {
            //This must be the right node so let's set it up;
            _root.Right = Insert(_root.Right, _inserting);
            _root.Right.Setup(_root, NodeType.Right);
        }
        ConnectNodes(_root);
        return _root;
    }
    /// <summary>
    /// Connects the child nodes via line renderer to the root node 
    /// </summary>
    /// <param name="_node"></param>
    private void ConnectNodes(Node _root)
    {
        if(_root.Left != null)
        {
            // The left node exists, so connect it via the line renderer
            _root.LeftConnector.positionCount = 2;
            _root.LeftConnector.SetPosition(0, _root.transform.position);
            _root.LeftConnector.SetPosition(1, _root.Left.transform.position);
        }
        else
        {
            //There is no left node so make the line invisible
            _root.LeftConnector.positionCount = 0;
        }
        if (_root.Right != null)
        {
            // The right node exists, so connect it via the line renderer
            _root.RightConnector.positionCount = 2;
            _root.RightConnector.SetPosition(0, _root.transform.position);
            _root.RightConnector.SetPosition(1, _root.Right.transform.position);
        }
        else
        {
            //There is no right node so make the line invisible
            _root.RightConnector.positionCount = 0;
        }
        
    }
    /// <summary>
    /// Searches through the tree to find a specific node.
    /// </summary>
    /// <param name="_root"> The node we are looking at.</param>
    /// <param name="_target">The node we are searching for.</param>
    public void Traverse(Node _root, Node _target)
    {

        //If the root is null, escape from the function
        if(_root == null)
        {
            return;
        }
        _root.Activate();

        //If the node we are looking for's value is less than the root, recurse and activate the left node
        if(_root == _target)
        {
            return;
        }
        // If the node we are looking for's value is less than the root, recurse and activate the left node
        else if (_target < _root)
        {
            Traverse(_root.Left, _target);
        }
        //If the node we are looking for's value is greater than the root, recurse and activate the right node
        else
        {
            Traverse(_root.Right, _target);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType
{
    Open =0,
    Closed =1
}
public class Node
{
    public NodeType nodeType = NodeType.Open;
    public int x = -1;
    public int y = -1;
    public Vector3 Pos;
    public List<Node> neighbours = new List<Node>();
    public Node previous = null;
    public Node(int x,int y,NodeType nodeType)
    {
        this.x = x;
        this.y = y;
        this.nodeType = nodeType;
    }
    public void Reset()
    {
        previous = null; 
    }
}

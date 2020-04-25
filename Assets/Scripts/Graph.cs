using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    // Start is called before the first frame update
    public Node[,] nodes;
    public List<Node> walls = new List<Node>();
    int[,] m_mapdata;
    int m_width;
    int m_height;
    public static readonly Vector2[] directions =
    {
        new Vector2(0f,1f),
        new Vector2(1f,1f),
        new Vector2(1f,0f),
        new Vector2(1f,-1f),
        new Vector2(0f,-1f),
        new Vector2(-1f,-1f),
        new Vector2(-1f,0f),
        new Vector2(-1f,1f)
    };
    public void Init(int[,] m_data)
    {
        this.m_mapdata = m_data;
        this.m_width = m_data.GetLength(0);
        this.m_height = m_data.GetLength(1);
        nodes = new Node[m_width,m_height];
        for (int y = 0; y < m_height; y++)
        {
            for (int x = 0; x < m_width; x++)
            {
                NodeType nodeType = (NodeType)m_data[x, y];
                Node node = new Node(x, y, nodeType);
                nodes[x, y] = node;
                node.Pos = new Vector3(x, 0, y);
                if(nodeType == NodeType.Closed)
                {
                    walls.Add(node);
                }
            }
        }
        for(int y=0;y<m_height; y++)
        {
            for(int x=0;x<m_width;x++)
            {
                if(nodes[x,y].nodeType != NodeType.Closed)
                {
                    nodes[x, y].neighbours = GetNeighbours(x, y);
                }
            }
        }
    }
    public bool IsWithinBounds(int x, int y)
    {
        return (x >= 0 && x < m_width && y >= 0 && y < m_height);
    }
    public List<Node> GetNeighbours(int x,int y,Node[,] nodes,Vector2[] directions)
    {
        List<Node> neighbour = new List<Node>();
        foreach(Vector2 dir in directions)
        {
            int newx = x + (int)dir.x;
            int newy = y + (int)dir.y;
            if(IsWithinBounds(newx,newy) && nodes[newx,newy]!=null && nodes[newx,newy].nodeType!=NodeType.Closed)
            {
                neighbour.Add(nodes[newx, newy]);
            }
        }
        return neighbour;
    }
    List<Node> GetNeighbours(int x,int y)
    {
        return GetNeighbours( x,  y, nodes, directions);
    }
}

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
    }
}

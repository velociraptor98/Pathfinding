using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Graph))]
public class GraphView : MonoBehaviour
{
    public GameObject nodeViewPrefab;
    public Color baseColor = Color.white;
    public Color wallColor = Color.black;
    public void Init(Graph graph)
    {
        if(graph == null)
        {
            Debug.LogWarning("No valid graph");
            return;
        }
        foreach(Node n in graph.nodes)
        {
            GameObject instance = Instantiate(nodeViewPrefab,Vector3.zero,Quaternion.identity);
            NodeView nodeView = instance.GetComponent<NodeView>();
            if(nodeView != null)
            {
                nodeView.Init(n);
                if(n.nodeType == NodeType.Closed)
                {
                    nodeView.colorNode(wallColor);
                }
                else if(n.nodeType == NodeType.Open)
                {
                    nodeView.colorNode(baseColor);
                }
            }

        }

    }
}

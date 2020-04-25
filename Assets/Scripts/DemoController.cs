using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoController : MonoBehaviour
{
    public Map map;
    public Graph graph;
    private void Start()
    {
        if(map != null && graph != null)
        {
            int[,] mapInstance = map.CreateMap();
            graph.Init(mapInstance);
            GraphView graphView = graph.gameObject.GetComponent<GraphView>();
            
            if(graphView!=null)
            {
                print('1');
                graphView.Init(graph);
            }
        }
    }
}

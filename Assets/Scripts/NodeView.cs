using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeView : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tile;
    [Range(0, 0.5f)]
    public float borderSize = 0.15f;
    public void Init(Node node)
    {
        if(tile!=null)
        {
            gameObject.name = "Node(" + node.x + "," + node.y + ")";
            gameObject.transform.position = node.Pos;
            tile.transform.localScale = new Vector3(1f - borderSize, 1f, 1f - borderSize);
        }
    }
    void colorNode(Color color, GameObject go) 
    {
        if(go!=null)
        {
            Renderer renderer = go.GetComponent<Renderer>();
            if(renderer!=null)
            {
                renderer.material.color = color;
            }
        }
    }
    public void colorNode(Color color)
    {
        colorNode(color,tile); 
    }
}

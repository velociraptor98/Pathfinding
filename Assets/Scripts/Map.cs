using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    public int width = 10;
    public int height = 10;
    void Start()
    {
        int[,] mapInstance = CreateMap();
    }
    private int[,] CreateMap()
    {
        int[,] map = new int[width, height];
        for(int y=0;y<height; y++ )
        {
            for(int x=0;x<width;x++)
            {
                map[x, y] = 0;
            }
        }
        return map;
    }
}

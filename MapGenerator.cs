using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    
    public int width;
    public int height;


    int[,] map;
    int[,] startPos;

    void Start() {
        GenerateMap();
    }

    void GenerateMap() {
        map = new int[width,height];
        Debug.Log(map);
        FillMap();
        Drunkard();
    }

    void FillMap() {
        for (int x = 0; x<width; x ++) {
            for (int y = 0; y < height; y ++) {
                map [x, y] = 1;
            }
        }
    }

    void Drunkard() {
        int startX = width/2;
        Debug.Log(startX);
        int startY = height/2;
        Debug.Log(startY);
        startPos = new int [startX,startY];
        Debug.Log(startPos);
    }

    void OnDrawGizmos() {
        if (map != null){
            for (int x = 0; x<width; x ++) {
                for (int y = 0; y < height; y ++) {
                    Gizmos.color = (map[x,y] == 1)?Color.black:Color.white;
                    Vector2 pos = new Vector2(-width/2 + x + .5f, -height/2 +y+.5f);
                    Gizmos.DrawCube(pos, Vector2.one);
                }
            }
        }
    }
}

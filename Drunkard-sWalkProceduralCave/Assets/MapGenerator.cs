using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapGenerator : MonoBehaviour
{
    
    public int width;
    public int height;

    int[,] map;
    public float timeChangeInMillis = 0;

    void Start() {
        GenerateMap();
    }
    
    void Update() {
        timeChangeInMillis = Time.deltaTime * 1000;
        Debug.Log(timeChangeInMillis);

        
    }

    void GenerateMap() {
        map = new int[width,height];
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
        int startY = height/2;
        while (startX != width - 1 && startX != 0 && startY != height - 1 && startY != 0) {
            map [startX,startY] = 0;
            int direction = Random.Range(0, 4);
            if (direction == 0) {
                startY = startY - 1;
            } else if (direction == 1) {
                startX = startX + 1;
            } else if (direction == 2) {
                startY = startY + 1;
            } else {
                startX = startX - 1;
            }
        }
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

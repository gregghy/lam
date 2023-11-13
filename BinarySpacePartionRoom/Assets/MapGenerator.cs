using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int width;
    public int height;
    int[,] map;
    public int rooms;
    public int iteractions;

    int roomCenterX;
    int roomCenterY;
    int [,] roomPos;
    

    void Start() {
        GenerateMap();
    }

    void GenerateMap() {
        map = new int[width,height];
        roomPos = new int [width, height];
        FillMap();
        for (int i = 0; i < rooms; i++){
            GenerateRoom2();
        }
        GeneratePathStraight();
    }

    void FillMap() {
        for (int x = 0; x<width; x ++) {
            for (int y = 0; y < height; y ++) {
                map [x, y] = 1;
                roomPos[x, y] = 1;
            }
        }
    }

    void GenerateRoom() {
        int X1 = 1;
        int X2 = width;
        int Y1 = 1;
        int Y2 = height;
        int lineX;
        int lineY;

        for (int i = 0; i < iteractions; i++) {

            int paddingX = 14;
            int paddingY = 14;

            bool ver = false;
            bool or = false;

            if ((X2 - X1)/(Y2 - Y1) > 2/1){
                or = true;
            }
            if ((Y2 - Y1)/(X2 - X1) > 2/1) {
                ver = true;
            } else {
                int direzione = Random.Range(0, 2);
                if (direzione == 0) {
                    or = true;
                } else {
                    ver = true;
                }
            }

            if (or == true){
                lineX = Random.Range(X1, X2 - (paddingX));
                
                if ((X2-X1)/2 < lineX){
                    X2 = lineX;
                } else {
                    X1 = lineX;
                }
            }
            else if (ver == true){
                lineY = Random.Range(Y1, Y2 - (paddingY));

                if ((Y2-Y1)/2 < lineY){
                    Y2 = lineY;
                } else {
                    Y1 = lineY;
                }
            }
        }
        for (int x = X1; x < X2; x++) {
                for (int y = Y1; y < Y2; y ++) {
                    map [x, y] = 0;
                }
        }

    }
    void GenerateRoom2() {
        int X1 = 0;
        int X2 = width;
        int Y1 = 0;
        int Y2 = height;

        for (int i = 0; i < iteractions; i++) {

            bool ver = false;
            bool or = false;

            if ((X2 - X1)/(Y2 - Y1) > 3/2){
                or = true;
            }
            if ((Y2 - Y1)/(X2 - X1) > 3/2) {
                ver = true;
            } else {
                int direzione = Random.Range(0, 2);
                if (direzione == 0) {
                    or = true;
                } else {
                    ver = true;
                }
            }
            
            
            if (or == true) {
                int verso = Random.Range(0, 2);
                if (verso == 0) {
                    X1 = X1 + (X2-X1)/2;
                } else {
                    X2 = X2 - (X2-X1)/2;
                }
            } if (ver == true) {
                int verso = Random.Range(0, 2);
                if (verso == 0) {
                    Y1 = Y1 + (Y2-Y1)/2;
                } else {
                    Y2 = Y2 - (Y2-Y1)/2;
                }
            }
        }
        for (int x = X1; x < X2; x++) {
                for (int y = Y1; y < Y2; y ++) {
                    map [x, y] = 0;
                }
        }
        roomCenterX = Mathf.RoundToInt((X1 + X2)/2);
        roomCenterY = Mathf.RoundToInt((Y1 + Y2)/2);

                        
        roomPos [roomCenterX, roomCenterY] = 0;
    }
    
    void GeneratePathStraight() {
        List<int> xPos = new List<int>();
        List<int> yPos = new List<int>();
        for (int x = 0; x < width; x ++) {
            for (int y = 0; y < height; y++) {
                if (roomPos [x, y] == 0) {
                    xPos.Add(x);
                    yPos.Add(y);
                } 
            }
            
        }

        int[] xxx = xPos.ToArray();
        int[] yyy = yPos.ToArray();

        for (int i = 0; i < rooms; i++) {
                for (int p = xxx[i]; p < xxx[i+1]; p ++) {
                    map[p,yyy[i]] = 0;
                }
                if ((yyy[i]-yyy[i+1]) > 0) {
                    for (int q = yyy[i]; q > yyy[i+1]; q = q - 1) {
                        map [xxx[i+1],q] = 0;
                    }
                } else {
                    for (int q = yyy[i]; q < yyy[i+1]; q++) {
                        map [xxx[i+1],q] = 0;
                    }
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

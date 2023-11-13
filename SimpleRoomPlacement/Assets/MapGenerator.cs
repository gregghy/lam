using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapGenerator : MonoBehaviour
{
    public int width;
    public int height;
    public int NumberOfRooms;

    int roomX1;
    int roomY1;
    int roomX2;
    int roomY2;
    
    int roomCenterX;
    int roomCenterY;
    int [,] roomPos;

    int[,] map;

    void Start() {
        GenerateMap();
    }

    void GenerateMap() {
        map = new int[width,height];
        roomPos = new int [width, height];
        FillMap();

        for (int i = 0; i < NumberOfRooms; i++) {
            FindASpot();
        }
        GeneratePath();
        
    }
    void FillMap() {
        for (int x = 0; x<width; x ++) {
            for (int y = 0; y < height; y ++) {
                map [x, y] = 1;
                roomPos[x, y] = 1;

            }
        }
    }
    void FindASpot() {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        int paddingX = 14;
        int paddingY = 14;
        roomX1 = UnityEngine.Random.Range(1, width - (paddingX));
        roomY1 = UnityEngine.Random.Range(1, height - (paddingY));

        roomX2 = UnityEngine.Random.Range(roomX1 + 6, roomX1 + (paddingX - 1));
        roomY2 = UnityEngine.Random.Range(roomY1 + 6, roomY1 + (paddingY - 1));

        bool xOK = true;
        bool yOK = true;

        for (int x = roomX1; x < roomX2; x++) {
            if (map[x - 1,roomY1] == 0 || map[x + 1,roomY2] == 0) {
                xOK = false;
            }
            
        }
        for (int y = roomY1; y < roomY2; y++) {
            if (map[roomX1,y - 1] == 0 || map[roomX2,y + 1] == 0) {
                yOK = false;
            }
        }
        if (xOK == true && yOK == true) {
            GenerateRoom();
            roomCenterX = Mathf.RoundToInt((roomX1 + roomX2)/2);
            roomCenterY = Mathf.RoundToInt((roomY1 + roomY2)/2);

                        
            roomPos [roomCenterX, roomCenterY] = 0;

        } else {
            FindASpot();
        }
        watch.Stop();
        Debug.Log($"Execution Time: {watch.ElapsedMilliseconds} ms");
    }

    void GenerateRoom() {
        for (int x = roomX1; x < roomX2; x++) {
                for (int y = roomY1; y < roomY2; y ++) {
                    map [x, y] = 0;
                }
        }
    }

    void GeneratePath() {
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

        

        for (int i = 0; i < NumberOfRooms - 1; i++) {
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


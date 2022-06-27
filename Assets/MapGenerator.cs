using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int width;
    public int height;

    int roomX1;
    int roomY1;
    int roomX2;
    int roomY2;

    int [] Xposition;
    int [] Yposition;

    public int NumberOfRooms;

    int[,] map;


    void Start() {
        GenerateMap();
    }

    void GenerateMap() {
        map = new int[width,height];
        FillMap();

        for (int i = 0; i < NumberOfRooms; i++) {
            FindASpot();
        }
    }
    void FillMap() {
        for (int x = 0; x<width; x ++) {
            for (int y = 0; y < height; y ++) {
                map [x, y] = 1;
            }
        }
    }
    void FindASpot() {
        int paddingX = 14;
        int paddingY = 14;
        roomX1 = Random.Range(0, width - paddingX);
        roomY1 = Random.Range(0, height - paddingY);

        roomX2 = Random.Range(roomX1 + 6, roomX1 + paddingX);
        roomY2 = Random.Range(roomY1 + 6, roomY1 + paddingY);

        bool xOK = true;
        bool yOK = true;

        for (int x = roomX1; x < roomX2; x++) {
            if (map[x,roomY1] == 0 || map[x,roomY2] == 0) {
                xOK = false;
            }
            
        }
        for (int y = roomY1; y < roomY2; y++) {
            if (map[roomX1,y] == 0 || map[roomX2,y] == 0) {
                yOK = false;
            }
        }
        if (xOK == true && yOK == true) {
            GenerateRoom();

        } else {
            FindASpot();
        }
    }

    void GenerateRoom() {
        for (int x = roomX1; x < roomX2; x++) {
                for (int y = roomY1; y < roomY2; y ++) {
                    map [x, y] = 0;
                }
        }
    }

    void GenratePath() {

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

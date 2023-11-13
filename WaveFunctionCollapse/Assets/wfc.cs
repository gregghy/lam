using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class wfc : MonoBehaviour
{
    public Tilemap grid;
    public Tile blank;
    public Tile grass;
    public Tile sand;
    public Tile water;
    public int iteractions;
    public int width;
    public int height;


    IDictionary<Vector3Int, int> tiles = new Dictionary<Vector3Int, int>();
    IDictionary<Vector3Int, int> temp_tiles = new Dictionary<Vector3Int, int>();

    void Start () {
        InitialMap();

        Collapse();

        GenerateMap();
        }

    void InitialMap() {
        int ten = width/10;
        Debug.Log(ten);
        for(int x = 0; x<width; x++){
            for(int y = 0; y<height; y++){
                tiles.Add(new Vector3Int(x, y, 0), 0);
                temp_tiles.Add(new Vector3Int(x, y, 0), 0);
            }
        }
        for(int i = 0; i<iteractions; i++){
            tiles[new Vector3Int(UnityEngine.Random.Range(0, ten * 6), UnityEngine.Random.Range(0, height), 0)] = 3;
            tiles[new Vector3Int(UnityEngine.Random.Range(ten * 6, ten * 7), UnityEngine.Random.Range(0, height), 0)] = 2;
            tiles[new Vector3Int(UnityEngine.Random.Range(ten * 7, ten * 10), UnityEngine.Random.Range(0, height), 0)] = 1;
        }

        /*for(int i = 0; i<iteractions; i++){
            int x1 = UnityEngine.Random.Range(1, width - 1);
            int y1 = UnityEngine.Random.Range(1, height - 1);
            //tiles[new Vector3Int(x1, y1, 0)] = UnityEngine.Random.Range(0, 4);
            tiles[new Vector3Int(0, 0, 0)] = 1;
            tiles[new Vector3Int(1, 1, 0)] = 3;
        }
        */
    }

    void Collapse() {
        foreach (var key in tiles.Keys){
            if (tiles[key] != 0) {
                continue;
            }
            else {
                int[] neighbours = new int[4];

                Vector3Int DOWN = new Vector3Int(key.x, key.y - 1, 0);
                Vector3Int LEFT = new Vector3Int(key.x - 1, key.y, 0);
                Vector3Int RIGHT = new Vector3Int(key.x + 1, key.y - 1, 0);
                Vector3Int UP = new Vector3Int(key.x, key.y + 1, 0);

                if (tiles.ContainsKey(DOWN)){
                    neighbours[0] = (tiles[DOWN]);
                }
                if (tiles.ContainsKey(LEFT)){
                    neighbours[1] = (tiles[LEFT]);
                }               
                if (tiles.ContainsKey(UP)){
                    neighbours[2] = (tiles[UP]);
                }                
                if (tiles.ContainsKey(RIGHT)){
                    neighbours[3] = (tiles[RIGHT]);
                }
                
                bool w = false;
                bool g = false;
                bool s = false;

                foreach (var i in neighbours) {
                    if (i == 1) {
                        w = true;
                    }
                    if (i == 3) {
                        g = true;
                    }
                    if (i == 2) {
                        s = true;
                    }
                }

                if (w & g) {
                    temp_tiles[key] = 2;
                }
                
                if (!w & !g) {
                    int j = Random.Range(0, 10);
                        
                        if (j > 6 & j < 7) {
                            temp_tiles[key] = 1;
                        } 
                        if (j < 6) {
                            temp_tiles[key] = 2;
                        } if (j > 7) {
                            temp_tiles[key] = 3;
                        }
                }
                if (!w & g) {
                    if (s) {
                        int j = Random.Range(0, 10);
                        
                        if (j < 7) {
                            temp_tiles[key] = 2;
                        }
                        else {
                            temp_tiles[key] = 3;
                        }
                    } else {
                        int j = Random.Range(0, 10);
                        
                        if (j < 7) {
                            temp_tiles[key] = 3;
                        }
                        else {
                            temp_tiles[key] = 2;
                        }
                    }
                if (w & !g) {
                    if (s) {
                        int j = Random.Range(0, 10);
                        
                        if (j < 7) {
                            temp_tiles[key] = 2;
                        }
                        else {
                            temp_tiles[key] = 1;
                        }
                    } else {
                        int j = Random.Range(0, 10);
                        
                        if (j < 7) {
                            temp_tiles[key] = 1;
                        }
                        else {
                            temp_tiles[key] = 2;
                        }
                    }
                }
            }
            
                
            
        }
    }
    }


    
    void GenerateMap(){
    foreach (var key in temp_tiles.Keys) {
        Debug.Log(tiles[key]);
        if (tiles[key] == 0) {
            grid.SetTile(key, blank);
        }
        if (tiles[key] == 1) {
            grid.SetTile(key, water);
        }
        if (tiles[key] == 2) {
            grid.SetTile(key, sand);
        }
        if (tiles[key] == 3) {
            grid.SetTile(key, grass);
        }
    }
}
}
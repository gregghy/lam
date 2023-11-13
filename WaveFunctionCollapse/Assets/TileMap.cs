using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMap : MonoBehaviour
{
    public Tilemap grid;
    public Tile blank;
    public Tile grass;
    public Tile sand;
    public Tile water;
    public Tile rock;
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
        for(int x = 0; x<width; x++){
            for(int y = 0; y<height; y++){
                tiles.Add(new Vector3Int(x, y, 0), 0);
                temp_tiles.Add(new Vector3Int(x, y, 0), 0);
            }
        }

        for(int i = 0; i<iteractions*2; i++){
            int x1 = UnityEngine.Random.Range(1, width - 1);
            int y1 = UnityEngine.Random.Range(1, height - 1);
            tiles[new Vector3Int(x1, y1, 0)] = 1;
        }
        for(int i = 0; i<iteractions; i++){
            int x1 = UnityEngine.Random.Range(1, width - 1);
            int y1 = UnityEngine.Random.Range(1, height - 1);
            tiles[new Vector3Int(x1, y1, 0)] = 3;
        }


    }

    /*void Collapse2() {
        for (int z = 0; z < width * height; z++) {
        foreach (var key in temp_tiles.Keys){
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
                    tiles[key] = 2;
                }
                if (!w & !g) {
                    int j = Random.Range(0, 10);
                    
                     if (j > 4) {
                            tiles[key] = 3;
                        } else {
                            tiles[key] = 1;
                        } 
                }
                if (!w & g) {
                    if (s) {
                        int j = Random.Range(0, 10);
                        
                        if (j < 7) {
                            tiles[key] = 2;
                        }
                        else {
                            tiles[key] = 3;
                        }
                    } else {
                        int j = Random.Range(0, 10);
                        
                        if (j < 7) {
                            tiles[key] = 3;
                        }
                        else {
                            tiles[key] = 2;
                        }
                    }
                if (w & !g) {
                    if (s) {
                        int j = Random.Range(0, 10);
                        
                        if (j < 7) {
                            tiles[key] = 2;
                        }
                        else {
                            tiles[key] = 1;
                        }
                    } else {
                        int j = Random.Range(0, 10);
                        
                        if (j < 7) {
                            tiles[key] = 1;
                        }
                        else {
                            tiles[key] = 2;
                        }
                    }
                }

                
            }
        }

    }
    }
    }*/

    void Collapse() {
       // for (int g = 0; g < width * height; g++) {
            foreach (var key in temp_tiles.Keys){
                if (tiles[key] == 0) {
                    //controllo dei vicini
                    Vector3Int DOWN = new Vector3Int(key.x, key.y - 1, 0);
                    Vector3Int LEFT = new Vector3Int(key.x - 1, key.y, 0);
                    Vector3Int RIGHT = new Vector3Int(key.x + 1, key.y - 1, 0);
                    Vector3Int UP = new Vector3Int(key.x, key.y + 1, 0);

                    List<int> neighbours = new List<int>();

                    if (tiles.ContainsKey(DOWN)){

                        neighbours.Add(tiles[DOWN]);
                    }
                    if (tiles.ContainsKey(LEFT)){
                        neighbours.Add(tiles[LEFT]);
                    }               
                    if (tiles.ContainsKey(UP)){
                        neighbours.Add(tiles[UP]);
                    }                
                    if (tiles.ContainsKey(RIGHT)){
                        neighbours.Add(tiles[RIGHT]);
                    }

                    bool is_grass = false;
                    bool is_water = false;

                    foreach (var i in neighbours) {
                        if (i == 3) {
                            is_grass = true;
                        }
                        if (i == 1) {
                            is_water = true;
                        }
                    }

                    //regolo per la creazione di nuove caselle
                    if (!is_grass & !is_water){
                        int j = Random.Range(0, 10);
                        
                        if (j > 4) {
                            tiles[key] = 1;
                        } if (j < 5) {
                            tiles[key] = 3;
                        }
    
                    }
                    if(is_grass & is_water) {
                        tiles[key] = 2;
                    }

                        
                    if (!is_grass & is_water) {
                        int j = Random.Range(0, 100);
                        
                        if (j > 25) {
                            tiles[key] = 1;
                        } else {
                            tiles[key] = 2;
                        }
                    }

                    if (is_grass & !is_water) {
                        int j = Random.Range(0, 100);
                        
                        if (j > 25) {
                            tiles[key] = 3;
                        } else {
                            tiles[key] = 2;
                        }
                    }


                    /*if (is_rock) {
                        int j = Random.Range(0, 100);
                        
                        if (j > 2) {
                            tiles[key] = 4;
                        } else {
                            tiles[key] = 3;
                        }
                    }*/
                    



                }
            }
       // }
    }


    void GenerateMap() {
        foreach (var key in tiles.Keys) {
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
            if (tiles[key] == 4) {
                grid.SetTile(key, rock);
            }
        }
    }
}


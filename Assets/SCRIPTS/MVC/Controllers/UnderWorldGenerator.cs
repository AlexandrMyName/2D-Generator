using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace PlatformerECS
{
    public class UnderWorldGenerator
    {
        private Tilemap _tilemap;
        private Tile _tile;
        private Tile _tileWater;

        private int _mapHeight;
        private int _mapWidth;

        private int _fillPercent;
        private int _smoothPercent;

        bool _borders;
        private int[,] map;


        public UnderWorldGenerator(UnderWorldGeneratorView view)
        {
            _tilemap = view._tilemap;
            _tile = view._tile;
            _mapHeight = view._mapHeight;
            _mapWidth = view._mapWidth;
            _fillPercent = view._fillPercent;
            _smoothPercent = view._smoothPercent;
            _borders = view._borders;
            _tileWater = view._tileWater;
            map = new int[_mapWidth, _mapHeight];  
        }
        public void Start()
        {
            FillMap();

            for(int i = 0; i < _smoothPercent; i++)
            {
                SmoothMap();
            }
             
             DrawTiles();
        }

      

        private void FillMap()
        {
            for(int x = 0; x < _mapWidth; x++)
            {
                for(int y = 0; y < _mapHeight; y++)
                {
                    if (x == 0 || x == _mapWidth - 1 || y == 0 || y == _mapHeight - 1)
                    {
                        if (_borders)
                        {
                            map[x, y] = 1;
                        }
                        else
                        {
                            map[x, y] = Random.Range(0, 100) < _fillPercent ? 1 : 0;
                        }
                    }
                    else
                    {
                        map[x, y] = Random.Range(0, 100) < _fillPercent ? 1 : 0;
                    }
                   
                }
            }
           
        }

        private void SmoothMap()
        {
            for( int x = 0; x < _mapWidth; x++)
            {
                for(int y = 0; y < _mapHeight; y++)
                {
                    int neighbors = GetNeigbors(x, y);

                    if(neighbors > 4)
                    {
                        map[x, y] = 1;
                    }
                    else if(neighbors < 4)
                    {
                        map[x, y] = 0;
                    }


                }
            }
        }
        private int GetNeigbors(int x, int y)
        {
            int neighbors = 0;
            for(int gridX = x-1; gridX <= x+1; gridX++)
            {
                for (int gridY = y - 1; gridY <= y + 1; gridY++)
                {
                    if(gridX >= 0 && gridX < _mapWidth && gridY >= 0 && gridY <_mapHeight)
                    {
                        if(gridX != x || gridY != y)
                        {
                            neighbors += map[gridX, gridY];
                        }
                    }
                    else
                    {
                        neighbors++;
                    }
                }
            }

            return neighbors;
        }



        private void DrawTiles()
        {
            if (map == null) return;

            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {

                    if(map[x, y] == 1)
                    {
                        _tilemap.SetTile(new Vector3Int(
                            
                          -100 + x,
                          -100 + y,
                            0
                            
                            ), _tile);
                    }
                    else
                    {
                        _tilemap.SetTile(new Vector3Int(

                        -100 + x,
                        -100 + y,
                          0

                          ), _tileWater);
                    }

                }
            }
        }




    }
}

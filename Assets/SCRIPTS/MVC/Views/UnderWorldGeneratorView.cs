using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace PlatformerECS
{
    public class UnderWorldGeneratorView : MonoBehaviour
    {
        public Tilemap _tilemap;
        public Tile _tile;
        public Tile _tileWater;

        public int _mapHeight;
        public int _mapWidth;

        [Range(0,100)] public int _fillPercent;
        public int _smoothPercent;

        public bool _borders;
    }
}

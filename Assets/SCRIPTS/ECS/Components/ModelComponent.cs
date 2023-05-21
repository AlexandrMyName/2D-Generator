using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerECS
{
    [Serializable]
    public struct ModelComponent
    {
        public SpriteRenderer Renderer;
        public Transform _transform;
    }
}

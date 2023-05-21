using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voody.UniLeo;

namespace PlatformerECS
{

    [Serializable]
    public struct InputComponent
    {
        public float horizontal;
        public float vertical;

        public bool isJump;
        public bool isMove;
        public bool isGround;
    }


}
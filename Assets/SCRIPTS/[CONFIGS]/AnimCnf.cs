using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace PlatformerECS
{
    public enum AnimationState { Idle = 0, Run = 1, Jump = 2 };

    [CreateAssetMenu(fileName = "AnimationCnf",menuName = "CONFIGS/AnimationCNF",order = 1)]
    public class AnimCnf : ScriptableObject
    {

        [Serializable]
        public class AnimationSequences
        {
           public List<Sprite> Sprites = new List<Sprite>();
           public AnimationState State;
        }

        public List <AnimationSequences> Animations;

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerECS
{
    public class AnimationController : IDisposable
    {
        public class Animation
        {
            public float speed;
            public List<Sprite> sprites = new List<Sprite>();
            public float counter;
            public bool isSleep;
            public bool isLoop;
            public AnimationState _track;

            public void Update()
            {
                if(isSleep) return;
                counter += Time.deltaTime * speed;

                if (isLoop)
                {
                    while (counter > sprites.Count)
                    {
                        counter-= sprites.Count;
                       
                    }
                }
                else if(counter > sprites.Count)
                {
                    counter = sprites.Count;
                    isSleep = true;
                }
            }
        }

        public AnimationController (AnimCnf config) => _config = config;


        private Dictionary<SpriteRenderer, Animation> _activeAnimations = new Dictionary<SpriteRenderer, Animation>();
        private AnimCnf _config;


        public void Start(SpriteRenderer renderer, bool isLoop, AnimationState track, float speed)
        {
            if (_activeAnimations.TryGetValue(renderer, out var animation))
            {

                if(animation._track != track)
                {
                    animation._track = track;
                    animation.sprites = _config.Animations.Find(x => x.State == track).Sprites;
                    animation.counter = 0;
                    animation.isSleep = false;
                }
                else
                {

                    animation.isSleep = false;
                   
                    animation.speed = speed;
                    animation.isLoop = isLoop;
                }
              
            }
            else
            {
                _activeAnimations.Add(renderer, new Animation()
                {
                    sprites = _config.Animations.Find(x => x.State == track).Sprites,
                    isLoop = isLoop,
                    speed = speed,
                    _track = track,
                    isSleep = false,
                    counter = 0
                    

            });
            }
        }

        public void Stop(SpriteRenderer renderer)
        {
            if(_activeAnimations.ContainsKey(renderer))
                _activeAnimations.Remove(renderer);
        }

        public void Update()
        {
            foreach(var animation in _activeAnimations)
            {
                animation.Value.Update();

                if(animation.Value.counter < animation.Value.sprites.Count)
                {
                    animation.Key.sprite = animation.Value.sprites[(int)animation.Value.counter];
                }
            }
        }

        public void Dispose()
        {
           _activeAnimations.Clear();
        }
    }
}

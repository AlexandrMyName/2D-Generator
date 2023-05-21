using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlatformerECS
{
    public class PlayerAnimator : IEcsRunSystem
    {
        private EcsFilter<PlayerTag,ModelComponent,InputComponent> _filter;

        private AnimCnf _config = Resources.Load<AnimCnf>("PlayerAnimCnf");
        private AnimationController animator;

        bool initialize = false;
        bool isMove;
        bool isGround;

        private float _animationSpeed = 24f;
        

        private SpriteRenderer renderer;

        public void Run()
        {
            if(!initialize) {
                animator = new AnimationController(_config);
                initialize = true;
            }

           

            foreach (var i in _filter)
            {
                ref var player = ref _filter.Get2(i);
                ref var input = ref _filter.Get3(i);
               
                renderer = player.Renderer;
                isMove = input.isMove;
                isGround = input.isGround;
            }
           
            AnimatorUpdate();
            
        }
        
        private void AnimatorUpdate(){

            animator.Update();

            if (isGround)
                   animator.Start(renderer, true, isMove == true ? AnimationState.Run : AnimationState.Idle, _animationSpeed);
            
                    else
                        animator.Start(renderer, false, AnimationState.Jump, _animationSpeed);
        }
    }
}

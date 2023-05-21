using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voody.UniLeo;

namespace PlatformerECS
{
    public sealed class ECS_INIT : MonoBehaviour
    {
        private EcsWorld _world = null;
        private EcsSystems _systems = null;

        void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _systems.ConvertScene();


            AddInjections();
            AddSystem();
            AddOneFrames();

            _systems.Init();
        }


        private void AddInjections() { }
        private void AddSystem() =>_systems.Add(new PlayerInputSystem()).Add(new PlayerAnimator());
         
        private void AddOneFrames() { }

        void Update() => _systems.Run();

        private void OnDestroy()
        {
            if(_systems == null) return;
            _systems.Destroy();
            _systems=null;
            _world.Destroy();
            _world = null;
        }
    }
}

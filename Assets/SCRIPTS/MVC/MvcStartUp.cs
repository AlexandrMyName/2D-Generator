using PlatformerECS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerECS
{
    public class MvcStartUp : MonoBehaviour
    {
        [SerializeField] private UnderWorldGeneratorView _worldGeneratorView;

        private UnderWorldGenerator _generatorController;
        void Start()
        {
            _generatorController = new UnderWorldGenerator(_worldGeneratorView);
            _generatorController.Start();
        }

      
        void Update()
        {

        }
    }
}

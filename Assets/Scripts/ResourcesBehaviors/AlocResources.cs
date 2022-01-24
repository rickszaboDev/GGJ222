using System.Collections;
using GGJ22.Variables;
using UnityEngine;

namespace GGJ22.Gameplay
{
    public class AlocResources : MonoBehaviour
    {
        [SerializeField] private AlocResourcesSet set;

        public int AlocValue = 0;
        private void Start()
        {
            set.Register(this);
        }

        private void OnDisable() 
        {
            set.Unregister(this);    
        }
    }
}

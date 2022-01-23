using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GGJ22.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent gameEvent;
        [SerializeField] private UnityEvent OnListenerCall;

        private void Start() 
        {
            gameEvent.Register(this);
        }

        private void OnDisable() 
        {
            gameEvent.Unregister(this);
        }

        public void Invoke()
        {
            OnListenerCall.Invoke();
        }
    }
}
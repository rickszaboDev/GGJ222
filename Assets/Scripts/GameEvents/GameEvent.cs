using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ22.Events
{
    [CreateAssetMenu(fileName="GameEvent", menuName="GameEvents/GameEvent")]
    public class GameEvent : ScriptableObject
    {    
        private List<GameEventListener> listeners = new List<GameEventListener>();
        private bool Lock = false;
        
        public void Register(GameEventListener listener)
        {
            if(!Lock)
            listeners.Add(listener);
        }

        public void Unregister(GameEventListener listener)
        {
            if(!Lock)
            listeners.Remove(listener);
        }

        public void Execute()
        {
            foreach(var listener in listeners)
            {
                Lock = true;
                listener.Invoke();
            }
            Lock = false;
        }
    }
}
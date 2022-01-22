using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace GGJ22.Variables
{
    public class ReactiveVariable<T> : ScriptableObject 
    {
        private bool _lock = false;
        private List<Action<T>> listeners = new List<Action<T>>();
        [SerializeField] private T startValue;
        [HideInInspector] [SerializeField] private T value;
        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                foreach(var listener in listeners)
                {
                    listener.Invoke(this.value);
                    _lock = true;
                }
                _lock = false;
            }
        }
        
        public void Register(Action<T> callback)
        {
            if(!_lock) return;
            
            listeners.Add(callback);   
        }

        public void Unregister(Action<T> callback)
        {
            if(!_lock) return;

            listeners.Remove(callback);
        }

        private void OnDisable()
        {
        	value = startValue;
        }
    }
}
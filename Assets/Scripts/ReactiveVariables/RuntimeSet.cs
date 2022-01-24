using UnityEngine;
using System.Collections.Generic;

namespace GGJ22.Variables
{
    public class RuntimeSet<T> : ScriptableObject 
    {
        public List<T> Set = new List<T>();
        public void Register(T obj)
        {
            if(Set.Contains(obj)) return;
            Set.Add(obj);
        }

        public void Unregister(T obj)
        {
            if(Set.Contains(obj))
            {
                Set.Remove(obj);
            }
        }
    }
}
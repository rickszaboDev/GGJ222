using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "RuntimeSet", menuName = "Variables/RuntimeSet", order = 0)]
public class RuntimeSet<T> : ScriptableObject 
{
    private List<T> set = new List<T>();

    public void Register(T obj)
    {
        if(set.Contains(obj)) return;

        set.Add(obj);
    }

    public void Unregister(T obj)
    {
        if(set.Contains(obj))
        {
            set.Remove(obj);
        }
    }
}
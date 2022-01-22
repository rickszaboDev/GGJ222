using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ22.Events;

public class DebugLogBeh : MonoBehaviour
{
    [SerializeField] private string DebugText;
    [SerializeField] private GameEvent gameEvent;
    public void Execute()
    {
        Debug.Log(DebugText);
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            gameEvent.Execute();
        }   
    }
}

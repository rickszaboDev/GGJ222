using GGJ22.StateMachine;
using UnityEngine;

public class StateMachineController : MonoBehaviour 
{
    [SerializeField] private State startState;
    [SerializeField] private State currentState;

    private void Start()
    {
        currentState = startState;
        currentState.OnStart();
    }
    public void SetState(State newState)
    {
        currentState.OnFinish();
        currentState = newState;
        currentState.OnStart();
    }
}
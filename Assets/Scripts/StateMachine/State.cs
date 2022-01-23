using UnityEngine;
using UnityEngine.Events;

namespace GGJ22.StateMachine
{
    [CreateAssetMenu(fileName = "State", menuName = "StateMachine/State", order = 0)]
public class State : ScriptableObject {
    
    [SerializeField] private UnityEvent OnStartEvent;
    [SerializeField] private UnityEvent OnFinishEvent;

    public void OnStart()
    {
        OnStartEvent.Invoke();
    }

    public void OnFinish()
    {
        OnFinishEvent.Invoke();
    }
}
}
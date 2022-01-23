using System.Collections;
using System.Collections.Generic;
using GGJ22.Variables;
using UnityEngine;

public class ToggleDayNight : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private BoolValue isDay;

    private void Start()
    {
        isDay.Register(Toggle);
    }

    private void Toggle(bool res)
    {
        var trigger = res ? "SetNight" : "SetDay";
        _animator.SetTrigger(trigger);
    }
}

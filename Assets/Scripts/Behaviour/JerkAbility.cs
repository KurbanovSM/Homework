using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerkAbility : MonoBehaviour, Iability
{
    [HideInInspector] public bool IsJerk;

    public float LenghtJerk;

    [SerializeField] private float _shootDelay;

    private float _time = float.MinValue;

    public void Execute()
    {
        if (Time.time < _shootDelay + _time) 
        {
            IsJerk = false;
        }
        else
        {
            _time = Time.time;
            IsJerk = true;
        }
    }
}

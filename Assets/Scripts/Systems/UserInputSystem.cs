using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine.InputSystem;

public class UserInputSystem : SystemBase
{
    private InputAction _moveAction;
    private InputAction _shootAction;
    private InputAction _jerkAction;

    private float2 _moveInput;
    private float _shootInput;
    private float _jerkInput;

    protected override void OnStartRunning()
    {
        _moveAction = new InputAction("move", binding: "<Gamepad>/LeftStick");
        _moveAction.AddCompositeBinding("Dpad")
            .With("Up", binding: "<Keyboard>/w")
            .With("Down", binding: "<Keyboard>/s")
            .With("Left", binding: "<Keyboard>/a")
            .With("Right", binding: "<Keyboard>/d");

        _moveAction.performed += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.started += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.canceled += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.Enable();


        _shootAction = new InputAction("shoot", binding: "<Keyboard>/Q");
        
        _shootAction.performed += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.started += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.canceled += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.Enable();

        _jerkAction = new InputAction("jerk", binding: "<Keyboard>/Space");

        _jerkAction.performed += context => { _jerkInput = context.ReadValue<float>(); };
        _jerkAction.started += context => { _jerkInput = context.ReadValue<float>(); };
        _jerkAction.canceled += context => { _jerkInput = context.ReadValue<float>(); };
        _jerkAction.Enable();
    }

    protected override void OnStopRunning()
    {
        _moveAction.Disable();
        _shootAction.Disable();
        _jerkAction.Disable();
    }

    protected override void OnUpdate()
    {
        var moveInput = _moveInput;
        var shootInput = _shootInput;
        var jerkInput = _jerkInput;

        Entities.ForEach((
            ref MoveComponent moveComponent,
            ref ShootComponent shootComponent,
            ref JerkComponent jerkComponent) => 
        {
            moveComponent.Move = moveInput;
            shootComponent.Shoot = shootInput;
            jerkComponent.Jerk = jerkInput;
        }).Run();
    }

}

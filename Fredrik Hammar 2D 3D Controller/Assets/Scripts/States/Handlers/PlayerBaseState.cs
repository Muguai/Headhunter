﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : State
{
    // Attributes
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Material material;

    protected PlayerStateHandler owner;

    // Methods
    public override void Enter()
    {
        owner.Renderer.material = material;
     //   owner.agent.speed = moveSpeed;
    }

    public override void Initialize(StateMachine owner)
    {
        this.owner = (PlayerStateHandler)owner;
    }
    protected bool IsCoporeal()
    {
        if (owner.current == owner.NonCorporeal)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


}

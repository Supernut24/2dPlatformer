﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : PlayerGroundedState
{
     public PlayerTurnState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base (player, stateMachine, playerData, animBoolName)
    {

    }

    public override void AnimationTrigger() { 
        base.AnimationTrigger();
    }
    public override void AnimationFinishTrigger(){
        base.AnimationFinishTrigger();
        player.Anim.SetBool("turn", false);
        player.CheckIfShouldFlip(xInput);
        

    }
    public override void Enter()
    {
        base.Enter(); 
        player.SetTurning(true);         

       
    }
    public override void Exit()
    {
        base.Exit();
        
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.SetVelocityX(playerData.turnVelocity * xInput);

        if (xInput == 0f){
            stateMachine.ChangeState(player.IdleState);
        } 
        if (isAnimationFinished){
            stateMachine.ChangeState(player.MoveState);
        }
        
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }    
}

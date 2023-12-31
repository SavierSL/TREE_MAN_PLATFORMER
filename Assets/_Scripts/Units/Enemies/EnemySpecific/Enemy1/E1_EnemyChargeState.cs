using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_EnemyChargeState : EnemyChargeState
{
    private Enemy1 enemy;
    public E1_EnemyChargeState(EnemyEntity enemyEntity, FiniteStateMachine stateMachine, string animBoolName, D_EnemyChargeState stateData, Enemy1 enemy) : base(enemyEntity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.MeleeAttackState);
        }
        else if (!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(enemy.LookForPlayerState);
        }
        else if (isChargeTimeOver)
        {

            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.PlayerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(enemy.LookForPlayerState);
            }
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

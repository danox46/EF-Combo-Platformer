using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBChaseState : ISweepbotInterface
{
    private float attackRange = 2f;
    private Sweepbot sweepbot;

    public void Enter(Sweepbot sBot)
    {
        this.sweepbot = sBot;
    }

    public void Execute()
    {
        Chase();

    }

    public void Exit()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        throw new System.NotImplementedException();
    }

    public void Chase()
    {
        if(sweepbot.transform.position.x < sweepbot.target.position.x)
        {
            sweepbot.Move(1, false, false);
        }
        else
        {
            sweepbot.Move(-1, false, false);
        }

        if(sweepbot.target.gameObject.layer != 6)
        {
            sweepbot.ChangeState(new SBIdleState());
        }

        if (sweepbot.transform.position.x >= sweepbot.target.position.x)
        {
            
            {
                sweepbot.ChangeState(new SBAttackState());
            }
        }
        else
        {
            if ((sweepbot.target.position.x - sweepbot.transform.position.x) < attackRange)
            {
                sweepbot.ChangeState(new SBAttackState());
            }
        }
    }

}

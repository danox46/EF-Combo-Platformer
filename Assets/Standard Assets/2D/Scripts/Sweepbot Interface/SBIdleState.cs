using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBIdleState : ISweepbotInterface
{
    private float idleDuration = 2.5f;
    private float idleTimer;

    private Sweepbot sweepbot;

    public void Enter(Sweepbot currentSB)
    {
        this.sweepbot = currentSB;

        sweepbot.stateName = "Idle";
        Debug.Log("trying to execute idle");

        sweepbot.Move(0, false, false);
        //kolo.StartCoroutine(kolo.AtiumAction(0, false, false));
    }

    public void Execute()
    {
        
        idleTimer += Time.deltaTime;
        Idle();
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        throw new System.NotImplementedException();
    }

    private void Idle()
    {

        sweepbot.Move(1f, false, false);

        

        /*if (idleTimer >= idleDuration)
        {
            kolo.ChangeState(new PatrolState());
        }

        if (kolo.target != null)
        {
            kolo.ChangeState(new ChaseState());
        }*/
    }


}

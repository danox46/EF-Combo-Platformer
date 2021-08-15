using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Sweepbot : PlatformerCharacter2D
{
    private ISweepbotInterface currentState;
    public string stateName;

    public override void Start()
    {
        base.Start();
        ChangeState(new SBIdleState());

        Debug.Log("Calling start on Sweepbot");
    }

    public override void Update()
    {
        base.Update();
        currentState.Execute();
    }

    public void ChangeState(ISweepbotInterface newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);
    }
}

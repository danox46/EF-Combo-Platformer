using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Sweepbot : PlatformerCharacter2D
{
    private ISweepbotInterface currentState;
    public string stateName;
    public Transform target;
    public bool awake;
    public float targetDetectionRange;
    public bool isPatrolChar;
    public List<Transform> patrollingPoints;
    public int patrolIndex;
    public bool patrollingRight;
    public float attackRange;

    public override void Start()
    {
        base.Start();

        target = GameObject.Find("CharacterCodePowers").transform;

        //ChangeState(new SBIdleState());

        Debug.Log("Calling start on Sweepbot");

        patrolIndex = 0;
    }

    public override void Update()
    {
        base.Update();
        if (currentHp > 0)
        {
            //currentState.Execute();
        }
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

    public void WakeUp()
    {
        awake = true;
    }

    public void BackToSleep() 
    { 
        awake = false; 
    }

    public Transform currentPatrolPoint()
    {
        return patrollingPoints[patrolIndex];
    }

    public void ChangePatrolPoint()
    {
        patrollingRight = patrolIndex == 0 ? true : patrollingRight;

        patrollingRight = patrolIndex == patrollingPoints.Count - 1 ? false : patrollingRight;

        if (patrollingRight)
            patrolIndex++;
        else
            patrolIndex--;
    }

    public bool CharIsAble()
    {
        return !attaking;
    }

    public override void Die()
    {
        base.Die();
        attaking = true;
        GameObject.Destroy(gameObject, 5f);
    }
}

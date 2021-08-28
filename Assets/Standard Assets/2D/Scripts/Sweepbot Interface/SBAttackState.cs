using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBAttackState : ISweepbotInterface
{

    private Sweepbot sweepbot;
    private bool attacked;

    public void Enter(Sweepbot sBot)
    {
        this.sweepbot = sBot;
        attacked = false;
    }

    public void Execute()
    {
        if (!attacked)
        {
            Attack();
            attacked = true;
        }

        if (!sweepbot.attaking)
        {
            sweepbot.ChangeState(new SBIdleState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        throw new System.NotImplementedException();
    }

    public void Attack()
    {
        sweepbot.TriggerAttacking();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

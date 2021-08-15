using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISweepbotInterface 
{
    void Execute();
    void Enter(Sweepbot sBot);
    void Exit();
    void OnTriggerEnter2D(Collider2D other);
}


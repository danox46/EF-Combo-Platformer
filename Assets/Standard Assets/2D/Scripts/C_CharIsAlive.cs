using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DnxBehaviorTree;

public class C_CharIsAlive : BaseNode
{
    private Sweepbot thisChar;

    public C_CharIsAlive(Sweepbot currentBot) : base()
    {
        thisChar = currentBot;
    }

    public override NodeState Evaluate()
    {
        m_state = thisChar.CurrentHP > 0 ? NodeState.SUCCESS : NodeState.FAILURE;

        if(m_state == NodeState.FAILURE)
        {
            thisChar.StopChar();
        }

        return m_state;
    }
}

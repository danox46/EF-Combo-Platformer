using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceBot : Sweepbot
{

    public override void TriggerAttacking()
    {
        base.TriggerAttacking();
    }

    public override void Update()
    {
        base.Update();

        if(transform.position.y > 0.3f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (Time.deltaTime / 2), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (Time.deltaTime/2), transform.position.z);
        }
    }

    public void shot()
    {
        GetComponentInChildren<AoE>().Shot();
    }

    public void EndShot()
    {
        GetComponentInChildren<AoE>().EndShot();
    }
}

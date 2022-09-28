using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;

public class Shoot : ShootOnce
{
    [InParam("delay", DefaultValue = 1.0f)]
    public float delay;

    // Time since the last shoot.
    private float elapsedTime = 0;

    public override TaskStatus OnUpdate()
    {
        if(delay > 0)
        {
            elapsedTime += Time.deltaTime;

            if(elapsedTime >= delay)
            {
                elapsedTime = 0;
                return TaskStatus.RUNNING;
            }
        }

        base.OnUpdate();
        return TaskStatus.RUNNING;
    }
}

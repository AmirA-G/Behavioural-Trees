using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;

public class SleepForever : BasePrimitiveAction
{
    public override TaskStatus OnUpdate()
    {
        return TaskStatus.SUSPENDED;
    }
}

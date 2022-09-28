using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;

public class IsNightCondition : ConditionBase
{
    private DayNightCycle light;

    public override bool Check()
    {
        return searchLight() && light.isNight;
    }

    public override TaskStatus MonitorCompleteWhenTrue()
    {
        if (Check())
        {
            return TaskStatus.COMPLETED;
        }

        if(light != null)
        {
            light.OnChanged += OnSunset;
        }

        return TaskStatus.SUSPENDED;
    }

    public override TaskStatus MonitorFailWhenFalse()
    {
        if (!Check())
        {
            return TaskStatus.FAILED;
        }
        light.OnChanged += OnSunrise;
        return TaskStatus.SUSPENDED;
    }

    private bool searchLight()
    {
        if(light != null)
        {
            return true;
        }

        GameObject lightGO = GameObject.FindGameObjectWithTag("MainLight");

        if(lightGO == null)
        {
            return false;
        }

        light = lightGO.GetComponent<DayNightCycle>();
        return light != null;
    }

    public void OnSunset(object sender, System.EventArgs night)
    {
        light.OnChanged -= OnSunset;
        EndMonitorWithSuccess();
    }

    public void OnSunrise(object sender, System.EventArgs e)
    {
        light.OnChanged -= OnSunrise;
        EndMonitorWithFailure();
    }
}

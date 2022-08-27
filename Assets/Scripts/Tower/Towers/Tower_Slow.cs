using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Slow : Tower
{
    [SerializeField]
    private int Effect_Range;
    [SerializeField]
    private float Effect_Rate;

    void Start()
    {

    }

    public override void LevelToSet(int setlevel)
    {
        Level = setlevel;
        if (setlevel == 1)
        {
            Power = 3;
            Delay = 1f;
            Cost = 20;
        }
        else if (setlevel == 2)
        {
            Power = 3;
            Delay = 1f;
            Cost = 50;
        }
        else
        {
            if (setlevel >= 3)
            {
                Level = 3;
                Power = 3;
                Delay = 1f;
                Cost = 70;
            }
        }
    }

    public override void LevelToSet_Stat(int setlevel)
    {
        Level_Stat = setlevel;
        if (setlevel == 1)
        {
            Power_Stat = 2;
            Delay_Stat = 2f;
            Effect_Range = 1;
            Effect_Rate = 0.1f;
        }
        else if (setlevel == 2)
        {
            Power_Stat = 4;
            Delay_Stat = 2f;
            Effect_Range = 2;
            Effect_Rate = 0.2f;
        }
        else
        {
            if (setlevel >= 3)
            {
                Level_Stat = 3;
                Power_Stat = 5;
                Delay_Stat = 1f;
                Effect_Range = 3;
                Effect_Rate = 0.4f;
            }
        }
    }
}

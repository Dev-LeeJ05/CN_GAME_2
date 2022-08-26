using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Multi : Tower
{
    void Start()
    {
        
    }

    protected override void Effect()
    {
    }

    public override void LevelToSet(int setlevel)
    {
        Level = setlevel;
        if (setlevel == 1)
        {
            Power = 2;
            Delay = 2f;
            Cost = 20;
        }
        else if (setlevel == 2)
        {
            Power = 3;
            Delay = 2f;
            Cost = 100;
        }
        else
        {
            if (setlevel >= 3)
            {
                Level = 3;
                Power = 4;
                Delay = 2f;
                Cost = 200;
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
            TargetCount = 3;
        }
        else if (setlevel == 2)
        {
            Power_Stat = 4;
            Delay_Stat = 2f;
            TargetCount = 6;
        }
        else
        {
            if (setlevel >= 3)
            {
                Level_Stat = 3;
                Power_Stat = 4;
                Delay_Stat = 2f;
                TargetCount = 10;
            }
        }
    }
}

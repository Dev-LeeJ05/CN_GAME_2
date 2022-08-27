using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Splash : Tower
{
    [SerializeField]
    private int Effect_Range;

    void Start()
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
            Effect_Range = 1;
        }
        else if (setlevel == 2)
        {
            Power = 4;
            Delay = 2f;
            Cost = 25;
            Effect_Range = 2;
        }
        else
        {
            if (setlevel >= 3)
            {
                Level = 3;
                Power = 5;
                Delay = 1f;
                Cost = 30;
                Effect_Range = 3;
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

        }
        else if (setlevel == 2)
        {
            Power_Stat = 4;
            Delay_Stat = 2f;
        }
        else
        {
            if (setlevel >= 3)
            {
                Level_Stat = 3;
                Power_Stat = 5;
                Delay_Stat = 1f;
            }
        }
    }
}

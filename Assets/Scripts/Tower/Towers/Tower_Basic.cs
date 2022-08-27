using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Basic : Tower
{
    protected override void Awake()
    {
        base.Awake();
        LevelToSet(1);
        LevelToSet_Stat(1);
    }

    void Start()
    {
        
    }

    public override void LevelToSet(int setlevel)
    {
        Level = setlevel;
        if (setlevel == 1)
        {
            Power = 3;
            Delay = 2f;
            Cost = 10;
        }
        else if (setlevel == 2)
        {
            Power = 5;
            Delay = 1.5f;
            Cost = 20;
        }
        else
        {
            if (setlevel >= 3)
            {
                Level = 3;
                Power = 7;
                Delay = 1f;
                Cost = 30;
            }
        }
    }

    public override void LevelToSet_Stat(int setlevel)
    {
        Level_Stat = setlevel;
        if (setlevel == 1)
        {
            Power_Stat = 3;
            Delay_Stat = 2f;
            
        }
        else if (setlevel == 2)
        {
            Power_Stat = 5;
            Delay_Stat = 1.5f;
        }
        else
        {
            if (setlevel >= 3)
            {
                Level_Stat = 3;
                Power_Stat = 7;
                Delay_Stat = 1f;
            }
        }
    }
}

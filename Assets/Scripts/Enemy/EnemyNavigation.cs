using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class EnemyNavigation : MonoBehaviour
{
    [HideInInspector]
    public static EnemyNavigation Instance;

    [SerializeField]
    private List<Transform> LeftTurnRoad;
    [SerializeField]
    private List<Transform> RightTurnRoad;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public Vector3 NextStreet(EnemyTurnDirection Direction, ref int current)
    {
        switch (Direction)
        {
            case EnemyTurnDirection.Left:
                if (++current == LeftTurnRoad.Count) return Vector3.zero;
                return LeftTurnRoad[current].position;
            case EnemyTurnDirection.Right:
                if (++current == RightTurnRoad.Count) return Vector3.zero;
                return RightTurnRoad[current].position;
        }
        return Vector3.zero;
    }
}

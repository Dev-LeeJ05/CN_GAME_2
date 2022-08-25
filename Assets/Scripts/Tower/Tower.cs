using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [Header("Tower Stat")]
    public int Level;
    public int Power;
    public float Delay;
    public int Cost;
    public int TargetCount;

    LayerMask Enemy;

    [SerializeField]
    List<Transform> TargetEnemies;

    Vector3 Pivot;

    protected void Awake()
    {
        Enemy = LayerMask.GetMask("Enemy");
        Pivot = new Vector3(transform.position.x, 0, transform.position.z);
    }

    void Start()
    {
        
    }

    protected void Update()
    {
        GetTarget();
    }

    protected void GetTarget()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, 15.5f, Enemy);
        if (enemies.Length == 0) TargetEnemies.Clear();
        if (TargetEnemies == null)
        {
            bool entered = false;
            for (int i = 0; i < enemies.Length; i++)
            { 
                foreach(Transform targetenemy in TargetEnemies)
                {
                    if (entered)
                    { continue; }
                    if (targetenemy == enemies[i].transform)
                    {
                        entered = true;
                    }
                }
            }
            if (!entered)
            {
                TargetEnemies = null;
                return;
            }

        }
            if (enemies.Length != 0)
            {
                GetClosetTarget(enemies);
            }
    }

    protected void GetClosetTarget(Collider[] colliders)
    {
        TargetEnemies.Clear();
        int counter = 0;
        Transform ClosetTarget = null;
        while (TargetCount != TargetEnemies.Count)
        {
            float closetDis = float.PositiveInfinity;
            counter++;
            if (colliders.Length < counter) return;
            foreach(Collider collider in colliders)
            {
                if (collider == null) continue;
                Vector3 offset = Pivot - collider.transform.position;
                if (TargetEnemies.Count > 0)
                {
                    bool included = false;
                    {
                        foreach (Transform trans in TargetEnemies)
                        {
                            if (offset.sqrMagnitude < closetDis * closetDis && collider.transform == trans)
                                included = true;
                        }
                        if (!included)
                            ClosetTarget = collider.transform;
                    }
                }
                else
                {
                    if (offset.sqrMagnitude < closetDis * closetDis)
                        ClosetTarget = collider.transform;
                }
            }

            if (ClosetTarget != null) Debug.LogWarning($":: Target -> {ClosetTarget.name}");
            TargetEnemies.Add(ClosetTarget);
        }
    }

    protected abstract void Effect();
}

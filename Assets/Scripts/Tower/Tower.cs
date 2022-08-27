using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public abstract class Tower : MonoBehaviour
{
    [Header("Tower Info Stat")]
    public TowerType Type;
    public string Name;
    public int Level;
    public int Power;
    public float Delay;
    public string Description;
    public int Cost;
    public int TargetCount;

    [Header("Tower Stat")]
    public int Level_Stat;
    protected int Power_Stat;
    protected float Delay_Stat;

    [Header("Bullet")]
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private Transform FirePos;

    LayerMask Enemy;

    [SerializeField]
    List<Transform> TargetEnemies;

    Vector3 Pivot;

    protected virtual void Awake()
    {
        Enemy = LayerMask.GetMask("Enemy");
        Pivot = new Vector3(transform.position.x, 0, transform.position.z);
    }

    void Start()
    {
        Level_Stat = 1;
    }

    protected void Fire()
    {
        for (int i = 0; i < TargetEnemies.Count; i++)
        {
            GameObject obj = Instantiate(BulletPrefab, this.transform);
            obj.transform.position = FirePos.position;
            obj.GetComponent<Bullet>().Target = TargetEnemies[i];
        }
        Invoke("Fire", Delay_Stat);
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

    public abstract void LevelToSet(int setlevel);

    public abstract void LevelToSet_Stat(int setlevel);
}

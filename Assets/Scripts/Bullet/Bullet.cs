using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public Transform Target;

    [Range(0f,100f)]
    [SerializeField]
    private float BulletSpeed;
    
    private int EnemyMask;

    private void Awake()
    {
        EnemyMask = LayerMask.NameToLayer("Enemy");
    }

    void Start()
    {
        
    }

    void Update()
    {
        Move(); 
    }

    protected void Move()
    {
        Vector3 direction = (Target.position - transform.position).normalized;
        transform.Translate(direction * BulletSpeed * Time.deltaTime);
    }

    protected abstract void Effect();

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == EnemyMask)
        {
            Debug.LogWarning($":: Bullet Hit Enemy");
            Effect();
            Destroy(this.gameObject);
        }
    }
}

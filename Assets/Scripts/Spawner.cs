using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> EnemyPrefabs;

    [SerializeField]
    Transform EnemyParent;

    public IEnumerator SpawnEnemy(EnemyType type)
    {
        GameObject obj;
        Enemy enemy;
        int rand_num;
        if (type == EnemyType.Basic)
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.5f);
                obj = Instantiate(EnemyPrefabs[(int)type],EnemyParent);
                obj.TryGetComponent<Enemy>(out enemy);
                rand_num = Random.Range(0, 3);
                if (rand_num == 2)
                    enemy.Direction = EnemyTurnDirection.Right;
                else
                    enemy.Direction = EnemyTurnDirection.Left;
            }
        }
        else
        {
            obj = Instantiate(EnemyPrefabs[(int)type],EnemyParent);
            obj.TryGetComponent<Enemy>(out enemy);
            rand_num = Random.Range(0, 3);
            if (rand_num == 2)
                enemy.Direction = EnemyTurnDirection.Right;
            else
                enemy.Direction = EnemyTurnDirection.Left;
        }
        yield return null;
    }
}

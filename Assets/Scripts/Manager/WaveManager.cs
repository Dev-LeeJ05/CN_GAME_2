using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;

    [SerializeField]
    private Spawner spawner;

    public List<Wave> Waves;

    [SerializeField]
    private float SpawnDelay;

    public int CurrentWave;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        foreach(Wave wave in Waves)
        {
            yield return WaveSpawn(wave);
            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator WaveSpawn(Wave wave)
    {
        foreach(EnemyType type in wave.Enemy)
        {
            yield return StartCoroutine(spawner.SpawnEnemy(type));
            yield return new WaitForSeconds(SpawnDelay);
        }
    }
}

[System.Serializable]
public class Wave
{
    public List<EnemyType> Enemy; 
}

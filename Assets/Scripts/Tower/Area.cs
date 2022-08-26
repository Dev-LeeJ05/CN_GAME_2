using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Define;

public class Area : MonoBehaviour
{
    public UnityEvent OnClick;
    public bool HasTower;
    public TowerType Type;

    [SerializeField]
    private Transform towerParent;
    public Transform TowerParent { set { towerParent = value; } get { return towerParent; } }

    public void PlaceTower(GameObject towerobj)
    {
        GameObject obj = Instantiate(towerobj, TowerParent);
        HasTower = true;
        obj.TryGetComponent<Tower>(out Tower tower);
        Type = tower.Type;
        tower.LevelToSet(1);
        tower.LevelToSet_Stat(1);        
    }
}

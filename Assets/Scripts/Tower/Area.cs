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
        obj.transform.position = Vector3.zero;
        HasTower = true;
        Type = obj.GetComponent<Tower>().Type;
    }
}

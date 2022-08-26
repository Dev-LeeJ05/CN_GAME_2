using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [HideInInspector]
    public static UIManager Instance;

    [Header("TowerShop")]
    [SerializeField]
    private Text Name;
    [SerializeField]
    private Text Level;
    [SerializeField]
    private Text Power;
    [SerializeField]
    private Text Delay;
    [SerializeField]
    private Text Description;
    [SerializeField]
    private Text Cost;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void SetShopInfo(Tower tower)
    {
        Name.text = $"{tower.Name}";
        Level.text = $"���� : {(tower.Level >= 3 ? "�ְ���" : tower.Level)}";
        Power.text = $"���ݷ� : {tower.Power}";
        Delay.text = $"���� ������ : {tower.Delay} ��";

        Description.text = tower.Description == "" ? "" : $"Ư¡ : {tower.Description}";

        //Cost.text = $"��� : {tower.Cost}";
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

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
        Level.text = $"레벨 : {(tower.Level >= 3 ? "최고레벨" : tower.Level)}";
        Power.text = $"공격력 : {tower.Power}";
        Delay.text = $"공격 딜레이 : {tower.Delay} 초";

        Description.text = tower.Description == "" ? "" : $"특징 : {tower.Description}";

        //Cost.text = $"비용 : {tower.Cost}";
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

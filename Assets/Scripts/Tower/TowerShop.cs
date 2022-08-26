using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShop : MonoBehaviour
{
    [SerializeField]
    List<TowerShopButton> ShopButtons;

    [SerializeField]
    private TowerShopButton CurrentSelectedButton; // 현재 선택된 타워 버튼
    [SerializeField]
    private Area CurrentSelectedArea; // 현재 선택된 타워 설치 위치
    private int CurrentCost;

    public void ActiveShop(Area area)
    {
        if (this.gameObject.activeSelf && CurrentSelectedArea == area) // 기존에 눌러져있는 곳을 눌렀다면 닫기
            this.gameObject.SetActive(false);
        else
        {
            CurrentSelectedArea = area;
            if (area.HasTower) // 해당한 곳에 타워가 설치 되어 있을때
            {
                
                area.TowerParent.GetChild(0).TryGetComponent<Tower>(out Tower tower);
                tower.LevelToSet(tower.Level_Stat + 1);
                UIManager.Instance.SetShopInfo(tower);
                CurrentSelectedButton = ShopButtons[(int)tower.Type];
            }
            else
            {
                CurrentSelectedButton = ShopButtons[0];
                Tower tower = ShopButtons[0].TowerPrefab.GetComponent<Tower>();
                tower.LevelToSet(1);
                CurrentCost = tower.Cost;
                UIManager.Instance.SetShopInfo(tower);
            }

            this.gameObject.SetActive(true);
        }
    }

    public void OnClickShopButton(TowerShopButton button)
    {
        CurrentSelectedButton = button;
        button.TowerPrefab.TryGetComponent<Tower>(out Tower tower);
        Transform currentTowerParent = CurrentSelectedArea.TowerParent;
        if (currentTowerParent.childCount > 0 && currentTowerParent.GetComponentInChildren<Tower>().Type == tower.Type)
            UIManager.Instance.SetShopInfo(currentTowerParent.GetComponentInChildren<Tower>());
        UIManager.Instance.SetShopInfo(tower);
    }

    public void OnClickBuy()
    {
        Debug.Log($"OnClick -> Buy");
        if (CurrentSelectedArea.HasTower) // 이미 지어져 있다면 (제거를 하고 해야됨)
        {
            // Error Message
        }
        // Check Cost

        CurrentSelectedArea.PlaceTower(CurrentSelectedButton.TowerPrefab);
        gameObject.SetActive(false);
    }

    public void OnClickUpgrade()
    {
        Debug.Log("OnClick -> Upgrade");
        if (!CurrentSelectedArea.HasTower) // 타워가 없으면 업그레이드가 아닌 구매
        {

        }
        Tower tower = CurrentSelectedArea.TowerParent.GetChild(0).GetComponent<Tower>();
        tower.LevelToSet_Stat(++tower.Level_Stat);
        tower.LevelToSet(tower.Level_Stat+1);
        UIManager.Instance.SetShopInfo(tower);

    }
}

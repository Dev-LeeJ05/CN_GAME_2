using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShop : MonoBehaviour
{
    [SerializeField]
    List<TowerShopButton> ShopButtons;

    [SerializeField]
    private TowerShopButton CurrentSelectedButton; // ���� ���õ� Ÿ�� ��ư
    [SerializeField]
    private Area CurrentSelectedArea; // ���� ���õ� Ÿ�� ��ġ ��ġ
    private int CurrentCost;

    public void ActiveShop(Area area)
    {
        if (this.gameObject.activeSelf && CurrentSelectedArea == area) // ������ �������ִ� ���� �����ٸ� �ݱ�
            this.gameObject.SetActive(false);
        else
        {
            CurrentSelectedArea = area;
            if (area.HasTower) // �ش��� ���� Ÿ���� ��ġ �Ǿ� ������
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
        if (CurrentSelectedArea.HasTower) // �̹� ������ �ִٸ� (���Ÿ� �ϰ� �ؾߵ�)
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
        if (!CurrentSelectedArea.HasTower) // Ÿ���� ������ ���׷��̵尡 �ƴ� ����
        {

        }
        Tower tower = CurrentSelectedArea.TowerParent.GetChild(0).GetComponent<Tower>();
        tower.LevelToSet_Stat(++tower.Level_Stat);
        tower.LevelToSet(tower.Level_Stat+1);
        UIManager.Instance.SetShopInfo(tower);

    }
}

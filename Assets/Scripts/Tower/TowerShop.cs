using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShop : MonoBehaviour
{
    [SerializeField]
    List<TowerShopButton> ShopButtons;

    private TowerShopButton CurrentSelectedButton; // ���� ���õ� Ÿ�� ��ư
    private Area CurrentSelectedArea; // ���� ���õ� Ÿ�� ��ġ ��ġ
    public void ActiveShop(Area area)
    {
        if (this.gameObject.activeSelf && CurrentSelectedArea == area) // ������ �������ִ� ���� �����ٸ� �ݱ�
            this.gameObject.SetActive(false);
        else
        {
            if (area.HasTower) // �ش��� ���� Ÿ���� ��ġ �Ǿ� ������
            {
                area.TowerParent.GetChild(0).TryGetComponent<Tower>(out Tower tower);
                UIManager.Instance.SetShopInfo(tower);
                CurrentSelectedButton = ShopButtons[(int)tower.Type];
            }
            else
            {
                CurrentSelectedButton = ShopButtons[0];
                UIManager.Instance.SetShopInfo(ShopButtons[0].TowerPrefab.GetComponent<Tower>());
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
        else
            UIManager.Instance.SetShopInfo(tower);
    }

    public void OnClickBuy()
    {

    }
}

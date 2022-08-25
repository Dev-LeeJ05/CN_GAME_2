using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShop : MonoBehaviour
{
    [SerializeField]
    List<TowerShopButton> ShopButtons;

    private TowerShopButton CurrentSelectedButton; // 현재 선택된 타워 버튼
    private Area CurrentSelectedArea; // 현재 선택된 타워 설치 위치
    public void ActiveShop(Area area)
    {
        if (this.gameObject.activeSelf && CurrentSelectedArea == area) // 기존에 눌러져있는 곳을 눌렀다면 닫기
            this.gameObject.SetActive(false);
        else
        {
            if (area.HasTower) // 해당한 곳에 타워가 설치 되어 있을때
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIShopFeedComponent : MonoBehaviour
{
    [SerializeField] private MoneySO _moneySO = default; // Fruit, Beans
    [SerializeField] private TreeSO _treeSO = default; // Tree Level, Levelup Price
    [SerializeField] private NutrientSO _nutrientSO = default; // 

    [SerializeField] private Button _buyingFeedButton = default;

    public void BuyingFeed()
    {
        Debug.Log("모이 구매 후 인벤토리에 넣고 왼쪽에 슬라이드 되는 UI를 넣어야 해");
    }
}

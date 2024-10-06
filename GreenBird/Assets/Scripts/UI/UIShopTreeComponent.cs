using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIShopTreeComponent : MonoBehaviour
{
    [SerializeField] private MoneySO _moneySO = default; // Fruit, Beans
    [SerializeField] private TreeSO _treeSO = default; // Tree Level, Levelup Price
    [SerializeField] private NutrientSO _nutrientSO = default; // 

    [SerializeField] private Button _treeLevelupButton = default;

    public void TreeLevelupButton()
    {
        Debug.Log("왜 안눌리지?");

        // 레벨업에 필요한 비용을 소지하고 있어야 한다.
        if (_moneySO.Fruit >= _treeSO.GetLevelUpPrice())
        {
            int currentTreeLevel = _treeSO.TreeLevel;
            _moneySO.Spend(_treeSO.GetLevelUpPrice());
            _treeSO.Levelup();
            Debug.Log($"나무 레벨 업 !! {currentTreeLevel} -> {_treeSO.TreeLevel}");
            _moneySO.ShowMoney();
        }
    }
}

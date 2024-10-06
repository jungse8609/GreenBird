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
        Debug.Log("�� �ȴ�����?");

        // �������� �ʿ��� ����� �����ϰ� �־�� �Ѵ�.
        if (_moneySO.Fruit >= _treeSO.GetLevelUpPrice())
        {
            int currentTreeLevel = _treeSO.TreeLevel;
            _moneySO.Spend(_treeSO.GetLevelUpPrice());
            _treeSO.Levelup();
            Debug.Log($"���� ���� �� !! {currentTreeLevel} -> {_treeSO.TreeLevel}");
            _moneySO.ShowMoney();
        }
    }
}

using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MoneySO", menuName = "Game Data/Money SO")]
public class MoneySO : DescriptionBaseSO
{
    [SerializeField] private TreeSO _treeSO = default;
    [SerializeField] private NutrientSO _nutrientSO = default;

    //[Header("Broadcasting on")]
    //[SerializeField] private HudEvent HudEvent = default;

    [ReadOnly, SerializeField] private int _fruit;
    public int Fruit => _fruit;

    // Fruit Per Hour
    private int _standard;

    public void GainFruit()
    {
        _fruit += CalculateGainedFruit();
        Debug.Log("��ġ�� �� �Ա� " + CalculateGainedFruit());
    }

    public void GainFruitAutomatically()
    {
        _fruit += CalculateAutomaticallyGainedFruit();

        Debug.Log("�ڵ� �� �Ա� " + CalculateAutomaticallyGainedFruit());
    }

    public void GetTimeMoney()
    {
        //sub�� ���� ���ӽð��� ������ ���ӽð����� �ð�����
        int maxTime = 10800; // 3�ð�
        int sub = DateTimeToUnixTimestamp(DateTime.Now) - _standard;
        int timeMoney = sub * CalculateAutomaticallyGainedFruit();
        int maxTimeMoney = CalculateAutomaticallyGainedFruit() * maxTime;

        _fruit += (sub <= maxTime) ? timeMoney : maxTimeMoney;
        _standard = DateTimeToUnixTimestamp(DateTime.Now);

        Debug.Log("Get Time Money " + timeMoney);
    }

    public void ShowMoney()
    {
        Debug.Log($"���� ���� {_fruit} �Դϴ�.");
    }

    private int CalculateGainedFruit()
    {
        return Mathf.CeilToInt(10 * (1 + _treeSO.TreeLevel * 0.3f) * Mathf.Pow(2, _nutrientSO.NutrientLevel));
    }

    private int CalculateAutomaticallyGainedFruit()
    {
        // ���߿� �� ��� �߰��Ǹ� �־�� ��
        return Mathf.CeilToInt(CalculateGainedFruit() * 0.4f);
    }

    private int DateTimeToUnixTimestamp(DateTime _DateTime)
    {
        TimeSpan _UnixTimeSpan = (_DateTime - new DateTime(1970, 1, 1, 0, 0, 0));
        return (int)_UnixTimeSpan.TotalSeconds;
    }
}

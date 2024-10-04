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
        Debug.Log("터치로 돈 먹기 " + CalculateGainedFruit());
    }

    public void GainFruitAutomatically()
    {
        _fruit += CalculateAutomaticallyGainedFruit();

        Debug.Log("자동 돈 먹기 " + CalculateAutomaticallyGainedFruit());
    }

    public void GetTimeMoney()
    {
        //sub는 현재 접속시간과 마지막 접속시간과의 시간차이
        int maxTime = 10800; // 3시간
        int sub = DateTimeToUnixTimestamp(DateTime.Now) - _standard;
        int timeMoney = sub * CalculateAutomaticallyGainedFruit();
        int maxTimeMoney = CalculateAutomaticallyGainedFruit() * maxTime;

        _fruit += (sub <= maxTime) ? timeMoney : maxTimeMoney;
        _standard = DateTimeToUnixTimestamp(DateTime.Now);

        Debug.Log("Get Time Money " + timeMoney);
    }

    public void ShowMoney()
    {
        Debug.Log($"남은 돈은 {_fruit} 입니다.");
    }

    private int CalculateGainedFruit()
    {
        return Mathf.CeilToInt(10 * (1 + _treeSO.TreeLevel * 0.3f) * Mathf.Pow(2, _nutrientSO.NutrientLevel));
    }

    private int CalculateAutomaticallyGainedFruit()
    {
        // 나중에 꽃 기능 추가되면 넣어야 해
        return Mathf.CeilToInt(CalculateGainedFruit() * 0.4f);
    }

    private int DateTimeToUnixTimestamp(DateTime _DateTime)
    {
        TimeSpan _UnixTimeSpan = (_DateTime - new DateTime(1970, 1, 1, 0, 0, 0));
        return (int)_UnixTimeSpan.TotalSeconds;
    }
}

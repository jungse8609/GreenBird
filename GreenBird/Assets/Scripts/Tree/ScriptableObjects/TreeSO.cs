using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu(fileName = "TreeSO", menuName = "Game Data/Tree SO")]
public class TreeSO : DescriptionBaseSO
{
    [/*ReadOnly, */SerializeField] private int _treeLevel = 1;
    public int TreeLevel => _treeLevel;

    public void Levelup()
    {
        _treeLevel += 1;
    }

    public int GetLevelUpPrice()
    {
        return Mathf.CeilToInt(1000 * Mathf.Pow(1.07f, _treeLevel - 1));
    }
}

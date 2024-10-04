using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[CreateAssetMenu(fileName = "TreeSO", menuName = "Game Data/Tree SO")]
public class TreeSO : DescriptionBaseSO
{
    [ReadOnly, SerializeField] private int _treeLevel = 1;
    public int TreeLevel => _treeLevel;
}

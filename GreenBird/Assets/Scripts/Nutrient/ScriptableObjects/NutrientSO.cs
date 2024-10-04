using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NutrientSO", menuName = "Game Data/Nutrient SO")]
public class NutrientSO : DescriptionBaseSO
{
    [ReadOnly, SerializeField] private int _nutrientLevel = 0;
    public int NutrientLevel => _nutrientLevel;
}

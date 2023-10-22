using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "ListLevel", menuName = "Level/ListLevel")]
public class ListLevel : ScriptableObject
{
    public List<LevelData> listLevel = new List<LevelData>();
}

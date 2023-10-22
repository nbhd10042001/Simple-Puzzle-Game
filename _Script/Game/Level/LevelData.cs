using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "Level", menuName = "Level/LevelData")]
public class LevelData : ScriptableObject
{
    public int level;
    public int numberBlockCombo;
    public int numberTypeBlock;
    public float minutes;
    public float seconds;
}

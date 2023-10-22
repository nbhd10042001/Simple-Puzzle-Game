using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public bool[] listActiveLevel;
    public int[] listLevel;
    public int[] scoreLevels;

    public void SetDefault()
    {
        ListLevel ll = Resources.Load<ListLevel>("LevelData/ListLevel");
        listLevel = new int[ll.listLevel.Count];
        listActiveLevel = new bool[ll.listLevel.Count];
        scoreLevels = new int[ll.listLevel.Count];
        for (int i = 0; i < ll.listLevel.Count; i++)
        {
            listLevel[i] = ll.listLevel[i].level;
            listActiveLevel[i] = false;
            scoreLevels[i] = 0;
        }

        listActiveLevel[0] = true;
    }
}

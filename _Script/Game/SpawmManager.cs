using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region -------------------- Enemy Pool ---------------------------
[System.Serializable]
public class EffectPool
{
    public EffectManager prefab;
    public Transform parent;
    public List<EffectManager> inactiveObjs;
    public List<EffectManager> activeObjs;
    public EffectManager Spawm(Vector3 position)
    {
        if (inactiveObjs.Count == 0)
        {
            EffectManager newObj = GameObject.Instantiate(prefab, parent);
            newObj.transform.position = position;
            newObj.name = prefab.name;
            activeObjs.Add(newObj);
            return newObj;
        }
        else
        {
            EffectManager oldObj = inactiveObjs[0];
            oldObj.gameObject.SetActive(true);
            oldObj.transform.position = position;
            oldObj.transform.SetParent(parent);
            activeObjs.Add(oldObj);
            inactiveObjs.RemoveAt(0);
            return oldObj;
        }
    }
    public void Release(EffectManager obj)
    {
        if (activeObjs.Contains(obj))
        {
            inactiveObjs.Add(obj);
            activeObjs.Remove(obj);
            obj.gameObject.SetActive(false);
        }
    }
    // clear pool
    public void Clear()
    {
        while (activeObjs.Count > 0)
        {
            EffectManager obj = activeObjs[0];
            obj.gameObject.SetActive(false);
            activeObjs.RemoveAt(0);
            inactiveObjs.Add(obj);
        }
    }
}
#endregion

public class SpawmManager : MonoBehaviour
{

    public static SpawmManager Instance;

    public EffectPool effectPool;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void OnDisable()
    {
        effectPool.Clear();
    }

    public EffectManager SpawmEffect(Vector3 position, float R, float G, float B)
    {
        EffectManager obj = effectPool.Spawm(position);
        obj.SetColor(R, G, B);
        return obj;
    }

    public void ReleaseEffect(EffectManager obj)
    {
        effectPool.Release(obj);
    }
}

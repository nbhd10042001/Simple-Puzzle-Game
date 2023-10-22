using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    private Sprite _defaultSprite;
    public bool isExist;
    public string nameSprite;
    public Image imageChild;

    private void Awake()
    {
        _defaultSprite = imageChild.sprite;
    }

    public void SetSlotWithNewBlock(Sprite sprite)
    {
        isExist = true;
        imageChild.sprite = sprite;
        nameSprite = sprite.name;
    }

    public void SetDefaultSlot()
    {
        imageChild.sprite = _defaultSprite;
        isExist = false;
        nameSprite = _defaultSprite.name;
    }
}

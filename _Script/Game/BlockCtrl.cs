using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockCtrl : MonoBehaviour
{
    public Image imageChild;

    public void Block_Click()
    {
        AudioManager.Instance.PlayOneShot_Click2();
        bool fullSlot = GameplayManager.Instance.AddBlockToSlot(imageChild.sprite);
        GameplayManager.Instance.CheckThreeBlockSameName();
        GameplayManager.Instance.CheckFullSlots();
        if (!fullSlot)
            StartCoroutine(EffectDestroyBlock());
    }

    public void SetSpriteInChild(Sprite sprite)
    {
        imageChild.sprite = sprite;
    }

    private IEnumerator EffectDestroyBlock()
    {
        float scaleM = transform.localScale.x;
        while (true)
        {
            scaleM -= 0.1f;
            transform.localScale = new Vector3(scaleM, scaleM, scaleM);

            if (scaleM <= 0)
                break;
            yield return null;
        }
        Destroy(gameObject);
    }

    public IEnumerator EffectSpawmBlock()
    {
        transform.localScale = Vector3.zero;
        float scaleM = 0;
        while (true)
        {
            scaleM += 0.1f;
            if (scaleM <= 1)
                transform.localScale = new Vector3(scaleM, scaleM, scaleM);

            if (scaleM > 1)
                break;
            yield return null;
        }
    }
}

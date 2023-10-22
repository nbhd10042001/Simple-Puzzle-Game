using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WritingManager : MonoBehaviour
{
    public Sprite spSweet;
    public Sprite spGood;
    public Sprite spSmashing;
    public Sprite spCool;
    public Sprite spAwesome;
    public Sprite spNiceOne;
    public Sprite spExcellent;
    public Sprite spWellPlay;
    public Sprite spYouRock;
    public Sprite spSUPERB;
    public Sprite spNone;

    private Vector3 _localScaleDefault;
    private float _scaleMulti;

    private void Awake()
    {
        _localScaleDefault = transform.localScale;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        UpdateComboWriting(0);
        StartCoroutine(UpdateScaleWriting());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator UpdateScaleWriting()
    {
        transform.localScale = Vector3.zero;
        _scaleMulti = 0f;
        while (true)
        {
            if (_scaleMulti < _localScaleDefault.x)
            {
                _scaleMulti += 0.01f;
                transform.localScale = new Vector3(_scaleMulti, _scaleMulti, _scaleMulti);
            }

            yield return null;
        }
    }

    public void UpdateComboWriting(int combo)
    {
        switch(combo)
        {
            case 2:
                SetSprite(spSweet);
                break;
            case 3:
                SetSprite(spGood);
                break;
            case 4:
                SetSprite(spSmashing);
                break;
            case 5:
                SetSprite(spCool);
                break;
            case 6:
                SetSprite(spAwesome);
                break;
            case 7:
                SetSprite(spNiceOne);
                break;
            case 8:
                SetSprite(spExcellent);
                break;
            case 9:
                SetSprite(spWellPlay);
                break;
            case 10:
                SetSprite(spYouRock);
                break;
            case 11:
                SetSprite(spSUPERB);
                break;

            default:
                SetSprite(spNone);
                break;

        }
    }

    private void SetSprite(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
        transform.localScale = Vector3.zero;
        _scaleMulti = 0f;
    }

}

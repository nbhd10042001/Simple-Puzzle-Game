using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private ParticleSystem _partiST;
    private float _hSliderValueR = 0.0F;
    private float _hSliderValueG = 0.0F;
    private float _hSliderValueB = 0.0F;

    private void Awake()
    {
        _partiST = GetComponent<ParticleSystem>();
    }

    public void SetColor (float R, float G, float B)
    {
        _hSliderValueR = R;
        _hSliderValueG = G;
        _hSliderValueB = B;

        var main = _partiST.main;
        main.startColor = new Color(_hSliderValueR, _hSliderValueG, _hSliderValueB, 1f);
    }
}

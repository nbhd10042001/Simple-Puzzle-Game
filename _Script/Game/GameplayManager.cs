using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    public GameObject spawmBlockGO;
    public List<SlotManager> listSlots = new List<SlotManager>();
    public GameObject TimeComboGO;
    public Image valueTimeComboImage;
    public TextMeshProUGUI txtCombo;
    public TextMeshProUGUI txtScore;
    public WritingManager writingMng;
    public TextMeshProUGUI txtTime;

    private List<SlotManager> _listSlotSameColor = new List<SlotManager>();
    private bool _isWin;
    private float _timeCombo;
    private float _timeMax = 3f;
    private int _score;
    private int _combo;
    private float _minutes;
    private float _seconds;
    private UiWinLose _UiWL;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        _UiWL = GetComponent<UiWinLose>();
    }

    private void Start()
    {
        int _levelSelect = PlayerManager.Instance.levelSelect;
        LevelData _levelData = Resources.Load<LevelData>($"LevelData/Level{_levelSelect}");
        _minutes = _levelData.minutes;
        _seconds = _levelData.seconds;
        StartCoroutine(TimeGameplayCount());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        if (!_isWin)
            CheckWinGame();

        // update time combo
        if (TimeComboGO.activeInHierarchy == true)
        {
            _timeCombo -= Time.deltaTime;
            valueTimeComboImage.fillAmount = _timeCombo * 1f / _timeMax;
            if (_timeCombo <= 0)
                DeactiveTimeCombo();
        }
    }

    private IEnumerator TimeGameplayCount()
    {
        while (true)
        {
            _seconds -= Time.deltaTime;
            if (_seconds <= 0)
            {
                _minutes -= 1f;
                if (_minutes < 0f)
                {
                    _minutes = 0f;
                    txtTime.text = $"{_minutes}:{(int)_seconds}";
                    _UiWL.GameWin(false);
                    break;
                }
                _seconds = 60f;
            }
            txtTime.text = $"{_minutes}:{(int)_seconds}";
            yield return null;
        } 
    }

    private void DeactiveTimeCombo()
    {
        TimeComboGO.SetActive(false);
        _combo = 0;
        writingMng.UpdateComboWriting(_combo);
    }

    private void ActiveTimeCombo()
    {
        _timeCombo = _timeMax;
        valueTimeComboImage.fillAmount = 1f;
        TimeComboGO.SetActive(true);
    }

    private void UpdateScore()
    {
        _score += 10 + (_combo * 2);
        txtScore.text = $"SCORE: {_score}";
    }

    private void UpdateCombo()
    {
        _combo += 1;
        txtCombo.text = $"{_combo}x";
        if (_combo > 11)
        {
            writingMng.UpdateComboWriting(11);
            return;
        }

        if (_combo > 1)
            writingMng.UpdateComboWriting(_combo);
    }

    public bool AddBlockToSlot(Sprite sprite)
    {
        int count = 0;
        for (int i = 0; i < listSlots.Count; i++)
        {
            if (!listSlots[i].isExist)
            {
                listSlots[i].SetSlotWithNewBlock(sprite);
                break;
            }
            count++;
        }
        if (count < listSlots.Count) return false;
        else 
            return true; 
    }

    public void CheckThreeBlockSameName()
    {
        for (int i = 0; i < listSlots.Count; i++)
        {
            for (int j = 0; j < listSlots.Count; j++)
            {
                if (i == j) continue; //continue when same slot

                if (listSlots[i].nameSprite == listSlots[j].nameSprite && listSlots[i].isExist && listSlots[j].isExist)
                    _listSlotSameColor.Add(listSlots[j]);
            }

            // add the slot check
            _listSlotSameColor.Add(listSlots[i]);

            if (_listSlotSameColor.Count == 3)
            {
                AudioManager.Instance.PlayOneShotCombo();
                SpawmEffectAndRandomColor();
                foreach (var slot in _listSlotSameColor)
                    slot.SetDefaultSlot();
                SortingSlotHaveSprite();
                ActiveTimeCombo();
                UpdateScore();
                UpdateCombo();
            }

            _listSlotSameColor.Clear();
        }
    }

    public void CheckFullSlots()
    {
        int count = 0;
        for (int i = 0; i < listSlots.Count; i++)
            if (listSlots[i].isExist)
                count++;

        if (count >= listSlots.Count)
        {
            _UiWL.GameWin(false);
            StopAllCoroutines();
        }

    }

    private void SortingSlotHaveSprite()
    {
        for (int i = 0; i < listSlots.Count; i++)
            if (!listSlots[i].isExist)
                for (int j = i + 1; j < listSlots.Count; j++)
                    if (listSlots[j].isExist)
                    {
                        listSlots[i].SetSlotWithNewBlock(listSlots[j].imageChild.sprite);
                        listSlots[j].SetDefaultSlot();
                        break;
                    }
    }

    public void CheckWinGame()
    {
        BlockCtrl[] children = spawmBlockGO.GetComponentsInChildren<BlockCtrl>();
        if (children.Length <= 0)
        {
            _isWin = true;
            _UiWL.GameWin(true);
            StopAllCoroutines();
        }
    }

    public int GetScore()
    {
        return _score;
    }

    private void SpawmEffectAndRandomColor()
    {
        float R = Random.Range(0f, 1f);
        float G = Random.Range(0f, 1f);
        float B = Random.Range(0f, 1f);

        SpawmManager.Instance.SpawmEffect(_listSlotSameColor[0].transform.position, R, G, B);
        SpawmManager.Instance.SpawmEffect(_listSlotSameColor[1].transform.position, R, G, B);
        SpawmManager.Instance.SpawmEffect(_listSlotSameColor[2].transform.position, R, G, B);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawmBlock : MonoBehaviour
{
    public GameObject prefab_block;
    public Transform parentBlock;
    public Transform posSpawm_topLeft;
    public Transform posSpawm_bottomRight;
    public int numberBlockCombo;
    public int numberTypeBlock;
    public List<Sprite> spriteBlocks = new List<Sprite>();

    private List<GameObject> _blocksList = new List<GameObject>();
    private int _levelSelect;
    private LevelData _levelData;

    private void Awake()
    {
        _levelSelect = PlayerManager.Instance.levelSelect;
        _levelData = Resources.Load<LevelData>($"LevelData/Level{_levelSelect}");
    }

    private void Start()
    {
        numberBlockCombo = _levelData.numberBlockCombo;
        numberTypeBlock = _levelData.numberTypeBlock;

        if (numberTypeBlock > spriteBlocks.Count) numberTypeBlock = spriteBlocks.Count;

        SpawnBlock();
        SetPositionBlock();
    }

    private void SpawnBlock()
    {
        int ranType = 0;
        for (int i = 0; i < numberBlockCombo; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject block = GameObject.Instantiate(prefab_block, parentBlock);
                block.GetComponentInChildren<BlockCtrl>().SetSpriteInChild(spriteBlocks[ranType]);
                StartCoroutine(block.GetComponentInChildren<BlockCtrl>().EffectSpawmBlock());
                block.name = spriteBlocks[ranType].name;
                _blocksList.Add(block);
            }
            ranType++;
            if (ranType >= numberTypeBlock) ranType = 0;
        }
    }

    private void SetPositionBlock()
    {
        for(int i = 0; i < _blocksList.Count; i++)
        {
            float ranPos_x = Random.Range(posSpawm_topLeft.position.x, posSpawm_bottomRight.position.x);
            float ranPos_y = Random.Range(posSpawm_topLeft.position.y, posSpawm_bottomRight.position.y);
            _blocksList[i].transform.position = new Vector2(ranPos_x, ranPos_y);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(posSpawm_topLeft.position, new Vector3(posSpawm_bottomRight.position.x, posSpawm_topLeft.position.y));
        Gizmos.DrawLine(posSpawm_topLeft.position, new Vector3(posSpawm_topLeft.position.x, posSpawm_bottomRight.position.y));
        Gizmos.DrawLine(posSpawm_bottomRight.position, new Vector3(posSpawm_bottomRight.position.x, posSpawm_topLeft.position.y));
        Gizmos.DrawLine(posSpawm_bottomRight.position, new Vector3(posSpawm_topLeft.position.x, posSpawm_bottomRight.position.y));
    }
}

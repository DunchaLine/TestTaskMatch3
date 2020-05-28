using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    public GameObject _matchObj;
    public GameObject gridObject;
    private CreateGrid _gridScript;
    private FindMatch _matchScript;
    private int _width, _height;
    private GameObject[,] _tiles;
    private GameObject[,] _tmpTiles;
    private Sprite _tmpSprite;
    void Start()
    {
        _matchScript = _matchObj.GetComponent<FindMatch>();
        _gridScript = gridObject.GetComponent<CreateGrid>();
        _width = _gridScript.width;
        _height = _gridScript.height;
        _tiles = new GameObject[_width, _height];
        _tiles = CreateGrid.gridMainScript._tiles;
        _tmpTiles = _tiles;
        StartCoroutine(FindTilesToFallDown());
    }
    void Update()
    {
        //StartCoroutine(FindTilesToFallDown());
    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _tmpSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
            for (int x = 0; x < _width; x++)
            {
            for (int y = 0; y < _height; y++)
            {
                
            }
            }
            StartCoroutine(FindTilesToFallDown());
            
        }
    }

    public IEnumerator FindTilesToFallDown()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                if (_tiles[x, y].GetComponent<SpriteRenderer>().sprite == null)
                {
                    _matchScript.Match(x, y, _tmpSprite);
                    yield return StartCoroutine(TilesFallingDown(x, y));
                    break;
                }
            }
        }
    }

    private IEnumerator TilesFallingDown(int posX, int posY)
    {
        List<SpriteRenderer> _sprites = new List<SpriteRenderer>();
        SpriteRenderer _tmpSpriteRenderer = null;
        int _countOfEmptyTiles = 0;
        for (int y = posY; y < _height; y++)
        {
            _tmpSpriteRenderer = _tiles[posX, y].GetComponent<SpriteRenderer>();
            if (_tmpSpriteRenderer.sprite == null)
            {
                _countOfEmptyTiles++;
            }
            _sprites.Add(_tmpSpriteRenderer);
        }

        for (int i = 0; i < _countOfEmptyTiles; i++)
        {
            yield return new WaitForSeconds(.1f);
            for (int j = 0; j < _sprites.Count - 1; j++)
            {
                _sprites[j].sprite = _sprites[j + 1].sprite;
                _gridScript.ChangeSprite(_sprites[j + 1].gameObject);
            }
        }
    }
}

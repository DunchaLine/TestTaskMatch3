using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    public GameObject gridObject;
    private CreateGrid _gridScript;
    private int _width, _height;
    private GameObject[,] _tiles;
    void Start()
    {
        _gridScript = gridObject.GetComponent<CreateGrid>();
        _width = _gridScript.width;
        _height = _gridScript.height;
        _tiles = new GameObject[_width, _height];
        _tiles = CreateGrid.gridMainScript._tiles;
    }
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
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
                    Debug.Log("Smth has deleted");
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
                Debug.Log("count: " + _countOfEmptyTiles);
            }
            _sprites.Add(_tmpSpriteRenderer);
        }

        for (int i = 0; i < _countOfEmptyTiles; i++)
        {
            yield return new WaitForSeconds(.04f);
            for (int j = 0; j < _sprites.Count - 1; j++)
            {
                _sprites[j].sprite = _sprites[j + 1].sprite;
                _gridScript.ChangeSprite(_sprites[j + 1].gameObject);
            }
        }
    }
}

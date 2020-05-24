using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FallingDown : MonoBehaviour
{
    public GameObject gridObject;
    private CreateGrid _gridScript;
    private int _widthGrid, _heightGrid;
    private GameObject[,] _grid;
    private List<Sprite> _sprites;
    private int _countOfEmptyTiles;
    private bool _onStart = true;
    void Start()
    {
        _gridScript = gridObject.GetComponent<CreateGrid>();
        _widthGrid = _gridScript.width;
        _heightGrid = _gridScript.height;
        Debug.Log("w: " + _widthGrid + " h: " + _heightGrid);
        _grid = new GameObject[_widthGrid, _heightGrid];
        _grid = _gridScript._tiles;
        StartCoroutine(FindTilesToFallDown());
    }

    public IEnumerator FindTilesToFallDown()
    {
        if (_onStart)
        {
            _grid = _gridScript._tiles;
            _onStart = false;
            if (_grid == null)
            {
                Debug.Log("asdafds");
            }
        }
        for (int x = 0; x < _widthGrid; x++)
        {
            for (int y = 0; y < _heightGrid; y++)
            {
                if (_grid[x, y].GetComponent<SpriteRenderer>().sprite == null)
                {
                    yield return StartCoroutine(TilesFallingDown(x, y));
                    break;
                }
            }
        }
    }

    private IEnumerator TilesFallingDown(int posX, int posY)
    {
        _countOfEmptyTiles = 0;
        for (int y = posY; y < _heightGrid; y++)
        {
            if (_grid[posX, posY].GetComponent<SpriteRenderer>().sprite == null)
            {
                _countOfEmptyTiles++;
            }
            _sprites.Add(_grid[posX, posY].GetComponent<SpriteRenderer>().sprite);
        }

        for (int i = 0; i < _countOfEmptyTiles; i++)
        {
            yield return new WaitForSeconds(.1f);
            for (int j = 0; j < _sprites.Count - 1; j++)
            {
                _sprites[j] = _sprites[j + 1];
                _sprites[j + 1] = _sprites[j];
            }
        }
    }
    
}

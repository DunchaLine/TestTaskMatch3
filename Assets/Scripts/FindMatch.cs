using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMatch : MonoBehaviour
{
    public static FindMatch match;
    public GameObject objGrid;
    private CreateGrid _scriptGrid;
    private int _width, _height;
    private DestroyOnClick _destroy;
    private GameObject[,] _grid;
    private bool _leftClear, _rightClear, _upClear, _downClear;
    private List<GameObject> _objToClear = new List<GameObject>();
    //private bool _horizontal = false, _vertical = false;
    void Start()
    {
        _destroy = gameObject.GetComponent<DestroyOnClick>();
        _scriptGrid = objGrid.GetComponent<CreateGrid>();
        _width = _scriptGrid.width;
        _height = _scriptGrid.height;
        _grid = new GameObject[_width, _height];
        _grid = CreateGrid.gridMainScript._tiles;
    }

    // void OnMouseDown()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
            
    //     }
    // }
    public void Match(int x, int y, Sprite sprite)
    {
        //Заменить рекурсию на Ray
        // Debug.Log("x: " + x + " y: " + y + "length y: " + _grid.GetLength(1));
        // if (x + 1 <= _grid.GetLength(0) - 1 && x - 1 >= 0)
        // {
        //     if (sprite == _grid[x + 1, y].GetComponent<SpriteRenderer>().sprite)
        //     {
        //         _objToClear.Add(_grid[x + 1, y]);
        //         Match(x + 1, y, sprite);
        //         _rightClear = false;
        //         Debug.Log("same sprite right side: " + _rightClear);
        //     }
        //     else 
        //     {
        //         _rightClear = true;
        //     }
        //     if (sprite == _grid[x - 1, y].GetComponent<SpriteRenderer>().sprite)  
        //     {
        //         _objToClear.Add(_grid[x - 1, y]);
        //         Match(x - 1, y, sprite);
        //         _leftClear = false;
        //         Debug.Log("same sprite left side: " + _leftClear);
        //     }  
        //     else 
        //     {
        //         _leftClear = true;
        //     } 
        // }
        // if (y + 1 <= _grid.GetLength(1) - 1 && y - 1 >= 0)
        // {
        //     if (sprite == _grid[x, y + 1].GetComponent<SpriteRenderer>().sprite)
        //     {
        //         _objToClear.Add(_grid[x, y + 1]);
        //         Match(x, y + 1, sprite);
        //         _upClear = false;
        //         Debug.Log("same sprite up side: " + _upClear);
        //     }
        //     else 
        //     {
        //         _upClear = true;
        //     }
        //     if (sprite == _grid[x, y - 1].GetComponent<SpriteRenderer>().sprite)
        //     {
        //         _objToClear.Add(_grid[x, y - 1]);
        //         Match(x, y - 1, sprite);
        //         _downClear = false;
        //         Debug.Log("same sprite down side: " + _downClear);
        //     }
        //     else 
        //     {
        //         _downClear = true;
        //     }
        // }
        // Debug.Log("length to delete; " + _objToClear.Count);
        // if (_leftClear && _rightClear && _upClear && _downClear)
        //     ClearMatch();
    }

    public void ClearMatch()
    {
        if (_objToClear.Count >= 2)
        {
            for (int i = 0; i < _objToClear.Count; i++)
            {
                Debug.Log("im in ClearMatch");
                _objToClear[i].GetComponent<SpriteRenderer>().sprite = null;
                _destroy.FindTilesToFallDown();
            }
            _objToClear.Clear();
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public GameObject tileToInstantiate;
    public List<Sprite> spritesOnTile = new List<Sprite>();
    public int width, height;
    private GameObject[,] _tiles;
    private Vector2 _sizeTile;
    private Sprite _rndSprite;
    void Start()
    {
        _tiles = new GameObject[width, height];
        _sizeTile = tileToInstantiate.GetComponent<SpriteRenderer>().bounds.size;
        CreationGrid(_sizeTile.x, _sizeTile.y);
    }

    void CreationGrid(float sizeX, float sizeY)
    {
        float spawnX = -2.5f;
        float spawnY = -3.6f;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject newTile = Instantiate(tileToInstantiate,
                 new Vector2(spawnX + (sizeX * i), spawnY + (sizeY * j)), 
                 tileToInstantiate.transform.rotation);
                _rndSprite = spritesOnTile[Random.Range(0, spritesOnTile.Count)];
                newTile.GetComponent<SpriteRenderer>().sprite = _rndSprite;
                _tiles[i, j] = newTile;
            }
        }
    }
}

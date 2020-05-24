using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class CreateGrid : MonoBehaviour
{
    public static CreateGrid gridMainScript;
    public GameObject tileToInstantiate;
    public List<Sprite> spritesOnTile = new List<Sprite>();
    public int width, height;
    [HideInInspector]public GameObject[,] _tiles;
    private Vector2 _sizeTile;
    private Sprite _rndSprite;
    void Awake()
    {
        _tiles = new GameObject[width, height];
        _sizeTile = tileToInstantiate.GetComponent<SpriteRenderer>().bounds.size;
        CreationGrid(_sizeTile.x, _sizeTile.y);
    }

    void Start()
    {
        gridMainScript = GetComponent<CreateGrid>();
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
                ChangeSprite(newTile);
                _tiles[i, j] = newTile;
                newTile.transform.parent = transform;
            }
        }
    }

    public void ChangeSprite(GameObject tile)
    {
        _rndSprite = spritesOnTile[Random.Range(0, spritesOnTile.Count)];
        tile.GetComponent<SpriteRenderer>().sprite = _rndSprite;
    }
}

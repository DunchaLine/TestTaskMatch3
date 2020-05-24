using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPull : MonoBehaviour
{
    public GameObject gridObject;
    public List<GameObject> pool;
    private Vector2 _posToSpawn;
    private CreateGrid _gridScript;
    void Start()
    {
        _gridScript = gridObject.GetComponent<CreateGrid>();
        foreach(var item in _gridScript._tiles)
        {
            pool.Add(item);
        }
    }

    void Update()
    {
        foreach(var item in pool)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = new Vector2(item.transform.position.x, item.transform.position.y + 9.5f);
                item.SetActive(true);
                _gridScript.ChangeSprite(item);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPull : MonoBehaviour
{
    private Vector2 _posToSpawn;
    public GameObject gridObject;
    private CreateGrid _gridScript;
    public List<GameObject> pool;
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
                item.transform.position = new Vector2(item.transform.position.x, 5.5f);
            }
        }
    }
}

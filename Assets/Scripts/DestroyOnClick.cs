using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    private ObjectPull _pullScript;
    void Start()
    {
        _pullScript = gameObject.GetComponent<ObjectPull>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
            //_pullScript.pool.Add(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    
    [SerializeField] private int amountPool;
    [SerializeField] private GameObject prefabObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountPool; i++)
        {
            GameObject obj = Instantiate(prefabObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    
    public void GetObject   
}
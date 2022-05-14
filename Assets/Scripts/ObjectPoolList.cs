using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolList : MonoBehaviour
{
    public static ObjectPoolList SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    int lastactive = 0;
    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
     public GameObject GetPooledObject()
    {
        lastactive++;
        for (int i = 0; i < amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                lastactive = i;
                return pooledObjects[i];
            }
        }
       
        return null;
    }
    public void DeactivePooledObject()
    {
        GameObject obj = pooledObjects[lastactive];
        obj.gameObject.name = "Empty";
        obj.SetActive(false);
        lastactive--;
    }

}

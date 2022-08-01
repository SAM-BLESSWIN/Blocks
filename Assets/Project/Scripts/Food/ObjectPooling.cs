using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public GameObject prefab;
    public int count;
    public GameObject[] prefabs;
    private int index=0;

    void Awake()
    {
        prefabs = new GameObject[count];
        for(int i=0;i<count;i++)
        {
            prefabs[i] = Instantiate(prefab,new Vector2(0,15),Quaternion.identity,transform);
        }
    }

    public GameObject GetObject()
    {
        if(index >= count)
        {
            index = 0;
        }

        prefabs[index].SetActive(true);
        GameObject go = prefabs[index];
        index++;
        return go;
    }
}

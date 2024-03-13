using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectpooler : MonoBehaviour
{
    public GameObject pooledObject;
    public int numberOfObject;
    private List<GameObject> gameObjects;

    private void Start()
    {
        for (int i = 0; i < numberOfObject; i++)
        {
            gameObjects = new List<GameObject>();
            GameObject gameObject = Instantiate(pooledObject);
            gameObject.SetActive(true); // �ʱ⿡�� ��Ȱ��ȭ
            gameObjects.Add(gameObject);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            if (!gameObject.activeInHierarchy)
            {
                return gameObject;
            }
        }

        GameObject gameObj = Instantiate(pooledObject);
        gameObj.SetActive(true); // ���� �� ��Ȱ��ȭ
        gameObjects.Add(gameObj);
        return gameObj;
    }
}

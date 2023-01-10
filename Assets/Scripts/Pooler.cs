using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{    
    private List<GameObject> pooledObjects;

    [SerializeField] private GameObject objectToPool;

    [SerializeField] private int amountToPool;

    [SerializeField] private float _distanceMin;
    [SerializeField] private float _distanceMax;

    private static Camera _camera;

    void Start()
    {
        if (!_camera) _camera = GameObject.Find("Camera").GetComponent<Camera>();

        pooledObjects = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);

            obj.transform.position = SetPosition();

            pooledObjects.Add(obj);
            obj.transform.parent = transform;
        }
    }

    private Vector3 SetPosition()
    {
        float randomDistance = Random.Range(_distanceMin, _distanceMax);

        Vector3 positionObjectToSpawn = _camera.ScreenToWorldPoint(
                new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), randomDistance));

        return positionObjectToSpawn;
    }


    public void GetPooledObject()
    {
        GameObject tempObject = pooledObjects[0];
        pooledObjects.RemoveAt(0);
        tempObject.transform.position = SetPosition();
        tempObject.SetActive(true);
        pooledObjects.Add(tempObject);
    }
}
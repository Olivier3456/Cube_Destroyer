using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public static Pooler PoolerInstance;
    private List<GameObject> pooledObjects;

    [SerializeField] private GameObject objectToPool;

    [SerializeField] private int amountToPool;

    [SerializeField] private Camera _cam;
    
    [SerializeField] private float _distanceMin;
    [SerializeField] private float _distanceMax;
    [SerializeField] private float _spawnInterval;

    private float _time;

    private void Awake()
    {
        if (PoolerInstance == null) PoolerInstance = this;
    }

    void Start()
    {
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

    void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _spawnInterval)
        {
            GetPooledObject();
            _time = 0;
        }
    }


    private Vector3 SetPosition()
    {
        float randomDistance = Random.Range(_distanceMin, _distanceMax);

        Vector3 positionObjectToSpawn = _cam.ScreenToWorldPoint(
                new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), randomDistance));

        return positionObjectToSpawn;
    }


    public GameObject GetPooledObject()
    {
        GameObject tempObject = pooledObjects[0];
        pooledObjects.RemoveAt(0);
        tempObject.transform.position = SetPosition();
        tempObject.SetActive(true);
        pooledObjects.Add(tempObject);

        return tempObject;
    }
}

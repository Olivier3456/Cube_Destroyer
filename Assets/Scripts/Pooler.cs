using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    private List<GameObject> pooledObjects;

    [SerializeField] private GameObject objectToPool;

    private int _amountToPool = 5;
    private bool _allObjectAlreadyActive;

    [SerializeField] private float _distanceMin;
    [SerializeField] private float _distanceMax;

    private static Camera _camera;

    void Start()
    {
        pooledObjects = new List<GameObject>();

        //pooledObjects.Add(InstantiateGameObject());   // Instancie un premier objet pour obtenir sa variable Speed.

        //amountToPool = (int)((1 / pooledObjects[0].GetComponent<CubeBehavior>().Speed) * 350); // Cette variable Speed nous sert à savoir combien
        //                                                                    // d'objets de ce type on va faire spawner.

        if (_amountToPool < 2) _amountToPool = 2;

        if (!_camera) _camera = GameObject.Find("Camera").GetComponent<Camera>();

        for (int i = 0; i < _amountToPool - 1; i++)
        {
            InstantiateGameObject();
        }
    }

    private GameObject InstantiateGameObject()
    {
        GameObject objectToAdd = Instantiate(objectToPool);
        objectToAdd.SetActive(false);
        objectToAdd.transform.parent = transform;
        pooledObjects.Add(objectToAdd);
        return objectToAdd;
    }

    private Vector3 SetPosition()
    {
        float randomDistance = Random.Range(_distanceMin, _distanceMax);

        Vector3 positionObjectToSpawn = _camera.ScreenToWorldPoint(
                new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), randomDistance));

        // Autre façon de faire (Random.value choisit une valeur entre 0 et 1) :
        Vector3 autrePosition = _camera.ViewportToWorldPoint(new Vector3(Random.value, Random.value, randomDistance));

        return positionObjectToSpawn;
    }


    public void GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].transform.position = SetPosition();
                pooledObjects[i].SetActive(true);
                break;
            }

            if (i == pooledObjects.Count - 1)
            {
                _allObjectAlreadyActive = true;
            }
        }

        if (_allObjectAlreadyActive)
        {
            InstantiateGameObject();
            _allObjectAlreadyActive = false;
        }
    }
}
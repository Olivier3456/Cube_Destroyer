using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pooler : MonoBehaviour
{
    private List<GameObject> disabledObjects;

    [SerializeField] private GameObject objectToPool;

    private int _amountToPool = 5;

    [SerializeField] private float _distanceMin;
    [SerializeField] private float _distanceMax;

    private static Camera _camera;      // Static car tous nos poolers se partagent la même caméra.
                                        // Seul le premier instancié aura besoin d'initialiser la variable _camera.

    void Start()
    {
        disabledObjects = new List<GameObject>();

        //pooledObjects.Add(InstantiateGameObject());   // Instancie un premier objet pour obtenir sa variable Speed.

        //amountToPool = (int)((1 / pooledObjects[0].GetComponent<CubeBehavior>().Speed) * 350); // Cette variable Speed nous sert à savoir combien
        // d'objets de ce type on va faire spawner.

        if (_amountToPool < 1) _amountToPool = 1;

        if (!_camera) _camera = GameObject.Find("Camera").GetComponent<Camera>();       // Ne s'exécute qu'au premier pooler instancié.

        for (int i = 1; i < _amountToPool; i++)
        {
            InstantiateGameObject(false);
        }
    }

    private void InstantiateGameObject(bool activateObject)
    {
        GameObject objectToAdd = Instantiate(objectToPool);
        objectToAdd.transform.parent = transform;
        objectToAdd.GetComponent<CubeBehavior>()._pooler = this;

        if (!activateObject) objectToAdd.SetActive(false);
        else objectToAdd.transform.position = SetPosition();
    }

    private Vector3 SetPosition()
    {
        float randomDistance = Random.Range(_distanceMin, _distanceMax);

        Vector3 positionObjectToSpawn = _camera.ScreenToWorldPoint(
                new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), randomDistance));

        // Autre façon de faire (Random.value choisit une valeur entre 0 et 1) :
        // Vector3 autrePosition = _camera.ViewportToWorldPoint(new Vector3(Random.value, Random.value, randomDistance));

        return positionObjectToSpawn;
    }


    public void AddObjectToDisabledList(GameObject objectToAdd)
    {
        disabledObjects.Add(objectToAdd);
    }


    public void GetPooledObject()
    {
        if (disabledObjects.Count == 0) InstantiateGameObject(true);      // S'il n'y a plus d'objets disponibles, on en instancie un.

        else
        {
            disabledObjects[0].transform.position = SetPosition();
            disabledObjects[0].SetActive(true);
            disabledObjects.RemoveAt(0);
        }
    }
}
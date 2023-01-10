using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] GameObject _prefabToSpawn;

    [SerializeField] private float _distanceMin;
    [SerializeField] private float _distanceMax;
    [SerializeField] private float _spawnInterval;

    private float _time;


    void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _spawnInterval)
        {
            SpawnNewObject();
            _time = 0;
        }
    }

    private void SpawnNewObject()
    {
        float randomDistance = Random.Range(_distanceMin, _distanceMax);

        Vector3 positionObjectToSpawn = _cam.ScreenToWorldPoint(
                new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), randomDistance));
        Instantiate(_prefabToSpawn, positionObjectToSpawn, Quaternion.identity);     
    }

    
}

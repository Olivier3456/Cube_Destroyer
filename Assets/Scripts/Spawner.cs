using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] GameObject[] _poolers;

    private GameObject[] _instantiatedPoolers;
    private Pooler[] _instantiatedPoolersPoolerClass;
         
    [SerializeField] private float _spawnInterval;

    private float _time = 0;


    private void Start()
    {
        _instantiatedPoolers = new GameObject[_poolers.Length];
        _instantiatedPoolersPoolerClass = new Pooler[_poolers.Length];

        for (int i = 0; i < _poolers.Length; i++)
        {
            _instantiatedPoolers[i] = Instantiate(_poolers[i], transform.position, Quaternion.identity);
            _instantiatedPoolers[i].transform.parent = transform;

            _instantiatedPoolersPoolerClass[i] = _instantiatedPoolers[i].GetComponent<Pooler>();
        }
    }


    void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _spawnInterval)
        {
            int randomSpooler = Random.Range(0, _poolers.Length);
            _instantiatedPoolersPoolerClass[randomSpooler].GetPooledObject();
            _time = 0;
        }
    }
}
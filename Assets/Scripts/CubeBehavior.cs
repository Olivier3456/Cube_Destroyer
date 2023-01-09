using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    [SerializeField] private float _speed;
    private static GameObject _cam;

    void Start()
    {
        if (!_cam)   _cam = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = _cam.transform.rotation;
        transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }
}

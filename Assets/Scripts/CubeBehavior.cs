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

    private void OnMouseDown()      // Pour désactiver l'objet si on clique dessus.
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {        
        transform.Translate(Vector3.back * _speed * Time.deltaTime);
        transform.rotation = _cam.transform.rotation;
    }
}

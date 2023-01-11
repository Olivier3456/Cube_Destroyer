using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    [SerializeField] private int _speed;
    public int Speed { get; private set; }

    public Pooler _pooler;

    private static GameObject _cam;     // Idem que pour les poolers, tous les objets ont la même caméra.

    [SerializeField] private int _scoreToAddWhenDestroyed;

    private void Awake()
    {
        Speed = _speed;
    }

    void Start()
    {
        gameObject.SetActive(false);
        if (!_cam) _cam = GameObject.Find("Camera");     // Seul le premier objet instancié a besoin d'initialiser la variable _cam static.
    }

    void Update()
    {
        transform.Translate(Vector3.back * Speed * Time.deltaTime);
        transform.rotation = _cam.transform.rotation;


        // On se place dans le référenciel de la caméra, et on désactive le cube si sa position Z dans ce référenciel est négative :
        if (_cam.transform.InverseTransformPoint(transform.position).z < 0) gameObject.SetActive(false);
    }

    private void OnMouseDown()      // Pour désactiver l'objet si on clique dessus.
    {
        gameObject.SetActive(false);
        GameManager.Instance.ChangeScore(_scoreToAddWhenDestroyed);
    }

    private void OnDisable()
    {
        _pooler.AddObjectToDisabledList(gameObject);
    }
}

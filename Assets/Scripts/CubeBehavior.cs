using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    [SerializeField] private int _speed;
    public int Speed { get; private set; }

    private static GameObject _cam;

    [SerializeField] private int _scoreToAddWhenDestroyed;

    private void Awake()
    {
        Speed = _speed;        
    }

    void Start()
    {
        if (!_cam) _cam = GameObject.Find("Camera");
    }

    void Update()
    {
        transform.Translate(Vector3.back * Speed * Time.deltaTime);
        transform.rotation = _cam.transform.rotation;


        // On se place dans le r�f�renciel de la cam�ra, et on d�sactive le cube si sa position Z dans ce r�f�renciel est n�gative :
        if (_cam.transform.InverseTransformPoint(transform.position).z < 0) gameObject.SetActive(false);
    }

    private void OnMouseDown()      // Pour d�sactiver l'objet si on clique dessus.
    {
        gameObject.SetActive(false);
        GameManager.Instance.ChangeScore(_scoreToAddWhenDestroyed);
    }
}

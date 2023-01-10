using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Camera _cam;
    
    void Start()
    {

    }

    
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))      Inutile : voir la classe CubeBehavior.
        //{
        //    Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit, 1000))
        //    {              
        //        Destroy(hit.transform.gameObject);                
        //    }

        //}
    }
}

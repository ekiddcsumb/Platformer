using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float distance;
    public LayerMask layermask;
    public GameObject coinText;
    private int coinCount;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo, distance, layermask))
            {
                Destroy(hitInfo.transform.gameObject);
            }
        }
        
    }
}

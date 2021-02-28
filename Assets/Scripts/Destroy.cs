using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    public float distance;
    public LayerMask layermask;

    public GameObject coinText;
    private int coinCount = 00;

    public GameObject pointText;
    private int pointCount = 0;
    void Update()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(transform.position, Vector3.up);

        if (Physics.Raycast(ray, out hitInfo, distance, layermask))
        {
            if (hitInfo.collider.name != "Rock(Clone)" && hitInfo.collider.name != "Stone(Clone)"
            && hitInfo.collider.name != "Lava(Clone)" && hitInfo.collider.name != "Goal(Clone)")
            {
                Destroy(hitInfo.transform.gameObject);

                if (hitInfo.transform.name == "QuestionBlock(Clone)")
                {
                    coinCount++;
                    pointCount += 100;
                }

                if (hitInfo.transform.name == "Brick(Clone)")
                {
                    pointCount += 100;
                }
            }
        }
        
        
        if (coinCount < 10)
        {
            coinText.GetComponent<Text>().text = "0" + coinCount;
        }
        else
        {
            coinText.GetComponent<Text>().text = coinCount.ToString();
        }
        pointText.GetComponent<Text>().text = pointCount.ToString();
    }
}

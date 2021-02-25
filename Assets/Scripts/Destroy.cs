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
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo, distance, layermask))
            {
                Destroy(hitInfo.transform.gameObject);

                if (hitInfo.collider.name == "QuestionBlock(Clone)")
                {
                    coinCount++;

                    if (coinCount < 10)
                    {
                        coinText.GetComponent<Text>().text = "0" + coinCount;
                    }
                    else
                    {
                        coinText.GetComponent<Text>().text = coinCount.ToString();
                    }
                }
            }
            Debug.Log(coinCount);
        }
    }
}

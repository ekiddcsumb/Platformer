using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject timerText;
    public float timer = 100;
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Debug.Log("You failed :(");
        }
        
        int inttimer = (int)timer;

        timerText.GetComponent<Text>().text = inttimer.ToString();
    }
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (timer > 0 && other.gameObject.name == "Goal")
    //     {
    //         Debug.Log("You win!");
    //     }
    //     else
    //     {
    //         Debug.Log("You failed :(");
    //     }
    // }
    
}

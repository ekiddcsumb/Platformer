using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject timerText;
    public float timer = 400;
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
}

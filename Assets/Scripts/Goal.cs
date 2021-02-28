using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    // public Text timer;

    // public Collision character;
    // Update is called once per frame
    // void Update()
    // {
    //     OnCollisionEnter(character);
    // }
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("You win!");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

   
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {

            FindObjectOfType<AudioManager>().Play("oof");
            PlayerController.player.CurrentHealth -= 5;
            PlayerController.player.Health();
            
            PlayerController.player.H();

        }
    }



}


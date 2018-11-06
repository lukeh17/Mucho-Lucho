using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAI : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" && PlayerController.player.Punched == true)
        {
            FindObjectOfType<AudioManager>().Play("oof");
            AIScript.AI.CurrentHealth -= 5;
            AIScript.AI.Health();
            AIScript.AI.H();
        }
    }
}

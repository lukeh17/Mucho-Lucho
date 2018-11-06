using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour {

    SpriteRenderer r;

    void Start()
    {
        r = GetComponent<SpriteRenderer>();
        SetColor();
    }

    private void SetColor()
    {
        int rand = Random.Range(1, 8);

        switch (rand)
        {
            case 1:
                r.color = Color.blue;
                break;
            case 2:
                r.color = Color.cyan;
                break;
            case 3:
                r.color = Color.green;
                break;
            case 4:
                r.color = Color.magenta;
                break;
            case 5:
                r.color = Color.red;
                break;
            case 6:
                r.color = Color.yellow;
                break;
            case 7:
                r.color = Color.white;
                break;
            case 8:
                r.color = Color.grey;
                break;  
        }
    }
}

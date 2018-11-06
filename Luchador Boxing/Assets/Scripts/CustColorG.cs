using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustColorG : MonoBehaviour {

    public static CustColorG colorG;

    public SpriteRenderer MaskSprite;
    public SpriteRenderer Pants;
    public SpriteRenderer Cape;

    void Awake()
    {
        if (colorG == null)
        {
            colorG = this;
        }
    }

	public void CustColor () {

        //getting Playerprefs value to know what one to toggle.
        int m = PlayerPrefs.GetInt("Mask", 1);
        switch (m)
        {
            case 1:
                MaskSprite.sprite = Customize.mask1;
                break;
            case 2:
                MaskSprite.sprite = Customize.mask2;
                break;
            case 3:
                MaskSprite.sprite = Customize.mask3;
                break;
            case 4:
                MaskSprite.sprite = Customize.mask4;
                break;
            case 5:
                MaskSprite.sprite = Customize.mask5;
                break;
            case 6:
                MaskSprite.sprite = Customize.mask6;
                break;
            case 7:
                MaskSprite.sprite = Customize.mask7;
                break;
            case 8:
                MaskSprite.sprite = Customize.mask8;
                break;
        }

        int p = PlayerPrefs.GetInt("Pants", 1);
        switch (p)
        {
            case 1:
                Pants.color = Colors.blue;
                break;
            case 2:
                Pants.color = Colors.purple;
                break;
            case 3:
                Pants.color = Colors.pink;
                break;
            case 4:
                Pants.color = Colors.lightBlue;
                break;
            case 5:
                Pants.color = Colors.green;
                break;
            case 6:
                Pants.color = Colors.orange;
                break;
            case 7:
                Pants.color = Colors.yellow;
                break;
            case 8:
                Pants.color = Colors.lime;
                break;
            case 9:
                Pants.color = Colors.red;
                break;
            case 10:
                Pants.color = Colors.white;
                break;
            case 11:
                Pants.color = Colors.grey;
                break;
            case 12:
                Pants.color = Colors.black;
                break;
        }

        int c = PlayerPrefs.GetInt("Cape", 1);
        switch(c)
        {
            case 1:
                Cape.color = Colors.blue;
                break;
            case 2:
                Cape.color = Colors.purple;
                break;
            case 3:
                Cape.color = Colors.pink;
                break;
            case 4:
                Cape.color = Colors.lightBlue;
                break;
            case 5:
                Cape.color = Colors.green;
                break;
            case 6:
                Cape.color = Colors.orange;
                break;
            case 7:
                Cape.color = Colors.yellow;
                break;
            case 8:
                Cape.color = Colors.lime;
                break;
            case 9:
                Cape.color = Colors.red;
                break;
            case 10:
                Cape.color = Colors.white;
                break;
            case 11:
                Cape.color = Colors.grey;
                break;
            case 12:
                Cape.color = Colors.black;
                break;
        }
    }
	

}

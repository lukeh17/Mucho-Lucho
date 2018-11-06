using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colors : MonoBehaviour {

    //UI Image components
    public Image pantsImage;
    public Image capeImage;
    
    //All Colors Used
    public static Color32 blue = new Color32(23, 43, 255, 255);
    public static Color32 purple = new Color32(149, 61, 255, 255);
    public static Color32 pink = new Color32(255, 116, 231, 255);
    public static Color32 lightBlue = new Color32(0, 206, 255, 255);
    public static Color32 green = new Color32(0, 166, 0, 255);
    public static Color32 orange = new Color32(255, 156, 0, 255);
    public static Color32 yellow = new Color32(247, 255, 0, 255);
    public static Color32 lime = new Color32(0, 255, 92, 255);
    public static Color32 red = new Color32(255, 0, 16, 255);
    public static Color32 white = new Color32(255, 255, 255, 255);
    public static Color32 grey = new Color32(147, 147, 147, 255);
    public static Color32 black = new Color32(19, 19, 19, 255);

    void Awake()
    {
        int p = PlayerPrefs.GetInt("Pants", 1);
        switch (p)
        {
            case 1:
                pantsImage.color = Colors.blue;
                break;
            case 2:
                pantsImage.color = Colors.purple;
                break;
            case 3:
                pantsImage.color = Colors.pink;
                break;
            case 4:
                pantsImage.color = Colors.lightBlue;
                break;
            case 5:
                pantsImage.color = Colors.green;
                break;
            case 6:
                pantsImage.color = Colors.orange;
                break;
            case 7:
                pantsImage.color = Colors.yellow;
                break;
            case 8:
                pantsImage.color = Colors.lime;
                break;
            case 9:
                pantsImage.color = Colors.red;
                break;
            case 10:
                pantsImage.color = Colors.white;
                break;
            case 11:
                pantsImage.color = Colors.grey;
                break;
            case 12:
                pantsImage.color = Colors.black;
                break;
        }


        int c = PlayerPrefs.GetInt("Cape", 1);
        switch (c)
        {
            case 1:
                capeImage.color = Colors.blue;
                break;
            case 2:
                capeImage.color = Colors.purple;
                break;
            case 3:
                capeImage.color = Colors.pink;
                break;
            case 4:
                capeImage.color = Colors.lightBlue;
                break;
            case 5:
                capeImage.color = Colors.green;
                break;
            case 6:
                capeImage.color = Colors.orange;
                break;
            case 7:
                capeImage.color = Colors.yellow;
                break;
            case 8:
                capeImage.color = Colors.lime;
                break;
            case 9:
                capeImage.color = Colors.red;
                break;
            case 10:
                capeImage.color = Colors.white;
                break;
            case 11:
                capeImage.color = Colors.grey;
                break;
            case 12:
                capeImage.color = Colors.black;
                break;
        }

    }

    //For Knowing if the Pants button is on or Cape button
    bool pants = false;
    bool cape = false;

    public void Pants()
    {
        pants = true;
        cape = false;
    }

    public void Cape()
    {
        cape = true;
        pants = false;
    }

    //Assigning Colors to UI and setting PlayerPrefs to be used on actual character in game.
    public void Blue()
    { 
        if(pants)
        {
            pantsImage.color = blue;
            PlayerPrefs.SetInt("Pants", 1);
        }


        if (cape)
        {
            capeImage.color = blue;
            PlayerPrefs.SetInt("Cape", 1);
        }
            
    }

    public void Purple()
    {
        if (pants)
        {
            pantsImage.color = purple;
            PlayerPrefs.SetInt("Pants", 2);
        }


        if (cape)
        {
            capeImage.color = purple;
            PlayerPrefs.SetInt("Cape", 2);
        }
            
    }

    public void Pink()
    {
        if (pants)
        {
            pantsImage.color = pink;
            PlayerPrefs.SetInt("Pants", 3);
        }


        if (cape)
        {
            capeImage.color = pink;
            PlayerPrefs.SetInt("Cape", 3);
        }
            
    }

    public void LightBlue()
    {
        if (pants)
        {
            pantsImage.color = lightBlue;
            PlayerPrefs.SetInt("Pants", 4);
        }


        if (cape)
        {
            capeImage.color = lightBlue;
            PlayerPrefs.SetInt("Cape", 4);
        }
            
    }

    public void Green()
    {
        if (pants)
        {
            pantsImage.color = green;
            PlayerPrefs.SetInt("Pants", 5);
        }


        if (cape)
        {
            capeImage.color = green;
            PlayerPrefs.SetInt("Cape", 5);
        }
    }

    public void Orange()
    {
        if (pants)
        {
            pantsImage.color = orange;
            PlayerPrefs.SetInt("Pants", 6);
        }


        if (cape)
        {
            capeImage.color = orange;
            PlayerPrefs.SetInt("Cape", 6);
        }
    }

    public void Yellow()
    {
        if (pants)
        {
            pantsImage.color = yellow;
            PlayerPrefs.SetInt("Pants", 7);
        }


        if (cape)
        {
            capeImage.color = yellow;
            PlayerPrefs.SetInt("Cape", 7);
        }
    }

    public void Lime()
    {
        if (pants)
        {
            pantsImage.color = lime;
            PlayerPrefs.SetInt("Pants", 8);
        }


        if (cape)
        {
            capeImage.color = lime;
            PlayerPrefs.SetInt("Cape", 8);
        }
    }

    public void Red()
    {
        if (pants)
        {
            pantsImage.color = red;
            PlayerPrefs.SetInt("Pants", 9);
        }


        if (cape)
        {
            capeImage.color = red;
            PlayerPrefs.SetInt("Cape", 9);
        }
    }

    public void White()
    {
        if (pants)
        {
            pantsImage.color = white;
            PlayerPrefs.SetInt("Pants", 10);
        }


        if (cape)
        {
            capeImage.color = white;
            PlayerPrefs.SetInt("Cape", 10);
        }
    }

    public void Grey()
    {
        if (pants)
        {
            pantsImage.color = grey;
            PlayerPrefs.SetInt("Pants", 11);
        }


        if (cape)
        {
            capeImage.color = grey;
            PlayerPrefs.SetInt("Cape", 11);
        }
    }

    public void Black()
    {
        if (pants)
        {
            pantsImage.color = black;
            PlayerPrefs.SetInt("Pants", 12);
        }


        if (cape)
        {
            capeImage.color = black;
            PlayerPrefs.SetInt("Cape", 12);
        }
    }

}

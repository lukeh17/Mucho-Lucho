using UnityEngine;
using UnityEngine.UI;

public class Customize : MonoBehaviour {

    public Image maskImage;

    public static Sprite mask1, mask2, mask3, mask4, mask5, mask6, mask7, mask8;

	void Awake ()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/Luchador");

        mask1 = sprites[19];
        mask2 = sprites[12];
        mask3 = sprites[13];
        mask4 = sprites[14];
        mask5 = sprites[15];
        mask6 = sprites[3];
        mask7 = sprites[16];
        mask8 = sprites[17];

        int m = PlayerPrefs.GetInt("Mask", 1);

        switch (m)
        {
            case 1:
                Mask1();
                break;
            case 2:
                Mask2();
                break;
            case 3:
                Mask3();
                break;
            case 4:
                Mask4();
                break;
            case 5:
                Mask5();
                break;
            case 6:
                Mask6();
                break;
            case 7:
                Mask7();
                break;
            case 8:
                Mask8();
                break;
        }

    }

    public void Mask1()
    {
        maskImage.sprite = mask1;
        PlayerPrefs.SetInt("Mask", 1);
    }

    public void Mask2()
    {
        maskImage.sprite = mask2;
        PlayerPrefs.SetInt("Mask", 2);
    }

    public void Mask3()
    {
        maskImage.sprite = mask3;
        PlayerPrefs.SetInt("Mask", 3);
    }

    public void Mask4()
    {
        maskImage.sprite = mask4;
        PlayerPrefs.SetInt("Mask", 4);
    }

    public void Mask5()
    {
        maskImage.sprite = mask5;
        PlayerPrefs.SetInt("Mask", 5);
    }

    public void Mask6()
    {
        maskImage.sprite = mask6;
        PlayerPrefs.SetInt("Mask", 6);
    }

    public void Mask7()
    {
        maskImage.sprite = mask7;
        PlayerPrefs.SetInt("Mask", 7);
    }

    public void Mask8()
    {
        maskImage.sprite = mask8;
        PlayerPrefs.SetInt("Mask", 8);
    }

}

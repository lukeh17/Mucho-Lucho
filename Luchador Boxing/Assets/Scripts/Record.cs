using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour {

    //public Text wins;
    //public Text L;

    const string characters = "abcdefghijklmnopqrstuvwxyz0123456789";

    private string username;

    void Start()
    {
        // wins.text = PlayerPrefs.GetInt("Wins", 0).ToString();
        //L.text = PlayerPrefs.GetInt("L", 0).ToString();

        if (!PlayerPrefs.HasKey("Username"))
        {
            PlayerPrefs.DeleteKey("Username");
            Generate();
        }
        Debug.Log("Username: " + username);

        username = PlayerPrefs.GetString("Username");

        Leaderboard.lb.AddRecord(username, GetWins(), GetLosses());

    }

    //
    //Add Check to generate to check server for same usernames
    //
    //

    private void Generate()
    {
        int charAmount = Random.Range(2, 12);
        for (int i = 0; i < charAmount; i++)
        {
            username += characters[Random.Range(0, characters.Length)];
        }
        PlayerPrefs.SetString("Username", username);
    }


    public static void RecordWin()
    {
        int x = PlayerPrefs.GetInt("Win", 0);
        x += 1;
        PlayerPrefs.SetInt("Win", x);
    }

    public static void RecordLoss()
    {
        int x = PlayerPrefs.GetInt("L", 0);
        x += 1;
        PlayerPrefs.SetInt("L", x);
    }

    public static int GetWins()
    {
        return PlayerPrefs.GetInt("Win", 0);
    }

    public static int GetLosses()
    {
        return PlayerPrefs.GetInt("L", 0);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour {

    const string privateCode = "3ERYYvxTP0mGS05fk3t6cgPgqmzrA2LE2chhenqbg-PQ";
    const string publicCode = "5b4e7a2a191a8a0bcc4eff87";
    const string webURL = "http://dreamlo.com/lb/";
    public static Leaderboard lb;

    public Score[] recordsList;
    private bool created;

    void Awake()
    {
        if (lb == null)
        {
            lb = this;
        }
    }


    public void AddRecord(string username, int wins, int L)
    {
        StartCoroutine(UploadHighScore(username, wins, L));
    }

    IEnumerator UploadHighScore(string username, int wins, int L)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + wins + "/" + L);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            //print("Upload Successful");
            DownloadHighScores();
        }
        else
        {
            print("Error uploading " + www.error);
        }
    }

    public void DownloadHighScores()
    {
        StartCoroutine("DownloadScoresFromDatabase");
    }

    IEnumerator DownloadScoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Format(www.text);
            LeaderboardDisplay.display.OnScoresDownloaded(recordsList); //Error
        }
        else
        {
            print("Error Downloading " + www.error);
        }
    }

    void Format(string text)
    {
        string[] entry = text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        recordsList = new Score[entry.Length];

        for (int i = 0; i < entry.Length; i++)
        {
            string[] entryInfo = entry[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int wins = int.Parse(entryInfo[1]);
            int l = int.Parse(entryInfo[2]);
            recordsList[i] = new Score(username, wins, l);
            //print(recordsList[i].username + " " + recordsList[i].wins + " " + recordsList[i].l);
        }
    }

    public struct Score
    {
        public string username;
        public int wins;
        public int l;

        public Score(string _username, int _wins, int _l)
        {
            username = _username;
            wins = _wins;
            l = _l;
        }
    }

}

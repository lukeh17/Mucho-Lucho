using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardDisplay : MonoBehaviour {

    public Text[] scoresText;
    public Text recordText;
    public static LeaderboardDisplay display;

    void Awake()
    {
        if (display == null)
        {
            display = this;
        }
    }

    void Start()
    {                        
        for (int i = 0; i < scoresText.Length; i++)
        {
            scoresText[i].text = i + 1 + ". Fetching...";
        }
        
        recordText.text = Record.GetWins() + " - " + Record.GetLosses(); //Gets Users own record
        
        StartCoroutine("Refresh");
    }

    public void OnScoresDownloaded(Leaderboard.Score[] recordsList)
    {
        for (int i = 0; i < scoresText.Length; i++)
        {
            scoresText[i].text = i + 1 + ".";
            if (i < scoresText.Length)
            {
                Debug.Log("Int i= " + i);
                scoresText[i].text += "  " + recordsList[i].wins + " - " + recordsList[i].l;
            }
        }
    }

    IEnumerator Refresh()
    {
        while (true)
        {
            Leaderboard.lb.DownloadHighScores();
            yield return new WaitForSeconds(30);
        }
    }
}

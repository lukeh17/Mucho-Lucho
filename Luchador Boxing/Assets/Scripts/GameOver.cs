using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject pause;
    public GameObject pT;
    public Text playerText;
    public static bool Enabled = true;
    public GameObject punchButton;
    public GameObject ragdoll;

    void Update()
    {
        if (gameObject == null)
        {
            return;
        }

        if (AIScript.AI.currentHealth <= 0)
        {
            pause.SetActive(false);
            pT.SetActive(true);
            playerText.text = "Player Wins!";
            //AIScript.AI.ShowDeath();
            Enabled = false;
            PlayerController.player.Win();
            punchButton.SetActive(false);
            Record.RecordWin();
            AIScript.AI.ShowRagdoll();
            Destroy(this);
            return;
        }
        else if (PlayerController.player.currentHealth <= 0)
        {
            pause.SetActive(false);
            pT.SetActive(true);
            playerText.text = "AI Wins!";
            //PlayerController.player.ShowDeath();
            Enabled = false;
            AIScript.AI.Win();
            punchButton.SetActive(false);
            Record.RecordLoss();
            PlayerController.player.ShowRagdoll();
            Destroy(this);
            return;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    
    public Text highScoreText;
    public Text messageText;

    void Start()
    {
        MainManager.Instance.LoadHighScore();
        MainManager.Instance.CheckName();

        if (MainManager.Instance.highScore != 0)
        {
            if (MainManager.Instance.playerHasName == true) //If there is already a high score and the player has entered a name this message will display
            {
                messageText.text = MainManager.Instance.playerName;
                highScoreText.text = "High Score: " + MainManager.Instance.highScore + " by " + MainManager.Instance.highScoreName;
            }
            else //If there is a high score and the player hasnt entered a name yet this message will display
            {
                messageText.text = "Enter your name below to try set a new high score";
                highScoreText.text = "High Score: " + MainManager.Instance.highScore + " by " + MainManager.Instance.highScoreName;
            }
        }
        else if (MainManager.Instance.playerHasName == false) //If there is no high score and the player has not entered a name this message will display
        {
            messageText.text = "Enter your name below";
            highScoreText.text = "Welcome new player";
        }
        else //If the player has a name but hasnt set a score this message will display
        {
            messageText.text = MainManager.Instance.playerName;
            highScoreText.text = "Set a new high score";
        }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

// Attatched to the canvas game object in all scenes

public class MenuUIHandler : MonoBehaviour
{
    public void Menu()//Return to menu
    {
        SceneManager.LoadScene(0); //Loads the menu scene
    }

    public void StartNew() //Starts new game
    {

        if (MainManager.Instance.playerHasName == true)
        {
            SceneManager.LoadScene(1); //Loads the game scene
            MainManager.Instance.LoadHighScore(); //Loads the current high score
        }
    }
   
    public void Exit() //Exits the game
    {
#if UNITY_EDITOR //If the game is played in Unity Editor
        EditorApplication.ExitPlaymode(); //Exits playmode in unity editor
#else //If the game is not being played in Unity Editor
        Application.Quit(); //Closes the application
#endif // Ends the statement and disregards whatever option is inapplicable
    }
}

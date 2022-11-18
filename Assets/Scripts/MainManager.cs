using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//ORIGINAL SCRIPT MOVED TO GAME MANAGER

public class MainManager : MonoBehaviour
{
    public string playerName;
    public bool playerHasName = false; //Added this for the high score messages
    public int currentScore;

    public int highScore;
    public string highScoreName;
    
    public static MainManager Instance; //public static means the values will be shared by all instances of that class.

    private void Awake() //Awake is called as soon as the object is created.
    {
        //This pattern is called a singleton.
        //You use it to ensure that only a single instance of the MainManager can ever exist, so it acts as a central point of access.
        if (Instance != null) //Conditional statement to check whether or not instance is null
        {
            Destroy(gameObject); //If a MainManager already exists delete the extra one
            return; 
        }
        
        Instance = this; //Stores "this" in the class member instance
        DontDestroyOnLoad(gameObject); //Marks the MainManager GameObject attatched to this script not to be destroyed
        LoadHighScore(); //Loads current high score when MainManager is created
        Debug.Log(Application.persistentDataPath);
    }

    public void CheckName() //Checks to see if player has a name for high score messages
    {
        if (playerName == null)
        {
            playerHasName = false;
            Debug.Log("Player doesnt have a name");
        }
    }

    [System.Serializable] //This is required for Json utility it will only convert data if they are tagged as serializeable
    public class SaveData
    {
        public int highScore;
        public string highScoreName;
    }

    public void SaveHighScore(int currentScore, string playerName) //Captures the two arguments currentScore and playerName
    {
        SaveData data = new SaveData(); //Creates a new instance of the save data

        data.highScore = currentScore; //Stores the score
        data.highScoreName = playerName; //Stores the player name

        string json = JsonUtility.ToJson(data); //Transforms the instance to JSON

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); //Writes string to file. Needs using System.IO; namespace
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json"; //Reversal of the SaveHighSCore method
        if (File.Exists(path)) //Uses File.Exists method to see if .json file exists
        {
            string json = File.ReadAllText(path); //If .json file exists this will read its contents
            SaveData data = JsonUtility.FromJson<SaveData>(json); //This transforms it back to a SaveData instance

            highScore = data.highScore; //Sets highScore to score saved in SaveData
            highScoreName = data.highScoreName; //Sets highScoreName to name saved in SaveData
        }
    }
}

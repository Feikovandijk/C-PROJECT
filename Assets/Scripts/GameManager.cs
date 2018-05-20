    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
	private static GameManager s_Instance = null;
	public int currentScore = 0;
	private int highscore;
	//public  int currentLevel;
	private int unlockedLevel;

	public int levelAmount = 2;

	 public static GameManager instance {
        get {
            if (s_Instance == null) {
                // This is where the magic happens.
                //  FindObjectOfType(...) returns the first GameManager object in the scene.
                s_Instance =  FindObjectOfType(typeof (GameManager)) as GameManager;
            }
 
            // If it is still null, create a new instance
            if (s_Instance == null) {
                GameObject obj = new GameObject("GameManager");
                s_Instance = obj.AddComponent(typeof (GameManager)) as GameManager;
                Debug.Log ("Could not locate a GameManager object. GameManager was Generated Automatically.");
            }
 
            return s_Instance;
        }
    }
 
    // Ensure that the instance is destroyed when the game is stopped in the editor.
    void OnApplicationQuit() {
        s_Instance = null;
    }
	public void CompleteLevel(){
		Scene scene = SceneManager.GetActiveScene();
		ScorePoint();
		if (scene.buildIndex < levelAmount)
		{
			SceneManager.LoadScene(scene.buildIndex + 1);
		}

	}
	public void ScorePoint(){
		currentScore++;
	}
	public void OnDeath(){
		currentScore = 0;
	}
}

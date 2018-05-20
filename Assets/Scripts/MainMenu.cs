using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 45), "Play"))
        {
            Application.LoadLevel(1);
        }

        if (GUI.Button(new Rect(10, 65, 100, 45), "Quit"))
        {
            Application.Quit();
        }
    }
    
    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void Option()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByName("OptionScreen").buildIndex + 1);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Starts the game 
    /// </summary>
    public void PlayMaze(){
          SceneManager.LoadScene("maze");
    }
    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitMaze(){
        Debug.Log("Quit Game");
        Application.Quit();
    }
}

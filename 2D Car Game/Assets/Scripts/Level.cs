using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    public void LoadGame()
    {
        //SceneManager.LoadScene(1);
        if (FindObjectsOfType<ScoreSession>().Length == 1)
        {
            FindObjectOfType<ScoreSession>().ResetGame();
        }
        else
        {
            SceneManager.LoadScene("2DCarGame"); //Loads the scene with the name 2DCarGame
        }
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0); //Loads the first scene in the project
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void GameQuit()
    {
        print("Quittng Game");
        Application.Quit(); //Quit game
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver"); //Loads the scene with the name GameOver
    }

    public void Winner()
    {
        SceneManager.LoadScene("Winner");
        print("Winner");
    }

    IEnumerator WaitAndLoadWin()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Winner");
    }
}
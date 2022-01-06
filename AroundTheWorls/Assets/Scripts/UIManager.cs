using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    int sceneIndex;
    int levelComplete;
    public void Menu()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreviousLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GeneralScore._generalScore -= GameManager._instance.scoreCount;
    }
}

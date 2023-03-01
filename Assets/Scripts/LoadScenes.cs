using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void RunGame()
    {
        SceneManager.LoadScene("MainARScene");
    }

    public static void DeathScreen()
    {
        SceneManager.LoadScene("DeathScene");
    }

    public static void MenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}

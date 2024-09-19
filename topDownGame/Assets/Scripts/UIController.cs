using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Prototype");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

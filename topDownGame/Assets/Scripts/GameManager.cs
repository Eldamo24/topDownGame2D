using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool win;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        instance = this;
    }

    public void CheckWin()
    {
        win = true;
        InGameUIController.instance.ActiveFinishPanel();
    }

    public void CheckLose()
    {
        win = false;
        InGameUIController.instance.ActiveFinishPanel();
    }
}

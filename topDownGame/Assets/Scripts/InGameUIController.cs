using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{
    public static InGameUIController instance;
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private TMP_Text enemiesCountText;
    private int enemiesKilled;

    private void Start()
    {
        instance = this;
        enemiesKilled = 0;
        enemiesCountText.text = "Enemies: " + enemiesKilled;
    }


    public void UpdateLifeText(int life)
    {
        lifeText.text = "Life: " + life;
    }

    public void UpdateEnemiesText()
    {
        enemiesKilled++;
        enemiesCountText.text = "Enemies: " + enemiesKilled;
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIController : MonoBehaviour
{
    public static InGameUIController instance;
    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private TMP_Text enemiesCountText;
    [SerializeField] private TMP_Text winOrLoseText;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject UIInGame;
    public int enemiesKilled;

    private void Start()
    {
        instance = this;
        enemiesKilled = 0;
        enemiesCountText.text = "Enemies: " + enemiesKilled;
        UpdateLifeText(100);
    }


    public void UpdateLifeText(int life)
    {
        lifeText.text = "Life: " + life;
    }

    public void UpdateEnemiesText()
    {
        enemiesKilled++;
        enemiesCountText.text = "Enemies: " + enemiesKilled;
        if (enemiesKilled >= 20)
            GameManager.instance.CheckWin();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Prototype");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ActiveFinishPanel()
    {
        Time.timeScale = 0f;
        endGamePanel.SetActive(true);
        if (GameManager.instance.win)
        {
            winOrLoseText.text = "Winner";
        }
        else
        {
            winOrLoseText.text = "Loser";
        }
    }
}

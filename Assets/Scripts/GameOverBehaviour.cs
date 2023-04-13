using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverBehaviour : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    public void Setup(float score)
    {
        gameObject.SetActive(true);
        ScoreText.text = score.ToString() + " POINTS!";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}

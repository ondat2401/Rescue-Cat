using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class GameUIManager : MonoBehaviour
{
    [Header("Lose Panel")]
    public GameObject failedPanel;
    public TMP_Text failedSpeedValue;
    public TMP_Text failedCatCounterText;
    public TMP_Text failedCoinRewardText;


    [Header("Win Panel")]
    public GameObject wonPanel;
    public TMP_Text wonSpeedValue;
    public TMP_Text wonCatCounterText;
    public TMP_Text wonTimeCounterText;
    public TMP_Text wonCoinRewardText;

    [Space]
    public TMP_Text levelText; 
    private void OnEnable()
    {
        UpdateLevelText();
        TransAplhaText(levelText);
    }

    private void Start()
    {
        failedPanel.SetActive(false);
        wonPanel.SetActive(false);
    }
    public void PauseButton()
    {
        GameManager.Instance.PauseGame();
    }

    public void ResumeButton()
    {
        GameManager.Instance.ResumeGame();
    }
    public void GiveupButton()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void EndGame()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;

        GameManager.Instance.allCoin += GameManager.Instance.coinReward;
    }
    public void NextRound()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
        GameManager.Instance.allCoin += GameManager.Instance.coinReward;

        GameManager.Instance.UpdateValues(GameManager.Instance.level + 1);

    }
    private void UpdateLevelText()
    {
        levelText.text = "LEVEL " + GameManager.Instance.level.ToString();
    }
    private IEnumerator FadeOutText(TMP_Text text)
    {
        Color currentColor = text.color;
        while (currentColor.a > 0f)
        {
            currentColor.a -= Time.deltaTime * 0.5f;
            text.color = currentColor;
            yield return null;
        }
        text.enabled = false;
    }
    private void TransAplhaText(TMP_Text text)
    {
        if (text.enabled)
            StartCoroutine(FadeOutText(text));
        else
        {
            text.enabled = true;
            StartCoroutine(FadeOutText(text));
        }
    }
}

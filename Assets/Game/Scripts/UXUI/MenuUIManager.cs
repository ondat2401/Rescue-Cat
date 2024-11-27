using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    [Header("Coin Info")]
    [SerializeField] private TMP_Text displayCoin;

    [SerializeField] private TMP_Text displayPlayerSpeed;
    [SerializeField] private TMP_Text displayPlayerSpeedPrices;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    private void Update()
    {
        DisplayData();
    }

    private void DisplayData()
    {
        if (gameManager.allCoin != int.Parse(displayCoin.text))
            displayCoin.text = gameManager.allCoin.ToString();

        if (gameManager.currentSpeedLevel != float.Parse(displayPlayerSpeed.text))
            displayPlayerSpeed.text = gameManager.currentSpeedLevel.ToString("F1");

        displayPlayerSpeedPrices.text = gameManager.currentSpeedPrices.ToString();
    }

    public void PlayeBtn()
    {
        SceneManager.LoadScene("Game");
        GameManager.Instance.GetComponent<LoadAndSaveData>().SaveAllData();
        GameManager.Instance.timeCounter = 0;
        GameManager.Instance.catCounter = 0;



        GameManager.Instance.ResetValue();
    }
    public void UpgradeSpeedBtn()
    {
        gameManager.IncreaseSpeedPrices();
    }
}

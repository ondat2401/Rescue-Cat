using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    [Header("Game Stat")]
    public float playerSpeed;
    public int allCoin;  
    public int coinReward = 0;  

    [Header("Upgrade Info")]
    public float currentSpeedLevel;
    public int currentSpeedPrices;

    public bool playerCanMove;
    public int catCounter = 0;
    public float timeCounter = 0;

    [Header("Game Level Increase Info")]
    public int level;
    public float catSpeed;
    public float stunamiSpeed;
    public int carCounter;
    public float carDistance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Debug.Log("Game started");
        GetComponent<LoadAndSaveData>().LoadAllData();
    }
    public void ResetValue()
    {
        level = 1;
        coinReward = 0;
        catSpeed = 4;
        stunamiSpeed = 10;
        carCounter = 4;
        carDistance = 150;
    }
    public void UpdateValues(int newLevel)
    {
        if (newLevel >= 1 && newLevel <= 10)
        {
            level = newLevel;

            coinReward = level * 10;
            catSpeed = 4 + level;
            stunamiSpeed = 10 + level;
            carCounter = 2 + level;

            carDistance = 100 - level * 10; 

            if (carDistance < 30)
            {
                carDistance = 30; 
            }
        }
        catCounter = 0;
        timeCounter = 0;
        coinReward = 0;
    }

    public void IncreaseSpeedPrices()
    {
        if (currentSpeedPrices <= allCoin)
        {
            currentSpeedLevel += .1f;
            allCoin -= currentSpeedPrices;
            currentSpeedPrices += currentSpeedPrices;
        }
    }

    
    private void Update()
    {
        if(playerSpeed != currentSpeedLevel * 15f)
            playerSpeed = currentSpeedLevel * 15f;
        if(playerCanMove)
            timeCounter += Time.deltaTime;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        Debug.Log("Game paused");

        GetComponent<LoadAndSaveData>().SaveAllData();

    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Debug.Log("Game resumed");

        GetComponent<LoadAndSaveData>().SaveAllData();
    }
    public void GameFailed()
    {
        Time.timeScale = 0;
        GameUIManager gameUIManager = FindAnyObjectByType<GameUIManager>();
        gameUIManager.failedPanel.SetActive(true);
        gameUIManager.failedSpeedValue.text = (currentSpeedLevel).ToString("F1") + " M/S";
        gameUIManager.failedCatCounterText.text = catCounter.ToString() + "/" + "6";

        coinReward = (int)(catCounter * (50 - timeCounter));
        gameUIManager.failedCoinRewardText.text = coinReward.ToString("F1");


        GetComponent<LoadAndSaveData>().SaveAllData();
    }
    public void GameWon()
    {
        Time.timeScale = 0;
        GameUIManager gameUIManager = FindAnyObjectByType<GameUIManager>();
        gameUIManager.wonPanel.SetActive(true);
        gameUIManager.wonSpeedValue.text = (currentSpeedLevel).ToString("F1") + " M/S";
        gameUIManager.wonCatCounterText.text = catCounter.ToString() + "/" + "6";
        gameUIManager.wonTimeCounterText.text = timeCounter.ToString("F1") + " s";

        coinReward = (int)(catCounter * (100 - timeCounter));
        gameUIManager.wonCoinRewardText.text = coinReward.ToString("F1");

        GetComponent<LoadAndSaveData>().SaveAllData();
    }
}

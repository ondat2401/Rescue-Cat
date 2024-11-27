using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    public void SaveAllCoin()
    {
        PlayerPrefs.SetInt("AllCoin", GameManager.Instance.allCoin);
        PlayerPrefs.Save();
        Debug.Log("Coins saved: " + GameManager.Instance.allCoin);
    }

    public void LoadAllCoin()
    {
        if (PlayerPrefs.HasKey("AllCoin"))
        {
            GameManager.Instance.allCoin = PlayerPrefs.GetInt("AllCoin");
            Debug.Log("Coins loaded: " + GameManager.Instance.allCoin);
        }
        else
        {
            GameManager.Instance.allCoin = 0;
            Debug.Log("No coin data found. Defaulting to 0.");
        }
    }
    public void SaveSpeedLevel()
    {
        PlayerPrefs.SetFloat("SpeedLevel", GameManager.Instance.currentSpeedLevel);
        PlayerPrefs.Save();
        Debug.Log("Speed Level saved: " + GameManager.Instance.currentSpeedLevel);
    }

    public void LoadSpeedLevel()
    {
        if (PlayerPrefs.HasKey("SpeedLevel"))
        {
            GameManager.Instance.currentSpeedLevel = PlayerPrefs.GetFloat("SpeedLevel");
            Debug.Log("Speed Level loaded: " + GameManager.Instance.allCoin);
        }
        else
        {
            GameManager.Instance.currentSpeedLevel = 1;
            Debug.Log("No speed level data found. Defaulting to 1.");
        }
    }
    public void SaveSpeedPrices()
    {
        PlayerPrefs.SetInt("SpeedPrices", GameManager.Instance.currentSpeedPrices);
        PlayerPrefs.Save();
        Debug.Log("Speed prices saved: " + GameManager.Instance.currentSpeedPrices);
    }

    public void LoadSpeedPrices()
    {
        if (PlayerPrefs.HasKey("SpeedPrices"))
        {
            GameManager.Instance.currentSpeedPrices = PlayerPrefs.GetInt("SpeedPrices");
            Debug.Log("Speed prices loaded: " + GameManager.Instance.currentSpeedPrices);
        }
        else
        {
            GameManager.Instance.currentSpeedPrices = 2;
            Debug.Log("No speed prices data found. Defaulting to 2.");
        }
    }
    public void SaveAllData()
    {
        SaveAllCoin();
        SaveSpeedLevel();
        SaveSpeedPrices();
        PlayerPrefs.Save();
        Debug.Log("All data saved.");
    }

    public void LoadAllData()
    {
        LoadAllCoin();
        LoadSpeedLevel();
        LoadSpeedPrices();
        Debug.Log("All data loaded.");
    }
}

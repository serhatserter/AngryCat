using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasCodes : MonoBehaviour
{
    public static CanvasCodes instance;

    public int levelIndex;

    public string baseSceneName = "Main";

    public GameObject inGamePanel;
    public GameObject failedPanel;
    public GameObject clearPanel;

    public TextMeshProUGUI[] levelTexts;
    private void Awake()
    {
        instance = this;

        if (!PlayerPrefs.HasKey("LEVEL"))
        {
            PlayerPrefs.SetInt("LEVEL", 1);
        }
        levelIndex = PlayerPrefs.GetInt("LEVEL");

        foreach (TextMeshProUGUI text in levelTexts)
        {
            text.text = "LEVEL " + levelIndex;
        }
    }

    void Start()
    {
        OpenInGamePanel();
        //OpenClearPanel();
        //OpenFailedPanel();
    }

    void Update()
    {
        
    }

    public void OpenClearPanel()
    {
        //ElephantSDK.Elephant.LevelCompleted(levelIndex);
        inGamePanel.SetActive(false);
        failedPanel.SetActive(false);
        clearPanel.SetActive(true);
    }

    public void OpenFailedPanel()
    {
        //ElephantSDK.Elephant.LevelFailed(levelIndex);
        inGamePanel.SetActive(false);
        clearPanel.SetActive(false);
        failedPanel.SetActive(true);
    }

    public void OpenInGamePanel()
    {
        //ElephantSDK.Elephant.LevelStarted(levelIndex);
        failedPanel.SetActive(false);
        clearPanel.SetActive(false);
        inGamePanel.SetActive(true);
    }

    public void NextBTN()
    {
        levelIndex++;
        PlayerPrefs.SetInt("LEVEL", levelIndex);
        SceneManager.LoadScene(baseSceneName.Trim() + " " + levelIndex);
    }

    public void RestartBTN()
    {
        SceneManager.LoadScene(baseSceneName.Trim() + " " + levelIndex);
    }
}

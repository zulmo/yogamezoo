using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton;
    public Button PosesButton;
    public GameObject GameSelection;
    public Button NormalGameButton;
    public Button RandomGameButton;
    public Button FiveFiveFiveButton;
    public Button CloseGameSelectionButton;

    public Action PlayNormalGame;
    public Action PlayRandomGame;
    public Action PlayFiveFiveFiveGame;
    public Action ShowPoseDetails;

    
    void Start()
    {
        PlayButton.onClick.AddListener(Play);
        PosesButton.onClick.AddListener(OnShowPoseDetails);
        NormalGameButton.onClick.AddListener(OnNormal);
        RandomGameButton.onClick.AddListener(OnRandom);
        FiveFiveFiveButton.onClick.AddListener(OnFiveFiveFive);
        CloseGameSelectionButton.onClick.AddListener(CloseGameSelection);
    }

    void Play()
    {
        GameSelection.SetActive(true);
    }

    void OnShowPoseDetails()
    {
        ShowPoseDetails.Invoke();
    }

    void OnNormal()
    {
        PlayNormalGame.Invoke();
        CloseGameSelection();
    }

    void OnRandom()
    {
        PlayRandomGame.Invoke();
        CloseGameSelection();
    }

    void OnFiveFiveFive()
    {
        PlayFiveFiveFiveGame.Invoke();
        CloseGameSelection();
    }

    void CloseGameSelection()
    {
        GameSelection.SetActive(false);
    }
}
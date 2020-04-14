using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pose : MonoBehaviour
{
    public Action GameOver;
    public List<PoseData> SelectedPoses;
    public Image PoseImage;
    public GameObject SuccessPanel;
    public Button TryAgainButton;
    public Button SuccessButton;
    public Button ReadyButton;
    public Button AnimalButton;
    public Image AnimalImage;
    public Text ReadyTimerText;
    float readyTimer;
    public Text PoseTimerText;
    float poseTimer;
    PoseData currentPose;
    public Image Animal1;
    public Image Animal2;
    public Image Animal3;
    public Image Animal4;
    public Image Animal5;
    public Image Animal6;
    public GameObject GameOverPanel;

    

    void OnEnable()
    {
        AnimalButton.onClick.AddListener(OnAnimal);
        ReadyButton.onClick.AddListener(OnReady);
        SuccessButton.onClick.AddListener(OnSuccess);
        TryAgainButton.onClick.AddListener(OnRetry);
    }

    void OnDisable()
    {
        AnimalButton.onClick.RemoveListener(OnAnimal);
        ReadyButton.onClick.RemoveListener(OnReady);
        SuccessButton.onClick.RemoveListener(OnSuccess);
        TryAgainButton.onClick.RemoveListener(OnRetry);
    }
    
    public void Play()
    {
        currentPose = SelectedPoses[0];
        SetupWinScreen();
        SetupCurrentPose();
        PoseImage.gameObject.SetActive(true);
    }

    void SetupCurrentPose()
    {
        PoseImage.sprite = currentPose.PlayerCard;
        ReadyTimerText.text = "3";
        readyTimer = 3;
        PoseTimerText.text = currentPose.Timer.ToString();
        poseTimer = currentPose.Timer;
        AnimalImage.sprite = currentPose.AnimalCaged;
        ReadyButton.gameObject.SetActive(true);
    }

    void Update()
    {
        if(ReadyTimerText.isActiveAndEnabled)
        {
            if(readyTimer <= 0)
            {
                PoseImage.sprite = currentPose.LeaderCard;
                ReadyTimerText.gameObject.SetActive(false);
                PoseTimerText.gameObject.SetActive(true);
            }
            else
            {
                readyTimer -= Time.deltaTime;
                ReadyTimerText.text = Mathf.CeilToInt(readyTimer).ToString();
            }
        }

        if(PoseTimerText.isActiveAndEnabled)
        {
            if(poseTimer <= 0)
            {
                PoseTimerText.gameObject.SetActive(false);
                SuccessPanel.gameObject.SetActive(true);
            }
            else
            {
                poseTimer -= Time.deltaTime;
                PoseTimerText.text = Mathf.CeilToInt(poseTimer).ToString();
            }
        }
    }

    void OnReady()
    {
        SuccessPanel.gameObject.SetActive(false);
        ReadyButton.gameObject.SetActive(false);
        ReadyTimerText.gameObject.SetActive(true);
    }

    void OnSuccess()
    {
        PoseImage.gameObject.SetActive(false);
        SuccessPanel.gameObject.SetActive(false);
        AnimalImage.gameObject.SetActive(true);
    }

    void OnRetry()
    {
        SuccessPanel.gameObject.SetActive(false);
        SetupCurrentPose();
    }

    void OnAnimal()
    {
        AnimalImage.sprite = currentPose.AnimalFree;
        StartCoroutine(PlayFreeAnimation());
    }

    IEnumerator PlayFreeAnimation()
    {
        yield return new WaitForSeconds(2);
        AnimalImage.gameObject.SetActive(false);
        SelectedPoses.RemoveAt(0);
        if(SelectedPoses.Count == 0)
        {
            StartCoroutine(PlayGameOver());
        }
        else
        {
            PoseImage.gameObject.SetActive(true);
            currentPose = SelectedPoses[0];
            SetupCurrentPose();
        }
    }

    void SetupWinScreen()
    {
        Animal1.sprite = SelectedPoses[0].AnimalFree;
        Animal2.sprite = SelectedPoses[1].AnimalFree;
        Animal3.sprite = SelectedPoses[2].AnimalFree;
        Animal4.sprite = SelectedPoses[3].AnimalFree;
        Animal5.sprite = SelectedPoses[4].AnimalFree;
        Animal6.sprite = SelectedPoses[5].AnimalFree;
    }

    IEnumerator PlayGameOver()
    {
        GameOverPanel.SetActive(true);
        yield return new WaitForSeconds(5);
        GameOverPanel.SetActive(false);
        GameOver.Invoke();
    }
}
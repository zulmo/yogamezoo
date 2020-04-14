using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoseDetail : MonoBehaviour
{
    public Action Close;
    public Button CloseButton;
    public Button NextButton;
    public Button PreviousButton;
    public GameDatabase database;
    public Image CurrentPose;
    public int iterator = 0;
    void OnEnable()
    {
        CloseButton.onClick.AddListener(OnClose);
        NextButton.onClick.AddListener(OnNext);
        PreviousButton.onClick.AddListener(OnPrevious);
        iterator = 0;
        UpdatePose();
    }

    void OnDisable()
    {
        CloseButton.onClick.RemoveListener(OnClose);
        NextButton.onClick.RemoveListener(OnNext);
        PreviousButton.onClick.RemoveListener(OnPrevious);
    }

    void OnClose()
    {
        Close.Invoke();
    }

    void OnNext()
    {
        iterator++;
        if(iterator >= database.Poses.Count)
        {
            iterator = 0;
        }
        UpdatePose();
    }

    void OnPrevious()
    {
        iterator--;
        if(iterator <= 0)
        {
            iterator = database.Poses.Count - 1;
        }
    }

    void UpdatePose()
    {
        Sprite newSprite = database.Poses[iterator].Detail;
        CurrentPose.sprite = newSprite;
    }
}

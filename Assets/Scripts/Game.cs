using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Splash Splash;
    public MainMenu MainMenu;
    public PoseDetail PoseDetail;
    public Pose Pose;
    public GameDatabase Database;

    void Start()
    {
        Random.InitState(Mathf.RoundToInt(Time.realtimeSinceStartup));

        Splash.SplashDone += ShowMainMenu;
        MainMenu.PlayNormalGame += PlayNormalGame;
        MainMenu.PlayRandomGame += PlayRandomGame;
        MainMenu.PlayFiveFiveFiveGame += PlayFiveFiveFiveGame;
        MainMenu.ShowPoseDetails += ShowPoseDetails;
        PoseDetail.Close += OnPoseDetailClose;
        Pose.GameOver += OnGameOver;
    }

    void ShowMainMenu()
    {
        Splash.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }

    void ShowPoseDetails()
    {
        PoseDetail.gameObject.SetActive(true);
    }

    void OnPoseDetailClose()
    {
        PoseDetail.gameObject.SetActive(false);
    }

    void PlayNormalGame()
    {

    }

    void PlayRandomGame()
    {
        MainMenu.gameObject.SetActive(false);
        Pose.gameObject.SetActive(true);
        List<PoseData> selectedPoses = RandomSelectPoses();
        Pose.SelectedPoses = selectedPoses;
        Pose.Play();
    }

    void PlayFiveFiveFiveGame()
    {
        
    }

    List<PoseData> RandomSelectPoses()
    {
        List<PoseData> selectedPoses = new List<PoseData>();
        List<PoseData> allPoses = new List<PoseData>(Database.Poses);
        int iterator = 0;
        for(int i = 0; i < 6; i++)
        {
            iterator = Random.Range(0, allPoses.Count-1);
            selectedPoses.Add(allPoses[iterator]);
            allPoses.RemoveAt(iterator);
        }
        return selectedPoses;
    }

    void OnGameOver()
    {
        Pose.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }
}

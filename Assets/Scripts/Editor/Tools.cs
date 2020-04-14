using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tools : MonoBehaviour
{
    [MenuItem("Tools/GeneratePoseData")]
    static void GeneratePoseData()
    {
        string[] poses = AssetDatabase.FindAssets("t:PoseData");
        foreach(string guid in poses)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            string name = Path.GetFileNameWithoutExtension(path);
            string nameLowCase = name.ToLower();
            PoseData data = AssetDatabase.LoadAssetAtPath<PoseData>(path);
            Sprite caged = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Poses/" + nameLowCase + "_caged.png");
            Sprite free = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Poses/" + nameLowCase + "_free.png");
            Sprite player = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Poses/" + nameLowCase + "_player.png");
            Sprite leader = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Poses/" + nameLowCase + "_leader.png");
            Sprite details = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Poses/" + nameLowCase + "_details.png");
            data.AnimalCaged = caged;
            data.AnimalFree = free;
            data.PlayerCard = player;
            data.LeaderCard = leader;
            data.Detail = details;
            data.Name = name;
            Debug.Log(name);
        }
        AssetDatabase.SaveAssets();
    }
}

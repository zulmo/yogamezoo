using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PoseData")]
public class PoseData : ScriptableObject
{
    public Sprite AnimalCaged;
    public Sprite AnimalFree;
    public Sprite PlayerCard;
    public Sprite LeaderCard;
    public Sprite Detail;
    public string Name = "Empty";
    public int Timer = 10;
}

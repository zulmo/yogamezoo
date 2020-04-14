using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameDatabase")]
public class GameDatabase : ScriptableObject
{
    public List<PoseData> Poses;
}

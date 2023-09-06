using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "LevelScriptableObject", order = 0)]
public class LevelScriptableObject : ScriptableObject
{

    [Header("Settings")]
    public Road[] roads;
}

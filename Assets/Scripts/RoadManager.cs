using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] LevelScriptableObject[] levels;
    [SerializeField] Transform roadParent;

    LevelManager levelManager;
    Vector3 chunkPosition = Vector3.zero;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        CreateLevel();

    }


    void Update()
    {

    }

    private void CreateLevel()
    {
        LevelScriptableObject level = levels[levelManager.GetLevel() - 1];

        for (int i = 0; i < level.roads.Length; i++)
        {
            if (i > 0)
            {
                chunkPosition.z += level.roads[i].returnZ() / 2;
            }

            var roadInstance = Instantiate(level.roads[i], chunkPosition,
             Quaternion.identity, roadParent);

             chunkPosition.z += level.roads[i].returnZ() / 2;
        }
    }
}

using UnityEngine;
using TMPro;

public class CrowdCounter : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Transform runnersParent;
    [SerializeField] TextMeshPro crowdCounterText;

    void Start()
    {
        UpdateCrowdText();
    }

    public void UpdateCrowdText()
    {
        crowdCounterText.text = runnersParent.childCount.ToString();
    }
}

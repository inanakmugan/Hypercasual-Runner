using UnityEngine;
using TMPro;

public class CrowdCounter : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] Transform runnersParent;
    [SerializeField] TextMeshPro crowdCounterText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateCrowdText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateCrowdText()
    {
        crowdCounterText.text = runnersParent.childCount.ToString();
    }
}

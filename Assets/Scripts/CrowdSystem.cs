using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] float radius;
    [SerializeField] float angle;
    [SerializeField] Transform runnersParent;
    [SerializeField] GameObject runnerPrefab;

    CrowdCounter crowdCounter;

    void Start()
    {
        crowdCounter = GetComponent<CrowdCounter>();
    }


    void Update()
    {
        PlaceRunners();
    }

    private void PlaceRunners()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            Vector3 childLocalPosition = GetRunnerLocation(i);
            runnersParent.GetChild(i).localPosition = childLocalPosition;
        }
    }

    private Vector3 GetRunnerLocation(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x, 0, z);
    }

    public float ReturnCrowdRadius()
    {
        return radius * Mathf.Sqrt(runnersParent.childCount);
    }

    //finds correct bonus with a switch case statament
    public void ApplyBonus(BonusType bonusType, int bonusAmount)
    {
        switch (bonusType)
        {
            case BonusType.addition:
                AddRunners(bonusAmount);
                break;
            case BonusType.subtraction:
                RemoveRunners(bonusAmount);
                break;
            case BonusType.division:
                int runnersAfterDivision = runnersParent.childCount - (runnersParent.childCount / bonusAmount);
                RemoveRunners(runnersAfterDivision);
                break;

            case BonusType.multiplication:
                int runnersAfterMultip = (runnersParent.childCount * bonusAmount) - runnersParent.childCount;
                AddRunners(runnersAfterMultip);
                break;
        }
    }

    private void AddRunners(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(runnerPrefab, runnersParent);
        }
        crowdCounter.UpdateCrowdText();
    }

    private void RemoveRunners(int amount)
    {
        if (amount > runnersParent.childCount)
        {
            amount = runnersParent.childCount;
        }

        int runnersAmount = runnersParent.childCount;

        for (int i = runnersAmount - 1; i >= runnersAmount - amount; i--)
        {
            Transform runnersToDestroy = runnersParent.GetChild(i);
            runnersToDestroy.SetParent(null);

            Destroy(runnersToDestroy.gameObject);
        }
        crowdCounter.UpdateCrowdText();
    }
}

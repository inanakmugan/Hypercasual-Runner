using UnityEngine;
using TMPro;

public enum BonusType { addition, subtraction, multiplication, division }
public class Door : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] TextMeshPro rightDoorText;
    [SerializeField] TextMeshPro leftDoorText;
    [SerializeField] SpriteRenderer rightDoorRenderer;
    [SerializeField] SpriteRenderer leftDoorRenderer;
    [SerializeField] Collider collider;

    [Header("Settings")]
    [SerializeField] BonusType rightDoorBonusType;
    [SerializeField] int rightDoorBonusAmount;
    [SerializeField] BonusType leftDoorBonusType;
    [SerializeField] int leftDoorBonusAmount;
    [SerializeField] Color penaltyColor;
    [SerializeField] Color awardColor;




    void Start()
    {
        ConfigureDoor();
    }

    private void ConfigureDoor()
    {
        switch (rightDoorBonusType)
        {
            case BonusType.addition:
                rightDoorRenderer.color = awardColor;
                rightDoorText.text = "+ " + rightDoorBonusAmount.ToString();
                break;
            case BonusType.multiplication:
                rightDoorRenderer.color = awardColor;
                rightDoorText.text = "x " + rightDoorBonusAmount.ToString();
                break;
            case BonusType.subtraction:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "- " + rightDoorBonusAmount.ToString();
                break;
            case BonusType.division:
                rightDoorRenderer.color = penaltyColor;
                rightDoorText.text = "/ " + rightDoorBonusAmount.ToString();
                break;
        }

        switch (leftDoorBonusType)
        {
            case BonusType.addition:
                leftDoorRenderer.color = awardColor;
                leftDoorText.text = "+ " + leftDoorBonusAmount.ToString();
                break;
            case BonusType.multiplication:
                leftDoorRenderer.color = awardColor;
                leftDoorText.text = "* " + leftDoorBonusAmount.ToString();
                break;
            case BonusType.subtraction:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "- " + leftDoorBonusAmount.ToString();
                break;
            case BonusType.division:
                leftDoorRenderer.color = penaltyColor;
                leftDoorText.text = "/ " + leftDoorBonusAmount.ToString();
                break;
        }
    }

    public BonusType ReturnDoorSide(float positionx)
    {
        if (positionx > 0)
        {
            return rightDoorBonusType;
        }
        else
        {
            return leftDoorBonusType;
        }
    }

    public int ReturnBonusAmount(float positionx)
    {
        if (positionx > 0)
        {
            return rightDoorBonusAmount;
        }
        else
        {
            return leftDoorBonusAmount;
        }
    }

    public void Disable()
    {
        collider.enabled = false;
    }

}

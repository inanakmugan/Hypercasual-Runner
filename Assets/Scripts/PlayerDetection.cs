using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    CrowdSystem crowdSystem;
    GameManager gameManager;


    void Start()
    {
        crowdSystem = FindObjectOfType<CrowdSystem>();
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        DetectDoors();
    }

    //not used 
    /* void OnCollisionEnter(Collision other)
    {
        GameObject collision = other.gameObject;
        if (collision.CompareTag("Door"))
        {
            Door door = collision.GetComponent<Door>();
            BonusType bonusType = door.ReturnDoorSide(transform.position.x);
            int bonusAmount = door.ReturnBonusAmount(transform.position.x);

            Debug.Log(bonusType.ToString() + " " + bonusAmount.ToString());
        }
    }
    */

    private void DetectDoors()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, 1);

        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].TryGetComponent(out Door door))
            {
                BonusType bonusType = door.ReturnDoorSide(transform.position.x);
                int bonusAmount = door.ReturnBonusAmount(transform.position.x);

                door.Disable();

                crowdSystem.ApplyBonus(bonusType, bonusAmount);
            }
            if (detectedColliders[i].tag == "Finish")
            {
                gameManager.Finish();
            }

            if (detectedColliders[i].tag == "Obstacle")
            {

            }
        }
    }

}

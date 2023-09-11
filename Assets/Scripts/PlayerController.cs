using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] float moveSpeed;
    [SerializeField] float slideSpeed;
    [SerializeField] float roadWidth = 10f;

    [Header("Elements")]
    [SerializeField] CrowdSystem crowdSystem;

    Vector3 clickedScreenPosition;
    Vector3 clickedPlayerPosition;


    void Update()
    {
        Move();

        SideControl();

    }

    private void Move()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    public void Stop()
    {
        moveSpeed = 0;
    }


    private void SideControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedPlayerPosition = transform.position;
            clickedScreenPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            float xScreenDiference = Input.mousePosition.x - clickedScreenPosition.x;

            xScreenDiference /= Screen.width;
            xScreenDiference *= slideSpeed;

            Vector3 position = transform.position;
            position.x = clickedPlayerPosition.x + xScreenDiference;

            position.x = Mathf.Clamp(position.x, -roadWidth / 2 + crowdSystem.ReturnCrowdRadius(),
                roadWidth / 2 - crowdSystem.ReturnCrowdRadius());

            transform.position = position;

        }
    }
}

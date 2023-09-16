using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] Canvas finishCanvas;
    PlayerAnimation[] playerAnimations;
    PlayerController playerController;

    bool isFinished = false;

    enum GameState { menu, game, success, gameover }

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void Finish()
    {
        if (isFinished) { return; }
        playerAnimations = FindObjectsOfType<PlayerAnimation>();
        finishCanvas.gameObject.SetActive(true);
        playerController.Stop();
        for (int i = 0; i < playerAnimations.Length; i++)
        {
            playerAnimations[i].StopRunning();
        }

        isFinished = true;

    }


}

using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartRunning();
    }

    private void StartRunning()
    {
        animator.SetBool("Run", true);
    }

    public void StopRunning()
    {
        animator.SetBool("Run", false);
    }
}

using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartRunning();
    }


    void Update()
    {

    }

    private void StartRunning()
    {
        animator.SetBool("Run", true);
    }
}

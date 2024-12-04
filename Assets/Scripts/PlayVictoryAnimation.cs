using UnityEngine;

public class PlayVictoryAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Victory");
    }
}

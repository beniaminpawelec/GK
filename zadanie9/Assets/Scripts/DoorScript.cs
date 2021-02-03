using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject door;
    private Animator animator;

    void Start()
    {
        animator = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isOpen", true);
        animator.SetTrigger("trigger");
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("isOpen", false);
        animator.SetTrigger("trigger");
    }
}
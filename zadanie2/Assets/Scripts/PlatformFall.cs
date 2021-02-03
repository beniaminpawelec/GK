using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    public float FallDelay = 1f;
    private Rigidbody2D Rb2d;

    void Awake()
    {
        Rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", FallDelay);
        }
    }

    void Fall()
    {
        Rb2d.isKinematic = false;
    }
}

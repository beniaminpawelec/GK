using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationScript : MonoBehaviour
{
    public KeyCode KeyToAnimateStart;
    public GameObject Player;
    private Animator _animator;

    private static readonly int IsMovingDown 
        = Animator.StringToHash("IsMovingDown");

    // Start is called before the first frame update
    void Start()
    {
        _animator = Player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
          _animator.
              SetBool(
                  IsMovingDown,
                  Input.GetKey(KeyToAnimateStart)
                  );
    }
}

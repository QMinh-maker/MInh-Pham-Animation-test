using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonStrike : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Strike();
        }
    }

    void Strike()
    {
        animator.SetTrigger("Strike");
    }
}

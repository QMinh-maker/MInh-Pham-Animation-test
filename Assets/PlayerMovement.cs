using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public CharacterController2D controller;
    
    public Animator animator;
    //private const HorizontalWrapMo

    float HorizontalMove = 0f;
    public float runSpeed = 40f;

    bool jump = false;
    bool crouch = false;
    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));


        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool IsCrouching)
    {
        animator.SetBool("IsCrouching", IsCrouching);
    }


     void FixedUpdate()
    {
        controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch,jump);
        jump = false;

    }
}

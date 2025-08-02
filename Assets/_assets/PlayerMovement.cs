using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // === Constants ===
    private const string Input_Horizontal = "Horizontal";
    private const string Input_Jump = "Jump";
    private const string Input_Crouch = "Crouch";

    private const string Animator_Speed = "Speed";
    private const string Animator_IsJumping = "IsJumping";
    private const string Animator_IsCrouching = "IsCrouching";

    // === Public fields ===
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;

    // === Private fields ===
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;

    void Update()
    {
        // Horizontal movement
        horizontalMove = Input.GetAxisRaw(Input_Horizontal) * runSpeed;
        animator.SetFloat(Animator_Speed, Mathf.Abs(horizontalMove));

        // Jump
        if (Input.GetButtonDown(Input_Jump))
        {
            jump = true;
            animator.SetBool(Animator_IsJumping, true);
        }

        // Crouch
        if (Input.GetButtonDown(Input_Crouch))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp(Input_Crouch))
        {
            crouch = false;
        }

        //OnCrouching(crouch);
    }

    public void OnLanding()
    {
        animator.SetBool(Animator_IsJumping, false);
    }

    public void OnCrouching(bool IsCrouching)
    {
        animator.SetBool(Animator_IsCrouching, IsCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}

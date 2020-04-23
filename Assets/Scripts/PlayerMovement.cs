using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

    public static bool isEnableMove = true;

    // Update is called once per frame
    void Update()
	{
		if (isEnableMove) {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            // Update speed parm in charcter animator.
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump")) {
                jump = true;

                // Update jump parm in charcter animator.
                animator.SetBool("IsJumping", true);
            }

            if (Input.GetButtonDown("Crouch")) {
                crouch = true;
            } else if (Input.GetButtonUp("Crouch")) {
                crouch = false;
            }
        }
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	// Event func will call from from character contoller OnEvent.
	public void OnLanding()
    {

		// Update jump parm in charcter animator.
		animator.SetBool("IsJumping", false);
	}

	// Event func will call from from character contoller OnEvent.
	public void OnCrouching(bool IsCrouching)
	{

		// Update jump parm in charcter animator.
		animator.SetBool("IsCrouching", IsCrouching);
	}
}

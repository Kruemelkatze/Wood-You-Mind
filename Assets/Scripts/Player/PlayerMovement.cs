using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	private Animator anim;
	
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	void Start()
	{
		anim = GetComponent<Animator>();
		Hub.Register(this);
	}
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			AudioControl.Instance.PlayRandomSound("jump");
		}
		
		if (Input.GetButtonDown("Fire1"))
		{
			anim.SetBool("isDoedel", true) ;
			AudioControl.Instance.PlayRandomSound("doedel");
		}
		else if (Input.GetButtonUp("Fire1"))
		{
			anim.SetBool("isDoedel", false) ;
		}
		
		// anims
		if (horizontalMove > -0.01 && horizontalMove < 0.01)
		{
			anim.SetBool("isIdle", true) ;
			anim.SetBool("isRunning", false) ;
		}
		else
		{
			anim.SetBool("isIdle", false);
			anim.SetBool("isRunning", true);
		}

//		if (Input.GetButtonDown("Crouch"))
//		{
//			crouch = true;
//		} else if (Input.GetButtonUp("Crouch"))
//		{
//			crouch = false;
//		}

	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	public bool IsDoedel()
	{
		return anim.GetBool("isDoedel");
	}
}

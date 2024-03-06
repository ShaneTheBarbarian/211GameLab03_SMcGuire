using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController3D : MonoBehaviour
{
	[SerializeField] private Animator animator;
	[SerializeField] private float walkPower;
	[SerializeField] private float walkSpeedMax = 1f;
	[SerializeField] private float aniSpeedMax = 1f;

	private float facing = 1;
    private float facingforward = 1;
    private float walkSpeed = 1f;
    private float aniSpeed = 0f;

	public CharacterController characterController;
	

	private void Update()
	{
		float input = (Input.GetAxisRaw("Horizontal"));
		float Forward = (Input.GetAxisRaw("Vertical"));

		if (input != 0 || Forward !=0)
        {
			walkSpeed += Time.deltaTime;
        }
        else
        {
			walkSpeed = 0;
        }
		if(walkSpeed == 0)
		{
			animator.SetInteger("State", 0);
        }
        else
        {
			if(Input.GetKey(KeyCode.LeftShift))
            {
				animator.SetInteger("State", 2);

			}
            else
            {
				animator.SetInteger("State", 1);

			}
		}

        facing = input;

        if (facing < 0)
        {
			transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 270f, 0f), Time.deltaTime * 4f);
		}
        else if (facing > 0)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 90f, 0f), Time.deltaTime * 4f);
		}

        transform.position += new Vector3(input * walkSpeed * Time.deltaTime, 0f);

        animator.SetFloat("MoveSpeed", Mathf.Abs(input));

		facingforward = Forward;

        if (facingforward < 0)
		{
			transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 180f, 0f), Time.deltaTime * 4f);
		}
		else if (facingforward > 0)
		{
			transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 0f, 0f), Time.deltaTime * 4f);
		}

		transform.position += new Vector3(input * walkSpeed * Time.deltaTime, 0f);

		animator.SetFloat("MoveSpeed", Mathf.Abs(input));


		Vector3 move = new Vector3(Input.GetAxis("Horizontal")*3, 0, Input.GetAxis("Vertical")*3);

		characterController.Move(move * Time.deltaTime * walkSpeed);

	}
}
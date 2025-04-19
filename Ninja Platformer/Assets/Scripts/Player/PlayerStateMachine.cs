using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStateMachine : StateMachine
{
	public Rigidbody2D RigidBody2D;
	public Animator Animator;
	public GameObject Ninja;

	public float speed;
	public float jumpForce = 10f;
	public float jumpAngle = 50f;
	public bool isJumping = false;
	public float jumpControlLockTime = 0.5f;


	public Transform playerDirection; // use this to get the facing direction

	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask groundLayer;




	private void Start()
	{
		RigidBody2D = GetComponent<Rigidbody2D>();
		Animator = GetComponentInChildren<Animator>();
		SwitchState(new PlayerBaseState(this));
	}
}

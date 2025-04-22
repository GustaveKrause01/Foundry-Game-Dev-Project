using System;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using Util;

public class PlayerStateMachine : StateMachine
{

	[field: SerializeField]
	public MeleeData MeleeData { get; private set; }

	public AnimationHashProvider AnimationHashProvider { get; private set; }

	public Rigidbody2D RigidBody2D;
	public Animator Animator;
	public GameObject Ninja;

	public float speed;
	public float jumpForce = 10f;
	public float jumpAngle = 50f;
	public float jumpControlLockTime = 0.5f;
	
	public Transform playerDirection; // use this to get the facing direction

	[field:SerializeField]
	public PlayerInput PlayerInput { get; private set; }

	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask groundLayer;

	private PlayerStates playerStates;

	private void Start()
	{
		RigidBody2D = GetComponent<Rigidbody2D>();
		Animator = GetComponentInChildren<Animator>();
		AnimationHashProvider = new AnimationHashProvider();
		BaseState();
	}

	private void BaseState()
	{
		playerStates = PlayerStates.Base;
		SwitchState(new PlayerBaseState(this));
	}

	private void JumpState()
	{
		playerStates = PlayerStates.Jump;
		SwitchState(new PlayerJumpState(this));
	}

	private void KatanaAttackState()
	{
		
	}

	private void KickAttackState()
	{
		
	}

	private void GrappleState()
	{
		
	}

	private void KunaiState()
	{
		
	}

	private void RageState()
	{
		
	}

	private void RegisterSubscriptions()
	{
		PlayerInput.Jump += JumpState;
		PlayerInput.Jump += JumpState;
	}

	private void UnregisterSubscriptions()
	{
		PlayerInput.Jump -= JumpState;
	}
}

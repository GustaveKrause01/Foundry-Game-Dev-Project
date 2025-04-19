using UnityEngine;

public class PlayerBaseState : State
{
	private PlayerStateMachine playerStateMachine;

	public PlayerBaseState(PlayerStateMachine playerStateMachine)
	{
		this.playerStateMachine = playerStateMachine;
	}

	private float controlLockTimer = 0f;
	private bool isGrounded;
	private float vx;
	private float vy;

	public override void Enter()
	{
	}

	public override void Tick(float deltaTime)
	{
		var horizontal = PlayerInput.Instance.Movement.x;
		var vertical = PlayerInput.Instance.Movement.y;

		// Determine direction (-1 for left, 1 for right)
		float direction = playerStateMachine.playerDirection.localScale.x >= 0 ? 1f : -1f;

		// Convert angle to radians
		float radians = playerStateMachine.jumpAngle * Mathf.Deg2Rad;

		// Calculate launch velocity components
		vx = Mathf.Cos(radians) * playerStateMachine.jumpForce * direction;
		vy = Mathf.Sin(radians) * playerStateMachine.jumpForce;

		isGrounded = Physics2D.OverlapCircle(playerStateMachine.groundCheck.position, playerStateMachine.groundRadius, playerStateMachine.groundLayer);

		if (horizontal != 0)
		{
			playerStateMachine.Animator.SetBool("Runing", true);
		}
		else
		{
			playerStateMachine.Animator.SetBool("Runing", false);
		}
		if (horizontal < 0)
		{
			playerStateMachine.Ninja.transform.localScale = new Vector2(-1.5f, 1.5f);
			Debug.Log("Left");
		}
		else if (horizontal > 0)
		{
			playerStateMachine.Ninja.transform.localScale = new Vector2(1.5f, 1.5f);
			Debug.Log("Right");
		}

		if (playerStateMachine.isJumping)
		{
			controlLockTimer -= deltaTime;
			if (controlLockTimer <= 0f)
			{
				playerStateMachine.isJumping = false; // regain control
				//OnDrawGizmosSelected();
			}
		}

		if (isGrounded)
		{
			playerStateMachine.Animator.SetBool("Jumping", false);
		}
		else if (!isGrounded && playerStateMachine.isJumping || !isGrounded && !playerStateMachine.isJumping)
		{
			playerStateMachine.Animator.SetBool("Jumping", true);
		}

		if (!playerStateMachine.isJumping && isGrounded)
		{

			playerStateMachine.RigidBody2D.linearVelocity = new Vector2(horizontal * playerStateMachine.speed, playerStateMachine.RigidBody2D.linearVelocity.y);

		}
		else if (!playerStateMachine.isJumping && !isGrounded)
		{
			playerStateMachine.Animator.SetBool("Jumping", true);
			playerStateMachine.RigidBody2D.linearVelocity = (new Vector2(horizontal + (vx / 6) * playerStateMachine.speed, playerStateMachine.RigidBody2D.linearVelocity.y));
		}
	}

	public override void Exit()
	{
	}

	public override void RegisterEvent()
	{
		PlayerInput.Instance.Jump += Jump;
	}

	public override void UnregisterEvent()
	{
		PlayerInput.Instance.Jump -= Jump;
	}

	private void Jump()
	{
		if (isGrounded && !playerStateMachine.isJumping)
		{
			PerformArcJump();
		}
	}

	void PerformArcJump()
	{
		playerStateMachine.isJumping = true;
		playerStateMachine.Animator.SetBool("Jumping", true);

		controlLockTimer = playerStateMachine.jumpControlLockTime;

		// Apply velocity
		playerStateMachine.RigidBody2D.linearVelocity = new Vector2(vx * 1.1f, vy);
	}
}

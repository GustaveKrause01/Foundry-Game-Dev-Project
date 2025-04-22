using UnityEngine;
using Util;

public class PlayerBaseState : State
{
    private PlayerStateMachine playerStateMachine;

    private bool isJumping;
    private float controlLockTimer = 0.5f;
    private bool isGrounded;
    private float vx;
    private float vy;
    private Vector2 baseScale;

    private int JumpHash;
    private int RunHash;
    private int movementInputHash;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
        JumpHash = playerStateMachine.AnimationHashProvider.GetAnimationHash(AnimationHashProvider.AnimationHash.Jump);
        RunHash = playerStateMachine.AnimationHashProvider.GetAnimationHash(AnimationHashProvider.AnimationHash.Run);

        this.baseScale = new Vector2(1.5f, 1.5f);
    }

    public override void Enter()
    {
        CalculateJumpVelocity();
        SetAnimation(RunHash, 0.1f);
    }
    
    public override void Tick(float deltaTime)
    {
        var horizontal = playerStateMachine.PlayerInput.Movement.x;
        
        isGrounded = Physics2D.OverlapCircle(
            playerStateMachine.groundCheck.position, 
            playerStateMachine.groundRadius, 
            playerStateMachine.groundLayer);

        if (horizontal != 0)
        {
            playerStateMachine.Animator.SetFloat("Blend", 1, 0.2f, deltaTime);
        }

        playerStateMachine.Ninja.transform.localScale =
            horizontal < 0 ? new Vector2(-baseScale.x, baseScale.y) : baseScale;

        if (isJumping)
        {
            controlLockTimer -= deltaTime;
            if (controlLockTimer <= 0f)
            {
                isJumping = false;
            }
        }
        
        if (!isJumping && isGrounded)
        {
            playerStateMachine.RigidBody2D.linearVelocity = new Vector2(
                horizontal * playerStateMachine.speed, 
                playerStateMachine.RigidBody2D.linearVelocity.y);
        }
        else if (!isJumping && !isGrounded)
        {
            float airControl = horizontal * playerStateMachine.speed * 0.8f;
            float momentumComponent = vx / 6f;
            
            playerStateMachine.RigidBody2D.linearVelocity = new Vector2(
                airControl + momentumComponent, 
                playerStateMachine.RigidBody2D.linearVelocity.y);
        }
    }

    public override void Exit()
    {
    }

    public override void RegisterEvent()
    {
        playerStateMachine.PlayerInput.Jump += StartJump;
    }

    public override void UnregisterEvent()
    {
        playerStateMachine.PlayerInput.Jump -= StartJump;
    }

    private void StartJump()
    {
        if (isGrounded)
        {
            CalculateJumpVelocity();
            PerformArcJump();
        }

        isJumping = true;
    }

    private void CalculateJumpVelocity()
    {
        float direction = playerStateMachine.playerDirection.localScale.x >= 0 ? 1f : -1f;
        float radians = playerStateMachine.jumpAngle * Mathf.Deg2Rad;
        
        vx = Mathf.Cos(radians) * playerStateMachine.jumpForce * direction;
        vy = Mathf.Sin(radians) * playerStateMachine.jumpForce;
    }

    void PerformArcJump()
    {
        playerStateMachine.Animator.CrossFadeInFixedTime(JumpHash, 0.1f);
        controlLockTimer = playerStateMachine.jumpControlLockTime;
        playerStateMachine.RigidBody2D.linearVelocity = new Vector2(vx * 1.1f, vy);
    }

    protected void SetAnimation(int animation, float duration)
    {
        playerStateMachine.Animator.CrossFadeInFixedTime(animation, duration);
    }
}
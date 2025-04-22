
public class PlayerInAirState: State
{
	private PlayerStateMachine playerStateMachine;

	public PlayerInAirState(PlayerStateMachine playerStateMachine)
	{
		this.playerStateMachine = playerStateMachine;
	}

	public override void Enter()
	{
		
	}

	public override void Tick(float deltaTime)
	{
		
	}

	public override void Exit()
	{
		
	}

	public override void RegisterEvent()
	{
		playerStateMachine.PlayerInput.Attack += Attack;
	}

	public override void UnregisterEvent()
	{
		playerStateMachine.PlayerInput.Attack -= Attack;
	}

	private void Attack()
	{
		//Enter Attack
	}
}
namespace Player
{
	public class PlayerJumpState: State
	{
		private PlayerStateMachine playerStateMachine;

		public PlayerJumpState(PlayerStateMachine playerStateMachine)
		{
			this.playerStateMachine = playerStateMachine;
		}

		public override void Enter()
		{
			throw new System.NotImplementedException();
		}

		public override void Tick(float deltaTime)
		{
			throw new System.NotImplementedException();
		}

		public override void Exit()
		{
			throw new System.NotImplementedException();
		}

		public override void RegisterEvent()
		{
			throw new System.NotImplementedException();
		}

		public override void UnregisterEvent()
		{
			throw new System.NotImplementedException();
		}
	}
}
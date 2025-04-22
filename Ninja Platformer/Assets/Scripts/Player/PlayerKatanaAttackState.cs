using System;
using Util;

public class PlayerKatanaAttackState : PlayerBaseState
{
	private PlayerStateMachine playerStateMachine;

	private readonly int currentAttackHash;

	private readonly PlayerInput playerInput;
	public readonly Attack attack;

	private bool alreadyAppliedForce;
	private AnimationHashProvider.AnimationHash animationHash;

	public PlayerKatanaAttackState(PlayerStateMachine playerStateMachine, int attackIndex) : base(playerStateMachine)
	{
		this.playerStateMachine = playerStateMachine;
		attack            = playerStateMachine.MeleeData.Attacks[attackIndex];
		playerInput       = playerStateMachine.PlayerInput;
		currentAttackHash = GetAnimationHash(attackIndex);
	}

	private int GetAnimationHash(int comboIndex)
	{
		return 0;
		/*AnimationHashProvider.AnimationHash attack;
		switch (comboIndex)
		{
			case 0:
				attack        = AnimationHashProvider.AnimationHash.LightAttackOne;
				animationHash = AnimationHashProvider.AnimationHash.LightImpactOne;
				return playerStateMachine.AnimationHashProvider.GetAnimationHash(attack);
			case 1:
				attack        = AnimationHashProvider.AnimationHash.LightAttackTwo;
				animationHash = AnimationHashProvider.AnimationHash.LightImpactTwo;
				return playerStateMachine.AnimationHashProvider.GetAnimationHash(attack);
			case 2:
				attack        = AnimationHashProvider.AnimationHash.LightAttackThree;
				animationHash = AnimationHashProvider.AnimationHash.LightImpactThree;
				return playerStateMachine.AnimationHashProvider.GetAnimationHash(attack);
			default:
				throw new IndexOutOfRangeException();
		}*/
	}
}

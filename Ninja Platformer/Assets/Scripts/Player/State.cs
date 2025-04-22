using UnityEngine;

public abstract class State
{
	public abstract void Enter();
	public abstract void Tick(float deltaTime);
	public abstract void Exit();
	public abstract void RegisterEvent();
	public abstract void UnregisterEvent();

	/*protected float GetNormalizedTime(Animator animator)
	{
		var currentInfo = animator.GetCurrentAnimatorStateInfo(0);
		var nextInfo = animator.GetNextAnimatorStateInfo(0);

		if (animator.IsInTransition(0) && nextInfo.IsTag("Attack"))
		{
			return nextInfo.normalizedTime;
		}
		if(!animator.IsInTransition(0) && currentInfo.IsTag("Attack"))
		{
			return currentInfo.normalizedTime;
		}

		return 0;
	}

	protected float GetSingleAnimationTime(Animator animator)
	{
		var currentInfo = animator.GetCurrentAnimatorStateInfo(0);
		var nextInfo    = animator.GetNextAnimatorStateInfo(0);

		if (animator.IsInTransition(0) && nextInfo.IsTag("HeavyAttack"))
		{
			return nextInfo.normalizedTime;
		}
		if(!animator.IsInTransition(0) && currentInfo.IsTag("HeavyAttack"))
		{
			return currentInfo.normalizedTime;
		}

		return 0f;
	}*/
}
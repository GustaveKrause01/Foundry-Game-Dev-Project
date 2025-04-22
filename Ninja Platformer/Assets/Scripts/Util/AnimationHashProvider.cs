using System;
using UnityEngine;

namespace Util
{
	public class AnimationHashProvider
	{
		public enum AnimationHash
		{
			Run,
			Jump,
			MovementInput
		}

		private readonly int run = Animator.StringToHash("Movement");
		private readonly int Jump = Animator.StringToHash("NinjaJump2");
		private readonly int movementInput = Animator.StringToHash("RunValue");

		public int GetAnimationHash(AnimationHash animationAction)
		{
			switch (animationAction)
			{
				case AnimationHash.Run:
					return run;
				case AnimationHash.Jump:
					return Jump;
				case AnimationHash.MovementInput:
					return movementInput;
				default:
					throw new ArgumentOutOfRangeException("Animation has not been added to the list");
			}
		}
	}
}
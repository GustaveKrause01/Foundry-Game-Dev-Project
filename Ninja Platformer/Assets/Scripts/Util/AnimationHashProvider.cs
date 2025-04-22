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

		private readonly int runHash = Animator.StringToHash("Run");
		private readonly int jumpHash = Animator.StringToHash("Jump");
		private readonly int runValueHash = Animator.StringToHash("RunValue");

		public int GetAnimationHash(AnimationHash animationAction)
		{
			switch (animationAction)
			{
				case AnimationHash.Run:
					return runHash;
				case AnimationHash.Jump:
					return jumpHash;
				case AnimationHash.MovementInput:
					return runValueHash;
				default:
					throw new ArgumentOutOfRangeException("Animation has not been added to the list");
			}
		}
	}
}
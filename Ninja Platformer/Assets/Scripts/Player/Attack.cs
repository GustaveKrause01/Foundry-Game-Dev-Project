using UnityEngine;

public class Attack
{
	public AudioClip SwingSound;
	public AudioClip ImpactSound;

	public float Damage { get; private set; } = 5f;
	public float TransitionDuration { get; private set; }
	public int ComboStateIndex { get; private set; } = -1;
	[Tooltip("How long the attack should last before transitioning/ending")]
	public float ComboAttackTime { get; private set; } = 0.5f;
}
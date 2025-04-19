using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
	public State CurrentState { get; private set; }

	protected virtual void Update()
	{
		CurrentState?.Tick(Time.deltaTime);
	}

	public void SwitchState(State newState)
	{
		CurrentState?.UnregisterEvent();
		CurrentState?.Exit();
		CurrentState = newState;
		CurrentState?.RegisterEvent();
		CurrentState?.Enter();
	}
}
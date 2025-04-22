using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
	public Vector2 Movement { get; private set; }
	public Action Jump { get; set; }
	public Action Attack { get; set; }
	

	private InputSystem_Actions inputActions;

	private void Awake()
	{
		inputActions = new InputSystem_Actions();
		inputActions.Player.SetCallbacks(this);
	}

	private void OnEnable()
	{
		inputActions.Player.Enable();
	}

	private void OnDisable()
	{
		inputActions.Player.Disable();
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		Movement = context.ReadValue<Vector2>();
	}

	public void OnLook(InputAction.CallbackContext context)
	{
		//Look = context.ReadValue<Vector2>();
	}

	public void OnAttack(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			Attack?.Invoke();
		}
	}

	public void OnInteract(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			Debug.Log("Interact performed");
		}
	}

	public void OnCrouch(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			Debug.Log("Crouch performed");
		}
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			Jump?.Invoke();
		}
	}

	public void OnPrevious(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			Debug.Log("Previous performed");
		}
	}

	public void OnNext(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			Debug.Log("Next performed");
		}
	}

	public void OnSprint(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			Debug.Log("Sprint performed");
		}
	}
}
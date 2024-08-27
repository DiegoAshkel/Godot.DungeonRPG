using Godot;
using System;

namespace Dungeon_RPG;

public partial class StateMachine : Node
{
	[Export]
	public Node[] AvailableStates { get; private set; }

	[Export]
	public Node CurrentState { get; private set; }

	public override void _Ready()
	{
		CurrentState.Notification(GameConstants.NOTIFICATION_ENTER_STATE);
	}

	public void SwitchState<T>()
	{
		if (CurrentState is T)
			return;

		Node newState = null;

		foreach (var state in AvailableStates)
		{
			if (state is T)
			{
				newState = state;
			}
		}

		if (newState == null)
			return;

		CurrentState.Notification(GameConstants.NOTIFICATION_EXIT_STATE);
		CurrentState = newState;
		CurrentState.Notification(GameConstants.NOTIFICATION_ENTER_STATE);
	}
}



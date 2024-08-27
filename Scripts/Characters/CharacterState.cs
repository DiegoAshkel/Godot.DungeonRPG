using Godot;
using System;

namespace Dungeon_RPG;

public abstract partial class CharacterState : Node
{
	protected Character _owner;

	public override void _Ready()
	{
		SetProcessInput(false);
		SetPhysicsProcess(false);
	}

	public override void _Notification(int what)
	{
		base._Notification(what);

		switch (what)
		{
			case GameConstants.NOTIFICATION_EXIT_STATE:
				SetProcessInput(false);
				SetPhysicsProcess(false);
				ExitState();
				break;
			case GameConstants.NOTIFICATION_ENTER_STATE:
				EnterState();
				SetProcessInput(true);
				SetPhysicsProcess(true);
				break;
		}
	}

	protected virtual void EnterState() { }
	protected virtual void ExitState() { }
}

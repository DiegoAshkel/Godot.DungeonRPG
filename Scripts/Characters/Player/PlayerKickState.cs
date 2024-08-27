using Dungeon_RPG;
using Godot;
using System;

namespace Dungeon_RPG;

public partial class PlayerKickState : PlayerState
{
	[Export]
	private Timer _timer;

	public override void _PhysicsProcess(double delta)
	{
	}

	protected override void EnterState()
	{
		_owner.AnimationPlayer.Play(GameConstants.ANIMATION_KICK);
		_timer?.Start();
	}

	private void HandleTimer()
	{
		_owner.StateMachine.SwitchState<PlayerIdleState>();
	}
}


using Dungeon_RPG;
using Godot;
using System;

namespace Dungeon_RPG;

public partial class PlayerAttackState : PlayerState
{
	[Export]
	private Timer _timer;

	protected override void EnterState()
	{
		_owner.AnimationPlayer.Play(GameConstants.ANIMATION_ATTACK);
		_timer?.Start();
	}

	private void HandleTimer()
	{
		_owner.StateMachine.SwitchState<PlayerIdleState>();
	}
}



using Dungeon_RPG;
using Godot;
using System;

namespace Dungeon_RPG;

public partial class EnemyIdleState : EnemyState
{
	public override void _PhysicsProcess(double delta)
	{
		_owner.StateMachine.SwitchState<EnemyReturnState>();
	}

	protected override void EnterState()
	{
		_owner.AnimationPlayer.Play(GameConstants.ANIMATION_IDLE);

		_owner.ChaseArea.BodyEntered += HandleChaseAreaBodyEntered;
		_owner.ChaseArea.BodyExited += HandleChaseAreaBodyExited;
	}

	protected override void ExitState()
	{
		_owner.ChaseArea.BodyEntered -= HandleChaseAreaBodyEntered;
		_owner.ChaseArea.BodyExited -= HandleChaseAreaBodyExited;
	}
}

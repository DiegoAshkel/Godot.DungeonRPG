using Godot;
using System;

namespace Dungeon_RPG;

public partial class EnemyChaseState : EnemyState
{
	public override void _PhysicsProcess(double delta)
	{
		if (_owner.Target != null)
		{
			_destination = _owner.Target.GlobalPosition;
			_owner.NavigationAgent.TargetPosition = _destination;

			Move(delta);
		}
	}

	protected override void EnterState()
	{
		_owner.AnimationPlayer.Play(GameConstants.ANIMATION_MOVE);

		_owner.ChaseArea.BodyExited += HandleChaseAreaBodyExited;
	}

	protected override void ExitState()
	{
		_owner.ChaseArea.BodyExited -= HandleChaseAreaBodyExited;
	}

}

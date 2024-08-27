using Dungeon_RPG;
using Godot;
using System;

namespace Dungeon_RPG;

public partial class EnemyReturnState : EnemyState
{
	public override void _Ready()
	{
		base._Ready();

		_destination = GetPathPointPosition(0);
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_owner.NavigationAgent.IsNavigationFinished())
		{
			_owner.StateMachine.SwitchState<EnemyPatrolState>();
			return;
		}

		Move(delta);
	}

	protected override void EnterState()
	{
		_owner.AnimationPlayer.Play(GameConstants.ANIMATION_MOVE);
		_owner.NavigationAgent.TargetPosition = _destination;

		// _owner.ChaseArea.BodyEntered += HandleChaseAreaBodyEntered;
		// _owner.ChaseArea.BodyExited += HandleChaseAreaBodyExited;
	}

	protected override void ExitState()
	{
		// _owner.ChaseArea.BodyEntered -= HandleChaseAreaBodyEntered;
		// _owner.ChaseArea.BodyExited -= HandleChaseAreaBodyExited;
	}
}

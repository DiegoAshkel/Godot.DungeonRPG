using Godot;
using System;

namespace Dungeon_RPG;

public abstract partial class EnemyState : CharacterState
{
	protected Vector3 _destination;

	public override void _Ready()
	{
		base._Ready();

		_owner = GetOwner<Enemy>();
	}

	public void Move(double delta)
	{
		Vector3 position = _owner.NavigationAgent.GetNextPathPosition();
		Vector3 velocity = _owner.GlobalPosition.DirectionTo(position);

		// Add the gravity.
		if (!_owner.IsOnFloor())
			velocity.Y -= _owner.Gravity * (float)delta;

		_owner.Velocity = velocity;

		_owner.MoveAndSlide();
		_owner.Flip();
	}

	protected Vector3 GetPathPointPosition(int index)
	{
		Vector3 globalPos = _owner.Path.GlobalPosition;
		Vector3 localPos = _owner.Path.Curve.GetPointPosition(index);
		return globalPos + localPos;
	}

	protected void HandleChaseAreaBodyEntered(Node3D body)
	{
		if (body is CharacterBody3D)
		{
			_owner.Target = body as Character;
		}

		_owner.StateMachine.SwitchState<EnemyChaseState>();
	}

	protected void HandleChaseAreaBodyExited(Node3D body)
	{
		if (_owner.Target != null)
		{
			_owner.Target = null;
		}

		_owner.StateMachine.SwitchState<EnemyPatrolState>();
	}
}

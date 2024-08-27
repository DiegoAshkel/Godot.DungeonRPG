using Godot;
using System;

namespace Dungeon_RPG;

public partial class PlayerIdleState : PlayerState
{
	public override void _PhysicsProcess(double delta)
	{
		if (_owner.Direction != Vector2.Zero)
		{
			_owner.StateMachine.SwitchState<PlayerMoveState>();
			return;
		}

		Vector3 velocity = Vector3.Zero;

		// Add the gravity.
		if (!_owner.IsOnFloor())
			velocity.Y -= _owner.Gravity;

		_owner.Velocity = velocity;

		_owner.MoveAndSlide();
	}

	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
		{
			_owner.StateMachine.SwitchState<PlayerDashState>();
		}
		else if (Input.IsActionJustPressed(GameConstants.INPUT_KICK))
		{
			_owner.StateMachine.SwitchState<PlayerKickState>();
		}
		else if (Input.IsActionJustPressed(GameConstants.INPUT_ATTACK))
		{
			_owner.StateMachine.SwitchState<PlayerAttackState>();
		}
	}

	protected override void EnterState()
	{
		_owner.AnimationPlayer.Play(GameConstants.ANIMATION_IDLE);
	}
}


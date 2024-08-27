using Godot;
using System;

namespace Dungeon_RPG;

public partial class PlayerMoveState : PlayerState
{

	[Export(PropertyHint.Range, "0,20,0.1")]
	public float MoveSpeed { get; private set; } = 5.0f;

	public override void _PhysicsProcess(double delta)
	{
		if (_owner.Direction == Vector2.Zero)
		{
			_owner.StateMachine.SwitchState<PlayerIdleState>();
			return;
		}

		Vector3 velocity = (_owner.Transform.Basis * new Vector3(_owner.Direction.X, 0, _owner.Direction.Y)).Normalized();
		velocity *= MoveSpeed;

		// Add the gravity.
		if (!_owner.IsOnFloor())
			velocity.Y -= _owner.Gravity;

		_owner.Velocity = velocity;

		_owner.MoveAndSlide();
		_owner.Flip();
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
		_owner.AnimationPlayer.Play(GameConstants.ANIMATION_MOVE);
	}
}


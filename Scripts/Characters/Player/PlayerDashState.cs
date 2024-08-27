using Godot;
using System;

namespace Dungeon_RPG;

public partial class PlayerDashState : PlayerState
{
	[Export]
	private Timer _timer;

	[Export(PropertyHint.Range, "0,20,0.1")]
	public float DashSpeed { get; private set; } = 10.0f;

	public override void _PhysicsProcess(double delta)
	{
		if (_owner.Velocity == Vector3.Zero)
			return;

		Vector3 velocity = _owner.Velocity;

		// Add the gravity.
		if (!_owner.IsOnFloor())
			velocity.Y -= _owner.Gravity;

		_owner.Velocity = velocity;

		_owner.MoveAndSlide();
		_owner.Flip();
	}

	protected override void EnterState()
	{
		Vector3 velocity = new(_owner.Direction.X, 0, _owner.Direction.Y);

		if (velocity == Vector3.Zero)
			velocity = _owner.Sprite.FlipH ? Vector3.Left : Vector3.Right;

		velocity *= DashSpeed;

		_owner.Velocity = velocity;

		_owner.AnimationPlayer.Play(GameConstants.ANIMATION_DASH);
		_timer?.Start();
	}

	private void HandleTimer()
	{
		_owner.Velocity = Vector3.Zero;
		_owner.StateMachine.SwitchState<PlayerIdleState>();
	}
}


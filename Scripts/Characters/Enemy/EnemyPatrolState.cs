using Godot;
using System;

namespace Dungeon_RPG;

public partial class EnemyPatrolState : EnemyState
{
	[Export]
	private Timer _idleTimer;

	[Export(PropertyHint.Range, "0.5,20,0.1")]
	private float _maxIdleTimer = 4f;

	private int _pathPoint = 0;

	public override void _Ready()
	{
		base._Ready();

		_idleTimer.Timeout += HandleIdleTimer;
	}

	public override void _PhysicsProcess(double delta)
	{
		if (!_idleTimer.IsStopped())
			return;

		Move(delta);
	}

	protected override void EnterState()
	{
		_owner.AnimationPlayer.Play(GameConstants.ANIMATION_MOVE);

		_pathPoint = 0;

		_destination = GetPathPointPosition(_pathPoint);
		_owner.NavigationAgent.TargetPosition = _destination;

		_owner.NavigationAgent.NavigationFinished += HandleNavigationFinished;
		_owner.ChaseArea.BodyEntered += HandleChaseAreaBodyEntered;
		_owner.ChaseArea.BodyExited += HandleChaseAreaBodyExited;
	}

	protected override void ExitState()
	{
		_owner.NavigationAgent.NavigationFinished -= HandleNavigationFinished;
		_owner.ChaseArea.BodyEntered -= HandleChaseAreaBodyEntered;
		_owner.ChaseArea.BodyExited -= HandleChaseAreaBodyExited;
	}

	private void HandleNavigationFinished()
	{
		RandomNumberGenerator rng = new();

		_idleTimer.WaitTime = rng.RandfRange(0.1f, _maxIdleTimer);
		_idleTimer.Start();

		_owner.AnimationPlayer.Play(GameConstants.ANIMATION_IDLE);
	}

	private void HandleIdleTimer()
	{
		_owner.AnimationPlayer.Play(GameConstants.ANIMATION_MOVE);

		_pathPoint = Mathf.PosMod(_pathPoint + 1, _owner.Path.Curve.PointCount);

		_destination = GetPathPointPosition(_pathPoint);
		_owner.NavigationAgent.TargetPosition = _destination;
	}
}

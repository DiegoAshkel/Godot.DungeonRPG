using Godot;
using System;

namespace Dungeon_RPG;

public partial class PlayerCamera : Camera3D
{
	[Export]
	public Vector3 StartPosition { get; private set; }

	[Export]
	public Vector3 StartRotation { get; private set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Reset();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionJustPressed(GameConstants.INPUT_CAMERA_RESET))
		{
			Reset();
		}

		float mouseWheel = Input.GetAxis(GameConstants.INPUT_CAMERA_ZOOMIN, GameConstants.INPUT_CAMERA_ZOOMOUT);
		if (mouseWheel != 0)
		{

		}
	}

	private void Reset()
	{
		Position = StartPosition;
		RotationDegrees = StartRotation;
	}
}

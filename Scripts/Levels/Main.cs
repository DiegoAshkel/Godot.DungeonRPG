using Godot;
using System;

namespace Dungeon_RPG;

public partial class Main : Node3D
{
	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Hidden;
	}

	public override void _Input(InputEvent @event)
	{
	}

	public override void _PhysicsProcess(double delta)
	{
	}

	public override void _Process(double delta)
	{
	}
}



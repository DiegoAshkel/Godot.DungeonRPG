using Godot;
using System;
using System.Collections.Generic;

namespace Dungeon_RPG;

public partial class Player : Character
{
	public override void _Input(InputEvent @event)
	{
		Direction = Input.GetVector(
			GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT,
			GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_BACKWARD);
	}
}



using Godot;
using System;

namespace Dungeon_RPG;

public abstract partial class PlayerState : CharacterState
{
	public override void _Ready()
	{
		base._Ready();

		_owner = GetOwner<Player>();
	}
}


using Dungeon_RPG;
using Godot;
using System;

namespace Dungeon_RPG;

public partial class PlayerDeadState : PlayerState
{
	protected override void EnterState()
	{
		_owner.AnimationPlayer.Play(GameConstants.ANIMATION_DEAD);
	}
}

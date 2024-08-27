using Godot;
using System;
using System.Collections.Generic;

namespace Dungeon_RPG;

/// <summary>
/// The CharacterAction enum is a fundamental component of the game animation project,
/// providing a set of distinct actions that a character can perform.
/// Each enum value corresponds to a specific character action,
/// facilitating efficient animation control and state management within the game.
/// </summary>
public enum CharacterAction
{
	/// <summary>
	/// Represents an undefined or unrecognized character action.
	/// This value is set as a default or placeholder when the character's action is not explicitly identified.
	/// </summary>
	Unknown = -1,
	/// <summary>
	/// Character is in a stationary position, not engaged in any particular action.
	/// </summary>
	Idle,
	/// <summary>
	/// Character executes an offensive action, such as kicking a enemy.
	/// </summary>
	Kick,
	/// <summary>
	/// Character is in motion, simulating running or sprinting.
	/// </summary>
	Run,
	/// <summary>
	/// Character executes an offensive action, such as swinging a weapon.
	/// </summary>
	Slash,
	/// <summary>
	/// Character performs a quick, short burst of movement in a specific direction.
	/// </summary>
	Slide,
	/// <summary>
	/// Character is in the process of dying or undergoing a defeat animation.
	/// </summary>
	Dead,
}

/// <summary>
/// The Character class is a key component of the game animation project,
/// responsible for managing the behavior, animations, and actions of the in-game character.
/// This class extends the CharacterBody3D class and encompasses various properties and
/// methods to handle character movements, actions, and animations.
/// </summary>
public abstract partial class Character : CharacterBody3D
{
	[ExportGroup("Required Nodes")]
	[Export(PropertyHint.NodeType)]
	public AnimationPlayer AnimationPlayer { get; protected set; }

	[Export(PropertyHint.NodeType)]
	public Sprite3D Sprite { get; protected set; }

	[Export(PropertyHint.NodeType)]
	public StateMachine StateMachine { get; protected set; }

	[ExportGroup("AI Nodes")]
	[Export(PropertyHint.NodeType)]
	public Path3D Path { get; protected set; }

	[Export(PropertyHint.NodeType)]
	public NavigationAgent3D NavigationAgent { get; protected set; }

	[Export(PropertyHint.NodeType)]
	public Area3D ChaseArea { get; protected set; }

	public Character Target { get; set; }

	public Vector2 Direction { get; protected set; } = new();

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float Gravity => _gravity;
	private float _gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public void Flip()
	{
		bool isNotMovingHorizontally = Velocity.X == 0;
		if (isNotMovingHorizontally)
		{
			return;
		}

		bool isMovingLeft = Velocity.X < 0.0f;
		Sprite.FlipH = isMovingLeft;
	}
}


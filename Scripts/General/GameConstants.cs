using System;

namespace Dungeon_RPG;

public partial class GameConstants
{
	#region Animations

	public const string ANIMATION_IDLE = "Idle";
	public const string ANIMATION_KICK = "Kick";
	public const string ANIMATION_MOVE = "Move";
	public const string ANIMATION_ATTACK = "Attack";
	public const string ANIMATION_DASH = "Dash";
	public const string ANIMATION_TAKEHIT = "TakeHit";
	public const string ANIMATION_DEAD = "Dead";

	#endregion


	#region Inputs

	public const string INPUT_MOVE_FORWARD = "MoveForward";
	public const string INPUT_MOVE_BACKWARD = "MoveBackward";
	public const string INPUT_MOVE_LEFT = "MoveLeft";
	public const string INPUT_MOVE_RIGHT = "MoveRight";
	public const string INPUT_DASH = "Dash";
	public const string INPUT_KICK = "Kick";
	public const string INPUT_ATTACK = "Attack";
	public const string INPUT_CAMERA_RESET = "CameraReset";
	public const string INPUT_CAMERA_ZOOMIN = "CameraZoomIn";
	public const string INPUT_CAMERA_ZOOMOUT = "CameraZoomOut";

	#endregion


	#region Notifications

	public const int NOTIFICATION_EXIT_STATE = 5000;
	public const int NOTIFICATION_ENTER_STATE = 5001;

	#endregion
}


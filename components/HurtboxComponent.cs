using Godot;
using System;

[GlobalClass]
public partial class HurtboxComponent : Area2D
{
	[Signal]
	public delegate void HurtEventHandler(HitboxComponent hitbox);

	private bool _isInvicible = false;
	public bool isInvicible
	{
		get { return _isInvicible; }
		set
		{
			_isInvicible = value; // Here, 'value' refers to the input parameter when setting the property.
			
			// Disable any collisions shapes on this hurtbox when it is invincible
			// And reenable them when it isn't invincible
			foreach (var child in GetChildren())
			{
				if (child.GetType() != typeof(CollisionShape2D) && child.GetType() != typeof(CollisionPolygon2D))
				{
					continue;
				}
				
				child.SetDeferred("disabled", _isInvicible);
			}
		}
	}
}

using Godot;
using System;

[GlobalClass]
public partial class HitboxComponent : Area2D
{
	[Export]
	public float damage = 1.0f;
	
	[Signal]
	public delegate void HitHurtboxEventHandler(HurtboxComponent hurtbox);
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Connect on area entered to our hurtbox entered function.
		this.AreaEntered += onHurtboxEntered;
	}
	
	public void onHurtboxEntered(Area2D hurtbox)
	{
		HurtboxComponent _hurtbox = (HurtboxComponent)hurtbox;
		
		// Make sure the hurtbox isn't invincible.
		if (_hurtbox.isInvicible)
		{
			return;
		}
		// Signal out that we hit a hurtbox (this is useful for destroying projectiles when they hit something).
		EmitSignal(nameof(HitHurtbox), _hurtbox);
		// Have the hurtbox signal out that it was hit.
		_hurtbox.EmitSignal(nameof(HurtboxComponent.Hurt), this);
	}
}

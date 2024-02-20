using Godot;
using System;

[GlobalClass]
public partial class EffectComponent : Node
{
	[Export]
	public Material effectMaterial;
	
	[Export]
	public CanvasItem sprite;
	
	[Export]
	public float effectDuration = 0.2f;
	
	// Store the original sprite's material so we can reset it after the effect.
	private Material originalMaterial;
	
	// Create a timer for the flash component to use.
	private Timer timer = new Timer();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Add the timer as a child of this component in order to use it.
		AddChild(timer);
		
		// Store the original sprite material.
		originalMaterial = sprite.@Material;
	}

	public async void effectPlay()
	{
		// Set the sprite's material to the effect material.
		sprite.@Material = effectMaterial;
		
		// Start the timer (passing in the flash duration)
		timer.Start(effectDuration);
		
		// Wait until the timer times out.
		await ToSignal(timer, "timeout");
		
		// Set the sprite's material back to the original material.
		sprite.@Material = originalMaterial;
	}
}

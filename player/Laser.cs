using Godot;
using System;

public partial class Laser : Node2D
{
	private VisibleOnScreenNotifier2D notifier;
	private ScaleComponent scaler;
	private EffectComponent effectPlayer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		notifier = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
		scaler = GetNode<ScaleComponent>("ScaleComponent");
		effectPlayer = GetNode<EffectComponent>("EffectComponent");
		
		notifier.ScreenExited += () => QueueFree();
		scaler.tweenScale();
		effectPlayer.effectPlay();
	}
}

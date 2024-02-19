using Godot;
using System;

public enum EnemyType
{
	green = 0x1,
	yellow = 0x2,
	pink = 0x3
}

public partial class Enemy : Node2D
{
	[Export]
	public EnemyType type;
	
	private VisibleOnScreenNotifier2D notifier;
	private HurtboxComponent hurtbox;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		notifier = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
		hurtbox = GetNode<HurtboxComponent>("HurtboxComponent");
		
		notifier.ScreenExited += () => QueueFree();
		hurtbox.Hurt += (HitboxComponent hitbox) => QueueFree();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

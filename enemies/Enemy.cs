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
	[Export]
	private float health = 1.0f;
	
	private AnimatedSprite2D body;
	private VisibleOnScreenNotifier2D notifier;
	private HurtboxComponent hurtbox;
	private SpawnerComponent explosionSpawner;

	private PackedScene EXPLOSION_SCENE = ResourceLoader.Load<PackedScene>("res://enemies/explosion.tscn");
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		notifier = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
		hurtbox = GetNode<HurtboxComponent>("HurtboxComponent");
		explosionSpawner = GetNode<SpawnerComponent>("SpawnerComponent");
		body = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		
		notifier.ScreenExited += () => QueueFree();
		hurtbox.Hurt += (HitboxComponent hitbox) => {
			health -= hitbox.damage;
		};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (health <= 0f)
		{
			defeated();
		}
	}

	private void defeated()
	{
		body.Visible = false;
		explosionSpawner.setScene(EXPLOSION_SCENE);
		explosionSpawner.spawn(GlobalPosition);

		QueueFree();
	}
}

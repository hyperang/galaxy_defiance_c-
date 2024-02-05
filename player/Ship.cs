using Godot;
using System;

public partial class Ship : Node2D
{
	private Marker2D leftCannon;
	private Marker2D rightCannon;
	private SpawnerComponent spawner;
	private Timer fireRate;
	private ScaleComponent scaler;
	private MoveComponent moveComponent;
	private AnimatedSprite2D shipAnimatedSprite;
	private AnimatedSprite2D flameAnimatedSprite;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		leftCannon = GetNode<Marker2D>("LeftCannon");
		rightCannon = GetNode<Marker2D>("RightCannon");
		spawner = GetNode<SpawnerComponent>("SpawnerComponent");
		fireRate = GetNode<Timer>("FireRateTimer");
		scaler = GetNode<ScaleComponent>("ScaleComponent");
		moveComponent = GetNode<MoveComponent>("MoveComponent");
		shipAnimatedSprite = GetNode<AnimatedSprite2D>("Anchor/ShipAnimatedSprite");
		flameAnimatedSprite = GetNode<AnimatedSprite2D>("Anchor/FlameAnimatedSprite");
		
		fireRate.Timeout += () => fire();
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var moveState = moveComponent.getMoveState();
		if(moveState == MoveState.left)
		{
			shipAnimatedSprite.Play("left");
			flameAnimatedSprite.Play("left");
		}
		else if(moveState == MoveState.right)
		{
			shipAnimatedSprite.Play("right");
			flameAnimatedSprite.Play("right");
		}
		else
		{
			shipAnimatedSprite.Play("center");
			flameAnimatedSprite.Play("center");
		}
	}
	
	void fire()
	{
		spawner.spawn(leftCannon.GlobalPosition);
		spawner.spawn(rightCannon.GlobalPosition);
		scaler.tweenScale();
	}
}

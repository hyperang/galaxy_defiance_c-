using Godot;
using System;

public enum Type
{
	ship = 0x1,
	laser = 0x2
}

public enum MoveState
{
	hold = 0x1,
	left = 0x2,
	right = 0x3
}

[GlobalClass]
public partial class MoveComponent : Node
{
	private Vector2 velocity;
	
	[Export]
	public Node2D charactor;
	
	[Export]
	public MoveStates states;
	
	[Export]
	public Type charactorType = Type.ship;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		move(delta);
	}
	
	// Called when there is an input event.
	public override void _Input(InputEvent @event)
	{
	}
	
	private void move(double delta)
	{
		if(this.charactorType == Type.ship)
		{
			var inputAxis = Input.GetAxis("ui_left", "ui_right");
			this.velocity = new Vector2(inputAxis * states.speed, 0);
		}
		else
		{
			this.velocity = new Vector2(0, -1 * states.speed);
		}
		
		this.charactor.Translate(new Vector2(velocity.X * (float)delta, velocity.Y * (float)delta));
	}
	
	public MoveState getMoveState()
	{
		if(this.velocity.X < 0)
		{
			return MoveState.left;
		}
		else if(this.velocity.X > 0)
		{
			return MoveState.right;
		}
		else
		{
			return MoveState.hold;
		}
	}
}

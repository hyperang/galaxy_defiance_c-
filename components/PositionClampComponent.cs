using Godot;
using System;

[GlobalClass]
public partial class PositionClampComponent : Node
{
	[Export]
	public Node2D charactor;
	
	[Export]
	public int margin = 8;
	
	private int leftBorder = 0;
	private int rightBorder = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var gPos = this.charactor.GlobalPosition;
		Vector2 cPos = new Vector2(Mathf.Clamp(gPos.X, leftBorder + margin, rightBorder - margin), gPos.Y);
		this.charactor.GlobalPosition = cPos;
	}
}

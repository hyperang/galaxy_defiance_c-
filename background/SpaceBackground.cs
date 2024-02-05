using Godot;
using System;

public partial class SpaceBackground : ParallaxBackground
{
	private ParallaxLayer spaceLayer;
	private ParallaxLayer farStarsLayer;
	private ParallaxLayer closeStarsLayer;
	
	private int screenYAxisLength = (int)ProjectSettings.GetSetting("display/window/size/viewport_height");
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		spaceLayer = GetNode<ParallaxLayer>("SpaceLayer");
		farStarsLayer = GetNode<ParallaxLayer>("FarStarsLayer");
		closeStarsLayer = GetNode<ParallaxLayer>("CloseStarsLayer");
		
		spaceLayer.MotionMirroring = new Vector2(0, screenYAxisLength);
		farStarsLayer.MotionMirroring = new Vector2(0, screenYAxisLength);
		closeStarsLayer.MotionMirroring = new Vector2(0, screenYAxisLength);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		spaceLayer.MotionOffset += new Vector2(0f, 5f * (float)delta);
		farStarsLayer.MotionOffset += new Vector2(0f, 10f * (float)delta);
		closeStarsLayer.MotionOffset += new Vector2(0f, 20f * (float)delta);
	}
}

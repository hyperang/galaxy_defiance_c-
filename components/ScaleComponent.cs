using Godot;
using System;

[GlobalClass]
public partial class ScaleComponent : Node
{
	// Export the sprite that this component will be scaling.
	[Export]
	public Node2D sprite;
	
	// Export the scale amount (as a vector).
	[Export]
	public Vector2 scaleAmount = new Vector2(1.5f, 1.5f);
	
	// Export the scale duration.
	[Export]
	public float scaleDuration = 0.4f;
	
	// Scale the sprite using a tween.
	public void tweenScale()
	{
		// Create the tween and set it's transition type and easing type
		Tween tween = GetTree().CreateTween().SetTrans(Tween.TransitionType.Expo).SetEase(Tween.EaseType.Out);
		
		// Scale the sprite from its current scale to the scale amount (in 1/10th of the scale duration)
		tween.TweenProperty(this.sprite, "scale", scaleAmount, scaleDuration * 0.1).FromCurrent();
		// Scale back to a value of 1 for the other 9/10ths of the scale duration
		tween.TweenProperty(this.sprite, "scale", Vector2.One, scaleDuration * 0.9).From(scaleAmount);
	}
}

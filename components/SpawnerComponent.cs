using Godot;
using System;

[GlobalClass]
public partial class SpawnerComponent : Node
{
	// The scene we want to spawn.
	[Export]
	public PackedScene scene;
	
	private Node defaultParent;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		defaultParent = GetTree().CurrentScene;
	}
	
	// Spawn an instance of the scene at a specific global position on a parent.
	public Node spawn(Vector2 globalSpawnPosition, Node parent = null)
	{	
		//  Instance the scene.
		Node2D instance = (Node2D)scene.Instantiate();
		// Add it as a child of the parent.
		if(parent != null)
		{
			parent.AddChild(instance);
		}
		else
		{
			defaultParent.AddChild(instance);
		}
		// Update the global position of the instance(This must be done after adding it as a child).
		instance.GlobalPosition = globalSpawnPosition;
		// Return the instance in case we want to perform any other operations on it after instancing it.
		return instance;
	}
}

using Godot;
using System;

public partial class EnemyGenerator : Node2D
{
	private int margin = 8;
	private int screenWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");
	
	private Timer greenEnemySpawnTimer;
	private SpawnerComponent enemySpawner;
	
	private PackedScene GREEN_ENEMY_SCENE = ResourceLoader.Load<PackedScene>("res://enemies/green_enemy.tscn");
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		greenEnemySpawnTimer = GetNode<Timer>("GreenEnemySpawnTimer");
		enemySpawner = GetNode<SpawnerComponent>("SpawnerComponent");
		
		greenEnemySpawnTimer.Timeout += () => handleSpawn(GREEN_ENEMY_SCENE, greenEnemySpawnTimer);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void handleSpawn(PackedScene enemyScene, Timer timer)
	{
		var random = new RandomNumberGenerator();
		
		enemySpawner.setScene(enemyScene);
		enemySpawner.spawn(new Vector2(random.RandiRange(margin, screenWidth - margin), -14));
		timer.Start();
	}
}

using Godot;
using System;

public partial class LevelController : Node2D
{
    [Export] public TileMapLayer TileMap;
    [Export] public Player Player;

    public override void _Ready()
    {
        var global = GetNode<GameData>("/root/GameData");
        if (global != null && Player != null && !string.IsNullOrEmpty(global.TargetSpawnMarker)){
            var spawnPoint = GetNodeOrNull<Marker2D>(global.TargetSpawnMarker);
            Player.GlobalPosition = spawnPoint.GlobalPosition;
        }
    }
}

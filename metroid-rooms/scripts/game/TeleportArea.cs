using Godot;
using System;

public partial class TeleportArea : Area2D
{
    [Export] public string TargetScenePath;
    
    // Deixamos opcional! Se for a tela final, basta deixar esse campo EM BRANCO no Inspector
    [Export] public string TargetMarkerName; 

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is Player)
        {
            if (!string.IsNullOrEmpty(TargetScenePath))
            {
                var global = GetNode<GameData>("/root/GameData");
                if (global != null)
                {
                    //verificação de path: se tiver algo, vai p o marker; se tiver vazio, vai pra cena destino
                    global.TargetSpawnMarker = !string.IsNullOrEmpty(TargetMarkerName) ? TargetMarkerName : "";
                }

                CallDeferred(MethodName.DeferredChangeScene, TargetScenePath);
            }
        }
    }

    private void DeferredChangeScene(string path)
    {
        GetTree().ChangeSceneToFile(path);
    }
}
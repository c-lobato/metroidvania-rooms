using Godot;
using System;

public partial class TeleportArea : Area2D
{
    [Export] public string TargetScene;

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }
    private void OnBodyEntered(Node2D body)
    {
        // Confirma se quem entrou foi realmente o Player
        if (body is Player)
        {
            if (!string.IsNullOrEmpty(TargetScene))
            {                
                GetTree().ChangeSceneToFile(TargetScene);
            }
            else
            {
                GD.PushWarning($"Aviso: TargetScene não configurado no nó {Name}!");
            }
        }
    }
}

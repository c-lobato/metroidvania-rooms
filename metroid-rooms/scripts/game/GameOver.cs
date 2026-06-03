using Godot;
using System;

public partial class GameOver : Node
{
    [Export] public Button Restart;
    [Export] public Button Quit;

    public override void _Ready()
    {

        if(Restart != null) Restart.Pressed += OnRestartButtonPressed;
        if(Quit != null) Quit.Pressed += OnQuitButtonPressed;
    }

    private void OnRestartButtonPressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/game/rooms/Fase1.tscn");
    }

     private void OnQuitButtonPressed()
    {
        GetTree().Quit();
    }

}

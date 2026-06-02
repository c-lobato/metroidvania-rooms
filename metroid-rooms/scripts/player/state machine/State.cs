using Godot;
using System;

public abstract partial class State : Node
{
    [Export] public AudioStreamPlayer2D Audio;
    [Export] public Player Player;
    public StateMachine stateMachine;
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update(double delta);
    public abstract void PhysicsUpdate(double delta);
    public abstract void HandleInput(InputEvent inputEvent);

}

using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] public StateMachine stateMachine;
    [Export] public CollisionShape2D Hitbox;
    [Export] public Sprite2D Sprite;

    

}

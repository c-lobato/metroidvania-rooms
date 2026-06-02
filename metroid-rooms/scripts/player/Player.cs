using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] public StateMachine stateMachine;
    [Export] public CollisionShape2D Hitbox;
    [Export] public AnimatedSprite2D Anim;
    [Export] public float WalkSpeed = 200.0f;
	[Export] public float JumpSpeed = -150.0f;
	[Export] public float Gravity = 800.0f;
    public bool WasOnFloor = true;
    public int FacingDirection = 1;
    public bool lastSprite = false;

    public override void _PhysicsProcess(double delta)
	{
		
		WasOnFloor = IsOnFloor();

		FlipPlayer();
		if (Velocity.X != 0) { FacingDirection = Math.Sign(Velocity.X); }
	}

    public void FlipPlayer()
	{
		if (Velocity.X < 0)
		{
			lastSprite = true;
			Anim.FlipH = lastSprite;
		}
		else if(Velocity.X == 0)
			Anim.FlipH = lastSprite;
		else 
		{
			lastSprite = false;
			Anim.FlipH = lastSprite;
		}
    }
}



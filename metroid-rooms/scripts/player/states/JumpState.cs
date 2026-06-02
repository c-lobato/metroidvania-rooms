using Godot;
using System;

public partial class JumpState : State
{

    public override void Enter()
    {
        Player.Anim.Play("jump");
        var vel = Player.Velocity;
		vel.Y = Player.JumpSpeed;
		Player.Velocity = vel;
    }
    public override void Exit(){}
    public override void Update(double delta){}
    public override void PhysicsUpdate(double delta)
    {
        var vel = Player.Velocity;
		vel.Y += Player.Gravity * (float)delta;

		if (vel.Y > 0)
		{
			stateMachine.ChangeState("FallState");
		}

		var direction = Input.GetAxis("MoveLeft","MoveRight");
		vel.X = direction * Player.WalkSpeed;
		Player.Velocity = vel;
		Player.MoveAndSlide();

		if (Player.IsOnFloor())
		{
			if (direction == 0)
			{
				stateMachine.ChangeState("IdleState");
			}
			else
			{
				stateMachine.ChangeState("WalkState");
			}
		}
    }
    public override void HandleInput(InputEvent inputEvent)
    {
        
    }
}

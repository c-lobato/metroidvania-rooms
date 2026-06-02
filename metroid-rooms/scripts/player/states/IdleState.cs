using Godot;
using System;

public partial class IdleState : State
{
    public override void Enter()
    {
        Player.Anim.Play("idle"); 
    }
    public override void Exit(){}
    public override void Update(double delta){}

    public override void PhysicsUpdate(double delta)
    {
        
        var vel = Player.Velocity;
        vel.X = 0;
        vel.Y = 0;

        if (!Player.IsOnFloor())
        {
            stateMachine.ChangeState("FallState");
        }

        Player.Velocity = vel;
        Player.MoveAndSlide();
    }
    public override void HandleInput(InputEvent inputEvent)
    {
        if (Input.IsActionPressed("MoveLeft")||Input.IsActionPressed("MoveRight"))
		{
			stateMachine.ChangeState("WalkState");
		}

        if (Input.IsActionPressed("Jump"))
		{
			stateMachine.ChangeState("JumpState");
		}

    }
}

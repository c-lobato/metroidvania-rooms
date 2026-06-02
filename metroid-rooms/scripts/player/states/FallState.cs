using Godot;
using System;

public partial class FallState : State
{
    public override void Enter()
    {
        Player.Anim.Play("fall");
    }
    public override void Exit(){}
    public override void Update(double delta){}
    public override void PhysicsUpdate(double delta)
    {
        var vel = Player.Velocity;
        vel.Y += Player.Gravity * (float)delta;

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
       //como não é um projeto grande, não implementei outras movimentações
       //mas aqui poderiam ser aplicadas mecanicas de ataque, double jump e dash
    }
}

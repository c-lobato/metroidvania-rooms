using Godot;
using System;

public partial class WalkState : State
{
    public override void Enter()
    {
        Player.Anim.Play("walk");
    }
    public override void Exit(){}
    public override void Update(double delta){}
    public override void PhysicsUpdate(double delta)
    {
         if (!Player.IsOnFloor())
        {
            stateMachine.ChangeState("FallState"); //fall state nao tem input, cai no physics update
        } 

        var vel = Player.Velocity;
        var direction = Input.GetAxis("MoveLeft","MoveRight"); //verificação de direção

        if (direction == 0)
        {
            stateMachine.ChangeState("IdleState"); //se não houver movimento, vota pro estado idle (tb nao tem input, por isso está aqui)
        }

        vel.X = direction * Player.WalkSpeed;
        Player.Velocity = vel;
        Player.MoveAndSlide();
    }
    public override void HandleInput(InputEvent inputEvent)
    {
        if (Input.IsActionPressed("Jump"))
        {
            stateMachine.ChangeState("JumpState");
        }

    }

}

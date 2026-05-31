using Godot;
using System;

public partial class IdleState : State
{
    public override void Enter()
    {
        //Anim.Play("idle");
        
    }
    public override void Exit(){}
    public override void Update(double delta){}

    public override void PhysicsUpdate(double delta)
    {
        //instanciamento do player para acesso
        Player player = new Player();
        var vel = player.Velocity;
        vel.X = 0;
        vel.Y = 0;

        if (!player.IsOnFloor())
        {
            stateMachine.ChangeState("FallState");
        }

        player.Velocity = vel;
        player.MoveAndSlide();
    }
    public override void HandleInput(){}
}

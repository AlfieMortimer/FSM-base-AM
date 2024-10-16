
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Player
{
    public class RunningState : State
    {
        // constructor
        public RunningState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            if (player.grounded == true)
            {
                player.animator.Play("arthur_run", 0, 0);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            player.CheckForIdle();
            player.CheckForJump();
            player.CheckForCrouch();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            Vector2 vel = player.rb.velocity;
            vel.x = player._horizontalInput * player.speed;
            player.rb.velocity = vel;
        }
    }
}
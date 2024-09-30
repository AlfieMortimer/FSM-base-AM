
using UnityEngine;
namespace Player
{
    public class JumpState : State
    {
        // constructor
        public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
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
            player.CheckForIdle();
            Debug.Log("checking for Idle");
            player.CheckForJump();
            Debug.Log("checking for Jump");
            base.LogicUpdate();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
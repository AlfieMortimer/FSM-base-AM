using Unity.VisualScripting.FullSerializer;
using UnityEngine;
namespace Player
{

    public class CrouchState : State
    {
        // constructor
        public CrouchState(PlayerScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.animator.Play("arthur_crouch", 0, 0);
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
            player.CheckForJump();
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}

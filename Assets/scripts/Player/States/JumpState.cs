
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
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
            if (Mathf.Abs(player._horizontalInput) < Mathf.Epsilon)
            {
                player.animator.Play("arthur_jump_up", 0, 0);
            }
            else
            {
                player.animator.Play("arthur_jump_forward", 0, 0);
            }
            player.rb.AddForce(player.transform.up * player.jumpheight * 10, ForceMode2D.Impulse);

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
            if (player.grounded)
            {
                player.CheckForIdle();
                sm.ChangeState(player.runningState);
            }
            base.LogicUpdate();
            
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
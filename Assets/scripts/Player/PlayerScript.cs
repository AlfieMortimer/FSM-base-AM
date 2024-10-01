using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.VFX;

namespace Player
{


    public class PlayerScript : MonoBehaviour
    {
        public Rigidbody2D rb;
        public float speed;
        public float _horizontalInput;
        public bool grounded = false;
        public float jumpheight = 0;

        // variables holding the different player states
        public IdleState idleState;
        public RunningState runningState;
        public JumpState jumpState;
        public CrouchState crouchState;

        public StateMachine sm;
        public Animator animator;
        public SpriteRenderer sr;


        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sm = gameObject.AddComponent<StateMachine>();
            animator = GetComponent<Animator>();
            sr = GetComponent<SpriteRenderer>();



            // add new states here
            idleState = new IdleState(this, sm);
            runningState = new RunningState(this, sm);
            jumpState = new JumpState(this, sm);
            crouchState = new CrouchState(this, sm);

            // initialise the statemachine with the default state
            sm.Init(idleState);
        }

        // Update is called once per frame
        public void Update()
        {
            sm.CurrentState.LogicUpdate();

            //output debug info to the canvas
            string s;
            s = string.Format("last state={0}\ncurrent state={1}", sm.LastState, sm.CurrentState);

            UIscript.ui.DrawText(s);

            UIscript.ui.DrawText("Press I for idle / R for run / Space for Jump");

        }



        void FixedUpdate()
        {
            sm.CurrentState.PhysicsUpdate();
        }



        public void CheckForRun()
        {
            _horizontalInput = Input.GetAxis("Horizontal");

             if (_horizontalInput < 0) // key held down
             {
                 sm.ChangeState(runningState);
                 sr.flipX = true;
                 return;
             }
             else if (_horizontalInput > 0)
             {
                 sm.ChangeState(runningState);
                 sr.flipX = false;
                 return;
             }

        }


        public void CheckForIdle()
        {

            _horizontalInput = Input.GetAxis("Horizontal");
            if (rb.velocity.x == 0 && !Input.GetKey("s") && rb.velocity.y == 0)
            {
                sm.ChangeState(idleState);
            }
        }

        public void CheckForJump()
        {
            if (Input.GetKey(KeyCode.Space) && grounded == true && rb.velocity.y == 0) // key held down
            {
                sm.ChangeState(jumpState);
                return;
            }

        }

        public void CheckForCrouch()
        {
            if (Input.GetKey("s") && grounded == true)
            {
                sm.ChangeState(crouchState);
                return;
            }
        }





        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 7)
            {
                grounded = true;
            }

        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            grounded = false;
        }
    }    
}
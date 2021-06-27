using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CMF
{
    //This character movement input class is an example of how to get input from a keyboard to control the character;
    public class CharacterKeyboardInput : CharacterInput
    {

        public string horizontalInputAxis = "Horizontal";
        public string verticalInputAxis = "Vertical";
        public KeyCode jumpKey = KeyCode.Space;

        public InputActionAsset inputs;

        public float horizontalInput;
        public float verticalInput;
        public bool doJump = false;
        float jumpResetThreshold = 0.1f;
        float timer = 0f;
        //If this is enabled, Unity's internal input smoothing is bypassed;
        public bool useRawInput = true;


        private void Update()
        {
            if(doJump)
            {
                timer += Time.deltaTime;
            }
            if(timer >= jumpResetThreshold)
            {
                timer = 0f;
                doJump = false;
            }
        }
        public void OnJump(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                doJump = true;
            }
        }
        public void HorizontalMove(InputAction.CallbackContext ctx)
        {
            horizontalInput = ctx.ReadValue<float>();
        }
        public void VerticalMove(InputAction.CallbackContext ctx)
        {
            verticalInput = ctx.ReadValue<float>();
        }
        public override float GetHorizontalMovementInput()
        {
            return horizontalInput;
            // if (useRawInput)
            //     return Input.GetAxisRaw(horizontalInputAxis);
            // else
            //     return Input.GetAxis(horizontalInputAxis);
        }

        public override float GetVerticalMovementInput()
        {
            return verticalInput;
            // if (useRawInput)
            //     return Input.GetAxisRaw(verticalInputAxis);
            // else
            //     return Input.GetAxis(verticalInputAxis);
        }

        public override bool IsJumpKeyPressed()
        {
            return doJump;
        }
    }
}

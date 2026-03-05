using UnityEngine;
using UnityEngine.InputSystem;

namespace AstronautPlayer
{
    [RequireComponent(typeof(CharacterController))]
    public class AstronautPlayer : MonoBehaviour
    {
        private Animator animator;
        private CharacterController controller;

        [Header("Movement")]
        public float moveSpeed = 6.0f;
        public float turnSpeed = 400.0f;
        public float gravity = 20.0f;
        public float jumpPower = 10.0f;

        private Vector3 moveDirection;
        private float verticalVelocity;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            if (Keyboard.current == null) return;

            float vertical = GetVerticalInput();
            float horizontal = GetHorizontalInput();

            UpdateAnimation(vertical);
            HandleJump();
            Move(vertical, horizontal);
        }

        private float GetVerticalInput()
        {
            float value = 0f;
            if (Keyboard.current.wKey.isPressed) value += 1f;
            if (Keyboard.current.sKey.isPressed) value -= 1f;
            return value;
        }

        private float GetHorizontalInput()
        {
            float value = 0f;
            if (Keyboard.current.aKey.isPressed) value -= 1f;
            if (Keyboard.current.dKey.isPressed) value += 1f;
            return value;
        }

        private void UpdateAnimation(float vertical)
        {
            animator.SetInteger("AnimationPar", vertical != 0 ? 1 : 0);
        }

        private void HandleJump()
        {
            if (controller.isGrounded)
            {
                if (verticalVelocity < 0f)
                    verticalVelocity = -2f;

                if (Keyboard.current.spaceKey.wasPressedThisFrame)
                {
                    verticalVelocity = jumpPower;
                }
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }
        }

        private void Move(float vertical, float horizontal)
        {
            Vector3 move = transform.forward * vertical * moveSpeed;

            transform.Rotate(0f, horizontal * turnSpeed * Time.deltaTime, 0f);

            move.y = verticalVelocity;

            controller.Move(move * Time.deltaTime);
        }
    }
}
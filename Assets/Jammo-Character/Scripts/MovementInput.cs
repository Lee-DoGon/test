using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour
{
    [Header("Movement")]
    public float Velocity = 5f;
    public float desiredRotationSpeed = 0.1f;
    public float allowPlayerRotation = 0.1f;
    public bool blockRotationPlayer;

    [Header("Input Values")]
    public float InputX;
    public float InputZ;
    public float Speed;

    [Header("References")]
    public Animator anim;
    public Camera cam;
    public CharacterController controller;

    public Vector3 desiredMoveDirection;
    public bool isGrounded;

    [Header("Animation Smoothing")]
    [Range(0, 1f)] public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)] public float VerticalAnimTime = 0.2f;
    [Range(0, 1f)] public float StartAnimTime = 0.3f;
    [Range(0, 1f)] public float StopAnimTime = 0.15f;

    public float verticalVel;
    private Vector3 moveVector;

    private void Start()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Keyboard.current == null) return;

        InputMagnitude();

        isGrounded = controller.isGrounded;
        verticalVel = isGrounded ? 0f : verticalVel - 1f;

        moveVector = new Vector3(0f, verticalVel * 0.2f * Time.deltaTime, 0f);
        controller.Move(moveVector);
    }

    private void ReadMovementInput()
    {
        InputX = 0f;
        InputZ = 0f;

        if (Keyboard.current.aKey.isPressed) InputX -= 1f;
        if (Keyboard.current.dKey.isPressed) InputX += 1f;
        if (Keyboard.current.wKey.isPressed) InputZ += 1f;
        if (Keyboard.current.sKey.isPressed) InputZ -= 1f;
    }

    private void PlayerMoveAndRotation()
    {
        ReadMovementInput();

        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

        if (!blockRotationPlayer && desiredMoveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(desiredMoveDirection),
                desiredRotationSpeed
            );

            controller.Move(desiredMoveDirection * Velocity * Time.deltaTime);
        }
    }

    public void LookAt(Vector3 pos)
    {
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(pos),
            desiredRotationSpeed
        );
    }

    public void RotateToCamera(Transform t)
    {
        Vector3 forward = cam.transform.forward;
        forward.y = 0f;

        t.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(forward),
            desiredRotationSpeed
        );
    }

    private void InputMagnitude()
    {
        ReadMovementInput();

        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        if (Speed > allowPlayerRotation)
        {
            anim.SetFloat("Blend", Speed, StartAnimTime, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else
        {
            anim.SetFloat("Blend", Speed, StopAnimTime, Time.deltaTime);
        }
    }
}
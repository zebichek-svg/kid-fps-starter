using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;
    public float crouchSpeed = 2.5f;
    public float jumpHeight = 1.5f;
    public float gravity = -20f;

    [Header("Crouch")]
    public float crouchHeight = 1f;
    public float standHeight = 2f;

    [Header("References")]
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private bool isCrouching;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        if (controller == null)
        {
            Debug.LogError("CharacterController is missing from the Player object.");
            enabled = false;
            return;
        }

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main != null ? Camera.main.transform : null;
        }

        if (cameraTransform != null)
        {
            cameraTransform.SetParent(transform, false);
            cameraTransform.localPosition = new Vector3(0f, 0.8f, 0f);
        }

        controller.height = standHeight;
        controller.center = new Vector3(0f, standHeight / 2f, 0f);
    }

    private void Update()
    {
        if (controller == null)
        {
            return;
        }

        HandleMovement();
        HandleCrouch();
        ApplyGravity();
    }

    private void HandleMovement()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        if (move.magnitude > 1f)
        {
            move.Normalize();
        }

        float speed = walkSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }

        if (isCrouching)
        {
            speed = crouchSpeed;
        }

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void HandleCrouch()
    {
        bool desiredCrouch = Input.GetKey(KeyCode.LeftControl);

        if (desiredCrouch != isCrouching)
        {
            isCrouching = desiredCrouch;

            float targetHeight = isCrouching ? crouchHeight : standHeight;
            float targetCenterY = targetHeight / 2f;

            controller.height = Mathf.Lerp(controller.height, targetHeight, Time.deltaTime * 12f);
            controller.center = new Vector3(0f, targetCenterY, 0f);
        }
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

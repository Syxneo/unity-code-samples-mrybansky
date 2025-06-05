using UnityEngine;

public class PlayerGravityMovement : MonoBehaviour
{
    [SerializeField] float maxMoveSpeed = 10;
    [SerializeField] float rotationSpeed = 20.0f; 
    [SerializeField] Joystick joystick; 
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rigidbodyPlayer;
    [SerializeField] Transform characterTransform;

    private Vector3 moveDirection;
    private float currentRotationSpeed = 0.0f;

    private void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        float moveSpeed = maxMoveSpeed * Mathf.Max(Mathf.Abs(horizontalInput), Mathf.Abs(verticalInput));

        moveDirection = transform.TransformDirection(new Vector3(horizontalInput, 0, verticalInput));

        animator.SetFloat("moveSpeed", moveSpeed / 10);
    }

    private void FixedUpdate()
    {
        Vector3 movement = moveDirection * maxMoveSpeed * Time.deltaTime;
        rigidbodyPlayer.MovePosition(rigidbodyPlayer.position + movement);

        RotateCharacter();

    }

    private void RotateCharacter()
    {
        if (moveDirection.magnitude > 0.01f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -characterTransform.up, out hit))
            {
                Quaternion rotation = Quaternion.LookRotation(moveDirection, hit.normal);
                characterTransform.rotation = Quaternion.Slerp(characterTransform.rotation, rotation, currentRotationSpeed * Time.deltaTime);
                currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, rotationSpeed, 0.2f);
            }
        }
        else
        {
            currentRotationSpeed = 0.0f;
        }
    }
}





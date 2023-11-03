using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    Animator animator;
    public float moveSpeed = 20f;
    public float rotationSpeed = 60f;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        // Detect movement input from WASD keys
        if (Input.GetKey(KeyCode.W))
            verticalInput = 1f;

        if (Input.GetKey(KeyCode.S))
            verticalInput = -1f;

        if (Input.GetKey(KeyCode.A))
            horizontalInput = -1f;

        if (Input.GetKey(KeyCode.D))
            horizontalInput = 1f;


        // Check for walking animation
        animator.SetBool("isWalking", verticalInput != 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttacking = true;
            animator.SetBool("isAttacking", true);
            animator.SetBool("isWalking", false);
        }

        // Update the total movement
        Vector3 movement = transform.forward * verticalInput * moveSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, horizontalInput * Time.deltaTime * rotationSpeed, 0));
        if (!isAttacking)
            transform.Translate(movement, Space.World);

        if (isAttacking && !Input.GetKey(KeyCode.Space))
        {
            isAttacking = false;
            animator.SetBool("isAttacking", false);
        }
    }
}

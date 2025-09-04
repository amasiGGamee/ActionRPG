using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SlimeController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    public float stopDistance = 2f;
    public float rotationSpeed = 5f;

    [Header("References")]
    public Transform player;
    private Rigidbody rb;

    [Header("Ground Check")]
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.2f;

    private bool isGrounded;
    private Vector3 movementDirection;

    void Start()
    {
        // หา Player อัตโนมัติถ้ายังไม่ได้กำหนด
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogWarning("Player not found! Make sure there is a GameObject with tag 'Player'");
            }
        }

        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        CheckGround();

        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange && distanceToPlayer > stopDistance)
        {
            FollowPlayer();
        }
        else
        {
            StopMoving();
        }
    }

    void CheckGround()
    {
        // เพิ่ม offset เล็กน้อยเพื่อให้ raycast ไม่ชนตัวเอง
        isGrounded = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, groundCheckDistance + 0.1f, groundLayer);
    }

    void FollowPlayer()
    {
        movementDirection = (player.position - transform.position).normalized;
        movementDirection.y = 0;

        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (isGrounded)
        {
            Vector3 newVelocity = movementDirection * moveSpeed;
            newVelocity.y = rb.linearVelocity.y; // เก็บความเร็วแนวตั้งจาก gravity
            rb.linearVelocity = newVelocity;     // ใช้ linearVelocity แทน velocity
        }
    }

    void StopMoving()
    {
        rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, stopDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);

        if (player != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, player.position);
            Gizmos.DrawWireSphere(player.position, 0.5f);
        }

        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(transform.position, movementDirection * 2f);
    }
}

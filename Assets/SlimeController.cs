using UnityEngine;

public class SlimeController : MonoBehaviour
{
    // กำหนดค่าความเร็วในการเคลื่อนที่และแรงกระโดดใน Inspector
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private Animator animator;
    private Rigidbody rb;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // รับคอมโพเนนต์ Animator และ Rigidbody ที่ผูกอยู่กับ GameObject นี้
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1. การเคลื่อนที่และการควบคุมแอนิเมชันเดิน

        // รับค่า input จากปุ่ม A/D หรือลูกศรซ้าย/ขวา
        float horizontalInput = Input.GetAxis("Horizontal");

        // อัปเดตพารามิเตอร์ "Speed" ใน Animator
        // Mathf.Abs() ทำให้ค่าเป็นบวกเสมอ ไม่ว่าตัวละครจะเดินไปทางไหนก็ตาม
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // สร้าง Vector3 สำหรับการเคลื่อนที่ โดยใช้ค่า input ที่ได้รับ
        // Time.deltaTime ทำให้การเคลื่อนที่ราบรื่นไม่ขึ้นอยู่กับเฟรมเรทของเกม
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;

        // เปลี่ยนตำแหน่งของ GameObject ให้เคลื่อนที่ไปตามทิศทางที่คำนวณไว้
        transform.position += movement;

        // 2. การกระโดดและการควบคุมแอนิเมชันกระโดด

        // ตรวจสอบว่าผู้เล่นกด Spacebar และตัวละครอยู่บนพื้น
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // เรียก Trigger "Jump" ใน Animator เพื่อเริ่มแอนิเมชันกระโดด
            animator.SetTrigger("Jump");

            // ใช้ AddForce เพื่อเพิ่มแรงกระโดดในทิศทางขึ้น
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // ตั้งค่า isGrounded เป็น false เพื่อป้องกันการกระโดดกลางอากาศ
            isGrounded = false;
        }
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    void OnCollisionEnter(Collision collision)
    {
        // 3. การตรวจสอบว่าตัวละครอยู่บนพื้น

        // ตรวจสอบว่าวัตถุที่ชนมี Tag "Ground" หรือไม่
        // อย่าลืมเพิ่ม Tag "Ground" ให้กับพื้นในเกมของคุณ
        if (collision.gameObject.CompareTag("Ground"))
        {
            // ถ้าชนกับพื้น ให้ตั้งค่า isGrounded เป็น true เพื่อให้สามารถกระโดดได้อีกครั้ง
            isGrounded = true;
        }
    }
}
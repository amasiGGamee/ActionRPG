using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;
    public float damageAmount = 10f;

    [Header("UI References")]
    public Image healthBarFill;

    void Start()
    {
        // กำหนดค่าเริ่มต้นให้สุขภาพ
        currentHealth = maxHealth;

        // อัพเดท Health Bar เริ่มต้น
        UpdateHealthBar();
    }

    void OnCollisionEnter(Collision collision)
    {
        // ตรวจสอบว่าชนกับวัตถุที่มี tag "Dangerous"
        if (collision.gameObject.CompareTag("Dangerous"))
        {
            TakeDamage(damageAmount);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าชนกับวัตถุที่มี tag "Dangerous" (สำหรับ Trigger Collider)
        if (other.CompareTag("Dangerous"))
        {
            TakeDamage(damageAmount);
        }
    }

    void TakeDamage(float damage)
    {
        // ลดสุขภาพ
        currentHealth -= damage;

        // ตรวจสอบไม่ให้สุขภาพต่ำกว่า 0
        currentHealth = Mathf.Max(0, currentHealth);

        // อัพเดท Health Bar
        UpdateHealthBar();

        // ตรวจสอบว่าสุขภาพเป็น 0 หรือไม่
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        // อัพเดท Fill Amount ของ Image
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        // ทำลาย Player หรือจัดการเมื่อสุขภาพเป็น 0
        Debug.Log("Player died!");
        // Destroy(gameObject);
    }
}
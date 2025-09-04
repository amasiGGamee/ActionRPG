using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Character
{
    public string name;  // Attribute
    public int hp;

    public Character(string n)  // Constructor
    {
        this.name = n;
        //this.hp = hp;
    }
    public void ReceiveDamage(int damage) // Method
    {
        hp -= damage;
        if (hp < 0) hp = 0;
    }
}

public class Gameplay : MonoBehaviour
{
    TextMeshProUGUI playerName;
    Image hpBar;
    Character player;

    void Start()
    {
        // ใช้ field player โดยตรง ไม่สร้างตัวแปรใหม่
<<<<<<< HEAD
        player = new Character("PicoChan", 100);
=======
        player = new Character("PicoChan");
>>>>>>> 169a97871726cb23fee664638dbd855de4b18b99

        playerName = GameObject.Find("PlayerName").GetComponent<TextMeshProUGUI>();
        //hpBar = GameObject.Find("HP").GetComponent<Image>();

        playerName.text = player.name;
    }

<<<<<<< HEAD
    void Update()
    {
        // Cast int -> float เพื่อให้ได้ค่า 0.0 ถึง 1.0
        hpBar.fillAmount = (float)player.hp / 100f;
    }
    

=======
    //void Update()
    //{
    //    // Cast int -> float เพื่อให้ได้ค่า 0.0 ถึง 1.0
    //    hpBar.fillAmount = (float)player.hp / 100f;
    //}
>>>>>>> 169a97871726cb23fee664638dbd855de4b18b99
}

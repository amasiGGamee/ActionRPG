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
}

public class Gameplay : MonoBehaviour
{
    TextMeshProUGUI playerName;
    Image hpBar;
    Character player;

    void Start()
    {
        // �� field player �µç ������ҧ���������
        player = new Character("PicoChan");

        playerName = GameObject.Find("PlayerName").GetComponent<TextMeshProUGUI>();
        //hpBar = GameObject.Find("HP").GetComponent<Image>();

        playerName.text = player.name;
    }

    //void Update()
    //{
    //    // Cast int -> float ����������� 0.0 �֧ 1.0
    //    hpBar.fillAmount = (float)player.hp / 100f;
    //}
}

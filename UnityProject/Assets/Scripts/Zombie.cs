using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Zombie : MonoBehaviour
{
    [Header("血量")]
    public float hp = 50;
    private float getHurt;
    [Header("攻擊力")]
    public float atk = 0;
    [Header("喇叭")]
    public AudioSource aud;
    [Header("音效")]
    public AudioClip SoundAtk;

    [Header("玩家")]
    public Player player;

    [Header("")]
    public Transform traZombie;

    /// <summary>
    /// 攻擊
    /// </summary>
    public void Attack()
    {
        if (hp <= 0)
        {
            print("敵人行動不能，遊戲結束");
            return;
        }

        player.Hurt();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    public void Hurt()
    {
        if (hp <= 0)
        {
            Dead();
            return;
        }
        getHurt = Random.Range(10f, 15f);
        print("<color=red>" + "殭屍受到傷害: " + getHurt + "</color>");
        hp -= getHurt;
        print("<color=red>" + "殭屍剩下血量: " + hp + "</color>");

        if (hp <= 0) Dead();
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {
        traZombie.eulerAngles = new Vector3(-90, 0, 180);
        traZombie.position = new Vector3(0, 0.2f, 3.5f);
        print("<color=fuchsia>殭屍死了！殭屍死了！別再打了！</color>");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Attack();
        }
    }
}
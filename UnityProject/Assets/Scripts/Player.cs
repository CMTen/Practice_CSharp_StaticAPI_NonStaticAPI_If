using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [Header("血量")]
    public float hp = 100;
    private float getHurt;
    [Header("攻擊力")]
    public float atk = 0;
    [Header("喇叭")]
    public AudioSource aud;
    [Header("音效")]
    public AudioClip SoundAtk;

    // 參考
    [Header("殭屍")]
    public Zombie zombie;
    [Header("")]
    public Transform traPlayer;
    [Header("傷害延遲")]
    public float Delay;

    private Animator ani;

    private IEnumerator hurtDelay()
    {
        yield return new WaitForSeconds(Delay);

        zombie.aud.PlayOneShot(SoundAtk);
        getHurt = UnityEngine.Random.Range(20f, 30f);
        print("<color=blue>" + "玩家受到傷害: " + getHurt + "</color>");
        hp -= getHurt;
        print("<color=blue>" + "玩家剩下血量: " + hp + "</color>");

        if (hp <= 0) Dead();
    }

    public void Attack()
    {
        if (hp <= 0)
        {
            print("玩家行動不能，遊戲結束");
            return;
        }
        ani.SetTrigger("玩家攻擊");
        zombie.Hurt();
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

        StartCoroutine(hurtDelay());
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {
        print("<color=aqua>已消滅人類！</color>");
        traPlayer.eulerAngles = new Vector3(-90, 0, 0);
        traPlayer.position = new Vector3(0, 0.2f, 0.9f);
    }

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && zombie.hp > 0)
        {
            Attack();
        }
    }
}

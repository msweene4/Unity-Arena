using System.Collections;
using System.Collections.Generic;
//using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class SkaterAnimation : MonoBehaviour {
    Animator anim;
    public bool alive;
    public bool blocking;
    public SliderHealthBar HB;
    public SliderHealthBar myH;
    public Guy1Animations me;
    int damage;
    public Text message;
    public bool doneTurn;

    // Use this for initialization
    void Start()
    {
        doneTurn = true; ;
        blocking = false;
        alive = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        displayHealth();
        
	}

    void displayHealth()
    {
        if (HB.health <= 0 && alive)
        {
            HB.health = 0;
            die();
            HB.healthDisplay.text = "Enemy Wasted";
            StartCoroutine(MyDefeat());
        }
        else
            HB.healthDisplay.text = "Enemy Health: " + HB.health + "/100";
    }

    public void attack()
    {
        if (PlayerPrefs.GetInt("Defense") > 15)
        {
            damage = 1;
        }
        else
            damage = Random.Range(5, 26 - PlayerPrefs.GetInt("Defense"));
        message.text = message.text + "\n Enemy punches for "+damage+" damage.";
        blocking = false;
        if (!me.blocking)
            myH.hurt(damage);
        anim.Play("SkaterPunch");
    }
    public void kick()
    {
        if (PlayerPrefs.GetInt("Defense") > 20)
        {
            damage = 1;
        }
        else
            damage = Random.Range(0, 36- PlayerPrefs.GetInt("Defense"));
        message.text = message.text + "\n Enemy kicks for " + damage + " damage.";
        blocking = false;
        if (!me.blocking)
            myH.hurt(damage);
        anim.Play("SkaterKick");
    }
    public void block()
    {
        message.text = message.text + "\n Enemy prepares to block.";
        blocking = true;
    }
    public void die()
    {
        if (alive)
        {
            message.text = message.text + "\n Enemy defeated.";
            alive = false;
            blocking = false;
            anim.Play("SkaterDie");
        }
    }

    public IEnumerator myPause()
    {
        yield return new WaitForSeconds(20.0f);
    }


    public void chooseMove()
    {
        doneTurn = false;
        //Makes Combat animations less chaotic by enemy waiting 3 seconds.
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(3f);
        displayHealth();
        if (alive)
        {
            int move = Random.Range(1, 4);
            if (move == 1)
                attack();
            else if (move == 2)
                kick();
            else
                block();
        }
        doneTurn = true;
    }

    IEnumerator MyDefeat()
    {
        yield return new WaitForSeconds(4f);
        PlayerPrefs.SetInt("Health", myH.health);
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 100);
        SceneManager.LoadScene("TownScene");
    }
}

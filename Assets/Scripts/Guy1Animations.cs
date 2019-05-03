using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Guy1Animations: MonoBehaviour{
    Animator anim;

    bool alive;
    public bool blocking;
    public SliderHealthBar myH;
    public SliderHealthBar EnH;
    public SkaterAnimation SA;
    int damage;
    public Text message;

	// Use this for initialization
	void Start () {
        blocking = false;
        anim = GetComponent<Animator>();
        alive = true;
        myH.health = PlayerPrefs.GetInt("Health");
	}
	
	// Update is called once per frame
	void Update () {

        if (myH.health <= 0 && alive)
        {
            myH.health = 0;
            die();
            myH.healthDisplay.text = "Wasted";
            StartCoroutine(MyDefeat());
        }
        else
            myH.healthDisplay.text = "My Health: " + myH.health + "/100";
        

        //Testing purposes.
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("Guy1Attacking");
        }*/
    }
    public void attack()
    {
        if (alive && SA.alive && SA.doneTurn)
        {
            damage = Random.Range(10 + PlayerPrefs.GetInt("Strength"), 26 + PlayerPrefs.GetInt("Strength"));
            message.text = "You punch for " + damage + " damage.";
            blocking = false;
            anim.Play("Guy1Attacking");
            if (!SA.blocking)
                EnH.hurt(damage);
            enemyTurn();
        }

    }
    public void kick()
    {
        if (alive && SA.alive && SA.doneTurn)
        {
            damage = Random.Range(0 + PlayerPrefs.GetInt("Strength"), 41 + PlayerPrefs.GetInt("Strength"));
            message.text = "You kick for " + damage + " damage.";
            blocking = false;
            anim.Play("Guy1Kicking");
            if (!SA.blocking)
                EnH.hurt(damage);
            enemyTurn();
        }

    }
    public void block()
    {
        if (alive && SA.alive && SA.doneTurn)
        {
            message.text = "You block for this turn.";
            blocking = true;
            enemyTurn();
        }

    }
    public void die()
    {
        if (alive)
        {
            message.text = "You were defeated.";
            blocking = false;
            alive = false;
            anim.Play("Guy1Die");
        }

    }
    public void enemyTurn()
    {
        SA.chooseMove();
    }

    IEnumerator MyDefeat()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("GameOverScene");
    }
    public void runAway()
    {
        PlayerPrefs.SetInt("Health", myH.health);
        SceneManager.LoadScene("TownScene");
    }
}

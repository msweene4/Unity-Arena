using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBar : MonoBehaviour {

    public Text healthDisplay;
    public Slider healthbar;
    public int health;

	// Use this for initialization
	void Start () {
        healthbar.value = health;
	}
	
	// Update is called once per frame
	void Update () {
        healthbar.value = health;
    }
    public void hurt(int dmg)
    {
        health = health - dmg;
    }
}

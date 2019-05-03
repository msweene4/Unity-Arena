using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour {

    public Text disp;
	// Update is called once per frame
	void Update () {
        disp.text = "Gold: "+PlayerPrefs.GetInt("Gold");
	}
}

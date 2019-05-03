using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyStuffandSleep : MonoBehaviour {

    public void StrengthUp()
    {
        if(PlayerPrefs.GetInt("Gold") >= 100)
        {
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - 100);
            PlayerPrefs.SetInt("Strength", PlayerPrefs.GetInt("Strength") + 5);
        }
    }
    public void DefenseUp()
    {
        if (PlayerPrefs.GetInt("Gold") >= 100)
        {
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - 100);
            PlayerPrefs.SetInt("Defense", PlayerPrefs.GetInt("Defense") + 5);
        }
    }
    public void heal()
    {
        if (PlayerPrefs.GetInt("Gold") >= 50)
        {
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - 50);
            PlayerPrefs.SetInt("Health", 100);
        }
    }
}

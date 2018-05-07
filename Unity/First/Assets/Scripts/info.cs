using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class info : MonoBehaviour {

    public Text Hp;
    public Text Ammo;
    public Text Kills;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Hp.text = "Health: " + PlayerController.playerhp;
        Ammo.text = "Ammo: " + PlayerController.ammo;
        Kills.text = "Kills: " + Enemy.kills;


    }
}

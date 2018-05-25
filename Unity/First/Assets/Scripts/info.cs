using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class info : MonoBehaviour {

    Enemy ckill;
    PlayerController cammo;
    PlayerController cplhl;
    public Text Hp;
    public Text Ammo;
    public Text Kills;

	// Use this for initialization
	void Start ()
    {
        ckill = GameObject.FindObjectOfType<Enemy>();
        cammo = GameObject.FindObjectOfType<PlayerController>();
        cplhl = GameObject.FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Hp.text = "Health: " + cplhl.playerhp;
        Ammo.text = "Ammo: " + cammo.ammo;
        Kills.text = "Kills: " + ckill.kills;
    }

    public void GoMenu()
    {
        Application.LoadLevel(0);
    }
}

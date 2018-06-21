using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class info : MonoBehaviour {

    PlayerController cammo, cammo2;
    PlayerController cplhl;
    public GameObject btnDMG, btnHp;
    public Text Hp;
    public Text Ammo;
    public Text Ammo2;
    public Text Kills;
    public Text Dmg;
    public Text Mission;
    public int ckill;
    int lvl;
    bool isLevelUp;
    int MaxKill;

	// Use this for initialization
	void Start ()
    {
        cammo2 = GameObject.FindObjectOfType<PlayerController>();
        MaxKill = 100;
        lvl = 0;
        cammo = GameObject.FindObjectOfType<PlayerController>();
        cplhl = GameObject.FindObjectOfType<PlayerController>();
    }
	public void UpgradeHp()
    {
        isLevelUp = false;
        cplhl.Maxplayerhp = cplhl.Maxplayerhp + 10;
    }

    public void UpgradeDMG ()
    {
        isLevelUp = false;
        cplhl.playerdmg = cplhl.playerdmg + 2;
    }

	// Update is called once per frame
	void Update ()
    {
        
        btnHp.SetActive(isLevelUp);
        btnDMG.SetActive(isLevelUp);
        Hp.text = "Health: " + cplhl.playerhp;
        Ammo.text = "MachineGun Ammo: " + cammo.ammo;
        Ammo2.text = "Pistol Ammo: " + cammo2.ammo2;
        Kills.text = "Kills: " + ckill;
        Dmg.text = "Damage: " + cplhl.playerdmg;
        Mission.text = 100 - ckill + " " + "Kills Left";
        if (ckill == 100) Application.LoadLevel(3);
    }

    public void AddKill()
    {
        ckill++;
        MaxKill--;
        if (!isLevelUp)
        {
            if (ckill % 10 == 0 && ckill != 0) isLevelUp = true;
        }
    }

    public void GoMenu()
    {
        Application.LoadLevel(0);
    }
}

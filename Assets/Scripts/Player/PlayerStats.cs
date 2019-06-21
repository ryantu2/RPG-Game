using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {


    [Header("Player Stats")]
    public string[] stats;
    public int[] statData;
    public string playerName;
    public int level;
    public int gold;
    public float dropSpeed;
    public float maxHP, maxMana, maxStam, maxExp;
    public float curHP, curMana, curStam, curExp;
    public float delayedHP;

    [Header("References")]
    public Vector3 savePos;
    [Header("delayed HP bar")]
    public Slider delayedHpBar;
    
    [Header("HP bar")]
    public Slider hpBar;
    
    [Header("Other Bars")]
    public Slider stamBar, manaBar, expBar;
    
          
    void Start () {
        Load();
    }


    public void Save()
    {
        Debug.Log("We Are in Save");
        savePos = this.transform.position;
        SaveToBinary.SaveData(this);
    }

    public void Load()
    {
        DataToSave data = SaveToBinary.LoadData(this); // parameter is being wasted
        if (data != null)
        {
            Debug.Log("We Loaded");
        }
        else
        {
            Debug.Log("We fucked up load!");
            return;
        }
        playerName = data.playerName;
        level = data.level;
        maxHP = data.maxHP;
        maxMana = data.maxMana;
        maxStam = data.maxStam;
        curHP = data.curHP;
        curMana = data.curMana;
        curStam = data.curStam;

        savePos.x = data.x;
        savePos.y = data.y;
        savePos.z = data.z;

        this.transform.position = savePos;


    }


    void Update () {

        savePos = this.transform.position;
        hpBar.value = Mathf.Clamp01(curHP / maxHP);
        if (curHP < delayedHP)
        {
            float x = (delayedHP - curHP) / 0.5f; 
            delayedHP -= (dropSpeed + x) * Time.deltaTime;
            delayedHpBar.value = Mathf.Clamp01(delayedHP / maxHP);
        }
        else
        {
            delayedHP = curHP;
        }
        manaBar.value = Mathf.Clamp01(curMana / maxMana);
        stamBar.value = Mathf.Clamp01(curStam / maxStam);
    }
}

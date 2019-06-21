using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float maxEnemyHP, curEnemyHP;
    public Canvas enemyCanvas;
    public Slider enemySlider;


	void Start () {
		
	}
	
	
	void Update () {
        enemySlider.value = Mathf.Clamp01(curEnemyHP / maxEnemyHP);
        enemyCanvas.transform.LookAt(Camera.main.transform);
	}
}

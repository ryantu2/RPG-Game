using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intereact : MonoBehaviour {


    Dialogue npcDialoge;


    void Start () {
		
	}
	
	
	void Update () {
        if (Input.GetButtonDown("Interact"))
        {
            // we pressed the interact button
            //lets create a ray
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10f))
            {
                // we hit something within 10f
                npcDialoge = hit.collider.GetComponent<Dialogue>();
                if (npcDialoge)
                {
                    // we actually hit the NPC and was able to get the dialogue class
                    //note: I have never turned off curser
                    npcDialoge.showDialogue = true;
                    Movement.canMove = false;
                }

            }
           

        }
	}
}

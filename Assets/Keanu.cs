using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keanu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLISION");

        if (other.gameObject.tag == "Player")
        {
            PlayerQuest q = other.GetComponent<PlayerQuest>();
            for (int i = 0; i < q.quests.Count; i++)
            {
                if (q.quests[i].name == "Find Kianu!!")
                {
                    q.quests[i].goal.ObjectCollected();
                }
            }
        }


    }

}

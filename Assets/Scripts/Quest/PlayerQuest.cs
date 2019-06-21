using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>(); //lists require using -- System.Collections.Generic --

    private void Update()
    {
        for (int i = 0; i < quests.Count; i++)
        {
            if (quests[i].goal.isReached())
            {
                quests[i].Complete();   
            }
        }
    }

}

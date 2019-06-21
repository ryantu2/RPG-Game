//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

[System.Serializable] // this makes the class able to be converted to binary stream (JSON format) for transmission
public class Quest
{
    //quest state
    public QuestState state = QuestState.New;
    //name
    public string name, description;
    //descritopt
    //experience Reward
    public int expReward;
    //gold reward
    public int goldReward;

    //goal
    public QuestGoal goal;

    //sourceID
    //questID
    //questChainID

    //complete
    public void Complete()
    {
        state = QuestState.Completed;
    }
}


public enum QuestState
{
    New,
    Accepted,
    Failed,
    Completed,
    Claimed
}
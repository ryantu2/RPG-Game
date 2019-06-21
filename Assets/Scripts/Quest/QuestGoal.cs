[System.Serializable]
public class QuestGoal
{
    //goal type
    public GoalType goalType;

    //required amount
    public int requiredAmount;

    //current amout
    public int currentdAmount;

    //isReached
    public bool isReached()
    {
        return (currentdAmount >= requiredAmount);
    }

    //enemy killed
    public void EnemyKilled()
    {
        if (goalType == GoalType.Kill)
        {
            currentdAmount++;
        }
    }

    //object collected
    public void ObjectCollected()
    {
        if (goalType == GoalType.Gather)
        {
            currentdAmount++;
        }
    }

}
public enum GoalType
{
    Kill,
    Gather
}

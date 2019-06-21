
[System.Serializable]
public class DataToSave
{
    public string playerName;
    public int level;
    public float maxHP, maxStam, maxMana;
    public float curHP, curStam, curMana;
    public float x, y, z;
    
    public DataToSave(PlayerStats p)
    {
        playerName = p.playerName;
        level = p.level;
        maxHP = p.maxHP;
        maxMana = p.maxMana;
        maxStam = p.maxStam;
        curHP = p.curHP;
        curMana = p.curMana;
        curStam = p.curStam;

        x = p.savePos.x;
        y = p.savePos.y;
        z = p.savePos.z;
    }



}

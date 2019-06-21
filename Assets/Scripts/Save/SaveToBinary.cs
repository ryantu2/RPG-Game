using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveToBinary
{
    public static void SaveData(PlayerStats p)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath +  p.playerName + ".death";
        FileStream stream = new FileStream(path, FileMode.Create);
        DataToSave data = new DataToSave(p);
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("We Saved");
    }

    public static DataToSave LoadData(PlayerStats p)
    {
        Debug.Log("playername: " + p.playerName);
        string path = Application.persistentDataPath + /*"/save.death"; */ p.playerName + ".death";
        if (File.Exists(path))
        {
            Debug.Log("Path Exists");
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DataToSave data = formatter.Deserialize(stream) as DataToSave;
            stream.Close();
            
            return data;

        }
        else
        {
            Debug.Log("Path NOT Exists: " + p.playerName);
            return null;
        }
    }



} 

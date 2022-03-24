using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void Save(Spawner sp)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/save.plz";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveHighScore save = new SaveHighScore(sp);

        formatter.Serialize(stream, save);
        stream.Close();
    }

    public static SaveHighScore Load()
    {
        string path = Application.persistentDataPath + "/save.plz";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveHighScore save = formatter.Deserialize(stream) as SaveHighScore;
            stream.Close();

            return save;
        }
        else
        {
            return null;
        }
    }
}

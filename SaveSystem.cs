using UnityEngine;
using System.IO;

public class SaveSystem
{
    static string SavePath(int slot)
    {
        return Application.persistentDataPath + "/save_slot_" + slot + ".json";
    }


    public static void SaveGame(SaveData data, int slot)
    {
        string path = Application.persistentDataPath + "/save_slot_" + slot + ".json";
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }


    public static SaveData LoadGame(int slot)
    {
        string path = Application.persistentDataPath + "/save_slot_" + slot + ".json";

        if (!File.Exists(path))
            return null;

        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public static bool SaveExists(int slot)
    {
        return File.Exists(SavePath(slot));
    }

    public static bool HasSave(int slot)
    {
        string path = Application.persistentDataPath + "/save_slot_" + slot + ".json";
        return File.Exists(path);
    }

}

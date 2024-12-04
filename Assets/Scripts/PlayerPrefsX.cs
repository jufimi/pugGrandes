using UnityEngine;

public static class PlayerPrefsX
{
    public static void SetVector3(string key, Vector3 value)
    {
        PlayerPrefs.SetFloat(key + "_x", value.x);
        PlayerPrefs.SetFloat(key + "_y", value.y);
        PlayerPrefs.SetFloat(key + "_z", value.z);
    }

    public static Vector3 GetVector3(string key)
    {
        float x = PlayerPrefs.GetFloat(key + "_x");
        float y = PlayerPrefs.GetFloat(key + "_y");
        float z = PlayerPrefs.GetFloat(key + "_z");
        return new Vector3(x, y, z);
    }

    public static void SetQuaternion(string key, Quaternion value)
    {
        PlayerPrefs.SetFloat(key + "_x", value.x);
        PlayerPrefs.SetFloat(key + "_y", value.y);
        PlayerPrefs.SetFloat(key + "_z", value.z);
        PlayerPrefs.SetFloat(key + "_w", value.w);
    }

    public static Quaternion GetQuaternion(string key)
    {
        float x = PlayerPrefs.GetFloat(key + "_x");
        float y = PlayerPrefs.GetFloat(key + "_y");
        float z = PlayerPrefs.GetFloat(key + "_z");
        float w = PlayerPrefs.GetFloat(key + "_w");
        return new Quaternion(x, y, z, w);
    }
}

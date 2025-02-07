using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SceneObfuscator : MonoBehaviour
{
    public bool IsExecuteOnAwake = false;
    public List<string> IgnoreNames = new List<string>
    {
        "SafeArea",
        "Animation"
    };
    
    void Awake()
    {
        if (IsExecuteOnAwake)
        {
            GameObject[] allGO = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];
            foreach (var item in allGO)
            {
                if (!IgnoreNames.Contains(item.name))
                {
                    Guid g = Guid.NewGuid();
                    string GuidString = Convert.ToBase64String(g.ToByteArray());
                    GuidString = GuidString.Replace("=", "");
                    GuidString = GuidString.Replace("+", "");
                    item.name = GuidString;
                }
            }
        }
    }
}
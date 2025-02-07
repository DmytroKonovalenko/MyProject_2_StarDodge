using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class AssetsObfuscator : MonoBehaviour
{
    public bool IsExecuteOnAwake = false;

    public List<string> ObfuscateAssetsFolderPaths;

    void Awake()
    {
        if (IsExecuteOnAwake)
        {
            var assetsGuids = AssetDatabase.FindAssets($"t:Object", ObfuscateAssetsFolderPaths.ToArray());

            foreach (var assetGuid in assetsGuids)
            {
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("+", "");

                AssetDatabase.RenameAsset(AssetDatabase.GUIDToAssetPath(assetGuid), GuidString);
            }
        }
    }

}
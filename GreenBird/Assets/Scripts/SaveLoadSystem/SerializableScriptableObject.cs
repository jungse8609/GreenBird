#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

public class SerializableScriptableObject : ScriptableObject
{
    private string _guid;
    public string Guid => _guid;

#if UNITY_EDITOR
    private void OnValidate()
    {
        var path = AssetDatabase.GetAssetPath(this);
        _guid = AssetDatabase.AssetPathToGUID(path);
    }
#endif
}

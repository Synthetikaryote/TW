//adapted from http://wiki.unity3d.com/index.php?title=CreateScriptableObjectAsset

using UnityEngine;
using UnityEditor;
using System.IO;

public static class DataUtilities
{
  public static void CreateAsset<T>() where T : ScriptableObject
  {
    T asset = ScriptableObject.CreateInstance<T>();

    string path = AssetDatabase.GetAssetPath(Selection.activeObject);
    string type = typeof(T).ToString();

    if (path == "")
    {
      path = "Data/" + type;
    }
    else if (Path.GetExtension(path) != "")
    {
      path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
    }

    string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New" + type + ".asset");

    AssetDatabase.CreateAsset(asset, assetPathAndName);

    AssetDatabase.SaveAssets();
    AssetDatabase.Refresh();
    EditorUtility.FocusProjectWindow();
    Selection.activeObject = asset;
  }
}

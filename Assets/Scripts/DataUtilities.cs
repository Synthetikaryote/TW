//adapted from http://wiki.unity3d.com/index.php?title=CreateScriptableObjectAsset

using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace DataObject
{
  public static class Utilities
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

    public static void AddAsset<T>() 
      where T : ScriptableObject
    {

    }

    static private Dictionary<int, string> ClassPathMap;
  }


}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class DataObjectRoot : System.Attribute
{
  private readonly string SaveDir = "Data";
  private readonly string MenuDir = "Assets/Create/DataObject";

  public DataObjectRoot()
  {
  }
}


[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class DataObjectClass : System.Attribute
{
  public DataObjectClass()
  {
  }

  //protected string SavePath()
  //{
  //}

  //protected string MenuPath()
  //{
  //}
}

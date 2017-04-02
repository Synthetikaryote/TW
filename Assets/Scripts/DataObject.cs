//adapted from http://wiki.unity3d.com/index.php?title=CreateScriptableObjectAsset

using UnityEngine;
using UnityEditor;

[DataObjectRoot()]
[DataObjectClass()]
public abstract class DataObject<Derived> : ScriptableObject
  where Derived : DataObject<Derived>
{
  public static void CreateAsset()
  {
    DataObject.Utilities.CreateAsset<Derived>();
  }
}
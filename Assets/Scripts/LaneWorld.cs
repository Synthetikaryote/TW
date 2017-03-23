using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaneWorld : MonoBehaviour
{
  //BN: y-up, z-forward, x-right

  public int LaneCount = 4; //lanes indexed from -z to +z
  public float LaneWidth = 2.0f;
  public float LaneLength = 5.0f;
  public GameObject LaneObjectPrefab;

  private List<LaneWorldObject>[] LaneObjectRoster;
      
	void Start ()
  {
    Debug.Assert(transform); //requires transform
    LaneObjectRoster = new List<LaneWorldObject>[LaneCount];
  }
	
	void Update ()
  {
	
	}

  void SpawnObject(int Lane, float NormedDistance, bool DistanceFromLeft)
  {
    Vector3 pos = GetPositionOnLane(Lane, NormedDistance * LaneLength, DistanceFromLeft);
    Quaternion rot = GetRotationOnLane(DistanceFromLeft);
    LaneWorldObject newObject = (LaneWorldObject)Instantiate(LaneObjectPrefab, pos, rot);
    newObject.SetDirection(GetLaneDirection(DistanceFromLeft));
    LaneObjectRoster[Lane].Add(newObject);
  }

  private Quaternion GetRotationOnLane(bool FromLeft)
  {
    return transform.rotation * Quaternion.AngleAxis(FromLeft ? 90.0f : -90.0f, transform.up);
  }

  private Vector3 GetPositionOnLane(int Lane, float Distance, bool DistanceFromLeft)
  {
    Debug.Assert(Distance >= 0.0f && Distance <= LaneLength);
    Debug.Assert(Lane >= 0 && Lane < LaneCount);

    return (transform.forward * DistanceToLaneCentre(Lane))
      + (GetLaneDirection(DistanceFromLeft) * Distance)
      + transform.position;
  }

  Vector3 GetLaneDirection(bool FromLeft)
  {
    return FromLeft ? transform.right : -transform.right;
  }

  private float DistanceToLaneCentre(int Lane)
  {
    return ((float)(Lane) - ((float)(LaneCount - 1) / 2)) * LaneWidth;
  }
}

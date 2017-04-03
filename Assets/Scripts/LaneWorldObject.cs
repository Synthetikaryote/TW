using UnityEngine;
using System.Collections;

public class LaneWorldObject : MonoBehaviour {

  private Vector3 Velocity = Vector3.zero;
  private float Speed = 6.0f;

  public void SetVelocity(Vector3 Direction)
  {
    Velocity = Speed * Direction;
  }

	// Use this for initialization
	void Start ()
  {
	
	}
	
	// Update is called once per frame
	void Update ()
  {
    transform.position += (Velocity * Time.deltaTime);
	}
}

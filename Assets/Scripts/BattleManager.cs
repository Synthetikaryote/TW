using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleManager : Singleton<BattleManager> {
    public MeshRenderer field;
    public Text timeLeft;
    public Text budget;
    public Text fame;
    public Text coins;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        FakePlayer();
	}

    float nextSpawn = 0f;
    public GameObject toSpawnPrefab;
    void FakePlayer()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + Random.Range(1f, 5f);
            var go = Instantiate<GameObject>(toSpawnPrefab);
            go.transform.position = new Vector3(Random.Range(field.bounds.min.x, field.bounds.max.x), field.bounds.max.y, field.bounds.min.z);
        }
    }
}

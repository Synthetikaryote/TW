using UnityEngine;
using System.Collections;

public class TrumpManager : Singleton<TrumpManager> {
    public MeshRenderer field;

    public float money;
    public float budget;

	// Use this for initialization
	void Start () {
        budget = 500000f;
        money = budget;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Damage(float amount)
    {
        money = Mathf.Max(0f, money - amount);
        BattleManager.Instance.budget.text = "Trump's Budget:\n$" + Mathf.RoundToInt(money / 1000f) + "K/$" + Mathf.RoundToInt(budget / 1000f) + "K";
    }
}

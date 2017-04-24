using UnityEngine;
using System.Collections;

public class BattleCharacter : MonoBehaviour {
    float speed = 30f;
    float moneyDamage = 10000f;
    float attackDelay = 5f;
    float nextAttack = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var p = transform.position;
        // move
        if (p.z < BattleManager.Instance.field.bounds.max.z)
        {
            p.z += speed * Time.deltaTime;
            transform.position = p;
        }

        // attack
        if (p.z >= BattleManager.Instance.field.bounds.max.z)
        {
            if (Time.time >= nextAttack)
            {
                nextAttack = Time.time + attackDelay;
                TrumpManager.Instance.Damage(moneyDamage);
            }
        }

    }
}

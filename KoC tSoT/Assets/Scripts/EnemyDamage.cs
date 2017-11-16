using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;
	void Start ()
    {
        nextDamage = 0f;
	}
	
	void Update ()
    {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && nextDamage < Time.time)
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            PushBack(other.transform);
        }
    }

    void PushBack(Transform pushedObject)
    {
        Vector2 pushDir = new Vector2(0, pushedObject.position.y - transform.position.y).normalized;
        pushDir *= pushBackForce;
        Rigidbody2D pushRb = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRb.velocity = Vector2.zero;
        pushRb.AddForce(pushDir, ForceMode2D.Impulse);
    }
}

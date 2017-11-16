using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth;
    float currentHealth;

    public int maxEstus;
    int currentEstus;

    PlayerController control;
	void Start ()
    {
        currentHealth = maxHealth;
        currentEstus = maxEstus;
        control = GetComponent<PlayerController>();
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentEstus > 0)
            {
                currentEstus -= 1;
                currentHealth += 20;
                if (currentHealth > maxHealth)
                    currentHealth = maxHealth;
            }
        }

    }

    public void addDamage(float damage)
    {
        if (damage <= 0)
            return;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void makeDead()
    {
        Destroy(gameObject);
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 150, 25), "Health " + currentHealth + " / " + maxHealth);
    }
}

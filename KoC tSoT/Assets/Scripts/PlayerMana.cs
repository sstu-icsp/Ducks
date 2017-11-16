using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{

    public float maxMana;
    float currentMana;

    public float timeDelay = 1;
    float timeDelayMana;
    void Start ()
    {
        currentMana = 20;
	}
	
	void Update ()
    {
        if (currentMana < maxMana)
        {
            timeDelayMana += Time.deltaTime;
            if (timeDelayMana >= timeDelay)
            {
                currentMana += 2;
                timeDelayMana = 0;
            }
        }
	}

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 40, 150, 25), "Mana " + currentMana + " / " + maxMana);
    }
}

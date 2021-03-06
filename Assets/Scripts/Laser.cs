﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public int damage;
    public bool damageDealed;
    public float laserSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        transform.Translate((Vector3.up / 100) * laserSpeed);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<ScoreObject>() && other.gameObject.tag != "Blocking Volume")
        {
            if (!damageDealed)
            {
                damageDealed = true;
                if (other.GetComponent<PlayerControl>())
                {
                    other.GetComponent<PlayerControl>().setHealth(other.GetComponent<PlayerControl>().getHealth() - damage);
                    other.GetComponent<PlayerControl>().healthText.text = " Health: " + other.GetComponent<PlayerControl>().getHealth().ToString();
                }

                Destroy(gameObject);
            }
        }
    }
}

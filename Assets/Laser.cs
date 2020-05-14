using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public int damage;
    public bool damageDealed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        transform.Translate(Vector3.up / 100);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (!damageDealed)
        {
            damageDealed = true;
            if (other.GetComponent<PlayerControl>())
            {
                other.GetComponent<PlayerControl>().health -= damage;
            }

            Destroy(gameObject);
        }
    }
}

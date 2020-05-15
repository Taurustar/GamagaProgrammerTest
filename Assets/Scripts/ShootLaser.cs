using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public GameObject[] laserPoints;
    public GameObject LaserObject;
    public int damage;
    public float speed = 1;
    public float frecuency = 1; //Shoots per second
    public float firstShotDelay;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(StartShooting());
    }

    public IEnumerator StartShooting()
    {
        yield return new WaitForSeconds(firstShotDelay);
        StartCoroutine(Shooting());

    }

    public IEnumerator Shooting()
    {
        gameObject.GetComponent<AudioSource>().Play();
        foreach (GameObject point in laserPoints)
        {
            GameObject newLaser = Instantiate(LaserObject, point.transform);
            newLaser.gameObject.transform.parent = null;
            newLaser.GetComponent<Laser>().damage = damage;
            newLaser.GetComponent<Laser>().laserSpeed = speed;
        }
        yield return new WaitForSeconds(1 / frecuency);
        StartCoroutine(Shooting());
    }

    
}

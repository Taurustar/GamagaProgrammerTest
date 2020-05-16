using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public TurretConfigObject configObject;
    [Tooltip("Game Objects array where the lasers are spawned")]
    public GameObject[] laserPoints;
    [SerializeField]
    GameObject LaserObject;
    [SerializeField]
    int damage;
    [SerializeField]
    float speed = 1;
    [SerializeField]
    float frecuency = 1; //Shoots per second
    [SerializeField]
    float firstShotDelay;
    // Start is called before the first frame update

    private void Awake()
    {
        LaserObject = configObject.laserObject;
        damage = configObject.turretDamage;
        speed = configObject.isLaserSpeedRandom ? Random.Range(1, 5) : configObject.laserSpeed;
        frecuency = configObject.isRandomFrecuency ? Random.Range(0.2f, 0.8f) : configObject.frecuency;
        firstShotDelay = configObject.isRandomDelay ? Random.Range(0, 1) : configObject.startDelay;
        if (configObject.isMovable)
        {
            gameObject.AddComponent<TurretMovable>();
            gameObject.GetComponent<TurretMovable>().configObject = configObject;
        }
    }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour
{


    public int health = 100;
    public Text healthText;
    public int score = 0;
    public Text scoreText;
    public float acceleration = 1.75f;

    Vector2 previousFramePos;
    // Start is called before the first frame update
    void Start()
    {
        previousFramePos = Vector2.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rotator>())
        {
            if (other.GetComponent<Rotator>().direction == 0 && !other.GetComponent<Rotator>().done)
            {
                StartCoroutine(TurnRight());
                other.GetComponent<Rotator>().done = true;
            }


            if (other.GetComponent<Rotator>().direction == 1 && !other.GetComponent<Rotator>().done)
            {
                StartCoroutine(TurnLeft());
                other.GetComponent<Rotator>().done = true;
            }
        }

        if(other.GetComponent<ActivateTurrets>())
        {
            foreach (ShootLaser turret in other.GetComponent<ActivateTurrets>().turrets)
            {
                turret.enabled = true;
            }
        }

        if (other.GetComponent<DeactivateTurrets>())
        {
            for( int i = 0; i < other.GetComponent<DeactivateTurrets>().turrets.Length; i++)
            {
                if(other.GetComponent<DeactivateTurrets>().turrets[i] != null)
                Destroy(other.GetComponent<DeactivateTurrets>().turrets[i].gameObject);
                
            }
        }

        if(other.GetComponent<ShootLaser>())
        {
            Destroy(other.gameObject);
            health -= 25;
            healthText.text = " Health: " + health.ToString();
        }

        if(other.GetComponent<ScoreObject>())
        {
            Destroy(other.gameObject);
            score += other.GetComponent<ScoreObject>().score;
            scoreText.text = " Score: " + score.ToString();
        }

    }



    // Update is called once per frame
    void Update()
    {
        /*

        if(Input.touchCount == 1)
        {
            
            Vector2 playerToScreen = Camera.main.WorldToScreenPoint(GetComponentInParent<Transform>().position);

            if(Input.GetTouch(0).position.x > playerToScreen.x)
            {
                MoveRight();
            }
            if (Input.GetTouch(0).position.x < playerToScreen.x)
            {
                MoveLeft();
            }
        }*/



        if(Input.touchCount == 1)
        {
            if (Input.GetTouch(0).position.x > previousFramePos.x)
            {
                MoveRight();
            }
            if (Input.GetTouch(0).position.x < previousFramePos.x)
            {
                MoveLeft();
            }

            previousFramePos = Input.GetTouch(0).position;
        }
        



        if(Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            acceleration = 3;
            transform.Translate((Vector3.forward / 100) * acceleration);
        }
        else
        {
            acceleration = 1;
            transform.Translate((Vector3.forward / 100) * acceleration);
        }
    }

    public IEnumerator TurnRight()
    {

        for(int i = 0; i < 45; i ++)
        {
            transform.Rotate(new Vector3(0, 1, 0));
            yield return new WaitForSeconds(0.01f);
        } 
    }

    public IEnumerator TurnLeft()
    {
        for (int i = 0; i < 45; i++)
        {
            transform.Rotate(new Vector3(0, -1, 0));
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void MoveLeft()
    {
        transform.Translate(Vector3.right / -100);
    }

    public void MoveRight()
    {
        transform.Translate(Vector3.right / 100);
    }


}

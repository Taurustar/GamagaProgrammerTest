using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovable : MonoBehaviour
{

    public enum Direction
    {
        FRONT,
        REAR,
        LEFT,
        RIGHT

    };

    public Direction direction;
    float distanceMoved;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (direction == Direction.FRONT || direction == Direction.REAR)
        {
            if (direction == Direction.FRONT)
            {
                float previous = transform.position.z;
                transform.Translate(Vector3.forward / 100);
                distanceMoved += Mathf.Abs(previous - transform.position.z);
                if(distanceMoved > 3)
                {
                    direction = Direction.REAR;
                    distanceMoved = 0;
                }
            }

            if (direction == Direction.REAR)
            {
                float previous = transform.position.z;
                transform.Translate((Vector3.forward / 100) * -1);
                distanceMoved += Mathf.Abs(previous - transform.position.z);
                if (distanceMoved > 3)
                {
                    direction = Direction.FRONT;
                    distanceMoved = 0;
                }
            }


        }


        if (direction == Direction.RIGHT || direction == Direction.LEFT)
        {
            if (direction == Direction.RIGHT)
            {
                float previous = transform.position.x;
                transform.Translate(Vector3.right / 100);
                distanceMoved += Mathf.Abs(previous - transform.position.x);
                if (distanceMoved > 3)
                {
                    direction = Direction.LEFT;
                    distanceMoved = 0;
                }
            }

            if (direction == Direction.LEFT)
            {
                float previous = transform.position.x;
                transform.Translate((Vector3.right / 100) * -1);
                distanceMoved += Mathf.Abs(previous - transform.position.x);
                if (distanceMoved > 3)
                {
                    direction = Direction.RIGHT;
                    distanceMoved = 0;
                }
            }


        }
    }
}

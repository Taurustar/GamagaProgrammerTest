using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    public int score;

    private void Update()
    {
        transform.Rotate(new Vector3(Random.value, Random.value, Random.value));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Manager : MonoBehaviour
{

    public GameObject target;
    public float speed = 1.0f;

    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = target.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetPosition = target.transform.position;
       // Debug.Log("my target is at " + targetPosition);

        var step = speed * Time.fixedDeltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}

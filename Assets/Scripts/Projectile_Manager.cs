using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Manager : MonoBehaviour
{

    public GameObject target;
    public float speed = 1.0f;

    private Vector3 targetPosition;
    private Vector3 direction;
    private bool hasBeenBonked = false;

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
        if (!hasBeenBonked)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            direction = Vector3.Normalize(targetPosition - transform.position);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + (direction.x*step), 
                                             transform.position.y + (direction.y*step), 
                                             transform.position.z + (direction.z*step));

        }
    }


    public void Rebondis(Transform shieldTransform, Vector3 normal)
    {
        hasBeenBonked = true;
        speed *= 2;
        direction = Vector3.Normalize(Vector3.Reflect(this.transform.position, normal));
    }
}

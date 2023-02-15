using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_manager : MonoBehaviour
{

    public GameObject BlueProjectilePrefab;
    public GameObject GreenProjectilePrefab;

    public float delay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateProjectile", 1.0f, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateProjectile()
    {

        GameObject target = GameObject.Find("Player");
        Debug.Log(target);

        // Random 1 chance sur 2
        bool flip = (Random.Range(0f, 1f) < 0.5f);

        if (flip)
        {
            Transform projectileParent = GameObject.Find("Blue balls").transform;
            var newBall = GameObject.Instantiate(BlueProjectilePrefab, projectileParent);

            newBall.GetComponent<Projectile_Manager>().target = target;
            newBall.transform.position = this.transform.position;
        }
        else 
        {
            Transform projectileParent = GameObject.Find("Green balls").transform;
            var newBall = GameObject.Instantiate(GreenProjectilePrefab, projectileParent);

            newBall.GetComponent<Projectile_Manager>().target = target;
            newBall.transform.position = this.transform.position;
        }

        
        
    }
}

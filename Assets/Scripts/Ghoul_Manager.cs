using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul_Manager : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;

    private bool isDead = false;

    private new Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) { return; }

        float step = speed * Time.deltaTime;

        //Si le monstre est près de nous, il attaque, sinon il avance
        if (Vector3.Distance(target.position, transform.position) <= 1f)
        {
            if (!animation.IsPlaying("Attack1"))
            {
                animation.Play("Attack1");
            }
        } 
        else
        {
            if(!animation.IsPlaying("Walk"))
            {
                animation.Play("Walk");
            }

            Vector3 relativePosition = target.position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            transform.rotation = Quaternion.LookRotation(relativePosition, Vector3.up);
            
        }

        
    }

    public void Die()
    {
        isDead = true;
        animation.playAutomatically = false;
        animation["Death"].wrapMode = WrapMode.Once;
        animation.Play("Death");

        Destroy(this.gameObject, 3);

    }

}


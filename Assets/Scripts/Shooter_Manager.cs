using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Manager : MonoBehaviour
{
    public Transform target;
    public GameObject projectilePrefab;

    private new Animation animation;
    private bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
        animation["Attack2"].wrapMode = WrapMode.Once;

        StartCoroutine("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        //Le monstre regarde toujours en direction du joueur
        Vector3 relativePosition = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePosition, Vector3.up);
    }

    private IEnumerator Attack()
    {
        while (!isDead)
        {
            //On attend 4 secondes
            animation.Play("Idle");
            yield return new WaitForSeconds(4);

            //...puis on tire
            animation.Play("Attack2");
            yield return new WaitUntil(() => !animation.IsPlaying("Attack2"));
            LanceBouleDeFeu();
        }
    }

    private void LanceBouleDeFeu()
    {
        Transform projectileParent = GameObject.Find("Projectiles").transform;
        var newBall = GameObject.Instantiate(projectilePrefab, projectileParent);

        newBall.GetComponent<Projectile_Manager>().target = target.gameObject;
        newBall.transform.position = this.transform.position + new Vector3(0,1.4f,0);//ouais c'est hard coded c'est pas ouf
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

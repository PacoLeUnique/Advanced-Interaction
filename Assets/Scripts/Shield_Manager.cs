using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Manager : MonoBehaviour
{

    public GameObject projectiles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        // On stoppe le mouvement du shield dans un premier temps (si on mets pas ca, notre boulcier s'envole apres une collision)
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision other)
    {
        

        Vector3 normal = other.contacts[0].normal;

        GameObject trigger = other.gameObject;
        Debug.Log("OBJECT TOUCHER");
        if (trigger.transform.IsChildOf(projectiles.transform))
        {
            AudioSource.PlayClipAtPoint(this.GetComponent<AudioSource>().clip, this.transform.position);
            trigger.GetComponent<Projectile_Manager>().Rebondis(this.transform, normal);
        }
    }
}

    

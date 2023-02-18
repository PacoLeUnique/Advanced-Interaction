using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Manager : MonoBehaviour
{

    public GameObject TriggerParent;
    
    void Start() {
       // Debug.Log(Trigger.transform.IsChildOf(TriggerParent.transform));
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject trigger = other.gameObject;
        Debug.Log("OBJECT TOUCHER");
        if(trigger.transform.IsChildOf(TriggerParent.transform)) {
            AudioSource.PlayClipAtPoint(TriggerParent.GetComponent<AudioSource>().clip, trigger.transform.position);
            Destroy(trigger);
        }
    }
}

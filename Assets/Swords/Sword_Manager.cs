using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Manager : MonoBehaviour
{

    public GameObject TriggerParent;
    public GameObject Trigger;
    
    void Start() {
        Debug.Log(Trigger.transform.IsChildOf(TriggerParent.transform));
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject trigger = other.gameObject;
        if(Trigger.transform.IsChildOf(TriggerParent.transform)) {
            AudioSource.PlayClipAtPoint(TriggerParent.GetComponent<AudioSource>().clip, trigger.transform.position);
            Destroy(trigger);
        }
    }
}

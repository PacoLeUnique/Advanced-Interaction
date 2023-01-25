using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Manager : MonoBehaviour
{

    public GameObject TriggerParent;

    void OnTriggerEnter(Collider other)
    {
        GameObject trigger = other.gameObject;
        if(trigger.transform.parent.gameObject == TriggerParent) {
            AudioSource.PlayClipAtPoint(TriggerParent.GetComponent<AudioSource>().clip, trigger.transform.position);
            Destroy(trigger);
        }
    }
}

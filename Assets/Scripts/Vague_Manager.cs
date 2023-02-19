using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vague_Manager : MonoBehaviour
{

    private List<Vague> vagues;
    private int currentVague;
    private bool started = false;

    private void Start()
    {
    }
    public void Launch()
    {
        vagues = new List<Vague>();
        foreach (Transform child in transform)
        {
            Debug.Log(child);
            vagues.Add(child.gameObject.GetComponent<Vague>());
        }
        vagues[0].SpawnAll();
        currentVague = 0;
        started = true;
    }

    private void Update()
    {
        if (started)
        {
            if (IsVagueClear())
            {
                Debug.Log("NOUVELLE VAGUE");
                currentVague++;
                vagues[currentVague].SpawnAll();
            }
        }
    }


    public bool IsVagueClear()
    {
        int un = GameObject.Find("GameManager/Monsters/Shooters").transform.childCount;
        int deux = GameObject.Find("GameManager/Monsters/Ghouls").transform.childCount;
        return (un == 0 && deux == 0);
    }
}

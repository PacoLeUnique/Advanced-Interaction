using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Vague_Manager vagueManager; 

    // Start is called before the first frame update
    void Start()
    {
        vagueManager.Launch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

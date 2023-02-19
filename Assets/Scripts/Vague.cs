using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vague : MonoBehaviour
{

    public void SpawnAll()
    {
        foreach (Transform child in transform)
        {
            Spawn(child);
        }
    }

    private void Spawn(Transform t)
    {
        GameObject enemy = t.gameObject;

        //On add l'enemy soir 
        Transform transformParent = (enemy.GetComponent<Ghoul_Manager>() == null) ? GameObject.Find("GameManager/Monsters/Shooters").transform 
                                                                                  : GameObject.Find("GameManager/Monsters/Ghouls").transform;
        GameObject newEnemy = Instantiate(enemy, transformParent);
        newEnemy.transform.position = enemy.transform.position;
        newEnemy.SetActive(true);
    }
}

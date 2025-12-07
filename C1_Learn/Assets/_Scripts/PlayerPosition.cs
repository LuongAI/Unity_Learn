using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPlayer : MonoBehaviour
{
    float playerPosX;
    List<GameObject> enemies = new List<GameObject>();
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.playerPosX = transform.position.x;
        if (this.playerPosX >= 7)
            Spawn();
    }
    
    void Spawn()
    {
        Debug.Log("Spawn");
        if (this.enemies.Count >= 7) return;
        int index = this.enemies.Count + 1;
        GameObject Enemy = new GameObject("Enemy_" + index);
        this.enemies.Add(Enemy);
    }

}

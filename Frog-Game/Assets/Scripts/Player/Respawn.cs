using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public Vector2 starterPosition;
    // Start is called before the first frame update
    void Start()
    {
        starterPosition = player.transform.position;
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D gameObject)
    {
        if (gameObject.tag == "Player")
        {
            player.transform.position = new Vector2(starterPosition.x, starterPosition.y);
        }
    }
}
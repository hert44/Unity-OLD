using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePlayer : MonoBehaviour
{
    private RoomTemp roomTemp;

    public float waitTimePlayer = 4f;
    public GameObject player;
    public GameObject camera;
    private bool spawnedPlayer = false;


    void Start()
    {
        roomTemp = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemp>();
    }

    void Update()
    {
        if(waitTimePlayer <= 0 && spawnedPlayer == false)
        {
            Instantiate(player, roomTemp.roomsList[0].transform.TransformPoint(0f, 8f, 0f), Quaternion.identity);
            Instantiate(camera, roomTemp.roomsList[0].transform.TransformPoint(0f, 8f, 0f), Quaternion.identity);
            spawnedPlayer = true;
        } else
        {
            waitTimePlayer -= Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemp : MonoBehaviour
{
    public GameObject[] northRooms;
    public GameObject[] eastRooms;
    public GameObject[] southRooms;
    public GameObject[] westRooms;

    public GameObject[] startingRooms;
    public GameObject[] startingNorthRooms;
    public GameObject[] startingEastRooms;
    public GameObject[] startingSouthRooms;
    public GameObject[] startingWestRooms;

    public GameObject[] finalNorthRooms;
    public GameObject[] finalEastRooms;
    public GameObject[] finalSouthRooms;
    public GameObject[] finalWestRooms;
    

    public GameObject closedRoom;

    public List<GameObject> roomsList;

    public float waitTimeBossRoom = 4f;
    public GameObject bossRoomIcon;
    public GameObject boss;
    private bool spawnedBossRoom = false;


    void Update()
    {
        if(waitTimeBossRoom <= 0 && spawnedBossRoom == false)
        {
            for(int i = 0; i < roomsList.Count; i++)
            {
                if(i == roomsList.Count - 1)
                {
                    Instantiate(bossRoomIcon, roomsList[i].transform.TransformPoint(0f, 8f, 0f), Quaternion.Euler(90f, 0f, 0f));
                    Instantiate(boss, roomsList[i].transform.TransformPoint(0f, 8f, 0f), Quaternion.identity);
                    spawnedBossRoom = true;
                }
            }
        } else
        {
            waitTimeBossRoom -= Time.deltaTime;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    private RoomTemp roomTemp;
    private TunnelTemp tunnelTemp;
    private int random;
    //private int randomSpawnRoomNumber = Random.Range(7,10);
    private bool spawned = false;
    private bool finalRoomSpawned = false;

    public float waitTimeFinalRoom = 2.8f;

    
    void Start()
    {
        roomTemp = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemp>();
        tunnelTemp = GameObject.FindGameObjectWithTag("Tunnels").GetComponent<TunnelTemp>();
        if(openingDirection == 5)
        {
            random = Random.Range(0,roomTemp.startingRooms.Length);
                Instantiate(roomTemp.startingRooms[random], transform.position, roomTemp.startingRooms[random].transform.rotation);
        }
        if(roomTemp.roomsList.Count < 10)
        {
            Invoke("Spawn", 0.05f);//Start Function but with delay so all rooms don't spawn simultaneously, breaking the game.
        }
    }

    void Spawn()
    {
            if(spawned == false)
            {
                //Spawn Rooms:
                if(openingDirection == 1) 
                {
                    random = Random.Range(0,roomTemp.northRooms.Length);
                    Instantiate(roomTemp.northRooms[random], transform.position, roomTemp.northRooms[random].transform.rotation);
                } else if(openingDirection == 2)
                {
                    random = Random.Range(0,roomTemp.eastRooms.Length);
                    Instantiate(roomTemp.eastRooms[random], transform.position, roomTemp.eastRooms[random].transform.rotation);
                } else if(openingDirection == 3)
                {
                    random = Random.Range(0,roomTemp.southRooms.Length);
                    Instantiate(roomTemp.southRooms[random], transform.position, roomTemp.southRooms[random].transform.rotation);
                } else if(openingDirection == 4)
                {
                    random = Random.Range(0,roomTemp.westRooms.Length);
                    Instantiate(roomTemp.westRooms[random], transform.position, roomTemp.westRooms[random].transform.rotation);

                //Spawn Starting Rooms:
                } else if(openingDirection == 6) 
                {
                    random = Random.Range(0,roomTemp.startingNorthRooms.Length);
                    Instantiate(roomTemp.startingNorthRooms[random], transform.position, roomTemp.startingNorthRooms[random].transform.rotation);
                } else if(openingDirection == 7)
                {
                    random = Random.Range(0,roomTemp.startingEastRooms.Length);
                    Instantiate(roomTemp.startingEastRooms[random], transform.position, roomTemp.startingEastRooms[random].transform.rotation);
                } else if(openingDirection == 8)
                {
                    random = Random.Range(0,roomTemp.startingSouthRooms.Length);
                    Instantiate(roomTemp.startingSouthRooms[random], transform.position, roomTemp.startingSouthRooms[random].transform.rotation);
                } else if(openingDirection == 9)
                {
                    random = Random.Range(0,roomTemp.startingWestRooms.Length);
                    Instantiate(roomTemp.startingWestRooms[random], transform.position, roomTemp.startingWestRooms[random].transform.rotation);
                
                //Spawn Tunnels:
                } else if (openingDirection == 10)
                {
                    random = Random.Range(0,tunnelTemp.verticalTunnels.Length);
                    Instantiate(tunnelTemp.verticalTunnels[random], transform.position, tunnelTemp.verticalTunnels[random].transform.rotation);
                } else if(openingDirection == 11)
                {
                    random = Random.Range(0,tunnelTemp.horizontalTunnels.Length);
                    Instantiate(tunnelTemp.horizontalTunnels[random], transform.position, tunnelTemp.horizontalTunnels[random].transform.rotation);
                } 
                spawned = true;
            }
    }

    void Update()
    {

        if(roomTemp.roomsList.Count >= 10 && waitTimeFinalRoom <= 0 && finalRoomSpawned == false)
        {
            if(openingDirection == 1) 
                {
                    random = Random.Range(0,roomTemp.finalNorthRooms.Length);
                    Instantiate(roomTemp.finalNorthRooms[random], transform.position, roomTemp.finalNorthRooms[random].transform.rotation);
                } else if(openingDirection == 2)
                {
                    random = Random.Range(0,roomTemp.finalEastRooms.Length);
                    Instantiate(roomTemp.finalEastRooms[random], transform.position, roomTemp.finalEastRooms[random].transform.rotation);
                } else if(openingDirection == 3)
                {
                    random = Random.Range(0,roomTemp.finalSouthRooms.Length);
                    Instantiate(roomTemp.finalSouthRooms[random], transform.position, roomTemp.finalSouthRooms[random].transform.rotation);
                } else if(openingDirection == 4)
                {
                    random = Random.Range(0,roomTemp.finalWestRooms.Length);
                    Instantiate(roomTemp.finalWestRooms[random], transform.position, roomTemp.finalWestRooms[random].transform.rotation);
                }
                finalRoomSpawned = true;
                waitTimeFinalRoom = waitTimeFinalRoom;
        } else
        {
            waitTimeFinalRoom -= Time.deltaTime;
        }
    }

    void SpawnFinalRoom()
    {
                
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(roomTemp.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}

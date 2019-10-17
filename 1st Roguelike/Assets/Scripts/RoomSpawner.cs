using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    private RoomTemp templates;
    private int random;
    private bool spawned = false;
    public float spawnedRooms = 0;

    void Start(){
        
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemp>();
        if(openingDirection == 5)
        {
            random = Random.Range(0,templates.startingRooms.Length);
                Instantiate(templates.startingRooms[random], transform.position, templates.startingRooms[random].transform.rotation);
                spawnedRooms++;
        }
                Invoke("Spawn", 0.3f);//Start Function but with delay so all rooms don't spawn simultaneously, breaking the game.
    }

    void Spawn()
    {
            if(spawned == false)
            {
                if(openingDirection == 1) 
                {
                    random = Random.Range(0,templates.northRooms.Length);
                    Instantiate(templates.northRooms[random], transform.position, templates.northRooms[random].transform.rotation);
                } else if(openingDirection == 2)
                {
                    random = Random.Range(0,templates.eastRooms.Length);
                    Instantiate(templates.eastRooms[random], transform.position, templates.eastRooms[random].transform.rotation);
                } else if(openingDirection == 3)
                {
                    random = Random.Range(0,templates.southRooms.Length);
                    Instantiate(templates.southRooms[random], transform.position, templates.southRooms[random].transform.rotation);
                } else if(openingDirection == 4)
                {
                    random = Random.Range(0,templates.westRooms.Length);
                    Instantiate(templates.westRooms[random], transform.position, templates.westRooms[random].transform.rotation);
                } else if(openingDirection == 6) 
                {
                    random = Random.Range(0,templates.startingNorthRooms.Length);
                    Instantiate(templates.startingNorthRooms[random], transform.position, templates.startingNorthRooms[random].transform.rotation);
                } else if(openingDirection == 7)
                {
                    random = Random.Range(0,templates.startingEastRooms.Length);
                    Instantiate(templates.startingEastRooms[random], transform.position, templates.startingEastRooms[random].transform.rotation);
                } else if(openingDirection == 8)
                {
                    random = Random.Range(0,templates.startingSouthRooms.Length);
                    Instantiate(templates.startingSouthRooms[random], transform.position, templates.startingSouthRooms[random].transform.rotation);
                } else if(openingDirection == 9)
                {
                    random = Random.Range(0,templates.startingWestRooms.Length);
                    Instantiate(templates.startingWestRooms[random], transform.position, templates.startingWestRooms[random].transform.rotation);
                }
                spawned = true;
                spawnedRooms++;
            }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}

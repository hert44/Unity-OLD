using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemp templates;

    void Start()
    {

        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemp>();
        templates.roomsList.Add(this.gameObject);
    }

}

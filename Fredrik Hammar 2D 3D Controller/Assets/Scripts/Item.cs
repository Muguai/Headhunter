﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int ID;
    public string type;
    public string description;
    public Sprite icon;

    public bool pickedUp;
    public bool equipped;

    public void Update()
    {
        if(equipped)
        {
            // items do stuff here

        }
    }


    public void ItemUsage()
    {
        // Different item types
        if(type == "Pengaboll")
        {
            equipped = true;
        }

    }

}

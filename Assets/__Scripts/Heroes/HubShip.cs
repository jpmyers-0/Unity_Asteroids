﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubShip : Hero
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Fire
        if (Input.GetAxis("Jump") == 1 && fireDelegate != null)
        {
            fireDelegate();
        }
    }

    

    
}
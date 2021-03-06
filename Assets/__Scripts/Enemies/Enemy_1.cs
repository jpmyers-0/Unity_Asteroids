﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    [Header("Set in Inspector: Enemy_1")]
    public float waveFrequency = 2; //# seconds for a full sine wavepublic float 
    public float waveWidth = 4; //sine wave width in meters
    public float waveRotY = 45;

    private float x0; //initial x value of pos
    private float birthTime;

    void Start()
    {
        x0 = pos.x;
        birthTime = Time.time;
    }

    private void Update()
    {
        Move();
        if (showingDamage && Time.time > damageDoneTime)
        {
            UnShowDamage();
        }
        if (bndCheck != null && !bndCheck.isOnScreen)
        {
            Main.S.enemyCount--;
            Destroy(gameObject);

        }
    }

    public override void Move()
    {
        Vector3 tempPos = pos;
        float age = Time.time - birthTime;
        float theta = Mathf.PI * 2 * age / waveFrequency;
        float sin = Mathf.Sin(theta);
        tempPos.x = x0 + waveWidth * sin;
        pos = tempPos;

        Vector3 rot = new Vector3(0, sin * waveRotY, 0);
        transform.rotation = Quaternion.Euler(rot);

        base.Move();
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = .1f;
    public float waveTime = 10f;

    private int count;
    private float timer;
    private float waveTimer;
    private int childCount;
    private List<Vector3> spawnPos = new List<Vector3>();

    private void Awake()
    {
        childCount = transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            spawnPos.Add(transform.GetChild(i).position);
        }
    }

    private void Start()
    {
        count = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        waveTimer += Time.deltaTime;

        if (timer > waveTimer)
        {
            count++;
        }
        
        if (timer > spawnRate)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        timer = 0;

        int random = Random.Range(0, childCount);
        Instantiate(enemy, spawnPos[random], Quaternion.LookRotation(-spawnPos[random]));
    }
}

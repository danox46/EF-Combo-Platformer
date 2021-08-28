using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwam : MonoBehaviour
{
    private float spawmTimer;
    [SerializeField] private float spawmTime;
    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawmTimer = spawmTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawmTimer += Time.deltaTime;

        if(spawmTimer > spawmTime)
        {
            Instantiate(enemyPrefab, transform);
            spawmTimer = 0f;
        }
    }
}

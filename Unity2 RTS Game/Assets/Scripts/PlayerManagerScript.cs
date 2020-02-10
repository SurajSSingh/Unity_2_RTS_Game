using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerScript : MonoBehaviour
{
    public UnitScript unit;
    private int health;
    private float speed;
    private float attackDamage;
    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        health = unit.health;
        speed = unit.speed;
        attackDamage = unit.attackDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= unit.health/2)
        {
            spr.color = unit.healthyColor;
        }
        else
        {
            spr.color = unit.nearDeathColor;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "CustomObjects/Enemy")]
public class EnemyScript : ScriptableObject
{
    // Overrides the name attribute from ScriptableObject class
    public new string name;

    public int health;
    public int speed;
    public int damage;
    public Sprite healthySprite;
    public Sprite damagedSprite;
    public Sprite nearDeathSprite;
}

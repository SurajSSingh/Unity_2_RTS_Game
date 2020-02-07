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
    public int rotRate;
    public int damage;
    public float coolDown;
    public Color healthyColor;
    public Color damagedColor;
    public Color nearDeathColor;
    public List<string> targetTags;
}

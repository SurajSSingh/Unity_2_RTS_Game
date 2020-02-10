using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "CustomObjects/Unit")]
public class UnitScript : ScriptableObject
{
    public int health;
    public float speed;
    public float attackDamage;
    public Color healthyColor;
    public Color nearDeathColor;
    public List<string> targetTags;
    public Projectile projectile;
    public int cost;
}

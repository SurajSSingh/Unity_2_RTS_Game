using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject projectile;
    public EnemyScript self;
    public Animator anim;
    [SerializeField]
    private int currentHealth;
    private SpriteRenderer spr;
    private int healthyLevelHealth = 60;
    private int damagedLevelHealth = 30;
    public GameObject currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        currentHealth = self.health;
        FindNextTarget();
        //Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSprite();
        UpdateDistance();
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Shoot()
    {
        //Debug.Log("Shooting");
        Vector3 shoot_pos = transform.position + (transform.up*transform.lossyScale.y);
        GameObject new_proj = Instantiate(projectile, shoot_pos, transform.rotation);
        Vector2 direction = currentTarget.transform.position - transform.position;
        new_proj.GetComponent<ProjectileManager>().proj.damage = self.damage;
        new_proj.GetComponent<ProjectileManager>().SetDir(direction.normalized);
    }

    void UpdateSprite()
    {
        // Changes Sprite color
        if (currentHealth >= healthyLevelHealth)
        {
            spr.color = self.healthyColor;
        }
        else if (currentHealth >= healthyLevelHealth)
        {
            spr.color = self.damagedColor;
        }
        else
        {
            spr.color = self.nearDeathColor;
        }
    }

    public Quaternion GetDir()
    {
        Vector2 direction = currentTarget.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        return rot;
    }

    void UpdateDistance()
    {
        if (anim.GetBool("hasTarget"))
        {
            float distance = Vector3.Distance(transform.position, currentTarget.transform.position);
            anim.SetFloat("distanceToTarget", distance);
        }
        else
        {
            FindNextTarget();
        }
    }

    void FindNextTarget()
    {
        foreach (string objTag in self.targetTags)
        {
            if (GameObject.FindGameObjectsWithTag(objTag).Length != 0)
            {
                currentTarget = GameObject.FindGameObjectsWithTag(objTag)[0];
            }
        }

        if (currentTarget == null)
        {
            currentTarget = GameObject.FindGameObjectWithTag("Player");
        }
        if (currentTarget != null)
        {
            anim.SetBool("hasTarget", true);
        }
        else
        {
            anim.SetBool("hasTarget", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")
            && !collision.gameObject.gameObject.GetComponent<ProjectileManager>().proj.attackTag.Contains(this.gameObject.tag))
        {
            currentHealth -= collision.gameObject.GetComponent<ProjectileManager>().proj.damage;
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBaseScript : MonoBehaviour
{
    public Text playerHealthText;
    public Text playerResourcesText;
    [SerializeField]
    private int health = 1000;
    [SerializeField]
    private int resources = 100;
    private float resourseCoolDown = 10f;
    private float timerCoolDown;
    private int resourcesIncrease = 100;

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "Health: " + health.ToString();
        playerResourcesText.text = "Scraps: " + resources.ToString();
        if (timerCoolDown <= 0f)
        {
            timerCoolDown = resourseCoolDown;
            resources += resourcesIncrease;
        }
        else
        {
            timerCoolDown -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= collision.gameObject.GetComponent<ProjectileManager>().proj.damage;
            Destroy(collision.gameObject);
        }
    }
}

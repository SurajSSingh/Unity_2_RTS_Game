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
    private float resourseCoolDown = 4f;
    private float timerCoolDown;
    private int resourcesIncrease = 100;
    [SerializeField]
    private int currentUnit = 0;
    public Dropdown unitDropDown;
    public List<GameObject> unitList;

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
        if (health <= 0)
        {
            Destroy(this.gameObject);
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

    public void BuyUnit()
    {
        // Spawn the units using selection
        if (unitList[currentUnit].GetComponent<PlayerManagerScript>().unit.cost <= resources)
        {
            resources -= unitList[currentUnit].GetComponent<PlayerManagerScript>().unit.cost;
            SpawnUnit();
            playerResourcesText.text = "Scraps: " + resources.ToString();
        }
    }

    public void SelectUnitToBuy()
    {
        currentUnit = unitDropDown.value;
    }

    Vector2 RandomPostion()
    {
        Vector3 randPos = Random.onUnitSphere * Random.Range(5, 6);
        return this.transform.position + randPos;
    }

    void SpawnUnit()
    {
        GameObject temp = Instantiate(unitList[currentUnit], this.transform.parent.parent);
        temp.transform.position = RandomPostion();
    }
}

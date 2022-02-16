using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    public static bool initial = true;

    static int level;
    public static int lives;
    public static int score;
    public static int ships;
    public static bool dead;

    public GameObject chaserPre;
    public GameObject shooterPre;
    public Transform player;

    public int shipCount = 8;
    public int remaining;
    public int clumpSize = 4;

    public float spawnDelayMod = 1.5f;
    float spawnDelay = 6f;
    float nextSpawn;

    public PauseEnd canvas;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI levelTxt;
    public TextMeshProUGUI livesTxt;

    public Sprite explosion;

    void Start()
    {
        if (initial)
        {
            score = 0;
            lives = 3;
            level = 1;

            initial = false;
        }
        ships = shipCount;
        remaining = shipCount;
        nextSpawn = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString();
        livesTxt.text = "Lives: " + lives.ToString();
        levelTxt.text = "Level: " + level.ToString();

        if (dead)
        {
            PlayerDeath();
        }

        if (ships == 0)
        {
            level++;
            score += 10;
            shipCount += 3;
            ships = shipCount;
            remaining = shipCount;
            if (level % 2 == 1)
            {
                lives++;
            }
            if (transform.childCount > clumpSize && level % 2 == 1)
            {
                clumpSize++;
            }
            spawnDelay = clumpSize * spawnDelayMod;
            nextSpawn = Time.time + spawnDelay;

        }
        else if (nextSpawn <= Time.time)
        {
            int[] pos = new int[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                pos[i] = i;
            }
            List<int> pos2 = new List<int>(pos);
            int count = clumpSize;
            if (remaining < clumpSize)
            {
                count = remaining;
            }
            for (int i = 0; i < count; i++)
            {
                int choice = Random.Range(0, 2);
                GameObject newShip;
                int loc = Random.Range(0, pos2.Count);
                if (choice == 0)
                {

                    newShip = Instantiate(chaserPre, transform.GetChild(pos2[loc]).position, Quaternion.identity);
                    newShip.GetComponent<AIChasers>().target = player;
                }
                else
                {
                    newShip = Instantiate(shooterPre, transform.GetChild(pos2[loc]).position, Quaternion.identity);
                    newShip.GetComponent<AIShooters>().player = player;
                }
                pos2.Remove(loc);
                newShip.transform.parent = null;
                remaining--;
            }
            nextSpawn = Time.time + spawnDelay;
        }
    }

    public void PlayerDeath()
    {
        player.GetComponent<SpriteRenderer>().sprite = explosion;
        Destroy(player.GetComponent<Movement>());
        Destroy(player.GetComponent<Shoot>());
        Destroy(player.GetComponent<CircleCollider2D>());
        lives--;
        dead = false;
        if (lives == 0)
        {
            initial = true;
            canvas.End();
        }
        else
        {
            //DEATH ANIMATION?
            Invoke("Reload", 1.5f);
        }
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }
}

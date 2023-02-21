using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    //object spawn
    public GameObject Butter;
    //place spawn
    public float Xrangemin;
    public float Xrangemax;
    public float Zrangemin;
    public float Zrangemax;

    public int waven; //number of the wave

    private float enemyn;

    private bool spawningWave;

    public int maxenemy;
   
   private int enemyspawn;

    [SerializeField]
    public EnemyScript EnemyScripts;


    private bool endwave;

    // Update is called once per frame
    void Start()
    {
        waven = 1;
        spawningWave = false;
        endwave = true;
    }

    void Update()
    {

        if(endwave == true && spawningWave == false)
        {
            if (enemyn < maxenemy)
            {
                //wave enemy
                Vector3 RandomPlanePosition = new Vector3(Random.Range(Xrangemin, Xrangemax), 5, Random.Range(Zrangemin, Zrangemax));

             if (Instantiate(Butter, RandomPlanePosition, Quaternion.identity))
                {
                    enemyn = enemyn + 1;
                    enemyspawn = enemyspawn + 1;
                }

                spawningWave = true;
            
            }
        }



        if (spawningWave == false)
        {
            //wavy number
            waven = waven + 1;

            maxenemy = maxenemy * 2;

        }
        
        if(enemyspawn == EnemyScripts.enemykill)
        {
            endwave = true;
           
        }
    }
}

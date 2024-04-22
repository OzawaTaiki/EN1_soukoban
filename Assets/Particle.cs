using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class particle : MonoBehaviour
{

    //ï`âÊÇ∑ÇÈéûä‘
    private float lifeTime;
    //écÇËéûä‘
    private float leftLifeTime;
    //ë¨ìx
    private Vector3 velocity;
    //èâä˙ÇÃíl
    private Vector3 defaultScale;



    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0.3f;
        leftLifeTime = lifeTime;
        defaultScale = transform.localScale;
        float maxVelocity = 3;
        velocity = new Vector3
            (
            Random.Range(-maxVelocity, maxVelocity),
            Random.Range(-maxVelocity, maxVelocity),
            0
            );


    }

    // Update is called once per frame
    void Update()
    {
        leftLifeTime -= Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        transform.localScale = Vector3.Lerp
            (
                new Vector3(0, 0, 0),
                defaultScale,
                leftLifeTime / lifeTime
            );

        if (leftLifeTime <= 0) { Destroy(gameObject); }
    }
}

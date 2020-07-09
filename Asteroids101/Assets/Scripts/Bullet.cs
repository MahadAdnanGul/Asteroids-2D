using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Timers;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class Bullet : MonoBehaviour
{
    const float death = 2f;
    Timer timed;
   

    // Start is called before the first frame update
    void Start()
    {
        timed = GetComponent<Timer>();
        timed.Duration = death;
        timed.Run();

    }

    // Update is called once per frame
    void Update()
    {
        if(timed.Finished)
        {
            Destroy(gameObject);
        }
        
    }


    public void applyforce(Vector2 direction)
    {
        float mag = 12f;
        Rigidbody2D r2d = gameObject.GetComponent<Rigidbody2D>();
        r2d.AddForce(mag * direction, ForceMode2D.Impulse);
    }
}

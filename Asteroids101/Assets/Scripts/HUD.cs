using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{


    [SerializeField]
    Text score;
    float elapsed = 0;
    bool isrunning = true;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "0" ;
    }

    // Update is called once per frame
    void Update()
    {
        if(isrunning)
        {
            elapsed += Time.deltaTime;
            int disp = (int)elapsed;
            score.text = disp.ToString();
        }

        
    }

    public void Stoptimer()
    {
        isrunning = false;
    }
}

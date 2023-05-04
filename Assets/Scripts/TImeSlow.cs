using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TImeSlow : MonoBehaviour
{
    public bool Slowed;
    public Movment Player;
   


    // Start is called before the first frame update

    void Start()
    {
        Slowed = false;
       




    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Q) && Slowed == false)
        {
                Slowed = true;
            Time.timeScale = 0.001f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            
            Player.movementSpeed = 2500f;
            
   
            
 


           
        }
        else if (Input.GetKeyDown(KeyCode.Q) && Slowed == true)
        {
                Slowed = false;
            Time.timeScale = 1f;
             Time.fixedDeltaTime = 0.02F ;
            Player.movementSpeed = 5f;




        }


    }




}

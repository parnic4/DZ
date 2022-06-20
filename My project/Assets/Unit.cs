using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int health;
    public float time;
    private void Start()
    {
        ReceiveHealing();
    }

    private void Update()
    {
        if (health == 100)
        {
            StopAllCoroutines(); 
        }
    }


    public void ReceiveHealing()
    {
        StartCoroutine(Timer());
    }

    IEnumerator HilCor()
    {
       
            health += 5;
            Debug.Log("5Hp");
            yield return new WaitForSeconds(0.5f);
       

        
          
    } 
    IEnumerator Timer()
    {
        for (int i = 0; i < 6; i++)
        {
            StartCoroutine(HilCor());
            time+= 0.5f;
            Debug.Log("Time");
            yield return new WaitForSeconds(0.5f);
        }
            
       
       
    }
    

}


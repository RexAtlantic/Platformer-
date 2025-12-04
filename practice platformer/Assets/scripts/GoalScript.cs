using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalScript : MonoBehaviour
{
    //variables
    

   private void OnTriggerEnter2D(Collider2D collision)
   {

    Destroy(gameObject);
   }
}

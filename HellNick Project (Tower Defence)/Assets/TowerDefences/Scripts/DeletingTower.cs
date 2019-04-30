using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletingTower : MonoBehaviour
{
    private GameObject tower;

    public void DeleteBurger()
    {
      if (tower == null)
      {
         tower = GameObject.FindWithTag("Tower");
         Destroy(tower);
      }
    }    
}

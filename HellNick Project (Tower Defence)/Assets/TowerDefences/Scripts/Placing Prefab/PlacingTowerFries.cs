using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingTowerFries : MonoBehaviour
{

    public Transform towerParent;
    public int currentTower = 0;
    public GameObject[] towers;
    public GameObject[] holograms;

    void OnDrawGizmos()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawLine(mouseRay.origin, mouseRay.origin + mouseRay.direction * 1000f);

        Gizmos.color = Color.blue;

    }


    // all  the holograms need to be disabled because they are unused
    void DisableAllHolograms()
    {
        // Loop through all holograms
        foreach (var holo in holograms)
        {
            // each holograms inside holograms array are disabled
            holo.SetActive(false);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (AllManager.Lives <= 0)
        {
            return;
        }

        // Disable all holograms at the start of each frame
        DisableAllHolograms();

        // Ray --> getting the player to be able to choose where to place the tower
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // This is what the raycast do
        if (Physics.Raycast(mouseRay, out hit))
        {
            // where the raycast wants to hit
            TowerPlace place = hit.collider.GetComponent<TowerPlace>();

            // if the place where the raycast wants to hit has no tower then just place a tower there
            if (place && place.noTower)
            {
                // (JUST HOVERING)
                // Get all the unused hologram towers that is inside holograms array
                GameObject hologram = holograms[currentTower];
                // Activate hologram
                hologram.SetActive(true);
                // Position hologram on top of the tops pivotpoint
                hologram.transform.position = place.PlacingTheTower();

                if (AllManager.Money < 30)
                {
                    hologram.SetActive(false);
                }

                // (ACTUAL PLACING TOWER)
                // if left mouse is pressed
                if (Input.GetMouseButtonDown(0))
                {
                    if(AllManager.Money >= 30)
                    {
                        // Get the actual tower prefab from towers array
                        GameObject towerPrefab = towers[currentTower];
                        // Spawn a new tower
                        GameObject tower = Instantiate(towerPrefab, towerParent);
                        // Position new tower to tops
                        tower.transform.position = place.PlacingTheTower();
                        // Top is no longer placeable
                        place.noTower = false;

                        AllManager.Money -= 30;
                    }
                    else
                    {
                        AllManager.Money = 0;
                    }

                }
            }
        }
    }
}

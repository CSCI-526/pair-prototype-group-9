using UnityEngine;

public class MultipleControl : MonoBehaviour
{
    public GameObject fatherGrid;
    public GameObject sonGrid;
    public GameObject sonGridBorder;


    void Update()
    {
        if (fatherGrid != null)
        {
            GridMovement gridMovement = fatherGrid.GetComponent<GridMovement>();

            if (gridMovement != null)
            {
                if (!gridMovement.enabled)
                {
                    PerformActionDisable();
                }
                if (gridMovement.enabled)
                {
                    PerformActionEnable();
                }
            }
            else
            {
                // Debug.LogWarning("GridMovement component not found on redGrid!");
            }
        }
        else
        {
            // Debug.LogError("redGrid is not assigned in the Inspector!");
        }
    }

    void PerformActionDisable()
    {
        // Debug.Log("GridMovement is disabled on redGrid. Performing action...");
        sonGridBorder.SetActive(false);
    }
    void PerformActionEnable()
    {
        // Debug.Log("GridMovement is enabled on redGrid. Performing action...");
        sonGridBorder.SetActive(true);

    }
}


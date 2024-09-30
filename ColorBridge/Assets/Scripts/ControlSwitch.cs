using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSwitch : MonoBehaviour
{
    public GameObject player;
    public GameObject redGrid;
    public GameObject blueGrid;

    public GameObject playerBorder;
    public GameObject redGridBorder;
    public GameObject blueGridBorder;

    private enum ControlMode { Player, RedGrid, BlueGrid }
    private ControlMode currentMode = ControlMode.Player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentMode = (ControlMode)(((int)currentMode + 1) % 3);
        }

        switch (currentMode)
        {
            case ControlMode.Player:
                player.GetComponent<GridMovement>().enabled = true;
                redGrid.GetComponent<GridMovement>().enabled = false;
                blueGrid.GetComponent<GridMovement>().enabled = false;

                playerBorder.SetActive(true);
                redGridBorder.SetActive(false);
                blueGridBorder.SetActive(false);
                break;

            case ControlMode.RedGrid:
                player.GetComponent<GridMovement>().enabled = false;
                redGrid.GetComponent<GridMovement>().enabled = true;
                blueGrid.GetComponent<GridMovement>().enabled = false;

                playerBorder.SetActive(false);
                redGridBorder.SetActive(true);
                blueGridBorder.SetActive(false);
                break;

            case ControlMode.BlueGrid:
                player.GetComponent<GridMovement>().enabled = false;
                redGrid.GetComponent<GridMovement>().enabled = false;
                blueGrid.GetComponent<GridMovement>().enabled = true;

                playerBorder.SetActive(false);
                redGridBorder.SetActive(false);
                blueGridBorder.SetActive(true);
                break;
        }
    }
}
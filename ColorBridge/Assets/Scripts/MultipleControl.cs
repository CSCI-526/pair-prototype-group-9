using UnityEngine;

public class MultipleControl : MonoBehaviour
{
    public GameObject fatherGrid;
    public GameObject sonGrid;
    public GameObject sonGridBorder;

    public Color targetColor = new Color(0.49f, 0.0f, 1.0f, 1.0f);

    public float tolerance = 0.01f;

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
                    if (sonGrid != null)
                    {
                        SpriteRenderer spriteRenderer = sonGrid.GetComponent<SpriteRenderer>();
                        if (spriteRenderer != null)
                        {
                            Color spriteColor = spriteRenderer.color;
                            if (ColorsAreClose(spriteColor, targetColor, tolerance))
                            {
                                PerformActionDisable();
                                // Debug.Log("目标对象的 Sprite 颜色是 RGBA(0.49, 0.0, 1.0, 1.0)。");
                            }
                            else
                            {
                                PerformActionEnable();
                                // Debug.Log("目标对象的 Sprite 颜色不是 RGBA(0.49, 0.0, 1.0, 1.0)。");
                            }
                        }
                    }
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

    bool ColorsAreClose(Color color1, Color color2, float tolerance)
    {
        return Mathf.Abs(color1.r - color2.r) < tolerance &&
               Mathf.Abs(color1.g - color2.g) < tolerance &&
               Mathf.Abs(color1.b - color2.b) < tolerance &&
               Mathf.Abs(color1.a - color2.a) < tolerance;
    }
}


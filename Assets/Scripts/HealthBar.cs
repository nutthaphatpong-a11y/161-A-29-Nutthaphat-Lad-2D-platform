using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    private Transform target;
    private Vector3 offset = new Vector3(0, 1.2f, 0);

    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
    }

    public void UpdateHealthBar(float current, float max)
    {
        fillImage.fillAmount = current / max;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 1.5f, 0);

    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
    }

    public void UpdateHealthBar(float current, float max)
    {
        if (fillImage != null)
            fillImage.fillAmount = current / max;
    }

    void Update()
    {
        if (target != null)
        {
            
            transform.position = target.position + offset;
            transform.LookAt(Camera.main.transform); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

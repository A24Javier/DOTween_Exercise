using UnityEngine;
using DG.Tweening;

public class CubeJump : MonoBehaviour
{
    private Vector3 startPoint;
    [SerializeField] private Transform destination;

    void Start()
    {
        startPoint = gameObject.transform.position;
    }

    public void ResetPosition()
    {
        transform.position = startPoint;
    }

    public void Move()
    {
        transform.DOJump(destination.position, 3f, 1, 2f);
    }
}

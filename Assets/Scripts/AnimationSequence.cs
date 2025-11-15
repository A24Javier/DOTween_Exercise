using UnityEngine;
using DG.Tweening;

public class AnimationSequence : MonoBehaviour
{
    [SerializeField] private Transform cubeA;
    [SerializeField] private Transform cubeB;

    [SerializeField] private Transform targetA;
    [SerializeField] private Transform targetB;

    private Vector3 startA;
    private Vector3 startB;

    void Start()
    {
        startA = cubeA.position;
        startB = cubeB.position;
    }

    public void ResetPosition()
    {
        cubeA.position = startA;
        cubeB.position = startB;

        cubeA.rotation = Quaternion.Euler(Vector3.zero);
        
        cubeB.localScale = Vector3.one;
    }

    public void PlaySequence()
    {
        Sequence seq = DOTween.Sequence();

        // Ambos cubos van a una posicion
        seq.Append(cubeA.DOMove(targetA.position, 1f));
        seq.Join(cubeB.DOMove(targetB.position, 1f));

        // Ambos cubos saltan
        seq.Append(cubeA.DOJump(targetA.position, 2f, 1, 0.8f));
        seq.Join(cubeB.DOJump(targetB.position, 2f, 1, 0.8f));

        // Un cubo rota y el otro salta
        seq.Append(cubeA.DORotate(new Vector3(0, 180, 0), 1f));
        seq.Join(cubeB.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f));

        // Vuelven a su posicion inicial
        seq.Append(cubeA.DOMove(startA, 1f));
        seq.Join(cubeA.DORotate(new Vector3(0, -180, 0), 1f));
        seq.Join(cubeB.DOMove(startB, 1f));

        // Vuelven a saltar
        seq.Append(cubeA.DOJump(startA, 1f, 1, 0.5f));
        seq.Join(cubeB.DOJump(startB, 1f, 1, 0.5f));
    }
}

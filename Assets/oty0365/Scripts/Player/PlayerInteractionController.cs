using System.Collections;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 2f;
    [SerializeField] private float detectionInterval = 0.2f;
    [SerializeField] private LayerMask interactionLayer;

    private IInteractable _closestInteractable;
    private Coroutine _detectionCoroutine;

    private void Start()
    {
        StartDetection();
    }
    private void Update()
    {
        print(_closestInteractable);
    }

    public void StartDetection()
    {
        StopDetection();
        _detectionCoroutine = StartCoroutine(DetectionCoroutine());
    }

    public void StopDetection()
    {
        if (_detectionCoroutine == null) return;
        StopCoroutine(_detectionCoroutine);
        _detectionCoroutine = null;
        _closestInteractable = null;
    }

    private IEnumerator DetectionCoroutine()
    {
        var interval = new WaitForSeconds(detectionInterval);

        while (true)
        {
            DetectClosest();
            yield return interval;
        }
    }

    private void DetectClosest()
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius, interactionLayer);

        if (hits.Length == 0)
        {
            _closestInteractable = null;
            return;
        }

        IInteractable closest = null;
        float closestDistance = float.MaxValue;

        foreach (var hit in hits)
        {
            if (!hit.TryGetComponent<IInteractable>(out var interactable)) continue;

            float distance = Vector2.Distance(transform.position, hit.transform.position);
            if (distance >= closestDistance) continue;

            closestDistance = distance;
            closest = interactable;
        }

        _closestInteractable = closest;
    }
}
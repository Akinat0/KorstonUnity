using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class InteractableObject : MonoBehaviour
{
    [SerializeField] UnityEvent onMouseDownEvent;
    [SerializeField] ApartmentsController controller;
    [SerializeField] float interactionTime = 3;
    [SerializeField] SpriteRenderer progress;

    public UnityEvent OnMouseDownEvent => onMouseDownEvent;
    
    void OnMouseDown()
    {
        Communication.SendMessageToFlutter("Click on " + gameObject.name);
        
        if (!controller.CurrentInteractable)
        {
            onMouseDownEvent?.Invoke();
            StartCoroutine(InteractionRoutine());
        }
    }


    IEnumerator InteractionRoutine()
    {
        controller.CurrentInteractable = this;
        
        float time = 0;
        
        while (time < interactionTime)
        {
            time += Time.deltaTime;
        
            float phase = time / interactionTime;

            float sin = Mathf.Sin(time * 5);
            
            transform.localScale = Vector3.one * (1 + sin * sin * 0.2f);
            yield return null;
        }

        transform.localScale = Vector3.one;
        controller.CurrentInteractable = null;
    }
}
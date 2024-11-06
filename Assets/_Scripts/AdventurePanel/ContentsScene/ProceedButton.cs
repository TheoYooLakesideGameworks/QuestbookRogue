using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProceedButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [Header("Current Action Content Data")]
    [SerializeField] public QuestSO currentQuestData;
    [SerializeField] public ContentSO currentActionContentData;

    [Header("Button Sprites")]
    [SerializeField] private Sprite defaultProceedButton;
    [SerializeField] private Sprite activatedProceedButton;
    [SerializeField] private Sprite mouseOverProceedButton;
    [SerializeField] private Sprite mouseDownProceedButton;

    private void OnEnable()
    {
        GetComponent<Image>().raycastTarget = false;
    }

    public void ActivateButton()
    {
        GetComponent<Image>().sprite = activatedProceedButton;
        GetComponent<Image>().raycastTarget = true;
    }

    public void DeActivateButton()
    {
        GetComponent<Image>().sprite = defaultProceedButton;
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = mouseOverProceedButton;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = activatedProceedButton;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = mouseDownProceedButton;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = activatedProceedButton;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        List<PaySlot> notThisPaySlots = new List<PaySlot>(transform.parent.parent.GetComponentsInChildren<PaySlot>());
        List<PaySlot> parentPaySlots = new List<PaySlot>(transform.parent.GetComponentsInChildren<PaySlot>());
        notThisPaySlots.RemoveAll(slot => parentPaySlots.Contains(slot));
        for (int i = 0; i < notThisPaySlots.Count; i++)
        {
            notThisPaySlots[i].ProceedNotThisPayment();
        }

        SceneController.Instance.TransitionToRewards(currentQuestData, currentActionContentData);
    }
}
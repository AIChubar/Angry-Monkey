using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ServiceLocator.UI
{
    public class MonkeyImageHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        private Image monkeyImage;
        private MonkeyCellController owner;
        private Sprite spriteToSet;
        private RectTransform rectTransform;
        private Vector3 originalPosition;
        private Vector3 originalAnchoredPosition;
        public void ConfigureImageHandler(Sprite spriteToSet, MonkeyCellController owner)
        {
            this.spriteToSet = spriteToSet;
            this.owner = owner;
        }

        private void Awake()
        {
            monkeyImage = GetComponent<Image>();
            rectTransform  = GetComponent<RectTransform>();
            monkeyImage.sprite = spriteToSet;
            originalPosition = rectTransform.position;
            originalAnchoredPosition = rectTransform.anchoredPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta;
            owner.MonkeyDraggedAt(rectTransform.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            ResetMonkeyImage();
            owner.MonkeyDroppedAt(eventData.position);
        }

        private void ResetMonkeyImage()
        {
            monkeyImage.color = Color.white;
            rectTransform.position = originalPosition;
            rectTransform.anchoredPosition = originalAnchoredPosition;
            GetComponent<LayoutElement>().enabled = false;
            GetComponent<LayoutElement>().enabled = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            monkeyImage.color = new Color(1f, 1f, 1f, 0.6f);
        }
    }
}
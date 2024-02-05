using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class Tab : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField]
        private TabManager tabManager;
        private int indexManager;

        [SerializeField]
        private Image img;

        [SerializeField]
        private Sprite spriteSelect;

        [SerializeField]
        private Sprite spriteUnselect;

        [SerializeField]
        private GameObject screen;


        public void Awake()
        {
            indexManager = tabManager.AddTab(this);
        }

        public void Select(bool select)
        {
            img.sprite = select ? spriteSelect : spriteUnselect;
            screen.SetActive(select);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (screen != null && !screen.activeSelf)
            {
                tabManager.ChangeTab(this, indexManager);
            }
        }
    }
}

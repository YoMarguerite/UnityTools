using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class TabManager : MonoBehaviour
    {
        public List<Tab> tabs;
        private int activeIndex;

        private void Start()
        {
            CloseTabs();
            if(tabs.Count > 0)
            {
                activeIndex = 0;
                tabs[activeIndex].Select(true);
            }
        }

        public int AddTab(Tab tab)
        {
            tabs.Add(tab);
            return tabs.Count - 1;
        }

        public void ChangeTab(Tab tab, int index)
        {
            tabs[activeIndex].Select(false);
            tab.Select(true);
            activeIndex = index;
        }

        private void CloseTabs()
        {
            foreach (Tab tab in tabs)
            {
                tab.Select(false);
            }
        }
    }
}

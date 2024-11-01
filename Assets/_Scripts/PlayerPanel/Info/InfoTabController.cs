using UnityEngine;
using System;

public class InfoTabController : Singleton<InfoTabController>
{
    [SerializeField] private GameObject diceTab;
    [SerializeField] private GameObject skillTab;
    [SerializeField] private GameObject relicTab;
    [SerializeField] private GameObject logTab;

    [SerializeField] private DiceTabIndex diceTabIndex;
    [SerializeField] private SkillTabIndex skillTabIndex;

    private void Start()
    {
        DefaultSetTabs();

        diceTabIndex.OnDiceTabClicked += HandleDiceTabActivate;
        skillTabIndex.OnSkillTabClicked += HandleSkillTabActivate;
    }

    private void OnDestroy()
    {
        diceTabIndex.OnDiceTabClicked -= HandleDiceTabActivate;
        skillTabIndex.OnSkillTabClicked -= HandleSkillTabActivate;
    }

    public void HandleDiceTabActivate()
    {
        ResetTabs();

        if (skillTab.activeSelf == false)
        {
            diceTab.SetActive(true);
        }

        diceTabIndex.ActivateDiceTab();
    }

    public void HandleSkillTabActivate()
    {
        ResetTabs();

        if (skillTab.activeSelf == false)
        {
            skillTab.SetActive(true);
        }

        skillTabIndex.ActivateSkillTab();

    }

    private void DefaultSetTabs()
    {
        if (skillTab != null)
        {
            skillTab.SetActive(false);
        }
        if (diceTab != null)
        {
            diceTab.SetActive(true);
        }

        if (diceTabIndex != null)
        {
            diceTabIndex.ActivateDiceTab();
        }
        if (skillTabIndex != null)
        {
            skillTabIndex.DeActivateSkillTab();
        }
    }

    private void ResetTabs()
    {
        if (diceTab.activeSelf == true)
        {
            diceTab.SetActive(false);
        }
        if (skillTab.activeSelf == true)
        {
            skillTab.SetActive(false);
        }

        if (skillTabIndex != null)
        {
            skillTabIndex.DeActivateSkillTab();
        }
        if (diceTabIndex != null)
        {
            diceTabIndex.DeActivateDiceTab();
        }
    }
}

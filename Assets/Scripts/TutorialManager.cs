using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TutorialManager : Singleton<TutorialManager>
{
    public TutorialManager() : base(false, false) { }

    public bool InTutorial = false;

    public int tutorialStage = 0;

    public GameObject[] tutorialSteps;

    void Start()
    {
        InTutorial = true;
    }

    void Update()
    {
        for (int i = 0; i < tutorialSteps.Length; i++)
            tutorialSteps[i].SetActive(i == tutorialStage);

        if (tutorialStage < 4 && Input.GetMouseButtonUp(0)) //click through first ones
            tutorialStage++;
        else if (tutorialStage == 4 && FindObjectsOfType<Plant>().Any(p => p.DirtEnabled))
            tutorialStage++;
        else if (tutorialStage == 5 && FindObjectsOfType<Plant>().Any(p => p.CropEnabled))
            tutorialStage++;
        else if (tutorialStage == 6 && FindObjectsOfType<Plant>().Any(p => p.DirtWet))
            tutorialStage++;
        else if (tutorialStage == 7 && FindObjectsOfType<Plant>().Any(p => p.ReadyToHarvest))
            tutorialStage++;
        else if (tutorialStage == 8 && FindObjectsOfType<Plant>().Any(p => p.DirtEnabled && !p.CropEnabled))
        {
            tutorialStage++;
            GameManager.instance.ShowStartDayButton = true;
        } 
        else if (tutorialStage > 8 && Input.GetMouseButtonUp(0))
            tutorialStage++;
            
        if (tutorialStage >= 10)
        {
            InTutorial = false;
            gameObject.SetActive(false); //disable this
        }
    }
}

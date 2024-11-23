using TMPro; // Import for TextMeshPro support
using UnityEngine;
using UnityEngine.Events;
using System.Collections;  // Required for IEnumerator

public class TimeManager : MonoBehaviour
{
    public int currentDay = 1;
    public TextMeshProUGUI dayCounterText; // Reference to the Text UI for the day counter
    public UnityEvent OnNextDay;
    public Animator lightAnimator;
    public float nextDayCooldown = 1.2f; // Cooldown duration for button
    private bool isCooldown = false;

    private void Start()
    {
        UpdateDayText();
    }

    public void NextDay()
    {
        if (isCooldown) return;
        
        // Trigger the light animation
        lightAnimator.SetTrigger("StartDayCycle");

        // Start the cooldown
        StartCoroutine(Cooldown());
    }

    private void doAfterDayCycleAnimation()
    {
        currentDay++;
        OnNextDay.Invoke(); // This is what invokes the OnNextDay event, and causes all other commands that listen in on this event to run.
        UpdateDayText();

        // Objective
        ObjectivesManager.Instance.CompleteObjective(2);
    }

    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(nextDayCooldown);
        doAfterDayCycleAnimation();
        isCooldown = false;
    }

    private void UpdateDayText()
    {
        if (dayCounterText != null)
            dayCounterText.text = "Day " + currentDay;
    }
}

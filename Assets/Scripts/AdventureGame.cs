using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private State startingState;

    private State currentState;

    private void Start()
    {
        SetState(startingState);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        ManageState();
    }

    private void ManageState()
    {
        State[] nextStates = currentState.GetNextStates();

        for (int i = 0; i < nextStates.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SetState(nextStates[i]);
                break;
            }
        }
    }

    private void SetState(State nextState)
    {
        currentState = nextState;
        storyText.text = currentState.GetStateStory();
    }
}

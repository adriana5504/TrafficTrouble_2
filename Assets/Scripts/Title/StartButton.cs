using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerClickHandler
{
    // OnPointerClick
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("Scene");     // Use the scene manager to load the Game scene
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    
    public string startPoint;

    private void Awake()
    {
        if(Player.P_instance == null)
        {
            return;
        }
        Player.P_instance.gameObject.SetActive(false);
        if (Player.P_instance.currentSpot == gameObject.name)
        {
            Player.P_instance.transform.position = transform.position;
            Debug.Log("Player: "+Player.P_instance.transform.position);
            Debug.Log("transform: "+transform.position);
        }
        Player.P_instance.gameObject.SetActive(true);
    }
}

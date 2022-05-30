using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapChange : MonoBehaviour
{
    public GameObject spot;
    public string scene = ""; // 열거형 씬전환
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Player.P_instance.currentSpot = spot.name;
            SceneManager.LoadScene(scene);
        }
    }
}

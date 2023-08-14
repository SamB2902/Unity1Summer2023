using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static GameObject instance;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance!= null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this.gameObject;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

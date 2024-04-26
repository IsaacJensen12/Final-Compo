using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleRotAnim : MonoBehaviour
{
    public Transform OscObj;
    [SerializeField]
    float speed;
    public LibPdInstance pdPatch;
    [SerializeField]
    SongTimer SongTimer;
    void Start()
    {
        
    }

    
    void Update()
    {
        
        if (SongTimer.is_section_on[1])
        {
            pdPatch.SendBang("ArpOn");
            OscObj.transform.Rotate(0, 0, speed * Time.deltaTime, Space.Self);
        }
    }
}

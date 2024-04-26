using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongTimer : MonoBehaviour
{
    float t;
    [SerializeField]
    public int beatMS;
    [SerializeField]
    int timeSignature;
    int counterBeat;
    int counterBeatUnbound;
    int counterMeasure;
    float ramp;
    [SerializeField]
    List<int> sections;
    int Intro, Verse, Chorus, Verse2, Chorus2, End;
    [HideInInspector]
    public bool[] is_section_on;
    void Start()
    {
        Intro = sections[0];
        Verse = sections[0] + sections[1];
        Chorus = sections[0] + sections[1] + sections[2];
        Verse2 = Chorus + sections[3];
        Chorus2 = Verse2 + sections[4];
        End = Chorus2 + sections[5];
        is_section_on = new bool[sections.Count];
    }

    
    void Update()
    {
        t += Time.deltaTime * 1000f;
        int dMs = Mathf.RoundToInt(Time.deltaTime * beatMS);
        bool beattrig = ramp > ((ramp + dMs) % beatMS);
        ramp = (ramp + dMs) % beatMS;
        if (beattrig) counterBeatUnbound += 1;
        counterBeat = counterBeatUnbound % timeSignature;
        counterMeasure = counterBeatUnbound / timeSignature;
        if (counterMeasure < Intro)
        {
            is_section_on[0] = true;
        }
        else if (counterMeasure > Intro && counterMeasure < Verse)
        {
            is_section_on[1] = true;
            is_section_on[0] = false;
        }
        else if (counterMeasure > Verse && counterMeasure < Chorus)
        {
            is_section_on[2] = true;
            is_section_on[1] = false;
        }
        else if (counterMeasure > Verse2 && counterMeasure < Chorus)
        {
            is_section_on[3] = true;
            is_section_on[2] = false;
        }
        else if (counterMeasure > Chorus2 && counterMeasure < Verse2)
        {
            is_section_on[4] = true;
            is_section_on[3] = false;
        }
        else if (counterMeasure > End && counterMeasure < Chorus2)
        {
            is_section_on[5] = true;
            is_section_on[4] = false;
        }
    }
}

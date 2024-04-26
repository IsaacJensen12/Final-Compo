using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumParticles : MonoBehaviour
{
    public LibPdInstance pdPatch;
    public ParticleSystem kickParticles;
    public ParticleSystem snareParticles;
    public ParticleSystem hihatParticles;
    public List<AudioClip> sounds;
    string[] drum_type = new string[] { "Kick", "Snare", "Hi-Hat" };
    [SerializeField]
    SongTimer SongTimer;
    float t;
    float ramp;
    [SerializeField]
    List<bool> kick;
    [SerializeField]
    List<bool> snare;
    [SerializeField]
    List<bool> hihat;
    int count = 0;
    void Start()
    {
        kickParticles = gameObject.GetComponent<ParticleSystem>();
        //kickParticles.Stop();
        snareParticles = gameObject.GetComponent<ParticleSystem>();
        //snareParticles.Stop();
        hihatParticles = gameObject.GetComponent<ParticleSystem>();
        //hihatParticles.Stop();

        for (int i = 0; i < sounds.Count; i++)
        {
            string name = sounds[i].name + ".wav";
            pdPatch.SendSymbol(drum_type[i], name);
        }


    }

    void Update()
    {

        t += Time.deltaTime;
        int dMs = Mathf.RoundToInt(Time.deltaTime * 1000);
        bool trig = ramp > ((ramp + dMs) % SongTimer.beatMS);
        ramp = (ramp + dMs) % SongTimer.beatMS;
        if (SongTimer.is_section_on[0])
        {
            if (trig)
            {
                if (kick[count])
                {
                    pdPatch.SendBang("kick_bang");
                }
                
            }
        }
        if(SongTimer.is_section_on[1])
        {
            if (trig)
            {
                if (kick[count])
                {
                    pdPatch.SendBang("kick_bang");
                }
                if (hihat[count])
                {
                    pdPatch.SendBang("Hi-Hat_bang");
                }
                
            }
            
        }
        count = (count + 1) % kick.Count;
    }
}

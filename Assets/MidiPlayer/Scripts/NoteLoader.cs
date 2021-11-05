using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK; // Add a reference to the MPTK namespace at the top of your script


public class NoteLoader : MonoBehaviour

{
    public GameObject Nota;
    public float posOffset;
    public Transform NoteHolder;
    int[] notelist = { 70, 61, 65, 51, 63, 66, 42, 46, 47, 59 };
    public float offset;

   public enum ButtonNumbers
    {
        Azul = 1,
        Rojo = 2,
        Amarillo= 3,
        Verde = 4
    }

    // Start is called before the first frame update
    void Start()
    {
        TheMostSimpleDemoForMidiLoader();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateNote (MPTKEvent mptk,float PosX, ButtonNumbers Note)
    {

        GameObject part1 = Instantiate(Nota, new Vector3(PosX, mptk.RealTime / 300 + posOffset, 0), Quaternion.identity, NoteHolder);

        NoteObject noteo = part1.GetComponent<NoteObject>();
        SpriteRenderer spriterenderer = part1.GetComponent<SpriteRenderer>();

        switch (Note)
        {
            case ButtonNumbers.Azul:
                {
                    noteo.keyToPress = KeyCode.A;
                    spriterenderer.color = Color.blue;

                }break;

            case ButtonNumbers.Rojo:
                {
                    noteo.keyToPress = KeyCode.S;
                    spriterenderer.color = Color.red;
                }
                break;
            case ButtonNumbers.Amarillo:
                {
                    noteo.keyToPress = KeyCode.D;
                    spriterenderer.color = Color.yellow;
                }
                break;
            case ButtonNumbers.Verde:
                {
                    noteo.keyToPress = KeyCode.F;
                    spriterenderer.color = Color.green;
                }
                break;
            default:
                break;
        }
        //noteo.keyToPress = KeyCode.

        //            part1.GetComponent<SpriteRenderer>().color = Color.blue;
    }
    private void TheMostSimpleDemoForMidiLoader()
    {
        // A MidiFileLoader prefab must be added to the hierarchy with the editor (see menu MPTK)
        MidiFileLoader loader = FindObjectOfType<MidiFileLoader>();
        if (loader == null)
        {
            Debug.LogWarning("Can't find a MidiFileLoader Prefab in the current Scene Hierarchy. Add it with the MPTK menu.");
            return;
        }

        // Index of the midi in the MidiDB (find it with 'Midi File Setup' from the menu MPTK)
        loader.MPTK_MidiIndex = 70;

        // Open and load the Midi
        loader.MPTK_Load();

        // Read midi event to a List<>
        List<MPTKEvent> mptkEvents = loader.MPTK_ReadMidiEvents();

        // Loop on each MIDI events
        foreach (MPTKEvent mptkEvent in mptkEvents)
        {
            if(mptkEvent.Value >= 42 && mptkEvent.Value <= 49)
            {
                CreateNote(mptkEvent,-1.34f - offset,ButtonNumbers.Azul);    //azul  
            }
            else if (mptkEvent.Value > 49  && mptkEvent.Value <= 56)
            {
                CreateNote(mptkEvent, -0.34f - offset, ButtonNumbers.Rojo);  // rojo
            }
            else if (mptkEvent.Value > 56 && mptkEvent.Value <= 63)
            {
                CreateNote(mptkEvent, 0.66f - offset, ButtonNumbers.Amarillo); // amarillo
            }
            else if (mptkEvent.Value > 63 && mptkEvent.Value <= 70)
            {
                CreateNote(mptkEvent, 1.66f - offset, ButtonNumbers.Verde); // verde
            }



            //switch (notelist[Random.Range(0, 9)])
            //{
            //    case 70:
            //        {

            //            GameObject part1 = Instantiate(Nota, new Vector3(notelist[Random.Range(0, 9)] / 5 - 10, mptkEvent.RealTime / 300 + posOffset, 0), Quaternion.identity, NoteHolder);
            //            part1.GetComponent<SpriteRenderer>().color = Color.blue;
            //        }
            //        break;

            //    case 61:
            //        {
            //            GameObject part1 = Instantiate(Nota, new Vector3(notelist[Random.Range(0, 9)] / 5 - 10, mptkEvent.RealTime / 300 + posOffset, 0), Quaternion.identity, NoteHolder);
            //            part1.GetComponent<SpriteRenderer>().color = Color.black;
            //        }

            //        break;

            //    case 65:
            //        {
            //            GameObject part1 = Instantiate(Nota, new Vector3(notelist[Random.Range(0, 9)] / 5 - 10, mptkEvent.RealTime / 300 + posOffset, 0), Quaternion.identity, NoteHolder);
            //            part1.GetComponent<SpriteRenderer>().color = Color.green;
            //        }

            //        break;
            //    case 63:
            //        {
            //            GameObject part1 = Instantiate(Nota, new Vector3(notelist[Random.Range(0, 9)] / 5 - 10, mptkEvent.RealTime / 300 + posOffset, 0), Quaternion.identity, NoteHolder);
            //            part1.GetComponent<SpriteRenderer>().color = Color.red;
            //        }
            //        break;
            //    case 51:
            //        {
            //            GameObject part1 = Instantiate(Nota, new Vector3(notelist[Random.Range(0, 9)] / 5 - 10, mptkEvent.RealTime / 300 + posOffset, 0), Quaternion.identity, NoteHolder);
            //            part1.GetComponent<SpriteRenderer>().color = Color.grey;
            //        }
            //        break;
            //    case 66:
            //        {
            //            GameObject part1 = Instantiate(Nota, new Vector3(notelist[Random.Range(0, 9)] / 5 - 10, mptkEvent.RealTime / 300 + posOffset, 0), Quaternion.identity, NoteHolder);
            //            part1.GetComponent<SpriteRenderer>().color = Color.cyan;
            //        }
            //        break;
            //    case 42:
            //        {
            //            GameObject part1 = Instantiate(Nota, new Vector3(notelist[Random.Range(0, 9)] / 5 - 10, mptkEvent.RealTime / 300 + posOffset, 0), Quaternion.identity, NoteHolder);
            //            part1.GetComponent<SpriteRenderer>().color = Color.yellow;
            //        }
            //        break;
            //    case 46:
            //        {
            //            GameObject part1 = Instantiate(Nota, new Vector3(notelist[Random.Range(0, 9)] / 5 - 10, mptkEvent.RealTime / 300 + posOffset, 0), Quaternion.identity, NoteHolder);
            //            part1.GetComponent<SpriteRenderer>().color = Color.magenta;
            //        }
            //        break;
            //    case 47:
            //        {
            //            GameObject part1 = Instantiate(Nota, new Vector3(notelist[Random.Range(0, 9)] / 5 - 10, mptkEvent.RealTime / 300 + posOffset, 0), Quaternion.identity, NoteHolder);
            //            part1.GetComponent<SpriteRenderer>().color = Color.white;
            //        }
            //        break;
            //    case 59:
            //        {
            //            GameObject part1 = Instantiate(Nota, new Vector3(notelist[Random.Range(0, 9)] / 5 - 10, mptkEvent.RealTime / 300 + posOffset, 0), Quaternion.identity, NoteHolder);
            //            part1.GetComponent<SpriteRenderer>().color = Color.red;
            //        }
            //        break;


            //    default:
            //        break;
        //}
            // Log if event is a note on
            if (mptkEvent.Command == MPTKCommand.NoteOn)
                Debug.Log($"Note On at {mptkEvent.RealTime} millisecond  Channel:{mptkEvent.Channel} Note:{notelist[Random.Range(0, 9)]}  Duration:{mptkEvent.Duration} millisecond  Velocity:{mptkEvent.Velocity}");
            else if (mptkEvent.Command == MPTKCommand.PatchChange)
                Debug.Log($"Patch Change at {mptkEvent.RealTime} millisecond  Channel:{mptkEvent.Channel}  Preset:{notelist[Random.Range(0, 9)]}");
            else if (mptkEvent.Command == MPTKCommand.ControlChange)
            {
                if (mptkEvent.Controller == MPTKController.BankSelectMsb)
                    Debug.Log($"Bank Change at {mptkEvent.RealTime} millisecond  Channel:{mptkEvent.Channel}  Bank:{notelist[Random.Range(0, 9)]}");
            }
            // Uncomment to display all MIDI events
            //Debug.Log(mptkEvent.ToString());
        }
    }
}

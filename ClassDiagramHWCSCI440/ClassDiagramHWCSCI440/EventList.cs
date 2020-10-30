using System;
using System.Collections.Generic;
using System.Text;

namespace ClassDiagramHWCSCI440
{


    class EventList
    {
        public Event currentEvent = new Event();//This is the current Event object of the class. This allows the program to run the current Events.       
        public int nextEvent;//This records the next Event Number.

        internal Simulator Simulator
        {
            get => default;
            set
            {
            }
        }

        public void SetEvent(int eventNumber)//This sets the event of the Current Event object. 
        {
            currentEvent.SetEvent(eventNumber);
        }


        public bool isRunning()//This Checks if the Simulation is finished.
        {
            if (currentEvent.W == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int RetrieveNextEvent()//This retrieves the next event from the currentEvent Object.
        {
            
            nextEvent = currentEvent.nextEvent;
            return nextEvent;
        }
    }


}

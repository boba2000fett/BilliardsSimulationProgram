using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDiagramHWCSCI440
{
    class Simulator
    {
        EventList firstEvent = new EventList();//Here is the EventList Object that allows us to generate the Events for this Program.
        int eventCount = 0; //This Keeps track of the total amount of events
        DateTime dateTime = new DateTime();
        static Simulator simulation = new Simulator();
        LinkedList<int> B1Statistics = new LinkedList<int>(); //This records the changes to the B1 State Variable
        LinkedList<int> B2Statistics = new LinkedList<int>();//This records the changes to the B2 State Variable
        LinkedList<int> T1Statistics = new LinkedList<int>();//This records the changes to the T1 State Variable
        LinkedList<int> T2Statistics = new LinkedList<int>();//This records the changes to the T2State Variable
        LinkedList<int> WStatistics = new LinkedList<int>();//This records the changes to the W State Variable
        LinkedList<double> UStatistics = new LinkedList<double>();//This records the changes to the U State Variable
        LinkedList<int> eventList = new LinkedList<int>(); //This keeps track of the Events that have occured
        int nextEvent = 0;//This is a general purpose variable that keeps track of the current and next event
        LinkedList<DateTime> timeList = new LinkedList<DateTime>();//This Keeps track of the running Time, almost like a CLK.

        static void Main()//Here is the main program. This just runs the main methods that are vital to the program's function
        {
            
            simulation.RunSimulation();
            simulation.Diagnostics();

        }
        /// <summary>
        /// Runs the Simulation through the use of a While Loop, coupled with functions form the EventList object firstEvent
        /// </summary>
        public void RunSimulation()
        {
            while(firstEvent.isRunning() == true)
            {
            
                
                firstEvent.SetEvent(nextEvent);//This runs the Event with the specified Number nextEvent
                //All of the following update the Statistics with the updated State Variables
                B1Statistics.AddLast(firstEvent.currentEvent.B1);
                B2Statistics.AddLast(firstEvent.currentEvent.B2);
                T1Statistics.AddLast(firstEvent.currentEvent.T1);
                T2Statistics.AddLast(firstEvent.currentEvent.T2);
                WStatistics.AddLast(firstEvent.currentEvent.W);
                UStatistics.AddLast(firstEvent.currentEvent.U);
                eventList.AddLast(nextEvent);
                timeList.AddLast(DateTime.Now);
                eventCount++;//This increments the eventCount.

                //Console.WriteLine("Current Event{0}",nextEvent);
                //switch (nextEvent)
                //{
                //    case 0:
                //        Console.WriteLine("Start");
                //        break;
                //    case 1:
                //        Console.WriteLine("HitBall1");
                //        break;
                //    case 2:
                //        Console.WriteLine("Pocket1");
                //        break;
                //    case 3:
                //        Console.WriteLine("Pocket2");
                //        break;
                //    case 4:
                //        Console.WriteLine("Miss");
                //        break;
                //    case 5:
                //        Console.WriteLine("Foul");
                //        break;
                //    case 6:
                //        Console.WriteLine("SWT1 (Switch Team 1)");
                //        break;
                //    case 7:
                //        Console.WriteLine("SWT2 (Switch Team 2)");
                //        break;
                //    case 8:
                //        Console.WriteLine("H8B1 (Team 1 Hits 8 Ball)");
                //        break;
                //    case 9:
                //        Console.WriteLine("H8B2 (Team 2 Hits 8 Ball)");
                //        break;
                //    case 10:
                //        Console.WriteLine("Win1");
                //        break;
                //    case 11:
                //        Console.WriteLine("Win2");
                //        break;
                //    case 12:
                //        Console.WriteLine("Victory");
                //        break;
                //}
                
                nextEvent = firstEvent.RetrieveNextEvent();//This retrieves the Number of the nextEvent. On the next run of the loop, this will be used to set the next Event.

                
            }
          
        }

        /// <summary>
        /// This Runs the Diagnostics of the Simulation once it is finished.
        /// </summary>
        public void Diagnostics()
        {
            //Here we convert the LinkedLists into Arrays so it can be easier to display the results. 
            int[] B1Stats = B1Statistics.ToArray();
            int[] B2Stats = B2Statistics.ToArray();
            int[] T1Stats = T1Statistics.ToArray();
            int[] T2Stats = T2Statistics.ToArray();
            int[] WStats = WStatistics.ToArray();
            double[] UStats = UStatistics.ToArray();
            int[] eventStats = eventList.ToArray();
            DateTime[] timeStats = timeList.ToArray();


            //Here we output the results of the Simulation, or the Statistics.
            Console.WriteLine($"Player {firstEvent.currentEvent.W} Won!");
            Console.WriteLine("Running Diagnostics");
            Console.WriteLine("{0,-4}{1,-4}{2,-4}{3,-4}{4,-4}{5,-25}{6,-15}{7,-4}","B1","B2","T1","T2","W","U","EventNumber","Time");
            for(int i = 0; i < B1Stats.Length; i++)
            {
                Console.WriteLine("{0,-4}{1,-4}{2,-4}{3,-4}{4,-4}{5,-25}{6,-15}{7,-4}:{8}", B1Stats[i], B2Stats[i], T1Stats[i], T2Stats[i], WStats[i], UStats[i], eventStats[i], timeStats[i].ToLongTimeString(),timeStats[i].Millisecond);
            }
            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ClassDiagramHWCSCI440
{

    class Event
    {
        Random rand = new Random();//This is a random object, that is used for assigning random values to the variable U
        /*   STATE VARIABLE DELARATIONS   */
        public int T1;    /***  Team 1 (Solids)   ***/
        public int T2;    /***  Team 2 (Stripes)  ***/
        public int B1;    /***  Number of Balls Remaining for Team 1  ***/
        public int B2;    /***  Number of Balls Remaining for Team 2  ***/
        public int W; /***  Which Team Won (1 or 2)  ***/
        public int F; /***  If there is a Foul  ***/
        public double U;   /***  Random Variable  ***/
        public int eventType;
        public int nextEvent;

        internal EventList EventList
        {
            get => default;
            set
            {
            }
        }

        //This Represents what each of the events numbers represent
         /*eventType = 0 Start
         * eventType = 1 HitBall 
         * eventType = 2 Pocket1
         * eventType  =3 Pocket2
         * eventType = 4 Miss
         * eventType = 5 Foul
         * eventType = 6 SWT1
         * eventType = 7 SWT2
         * eventType = 8 H8B1
         * eventType = 9 H8B2
         * eventType = 10 Win1
         * eventType = 11 Win2
         * eventType = 12 Victory
         * 
         */


        public void SetEvent(int eventNumber)//This sets the next Event, with a parameter eventNumber
        {
            switch (eventNumber)
            {
                case 0:
                    Start();
                    break;
                case 1:
                    HitBall();
                    break;
                case 2:
                    Pocket1();
                    break;
                case 3:
                    Pocket2();
                    break;
                case 4:
                    Miss();
                    break;
                case 5:
                    Foul();
                    break;
                case 6:
                    SWT1();
                    break;
                case 7:
                    SWT2();
                    break;
                case 8:
                    H8B1();
                    break;
                case 9:
                    H8B2();
                    break;
                case 10:
                    Win1();
                    break;
                case 11:
                    Win2();
                    break;
                case 12:
                    Victory();
                    break;
            }
        }


        /*** This Starts the Simulation and Displays all of the Variables ***/
        public void Start()
        {
            T1 = 1;
            T2 = 0;
            B1 = 7;
            B2 = 7;
            W = 0;
            F = 0;
            U = 0;

            nextEvent = 1;

        }
        /*** A Team Hits the Ball ***/
        //The Team that is hitting the Ball depends which team is currently playing a turn. The If Statements represent Edge Conditions.
        public void HitBall()
        {
            F = 0;
            U = rand.NextDouble();//This sets the Value of U to a random value between 1 and 0.
            if (T1 == 1 && U < 1 && U > .70)//This is for when Team 1 Pockets the ball
            {

                nextEvent = 2;
            }
            if (T2 == 1 && U < 1 && U > .70)//This is for when Team 2 Pockets the Ball
            {

                nextEvent = 3;
            }
            if (U < .55)//The Current Team misses the ball
            {
                nextEvent = 4;
            }
            if (U < .70 && U > .55)//The Current Team gets a Fou
            {

                nextEvent = 5;
            }
            if (B1 == 0 && T1 == 1)//If Team 1 does not have to hit any more balls, and only has to hit the 8 Ball, the Team goes to a special 8 Ball state.
            {

                nextEvent = 8;
            }
            if (B2 == 0 && T2 == 1)//If Team 2 does not have to hit any more balls, and only has to hit the 8 Ball, the Team goes to a special 8 Ball state.
            {

                nextEvent = 9;
            }

        }

        public void Pocket1()//This is when the first Team pockets a Ball.
        {
            /* state changes */
            B1 = B1 - 1;

            nextEvent = 1;


        }
        public void Pocket2()//This is when the Second Team pockets a Ball.
        {
            /* state changes */
            B2 = B2 - 1;

            nextEvent = 1;

        }
        /*** The Current Team Misses the Ball ***/
        public void Miss()
        {
            //Edge Conditions
            if (T1 == 1)
            {
                nextEvent = 6;
            }
            if (T2 == 1)
            {
                nextEvent = 7;
            }
        }
        /*** The Current Team gets a Foul ***/
        public void Foul()
        {
            /* state changes */
            F = 1;
            //Edge Conditions
            if (T1 == 1)
            {
                nextEvent = 6;
            }
            if (T2 == 1)
            {
                nextEvent = 7;
            }


        }
        /*** This Switches Teams from Team 1 to Team 2 ***/
        public void SWT1()
        {
            /* state changes */
            T1 = 0;
            T2 = 1;

            nextEvent = 1;
        }
        /*** This switches teams from Team 2 to Team 1 ***/
        public void SWT2()
        {
            /* state changes */
            T1 = 1;
            T2 = 0;

            nextEvent = 1;
        }
        /*** This is the event that occurs if Team 1 has to only hit the 8 Ball to Win! ***/
        public void H8B1()
        {
            /* state changes */
            U = rand.NextDouble();

            if (U > .80)
            {
                nextEvent = 10;
            }
            if (U < .80)
            {
                nextEvent = 6;
            }
        }
        /*** This is the event that occurs if Team 2 has to only hit the 8 Ball to Win! ***/
        public void H8B2()
        {
            /* state changes */
            U = rand.NextDouble();

            if (U > .80)
            {
                nextEvent = 11;
            }
            if (U < .80)
            {
                nextEvent = 7;
            }
        }
        public void Win1()//This State means that Team 1 has won the Game!
        {
            /* state changes */
            W = 1;
            //Next Event
            nextEvent = 12;
        }
        public void Win2()//This State means that Team 2 has won the Game!
        {
            /* state changes */
            W = 2;
            //Next Event
            nextEvent = 12;
        }
        public void Victory()
        {
            
        }
    }

}

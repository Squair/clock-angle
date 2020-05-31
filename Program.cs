using System;
using System.Collections.Generic;

namespace clock_angle
{
    //This program, when given a clocks hour and minute will calculate the angle between both hands.
    class Program
    {
        static void Main(string[] args)
        {
            //Driver data
            var clocks = new List<Clock> {
                new Clock(6, 00), //6:00 am/pm
                new Clock(3, 00), //3:00 am/pm
                new Clock(4, 45), //4:45 am/pm
                new Clock(16, 46), //16:45 pm
                new Clock(4, 60) //4:60 which is actually 5:00am/pm
            };

            clocks.ForEach(clock =>
            {
                Console.WriteLine("At time {0}:{1}am/pm", clock.hourHand, clock.minuteHand);

                //Call for acute angle
                Console.WriteLine("Acute: {0} degrees", clock.findAngle());

                //Call for obtuse angle
                Console.WriteLine("Obtuse: {0} degrees", clock.findAngle(false));
            });

        }
    }
}

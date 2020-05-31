using System;

namespace clock_angle
{
    public class Clock
    {
        //Constructor takes in hourHand and minuteHand
        public Clock(int hourHand, int minuteHand)
        {
            //Basic validation to ensure range is correct
            if (minuteHand < 0 || minuteHand > 60){
                throw new Exception("Minute value must be between 0 and 60");
            } 

            if (hourHand < 1 || hourHand > 24){
                throw new Exception("Hour value must be between 1 and 24");
            }

            //If 24 hour clock is entered, convert to 12 hour
            this.hourHand = hourHand > 12 ? hourHand - 12 : hourHand;

            //0 and 60 are in same position for minutes, for instance cant have 16:60 as this is actually 17:00
            if (minuteHand == 60) {
                minuteHand = 0;
                this.hourHand++;
            }

            this.minuteHand = minuteHand;
        }

        public int minuteHand { get; set; }
        public int hourHand { get; set; }

        private const int wholeClockDegrees = 360;
        private const int clockSegments = 12;

        public double findAngle(bool acute = true)
        {
            //Find number of segments minute hand uses then calculate total degree of angle
            var minuteHandSegments = findSegments(this.minuteHand);
            var minuteDegrees = findDegrees(minuteHandSegments);

            //Get the fraction to modify the hour hands degree value
            var angleModifier = (minuteDegrees / wholeClockDegrees) * (wholeClockDegrees / clockSegments);
            var hourDegrees = findDegrees(this.hourHand) + angleModifier;

            //Take absolute value to find difference between two angles
            var angle = Math.Abs(hourDegrees - minuteDegrees);
            
            //Return acute depending on acute parameter = true otherwise return obtuse
            return acute == true && (angle <= wholeClockDegrees / 2) ? angle : (wholeClockDegrees - angle);
        }

        public override string ToString(){
            return $"At time {this.hourHand}:{this.minuteHand}am/pm";
        }
        private float findSegments(int hand)
        {
            //5 minutes in one segement
            return (float)hand / 5;
        }

        private double findDegrees(double segments)
        {  
            return segments * (wholeClockDegrees / clockSegments);
        }



    }
}

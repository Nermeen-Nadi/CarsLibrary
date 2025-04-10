using System.Drawing;

namespace CarsLibrary
{
    public abstract class Car
    {
        public int velocity { get; set; }
        public DrivingMode drivingMode{ get; set; }
        public Car()
        {
            velocity = 0;
            drivingMode = DrivingMode.stopped;
        }
        public bool IsStop() {
            return velocity == 0 ? true : false;
        }
        public void Stop()
        {
            velocity = 0;
            drivingMode = DrivingMode.stopped;
        }

        public void IncreaseVelocity(int addedVelocity)
        {
            velocity += addedVelocity;
            drivingMode = DrivingMode.forwoard;
        }

        public abstract void Accelerate();

        public string GetDirection()
        {
            return drivingMode.ToString();
        }

        public Car GetMyCar()
        {
            //return this;   // shallow copy

            // deep copy
            return new Toyota() { velocity = this.velocity, drivingMode = this.drivingMode };
        }


        public double TimeToCoverDistance(double distance)
        {
            return distance / velocity;
        }

        public override bool Equals(object? obj)
        {
            Car? car = obj as Car;
            if (car == null) return false;

            return car.velocity == velocity && car.drivingMode == drivingMode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.drivingMode, this.velocity);
        }



    }
}

using System;

namespace GeometryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Cylinder cylinder = new Cylinder(38.64, 22.48); // Example values for radius and height
            cylinder.Process();
            cylinder.Result();
            Lion lion = new Lion(200, "Simba");
            Tiger tiger = new Tiger(180, "Rajah");
            Console.WriteLine();
            tiger.Show();
            lion.Show();
            
        }
    }

    class Cylinder
    {
        private double Radius { get; set; }
        private double Height { get; set; }
        private double BaseArea { get; set; }
        private double LateralArea { get; set; }
        private double TotalArea { get; set; }
        private double Volume { get; set; }

        public Cylinder(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }

        public void Process()
        {
            BaseArea = Radius * Radius * Math.PI;
            LateralArea = 2 * Math.PI * Radius * Height;
            TotalArea = 2 * Math.PI * Radius * (Height + Radius);
            Volume = Math.PI * Radius * Radius * Height;
        }

        public void Result()
        {
            Console.WriteLine("Enter the dimenstions of the cylinder");
            Console.WriteLine($"Radius: {Radius}");
            Console.WriteLine($"Height: {Height}");
            Console.WriteLine();
            Console.WriteLine($"Cylinder Chaaracteristics");
            Console.WriteLine($"Radius: {Radius}, Height: {Height}");
            Console.WriteLine($"Base: {BaseArea:F2} | Lateral {LateralArea:F2} | Total: {TotalArea:F2} | Volume: {Volume:F2}");
        }
    }

    class Animal
    {
        protected string name;
        protected double weight;

        public Animal()
        {
            name = "Unknown";
            weight = 0.0;
        }

        public Animal(double weight, string name)
        {
            this.weight = weight;
            this.name = name;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Name: {name}, Weight: {weight}");
        }

        public void SetMe(double weight, string name)
        {
            this.weight = weight;
            this.name = name;
        }
    }

    class Lion : Animal
    {
        public Lion(double weight, string name) : base(200, "lion")
        {
        }

        public override void Show()
        {
            Console.WriteLine($"Name: {name}, Weight: {weight}");
        }
    }

    class Tiger : Animal
    {
        public Tiger(double weight, string name) : base(100, "tiger")
        {
        }

        public override void Show()
        {
            Console.WriteLine($"Name: {name}, Weight: {weight}");
        }
    }

}
namespace softUniClassesExc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            int totalCarHorsePower = 0;
            int cars = 0;
            int totalTruckHorsePower = 0;
            int trucks = 0;

            List<Vehicle> vehicles = new List<Vehicle>();
            while(command != "End")
            {
                string[] details = command.Split().ToArray();
                string type = details[0];
                string model = details[1];
                string color = details[2];
                int horsepower = int.Parse(details[3]);

                Vehicle vehicle = new Vehicle(type, model, color, horsepower);

                if(vehicle.Type == "car")
                {
                    totalCarHorsePower += vehicle.Horsepower;
                    cars++;
                }
                else if(vehicle.Type == "truck")
                {
                    totalTruckHorsePower += vehicle.Horsepower;
                    trucks++;
                };
                vehicles.Add(vehicle);

                command = Console.ReadLine();
            }

            while (command != "Close the Catalogue")
            {
                string model = command;
                foreach(Vehicle vehicle in vehicles)
                {
                    if(vehicle.Model == model) Console.WriteLine(vehicle);
                }

                command = Console.ReadLine();
            }

            double avgCarHorsePower;
            if(cars > 0) avgCarHorsePower = 1.00 * totalCarHorsePower / cars;
            else avgCarHorsePower = 0;
                
            double avgTruckHorsePower;
            if(trucks > 0) avgTruckHorsePower = 1.00 * totalTruckHorsePower / trucks;
            else avgTruckHorsePower = 0;

            Console.WriteLine($"Cars have average horsepower of: {avgCarHorsePower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {avgTruckHorsePower:f2}.");
        }
    }

    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
        public Vehicle(string type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }

        public override string ToString()
        {
            string typeTxt = "";

            if(Type == "car") typeTxt = "Car";
            else if(Type == "truck") typeTxt = "Truck";

            return $"Type: {typeTxt}\n"
                + $"Model: {Model}\n"
                + $"Color: {Color}\n"
                + $"Horsepower: {Horsepower}";
        }
    }
}
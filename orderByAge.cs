namespace softUniClassesExc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<Person> people = new List<Person>();
            while(command != "End")
            {
                string[] details = command.Split(' ').ToArray();
                string name = details[0];
                string id = details[1];
                int age = int.Parse(details[2]);

                Person person = new Person(name, id, age);

                foreach(Person samePerson in people)
                {
                    if(samePerson.ID == id)
                    {
                        samePerson.Age = age;
                        samePerson.Name = name;
                        break;
                    }
                }
                if(!people.Contains(person)) people.Add(person);

                command = Console.ReadLine();
            }

            people = people.OrderBy(p => p.Age).ToList();
            foreach(Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
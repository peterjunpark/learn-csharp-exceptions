Person peter = new("Peter", 28);
Console.WriteLine(peter.Name + ", " + peter.Age);
Console.ReadKey();

internal class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
        if (name == string.Empty)
        {
            throw new Exception("Name is required.");
        }
        Name = name;

        if (age < 0)
        {
            throw new Exception("age must be a positive integer.");
        }
        Age = age;
    }
}

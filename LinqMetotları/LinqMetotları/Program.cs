using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    public static void Main(string[] args)
    {

        static Animal[] GetAquaticAnimals()
        {
            Animal[] AquaticAnimals =
            {new Animal{Name="Shark", chromosome=82},
             new Animal{Name="Frog", chromosome= 26},
             new Animal{Name="SeaHorse", chromosome =23},
             new Animal {Name="Dolphin", chromosome= 22}};
            return AquaticAnimals;
        }

        static Animal[] GetAirborneAnimals()
        {
            Animal[] AirborneAnimals =
            {
        new Animal{Name="Eagle", chromosome=78},
        new Animal{Name="Bat", chromosome=38},
        new Animal{Name="Butterfly", chromosome=380},
        new Animal{Name="Pigeon", chromosome=40}};
            return AirborneAnimals;
        }

        Animal[] AirborneAnimals =
           {
        new Animal{Name="Eagle", chromosome=78},
        new Animal{Name="Bat", chromosome=38},
        new Animal{Name="Butterfly", chromosome=380},
        new Animal{Name="Pigeon", chromosome=40}};



        Animal[] TerrestrialAnimals =
            {
        new Animal{Name="Lion", chromosome=38},
        new Animal{Name="Elephant", chromosome=56},
        new Animal{Name="Giraffe", chromosome=30},
         new Animal{Name="Giraffe", chromosome=30},
        new Animal{Name="Tiger", chromosome=38}};
        
        //Concat metodu
         static void ConcatExample()
        {
            Animal[] airborneAnimals = GetAirborneAnimals();
            Animal[] aquaticAnimals = GetAquaticAnimals();

            IEnumerable<string> query =
                airborneAnimals.Select(animal => animal.Name).Concat(aquaticAnimals.Select(animal => animal.Name));

            foreach (string name in query)
            {
                Console.WriteLine(name);
            }
        }
        Console.WriteLine("Concat Method:");
        ConcatExample();
        Console.WriteLine();


        //Disdinct metodu
        Console.WriteLine("Distinct Method:");
        var noDuplicates = TerrestrialAnimals.Distinct(new AnimalComparer()).ToArray();

        foreach (var animal in noDuplicates)
        {
            Console.WriteLine(animal.Name + " " + animal.chromosome);
        }
        Console.WriteLine();


        //Skip metodu
        Console.WriteLine("Skip Method:");
        Console.WriteLine("All terrestrial animals except first 3: ");
        foreach (var animal in TerrestrialAnimals.Skip(3))
        {
            Console.WriteLine(animal.Name);
        }
        Console.WriteLine();

        //Take metodu ve OrderByDescending metodu
        Console.WriteLine("Take Method & OrderByDescending Method:");
        var sortedAnimals = TerrestrialAnimals.OrderByDescending(animal => animal.chromosome).ToArray();
        Console.WriteLine("First 3 terrestrial animals who has most chromosomes:");
        foreach (var animal in sortedAnimals.Take(3))
        {
            Console.WriteLine(animal.Name+" "+animal.chromosome);
        }
        Console.WriteLine();


        //OrderBy metodu
        Console.WriteLine("OrderBy Method:");
        var AlphabeticSortedAnimals = TerrestrialAnimals.OrderBy(animal => animal.Name).ToArray();
        Console.WriteLine("Alphabetical ordered terrestrial animals:");
        foreach (var animal in AlphabeticSortedAnimals)
        {
            Console.WriteLine(animal.Name);
        }
        Console.WriteLine();

        //Count metodu
        Console.WriteLine("Count Method:");
        var lessThan38Chromosomes = TerrestrialAnimals.Count(animal => animal.chromosome < 38);
        Console.WriteLine("Count of chromosomes who are less than 38");
        Console.WriteLine(lessThan38Chromosomes);
        Console.WriteLine();


        //Join methodu
        Console.WriteLine("Join Method:");
        Console.WriteLine("Common chromosome amounts in AirborneAnimals and TerrestrialAnimals");
        var commonChromosomes = TerrestrialAnimals.Join(AirborneAnimals,
                                            animal => animal.chromosome,
                                            anotherAnimal => anotherAnimal.chromosome,
                                            (animal, anotherAnimal) => animal).ToArray();
        foreach (var animal in commonChromosomes)
        {
            Console.WriteLine("Name: "+animal.Name+" Chromosome: "+animal.chromosome);
        }
        Console.WriteLine();

        //Where metodu
        Console.WriteLine("TakeWhile Method:");
        var animalsUntilChromosome50 = AirborneAnimals.Where(animal => animal.chromosome <= 50).ToArray();
        foreach (var animal in animalsUntilChromosome50)
        {
            Console.WriteLine("Name: " + animal.Name + " Chromosome: " + animal.chromosome);
           
        }
        Console.WriteLine();



    }



}

public class Animal
{
    public string Name { get; set; }
    public int chromosome { get; set; }
}


public class AnimalComparer : IEqualityComparer<Animal>
{
    public bool Equals(Animal x, Animal y)
    {
        if (object.ReferenceEquals(x, y)) return true;
        if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false;
        return x.Name == y.Name && x.chromosome == y.chromosome;
    }

    public int GetHashCode(Animal obj)
    {
        if (object.ReferenceEquals(obj, null)) return 0;
        int nameHashCode = obj.Name == null ? 0 : obj.Name.GetHashCode();
        int chromosomeHashCode = obj.chromosome.GetHashCode();
        return nameHashCode ^ chromosomeHashCode;
    }

}






using System;
using System.Collections.Generic;

namespace CollectionsPractice
{

    class ArraySolutions
    {
        public static int[] ZeroToNine()
        {
            int[] nums = new int[10];
            for (int i = 0; i < nums.Length; ++i)
            {
                nums[i] = i;
            }

            return nums;
        }

        public static string[] Names()
        {
            string[] names = {"Tim", "Martin", "Nikki", "Sara"};
            return names;
        }

        public static bool[] AlternatingTrueFalse()
        {
            bool[] bools = new bool[10];
            for (int i = 0; i < bools.Length; ++i)
            {
                bools[i] = (i % 2 == 0) ? true : false;
            }

            return bools;
        }
    }
    class IceCream
    {
        // CONSTRUCTOR
        // Empty overload, assigns a new empty list to _Flavors.
        public IceCream()
        {
            _Flavors = new List<string>{};
        }
        // CONSTRUCTOR
        // List<string> overload, assigns flavors to _Flavors.
        public IceCream(List<string> flavors)
        {
            _Flavors = flavors;
        }

        // PROPERTY
        // Getter and setter for _Flavors.
        public List<string> Flavors
        {
            get { return _Flavors; }
            set { _Flavors = value; }
        }

        // PROPERTY
        // Getter for the number of flavors in the _Flavors list.
        public int NumFlavors
        {
            get { return _Flavors.Count; }
        }

        // PUBLIC METHOD
        // Appends new flavor to end of _Flavors list.
        public void AddFlavor(string flavor)
        {
            _Flavors.Add(flavor);
        }
        // PUBIC METHOD
        // Overload with an integer index. Inserts flavor at specified index.
        public void AddFlavor(int index, string flavor)
        {
            _Flavors.Insert(index, flavor);
        }

        // PUBLIC METHOD
        // Deletes flavor at specified index.
        public void DeleteFlavor(int index)
        {
            _Flavors.RemoveAt(index);
        }
        // PUBLIC METHOD
        // Overloads DeleteFlavor with a string rather than an index.
        public void DeleteFlavor(string flavor)
        {
            _Flavors.Remove(flavor);
        }

        // PUBLIC METHOD
        // Prints all flavors
        public void printAll()
        {
            foreach (string flavor in _Flavors)
            {
                Console.WriteLine(flavor);
            }
        }

        // INDEXER
        // Allows for assignment and retrieval of _Flavors with [] operator.
        // Essentially the same as overloading operator[] in C++. But like, cooler.
        public string this[int index]
        {
            get { return _Flavors[index]; }
            set { _Flavors[index] = value; }
        }

        private List<string> _Flavors;
    }

    class Users
    {
        // CONSTRUCTOR
        // Assigns _UserInfo to a new empty dictionary, loops through the names
        // from the ArraySolutions class and creates new key-value pairs in the
        // _UserInfo dictionary with each name as a key and a random ice cream
        // flavor as the value.
        public Users()
        {
            _UserInfo = new Dictionary<string, string>{};

            foreach (string name in _Names)
            {
                Random rand = new Random();
                int randNum = rand.Next(_IceCream.NumFlavors);

                _UserInfo[name] = _IceCream[randNum];
            }
        }

        // Prints each name in the _UserInfo dictionary along with the associated
        // ice cream flavor.
        public void PrintAll()
        {
            foreach (KeyValuePair<string, string> user in _UserInfo)
            {
                Console.WriteLine(user.Key + "'s favorite ice cream flavor: " + user.Value);
            }
        }

        private Dictionary<string, string> _UserInfo;
        private string[] _Names = ArraySolutions.Names();
        private IceCream _IceCream = new IceCream(new List<string>{
            "chocolate", "raspberry chocolate chip", "brownie", "mint", "caramel"
            });
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ARRAYS
            Console.WriteLine("************************");
            Console.WriteLine("ARRAYS");

            // Array of integers from zero to nine. Print each number.
            int[] nums = ArraySolutions.ZeroToNine();
            for (int i = 0; i < nums.Length; ++i)
            {
                Console.WriteLine(nums[i]);
            }

            // Array with the specified names. Print each name.
            string[] names = ArraySolutions.Names();
            for (int i = 0; i < names.Length; ++i)
            {
                Console.WriteLine(names[i]);
            }

            // Array of 10 bools alternating between true and false. Print each.
            bool[] bools = ArraySolutions.AlternatingTrueFalse();
            for (int i = 0; i < bools.Length; ++i)
            {
                Console.WriteLine(bools[i]);
            }


            // ICE CREAM
            Console.WriteLine("************************");
            Console.WriteLine("ICE CREAM");

            // Initialize new IceCream instance with List of strings.
            List<string> flavors = new List<string>{ 
                "chocolate", "raspberry chocolate chip", "brownie", "mint", "caramel"
                };
            IceCream iceCream2 = new IceCream(flavors);

            // Access NumFlavors property and print it to the console.
            Console.WriteLine("Number of flavors: " + iceCream2.NumFlavors);

            // Access third flavor using indexer, print the flavor.
            Console.WriteLine("Third flavor: " + iceCream2[2]);

            // Delete the third flavor by value
            // By index would like: iceCream2.DeleteFlavor(2);
            iceCream2.DeleteFlavor("brownie");

            // Print number of flavors after the delete
            Console.WriteLine("New number of flavors: " + iceCream2.NumFlavors);


            // USER INFO
            Console.WriteLine("************************");
            Console.WriteLine("USER INFO");

            // New Users instance. Everything is handled in the constructor
            // Prints each name with their corresponding ice cream flavor
            Users users1 = new Users();
            users1.PrintAll();
        }
    }
}

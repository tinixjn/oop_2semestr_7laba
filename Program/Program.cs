using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubList MyList = new DoubList();
            Console.WriteLine("Doubly linked list successfully created!");
            Console.WriteLine("Size of the list: " + MyList.Size);

            int choice;
            string menu = "\n==== MENU ====\n" +
            "1. Add element to the list\n" +
            "2. Add multiple elements to the list\n" +
            "3. Remove element by value\n" +
            "4. Remove element by index\n" +
            "5. Remove multiple elements from list\n" + 
            "6. Display the list\n" +                   
            "7. Get element by index\n" +
            "8. Find first element that is a multiple of 5\n" +
            "9. Calculate sum of elements on even positions\n" +
            "10. Create new list with elements greater than given value\n" +
            "11. Remove elements greater than average\n" +
            "12. Size of the list\n" +
            "13. Display this menu again\n" +
            "14. Clear the list\n" +
            "15. Fill list with random elements\n" +
            "16. Show average of the list\n" +
            "0. Exit";

            Console.WriteLine(menu);
            do
            {
                choice = GetIntInput("\nEnter your choice: ");
                switch (choice)
                {
                    case 1:
                        long val = GetLongInput("Enter the value to add: ");
                        MyList.Add(val);
                        Console.WriteLine("Element added successfully.");
                        break;

                    case 2:
                        int count;
                        do
                        {
                            count = GetIntInput("Enter the number of elements to add: ");
                            if (count <= 0)
                                Console.WriteLine("The number must be positive.");
                        } while (count <= 0);

                        for (int i = 0; i < count; i++)
                        {
                            long input = GetLongInput($"Enter value {i + 1}: ");
                            MyList.Add(input);
                        }
                        Console.WriteLine("Elements added successfully.");
                        break;


                    case 3:
                        try
                        {
                            MyList.isEmpty();
                            long removeVal = GetLongInput("Enter the value to remove: ");
                            if (MyList.Remove(removeVal))
                                Console.WriteLine("Element removed successfully.");
                            else
                                Console.WriteLine("Element not found.");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 4:
                        try
                        {
                            MyList.isEmpty();
                            int idx = GetIntInput("Enter the index to remove: ")-1;
                            if (MyList.RemoveAt(idx))
                                Console.WriteLine("Element removed successfully.");
                            else
                                Console.WriteLine("Element not found.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                        try
                        {
                            MyList.isEmpty();

                            int numToRemove;
                            do
                            {
                                numToRemove = GetIntInput("Enter number of elements to remove from end: ");
                                if (numToRemove < 0)
                                    Console.WriteLine("The number must be non-negative.");
                            } while (numToRemove < 0);

                            if (numToRemove >= MyList.Size)
                            {
                                while (MyList.Size > 0)
                                {
                                    MyList.RemoveAt((int)(MyList.Size - 1));
                                }
                                Console.WriteLine("The number of elements is greater than or equal to list size. List has been cleared.");
                            }
                            else
                            {
                                for (int i = 0; i < numToRemove; i++)
                                {
                                    MyList.RemoveAt((int)(MyList.Size - 1));
                                }
                                Console.WriteLine($"{numToRemove} elements removed from the end.");
                            }
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;


                    case 6:
                        Console.WriteLine($"List size: {MyList.Size}");
                        try
                        {
                            MyList.isEmpty();
                            Console.WriteLine("Elements with indexes:");
                            int index = 1;
                            foreach (long item in MyList)
                            {
                                Console.WriteLine($"[{index++}] = {item}");
                            }
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 7:
                        try
                        {
                            MyList.isEmpty();
                            int getIndex = GetIntInput("Enter the index to get: ")-1;
                            long element = MyList[getIndex];
                            Console.WriteLine($"Element at index {getIndex+1}: {element}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 8:
                        try
                        {
                            MyList.isEmpty();
                            var result = MyList.FirstMultipleOfFive();
                            Console.WriteLine($"First element that is a multiple of 5: {result.value} at index {result.index + 1}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 9:
                        try
                        {
                            MyList.isEmpty();
                            Console.WriteLine($"Sum of elements on even positions: {MyList.SumElementsOnEvenPositions()}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 10:
                        try
                        {
                            MyList.isEmpty();
                            long cmp = GetLongInput("Enter the value to compare: ");
                            DoubList filtered = MyList.GetNewListGreaterThan(cmp);
                            filtered.isEmpty();
                            Console.WriteLine("New list:");
                            int index = 1;
                            foreach (long item in filtered)
                            {
                                Console.WriteLine($"[{index++}] = {item}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 11:
                        try
                        {
                            MyList.isEmpty();
                            MyList.RemoveElementsGreaterThanAverage();
                            Console.WriteLine($"Average: {MyList.Average()}");
                            Console.WriteLine("Elements greater than average removed. New list:");
                            int idx = 1;
                            foreach (long item in MyList)
                            {
                                Console.WriteLine($"[{idx++}] = {item}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 12:
                        Console.WriteLine($"Size of the list: {MyList.Size}");
                        break;

                    case 13:
                        Console.WriteLine(menu);
                        break;

                    case 14:
                        try
                        {
                            MyList.isEmpty();
                            List<int> indicesToRemove = new List<int>();
                            int i = 0;
                            foreach (var _ in MyList)
                            {
                                indicesToRemove.Add(i++);
                            }
                            indicesToRemove.Reverse();
                            foreach (var idx in indicesToRemove)
                            {
                                MyList.RemoveAt(idx);
                            }
                            Console.WriteLine("List cleared.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 15:
                        int randCount;
                        do
                        {
                            randCount = GetIntInput("How many random elements to add? ");
                            if (randCount <= 0)
                                Console.WriteLine("The number of elements must be greater than zero.");
                        } while (randCount <= 0);

                        Random rand = new Random();
                        for (int i = 0; i < randCount; i++)
                        {
                            long number = rand.Next(-10000, 100000);
                            MyList.Add(number);
                        }
                        Console.WriteLine("Random elements added.");
                        break;

                    case 16:
                        try
                        {
                            MyList.isEmpty();
                            Console.WriteLine($"Average: {MyList.Average()}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 0:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

            } while (choice != 0);
        }
        static int GetIntInput(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                    return result;
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        }

        static long GetLongInput(string prompt)
        {
            long result;
            while (true)
            {
                Console.Write(prompt);
                if (long.TryParse(Console.ReadLine(), out result))
                    return result;
                Console.WriteLine("Invalid input. Please enter a valid long integer.");
            }
        }
    }
}
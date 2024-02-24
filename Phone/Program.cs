using System;
using System.Collections.Generic;
using System.Linq;

abstract class Phone
{
    public abstract void InsertPhone(string name, string phone);
    public abstract void RemovePhone(string name);
    public abstract void UpdatePhone(string name, string newPhone);
    public abstract void SearchPhone(string name);
    public abstract void Sort();
}

class PhoneBook : Phone
{
    private List<string> phoneList = new List<string>();

    public override void InsertPhone(string name, string phone)
    {
        int index = phoneList.IndexOf(name);
        if (index != -1)
        {
            // Name already exists
            if (phoneList[index + 1] != phone)
            {
                phoneList[index + 1] = phone;
                Console.WriteLine($"Updated phone number for {name}");
            }
            else
            {
                Console.WriteLine($"Phone number for {name} already exists");
            }
        }
        else
        {
            phoneList.Add(name);
            phoneList.Add(phone);
            Console.WriteLine($"Added new contact: {name}");
        }
    }

    public override void RemovePhone(string name)
    {
        int index = phoneList.IndexOf(name);
        if (index != -1)
        {
            phoneList.RemoveAt(index + 1); // Remove phone number
            phoneList.Remove(name); // Remove name
            Console.WriteLine($"Removed contact: {name}");
        }
        else
        {
            Console.WriteLine($"Contact not found: {name}");
        }
    }

    public override void UpdatePhone(string name, string newPhone)
    {
        int index = phoneList.IndexOf(name);
        if (index != -1)
        {
            phoneList[index + 1] = newPhone;
            Console.WriteLine($"Updated phone number for {name}");
        }
        else
        {
            Console.WriteLine($"Contact not found: {name}");
        }
    }

    public override void SearchPhone(string name)
    {
        int index = phoneList.IndexOf(name);
        if (index != -1)
        {
            Console.WriteLine($"Phone number for {name} is: {phoneList[index + 1]}");
        }
        else
        {
            Console.WriteLine($"Contact not found: {name}");
        }
    }

    public override void Sort()
    {
        phoneList = phoneList.OrderBy(x => x).ToList();
        Console.WriteLine("Phone book sorted.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        PhoneBook phoneBook = new PhoneBook();

        phoneBook.InsertPhone("John", "123456789");
        phoneBook.InsertPhone("Alice", "987654321");
        phoneBook.InsertPhone("Bob", "555555555");

        phoneBook.Sort();

        phoneBook.SearchPhone("Alice");
        phoneBook.UpdatePhone("Alice", "999999999");
        phoneBook.SearchPhone("Alice");

        phoneBook.RemovePhone("Bob");
        phoneBook.RemovePhone("Jack");
    }
}
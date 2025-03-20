using ServiceReference1;
using System;


class Program
{
    static async Task Main()
    {
        // Create the client
        ServiceClient client = new ServiceClient();

        // Call the Get method
        var users = await client.GetAsync();

        // Display results
        foreach (var user in users)
        {
            Console.WriteLine($"ID: {user.Id}, Name: {user.FirstName}, Email: {user.LastName}");
        }

        // Close the client
        client.Close();
    }
}

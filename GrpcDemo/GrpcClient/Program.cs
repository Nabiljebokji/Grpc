// See https://aka.ms/new-console-template for more information



using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;

/*var input = new HelloRequest { Name = "Nabil" };

var channel = GrpcChannel.ForAddress("https://localhost:7205");
var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(input);

Console.WriteLine(reply.Message );
*/

var channel = GrpcChannel.ForAddress("https://localhost:7205");
var customerClient = new Customer.CustomerClient(channel);

var input = new CustomerLookUpModel { UserId = 3 };

var reply = await customerClient.GetCustomerInfoAsync(input);

Console.WriteLine($"{reply.FirstName}{reply.LastName}");

Console.WriteLine();
Console.WriteLine("new customer List.. "); 
Console.WriteLine();    

using(var call = customerClient.GetNewCustomers(new NewCustomersRequest()))
{
    while(await call.ResponseStream.MoveNext())
    {
        var customer = call.ResponseStream.Current;
        Console.WriteLine($"{customer.FirstName}{customer.LastName}:{customer.Email}");
    }
    Console.ReadLine();
}

Console.ReadLine(); 

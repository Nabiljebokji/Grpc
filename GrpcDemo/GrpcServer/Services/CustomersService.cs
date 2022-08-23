using Grpc.Core;

namespace GrpcServer.Services
{
    public class CustomersService : Customer.CustomerBase
    {
        private readonly ILogger<CustomersService> _logger;

        public CustomersService(ILogger<CustomersService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookUpModel request, ServerCallContext context)
        {
            CustomerModel output = new CustomerModel();

            if (request.UserId == 1)
            {
                output.FirstName = "Nabil";
                output.LastName = "Jebokji";
            }
            else if (request.UserId == 2)
            {
                output.FirstName = "Sara";
                output.LastName = "Hmara";
            }
            else if (request.UserId == 3)
            {
                output.FirstName = "Sami";
                output.LastName = "Yousef";
            }
            else
            {
                output.FirstName = "Samir";
                output.LastName = "Abu shaar";
            }
            return Task.FromResult(output);
        }
        public override async Task GetNewCustomers(NewCustomersRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            List<CustomerModel> customers = new List<CustomerModel>
            {
                new CustomerModel
                {
                    FirstName = "Nabil",
                    LastName = "Jebokji",
                    Email = "Jason.jebokji71@gmail.com",
                    Age = 24,
                    IsAlive = true,
                },
                new CustomerModel
                {
                    FirstName = "Ahmad",
                    LastName = "reyyes",
                    Email = "happy@gmail.com",
                    Age = 24,
                    IsAlive = true,
                },
                new CustomerModel
                {
                    FirstName = "sara",
                    LastName = "samira",
                    Email = "sara@gmail.com",
                    Age = 24,
                    IsAlive = true,
                },
                new CustomerModel
                {
                    FirstName = "joud",
                    LastName = "saad",
                    Email = "joud@gmail.com",
                    Age = 24,
                    IsAlive = true,
                },
            };

            foreach(var cust in customers)
            {
                await responseStream.WriteAsync(cust);
            }
        }
    }
}

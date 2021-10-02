Requirements:

1. API listing all customers - Implemented in CustomerController with Get()
2. API retrieving a customer - Implemented in CustomerController with GetById(int id)
3. API adding a customer - Implemented in CustomerController with Add(string value)
4. API updating a customer - Implemented in CustomerController with Update(int id, string value)
5. API deleting a customer - Implemented in CustomerController with Delete(int id)
6. API should preserve state - Returned corresponding status code and additional info (e.g. location of newly added customer or updated customer) back to client
7. Unit tests - See GroceryStoreAPITests project

CustomerControllerTests_JsonFile - Use Json file as data source
CustomerControllerTests_InMemoryData - User in-memory List as data source

8. Use .NET Core 3.1 or NET 5+ - Chose to use .NET Core 3.1 as it's LTS version.
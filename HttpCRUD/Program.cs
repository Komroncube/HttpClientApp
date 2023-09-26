// See https://aka.ms/new-console-template for more information
using HttpCRUD;

Console.WriteLine("Hello, World!");
HttpCrudMethod http = new HttpCrudMethod();
string result;
//result = await http.GetAllAsync();

//await http.PostAsync("Kitchen");
//await http.GetAllAsync();
await http.PutAsync(3,"Garment");
//result = await http.PostAsync();
//result = await http.DeleteAsync(4);
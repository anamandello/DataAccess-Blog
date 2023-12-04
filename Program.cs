using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
var connection = new SqlConnection(CONNECTION_STRING);
connection.Open();
ReadUsersWithRoles(connection);
// ReadRoles(connection);
// ReadTags(connection);
connection.Close();

void ReadUsersWithRoles(SqlConnection connection){
  var repository = new UserRepository(connection);
  var items = repository.GetWithRoles();

  foreach(var item in items){
    Console.WriteLine(item.Name);
    foreach(var role in item.Roles){
      Console.WriteLine($" - {role.Name}");
    }
  }
}

void ReadRoles(SqlConnection connection){
  var repository = new Repository<Role>(connection);
  var items = repository.Get();

  foreach(var item in items)
    Console.WriteLine(item.Name);
}

void ReadTags(SqlConnection connection){
  var repository = new Repository<Tag>(connection);
  var items = repository.Get();

  foreach(var item in items)
    Console.WriteLine(item.Name);
}
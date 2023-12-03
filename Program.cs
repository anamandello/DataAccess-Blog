using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
var connection = new SqlConnection(CONNECTION_STRING);
connection.Open();
ReadUsers(connection);
ReadRoles(connection);
connection.Close();
//ReadUser();
//CreateUser();
//UpdateUser();
//DeleteUser();

void ReadUsers(SqlConnection connection){
  var repository = new Repository<User>(connection);
  var users = repository.Get();

  //repository.DeleteById(1005);

  foreach(var user in users)
    Console.WriteLine(user.Name);
}

void ReadRoles(SqlConnection connection){
  var repository = new RoleRepository(connection);
  var roles = repository.Get();

  foreach(var role in roles)
    Console.WriteLine(role.Name);
}
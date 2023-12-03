using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
var connection = new SqlConnection(CONNECTION_STRING);
//ReadUsers();
//ReadUser();
//CreateUser();
//UpdateUser();
DeleteUser();

void ReadUsers(){
  var repository = new UserRepository(connection);
  var users = repository.Get();

  foreach(var user in users)
    Console.WriteLine(user.Name);
}

void ReadUser(){
  using(var connection = new SqlConnection(CONNECTION_STRING)){
    var user = connection.Get<User>(1);

    Console.WriteLine(user.Name);
  }
}

void CreateUser(){
  var user = new User(){
    Bio = "Estudante dev",
    Email = "teste@algo.io",
    Image = "https://",
    Name = "Estudante de desenvolvimento",
    PasswordHash = "HASH",
    Slug = "est-dev"
  };
  using(var connection = new SqlConnection(CONNECTION_STRING)){
    connection.Insert<User>(user);
    Console.WriteLine("Cadastro realizado com sucesso");
  }
}

void UpdateUser(){
  var user = new User(){
    Id = 2,
    Bio = "Estudante",
    Email = "teste@algo",
    Image = "https://",
    Name = "Estudante",
    PasswordHash = "HASH",
    Slug = "est"
  };
  using(var connection = new SqlConnection(CONNECTION_STRING)){
    connection.Update<User>(user);
    Console.WriteLine("Atualização realizada com sucesso");
  }
}

void DeleteUser(){
  using(var connection = new SqlConnection(CONNECTION_STRING)){
    var user = connection.Get<User>(2);
    connection.Delete<User>(user);
    Console.WriteLine("Exclusão realizada com sucesso");
  }
}
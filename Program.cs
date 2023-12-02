﻿using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

ReadUsers();

static void ReadUsers(){
  using(var connection = new SqlConnection(CONNECTION_STRING)){
    var users = connection.GetAll<User>();

    foreach(var user in users){
      Console.WriteLine(user.Name);
    }
  }
}
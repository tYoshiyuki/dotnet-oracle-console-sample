﻿using System;
using System.Linq;
using DotNetOracleConsoleSample.DotNet.Extensions;
using DotNetOracleConsoleSample.DotNet.Models;

namespace DotNetOracleConsoleSample.DotNet;

class Program
{
    static void Main(string[] args)
    {
        // TODO 設定化する
        var db = new OracleDbContext("User Id=sample;Password=samplepw;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)))");
        var blog = db.Blogs.ToList();

        Console.WriteLine("----- get data from db (ef core model) -----");
        blog.ForEach(x => Console.WriteLine($"{x.Id}:{x.Name}"));
        Console.WriteLine("----------");

        blog = db.SqlQuery<Blog>("SELECT * FROM SAMPLE.\"Blogs\"").ToList();
        Console.WriteLine("----- get data from db (extension method) -----");
        blog.ForEach(x => Console.WriteLine($"{x.Id}:{x.Name}"));
        Console.WriteLine("----------");
    }
}
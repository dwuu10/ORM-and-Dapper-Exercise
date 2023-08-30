using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            #region Departments
            /*
            var departmentRepo = new DapperDepartmentRepository(conn);

            departmentRepo.InsertDepartments("My department");
            var departments = departmentRepo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine(dept.Name);
                Console.WriteLine(dept.DepartmentID);
                Console.WriteLine();
            }
            */
            #endregion

            var productRepo = new DapperProductRepository(conn);

            productRepo.CreateProduct("nokia 3310", 9999.99, 3);

            var products = productRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine();
            }
        }
    }
}
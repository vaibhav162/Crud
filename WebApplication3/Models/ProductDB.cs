using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using System.IO;

namespace WebApplication3.Models
{
    public class ProductDB
    {
        
    //declare connection string  
    string cs = ConfigurationManager.ConnectionStrings["Crud1Entities"].ConnectionString;

        //Return list of all Employees  
        public List<Product> ListAll()
        {
            String path = @"D:\Crud\WebApplication3\";//Path
            List<Product> lst = new List<Product>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Selectproduct", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Product
                    {
                        id = Convert.ToInt32(rdr["Id"]),
                        productTitle = rdr["producttitle"].ToString(),
                        stock = Convert.ToInt32(rdr["stock"]),
                        price = Convert.ToInt32(rdr["price"]),
                       Image =  Path.Combine(path,rdr["image"].ToString()).ToString()
                   
                    });
                }
                return lst;
            }
        }

        //Method for Adding an Employee  
        public int Add(Product pro)
        {
            
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand com = new SqlCommand("InsertUpdateproducts", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", pro.id);
                com.Parameters.AddWithValue("@producttitle", pro.productTitle);
                com.Parameters.AddWithValue("@image", pro.Image);
                com.Parameters.AddWithValue("@stock", pro.stock);
                com.Parameters.AddWithValue("@price", pro.price);
                
                com.Parameters.AddWithValue("@Action", "Insert");
                i = com.ExecuteNonQuery();
                Console.WriteLine(i);
            }
            return i;
        }

        //Method for Updating Employee record  
        public int Update(Product pro)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateproducts", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", pro.id);
                com.Parameters.AddWithValue("@producttitle", pro.productTitle);
                com.Parameters.AddWithValue("@stock", pro.stock);
                 com.Parameters.AddWithValue("@image", pro.Image);
                com.Parameters.AddWithValue("@price", pro.price);
               
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        //Method for Deleting an Employee  
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Deleteproduct", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}
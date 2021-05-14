using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VendingMachineAPI.Interface;
using VendingMachineAPI.Models;



namespace VendingMachineAPI.Repos
{
    public class VendingMachineRepositoryADO : IVendingMachineRepository
    {
        public List<Item> GetAllItems()
        {
            List<Item> items = new List<Item>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllItems", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Item currentRow = new Item
                        {
                            id = (int)dr["id"],
                            name = dr["name"].ToString(),
                            price = (decimal)dr["price"],
                            quantity = (int)dr["quantity"]
                        };


                        items.Add(currentRow);
                    }
                }
                return items;
            }
        }

        public Item GetItemById(int id)
        {
            List<Item> items = new List<Item>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetItemById", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        Item currentRow = new Item
                        {
                            id = (int)dr["id"],
                            name = dr["name"].ToString(),
                            price = (decimal)dr["price"],
                            quantity = (int)dr["quantity"]
                        };


                        items.Add(currentRow);
                    }
                }
                return items[0];
            }
        }


        public void Update(Item item)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ItemUpdate", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@id", item.id);
                cmd.Parameters.AddWithValue("@name", item.name);
                cmd.Parameters.AddWithValue("@price", item.price);
                cmd.Parameters.AddWithValue("@quantity", item.quantity - 1);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}

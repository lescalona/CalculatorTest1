using Calculator.WindowsUi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.WindowsUi
{
    public class DataAccess
    { 
        public void InsertarOperaciones(Operaciones operacion)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection("Server=DESKTOP-L8G8O5U\\SQLEXPRESS;Database=test;Trusted_Connection=True;"))
            {
                connection.Open();
                string query = "INSERT INTO operaciones VALUES (" + operacion.numeroAnterior + ",'" + operacion.signo + "'," + operacion.numeroNuevo + "," + operacion.resultado + ")";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

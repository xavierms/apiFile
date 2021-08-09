using ArchivoUplo.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace ArchivoUplo.Connections
{
    public class myConnect : ImyConnect
    {
        private readonly IConfiguration _configuration;
        public myConnect(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Añadir(clsArchivo model)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("myConnection")))

            {

                SqlCommand cmd = new SqlCommand("insertarArchivo", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", model.nombre);
                cmd.Parameters.AddWithValue("@extension", model.extension);
                cmd.Parameters.AddWithValue("@tamanio", model.tamanio);
                cmd.Parameters.AddWithValue("@ubicacion", model.ubicacion);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

    }
}

using Dapper;
using Prueba.Net.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Prueba.Net.Infrastructure.Data
{
    public class DapperManager: IDisposable
    {
        private readonly IDbConnection connection;

        public DapperManager(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            connection.Close();
        }

        public List<Personas> ObtenerPersonas()
        {
            connection.Open();
            string storedProcedured = $"PR_GET_Personas";
            var resultado = connection.Query<Personas>(storedProcedured).AsList();
            Dispose();
            return resultado;
        }

        public Usuarios ObtenerUsuarioPorNombreUsuario(string usario)
        {
            connection.Open();
            string storedProcedured = $"EXEC PR_GET_Usuario @Usuario";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Usuario", usario);
            var resultado = connection.Query<Usuarios>(storedProcedured, parameter).FirstOrDefault();
            Dispose();
            return resultado;
        }

        public int InsertarPersona(Personas persona)
        {
            connection.Open();
            string storedProcedured = $"EXEC PR_INSERT_Personas @Nombres, @Apellidos, @NumeroIdentificación, @Email, @TipoIdentificación, @FechaCreación";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Nombres", persona.Nombres);
            parameter.Add("@Apellidos", persona.Apellidos);
            parameter.Add("@NumeroIdentificación", persona.NumeroIdentificación);
            parameter.Add("@Email", persona.Email);
            parameter.Add("@TipoIdentificación", persona.TipoIdentificación);
            parameter.Add("@FechaCreación", persona.FechaCreación);
            var resultado = connection.ExecuteScalar<int>(storedProcedured, parameter);
            Dispose();
            return resultado;
        }

        public int InsertarUsuario(Usuarios usuario)
        {
            connection.Open();
            string storedProcedured = $"EXEC PR_INSERT_Usuarios @Identificador, @Usuario, @Pass, @FechaCreación";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Identificador", usuario.Identificador);
            parameter.Add("@Usuario", usuario.Usuario);
            parameter.Add("@Pass", usuario.Pass);
            parameter.Add("@FechaCreación", usuario.FechaCreación);
            var resultado = connection.ExecuteScalar<int>(storedProcedured, parameter);
            Dispose();
            return resultado;
        }

    }
}

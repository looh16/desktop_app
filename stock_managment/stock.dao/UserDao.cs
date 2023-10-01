using MySql.Data.MySqlClient;
using stock_managment.stock.database.connection;
using stock_managment.stock.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stock_managment.stock.dao
{
    public class UserDao
    {
        //Conexao com a base de dados
        private readonly MySqlConnection _connection;

        //Construtor
        public UserDao()
        {
            this._connection = new ConnectionFactory().GetConnection();
        }

        #region Criar Utilizador
        public void Create(User user)
        {
            try
            {
                string sql = @"INSERT INTO user(name, username, password, status, role) 
                               VALUES(@name, @username, @password, @status, @role)";

                MySqlCommand mySqlCommand = new MySqlCommand(sql, _connection);
                // Set the parameters for your SQL command.
                mySqlCommand.Parameters.AddWithValue("@name", user.Name);
                mySqlCommand.Parameters.AddWithValue("@username", user.Username);
                mySqlCommand.Parameters.AddWithValue("@password", user.Password);
                mySqlCommand.Parameters.AddWithValue("@status", user.Status);
                mySqlCommand.Parameters.AddWithValue("@role", user.Role);

                _connection.Open();
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("usuario cadastrado com sucesso", "Sucesso ao cadastrar", MessageBoxButtons.OK);
                _connection.Close();
                _connection.Dispose();
                _connection.ClearAllPoolsAsync();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar usuario: " + ex.Message);
            }
        }

        #endregion

        #region Editar Utilizador
        public void Edit(User user, string id)
        {
            try
            {
                string sql = @"UPDATE user SET name=@name, username=@username, password=@password, 
                              status=@status, role=@role where id=@id";

                MySqlCommand mySqlCommand = new MySqlCommand(sql, _connection);
                // Set the parameters for your SQL command.
                mySqlCommand.Parameters.AddWithValue("@name", user.Name);
                mySqlCommand.Parameters.AddWithValue("@username", user.Username);
                mySqlCommand.Parameters.AddWithValue("@password", user.Password);
                mySqlCommand.Parameters.AddWithValue("@status", user.Status);
                mySqlCommand.Parameters.AddWithValue("@role", user.Role);
                mySqlCommand.Parameters.AddWithValue("@id", id);

                _connection.Open();
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("usuario editado com sucesso", "Sucesso ao editar", MessageBoxButtons.OK);
                _connection.Close();
                _connection.Dispose();
                _connection.ClearAllPoolsAsync();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar usuario: " + ex.Message);
            }
        }

        #endregion

        #region Apagar Utilizador

        public void Delete(string id)
        {
            try
            {
                string sql = @"DELETE FROM user where id=@id";

                MySqlCommand mySqlCommand = new MySqlCommand(sql, _connection);
                // Set the parameters for your SQL command.
                mySqlCommand.Parameters.AddWithValue("@id", id);

                _connection.Open();
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show("usuario apagado com sucesso", "Sucesso ao apagar", MessageBoxButtons.OK);
                _connection.Close();
                _connection.Dispose();
                _connection.ClearAllPoolsAsync();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar usuario: " + ex.Message);
            }
        }
        #endregion

        #region Buscar Todos Usuarios

        public DataTable GetAll()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT id, name, username, status, role, password FROM user";

                MySqlCommand mySqlCommand = new MySqlCommand(sql, _connection);
                _connection.Open();
                mySqlCommand.ExecuteNonQuery ();
                MySqlDataAdapter mySqlData = new MySqlDataAdapter(mySqlCommand);
                mySqlData.Fill(dt);
                _connection.Clone();
                _connection.Dispose ();
                _connection.ClearAllPoolsAsync ();
                return dt;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao buscar todos usuarios: " + ex.Message);
                return null;
            }
        }
        #endregion
    }
}

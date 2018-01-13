using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProjetoCidades.Models;

namespace ProjetoCidades.Repositorio
{
    public class CidadeRep
    {
        string connectionString = @"Data source=.\SqlExpress;Initial Catalog=ProjetoCidades;uid=sa;pwd=senai@123";

        public List<Cidade> Listar(){
            List<Cidade> lstCidades = new List<Cidade>();
            
            SqlConnection con = new SqlConnection(connectionString);

            string SqlQuery = "Select * from Cidades";

            SqlCommand cmd = new SqlCommand(SqlQuery, con);

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            while(sdr.Read()){
                Cidade cidade = new Cidade();

                cidade.Id = Convert.ToInt16(sdr["Id"]);
                cidade.Nome = sdr["Nome"].ToString();
                cidade.Estado = sdr["Estado"].ToString();
                cidade.Habitantes = Convert.ToInt16(sdr["Habitantes"]);

                lstCidades.Add(cidade);
            }

            con.Close();

            return lstCidades;
        }

        public Cidade Listar(int Id){
            Cidade cidade = new Cidade();
            
            SqlConnection con = new SqlConnection(connectionString);

            string SqlQuery = "Select * from Cidades where id=" + Id;

            SqlCommand cmd = new SqlCommand(SqlQuery, con);

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            sdr.Read();
               
            cidade.Id = Convert.ToInt16(sdr["Id"]);
            cidade.Nome = sdr["Nome"].ToString();
            cidade.Estado = sdr["Estado"].ToString();
            cidade.Habitantes = Convert.ToInt16(sdr["Habitantes"]);
            con.Close();

            return cidade;
        }

        public void Cadastrar(Cidade cidade){
            SqlConnection con = new SqlConnection(connectionString);

            string SqlQuery = "insert into Cidades(Nome, Estado, Habitantes)" + 
            "values ('"+ cidade.Nome +"','"+ cidade.Estado +"',"+ cidade.Habitantes +")";

            SqlCommand cmd = new SqlCommand(SqlQuery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Editar(Cidade cidade){

            SqlConnection con = new SqlConnection(connectionString);

            string SqlQuery = string.Format("UPDATE Cidades SET Nome='{0}', Estado='{1}', Habitantes={2} where id={3}", 
            cidade.Nome, cidade.Estado, cidade.Habitantes, cidade.Id);

            SqlCommand cmd = new SqlCommand(SqlQuery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(Cidade cidade){

            SqlConnection con = new SqlConnection(connectionString);

            string SqlQuery = string.Format("Delete from Cidades where Id='{0}'", cidade.Id);

            SqlCommand cmd = new SqlCommand(SqlQuery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
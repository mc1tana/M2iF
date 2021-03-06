using TpCompteBancaireWPF.Data;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;

namespace TpCompteBancaireWPF.Classes
{
    public class Client
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;        

        public int Id { get => id; set => id = value; }
        public string Nom
        {
            get => nom;
            set
            {
                //if (Tools.IsName(value))
                    nom = value;
                //else
                    //throw new FormatException("Erreur nom");
            }
        }
        public string Prenom
        {
            get => prenom;
            set
            {
                //if (Tools.IsName(value))
                    prenom = value;
                //else
                //    throw new FormatException("Erreur prénom");
            }
        }
        public string Telephone
        {
            get => telephone;
            set
            {
                //if (Tools.IsPhone(value))
                    telephone = value;
                //else
                //    throw new FormatException("Erreur téléphone");
            }
        }
        public Client()
        {
            
        }
        public Client(string n, string p, string t) : this()
        {            
            Nom = n;
            Prenom = p;
            Telephone = t;
        }

        public override string ToString()
        {
            return $"Nom : {Nom}, Prénom : {Prenom}, Téléphone : {Telephone}";
        }

        public int Add()
        {
            SqlConnection connection = DataBase.Connection;
            SqlCommand command = new SqlCommand("INSERT INTO clientBanque (nom,prenom,telephone)" +
                " OUTPUT INSERTED.ID VALUES (@Nom, @Prenom, @Telephone)", connection);
            command.Parameters.Add(new SqlParameter("@Nom", SqlDbType.VarChar) { Value = Nom });
            command.Parameters.Add(new SqlParameter("@Prenom", SqlDbType.VarChar) { Value = Prenom });
            command.Parameters.Add(new SqlParameter("@Telephone", SqlDbType.VarChar) { Value = Telephone });

            connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return Id;
        }
    }
}

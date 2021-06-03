using System;
using DataModel;
using MySql.Data.MySqlClient;

namespace DBConnect
{
    public class DB
    {
        string connectionString = "Server=mysql60.hostland.ru;Database=host1323541_shambala1;Uid=host1323541_itstep;Pwd=269f43dc;";

        private MySqlConnection _connection;
        private MySqlCommand _query;

        public DB()
        {
            _connection = new MySqlConnection(connectionString);
            _query = new MySqlCommand
            {
                Connection = _connection
            };
        }

        public void Open()
        {
            try
            {
                _connection.Open();
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Ошибка открытия БД");
            }
            catch (MySqlException)
            {
                throw new Exception("Подключаемся к уже открытой БД");
            }
        }

        //TODO Дополнить метод проверками исключений
        public void Close()
        {
            _connection.Close();
        }

        private MySqlDataReader SelectQuery(string sql)
        {
            _query.CommandText = sql;
            var result = _query.ExecuteReader();
            return result;
        }

        public Author GetAuthor(string name)
        {
            var sql = $"select * from tab_author where author_name = '{name}';";
            var result = SelectQuery(sql);
            result.Read();

            var id = result.GetInt32("id");

            string authorName;
            if (result.IsDBNull(result.GetOrdinal("author_name"))) authorName = "не заполнено";
            else if (String.IsNullOrEmpty(result.GetString("author_name"))) authorName = "не заполнено";
                 else authorName = result.GetString("author_name");

            var birthDate = result.GetDateTime("birth_date").ToString("dd.MM.yyyy");
            var deathDate = result.GetDateTime("death_date").ToString("dd.MM.yyyy");

            string birthCountry;
            if (result.IsDBNull(result.GetOrdinal("birth_country"))) birthCountry = "не заполнено";
            else if (String.IsNullOrEmpty(result.GetString("birth_country"))) birthCountry = "не заполнено";
                 else birthCountry = result.GetString("birth_country");

            Author author = new Author(id, authorName, birthDate, deathDate, birthCountry);

            return author;
        }

        public ExhibitsModel GetExhibits(string name)
        {
            var sql = $"select * from tab_exhibits where exhibit_name = '{name}';";
            var result = SelectQuery(sql);
            result.Read();

            var id = result.GetInt32("id");
            var exhibitsName = result.GetString("exhibit_name");
            var idAuthor = result.GetInt32("id_author");

            string creationDate;
            if (result.IsDBNull(result.GetOrdinal("creation_date"))) creationDate = "неизвестно";
            else creationDate = result.GetString("creation_date");
           
            string artDirection;
            if (result.IsDBNull(result.GetOrdinal("art_direction"))) artDirection = "не заполнено";
            else if (String.IsNullOrEmpty(result.GetString("art_direction"))) artDirection = "не заполнено";
                 else artDirection = result.GetString("art_direction");

            string artForm;
            if (result.IsDBNull(result.GetOrdinal("art_form"))) artForm = "не заполнено";
            else if (String.IsNullOrEmpty(result.GetString("art_form"))) artForm = "не заполнено";
                 else artForm = result.GetString("art_form");
                       
            string materials;            
            if (result.IsDBNull(result.GetOrdinal("materials"))) materials = "не заполнено";   
            else if(String.IsNullOrEmpty(result.GetString("materials"))) materials = "не заполнено";
                 else materials = result.GetString("materials");

            ExhibitsModel exhibits = new ExhibitsModel(id, exhibitsName, idAuthor, creationDate,
                                                        artDirection, artForm, materials);

            return exhibits;
        }

        public SpaceStorageModel GetSpaceStorage(int idExhib)
        {
            var sql = $"select * from tab_space_storage where id_exhibits = '{idExhib}';";
            var result = SelectQuery(sql);
            result.Read();

            var id = result.GetInt32("id");
            var idExhibits = result.GetInt32("id_exhibits");
            var idStorage = result.GetInt32("id_storage");
            var specialConditions = result.GetBoolean("special_conditions");


            SpaceStorageModel spaceStorage = new SpaceStorageModel(id, idExhibits, idStorage, specialConditions);

            return spaceStorage;
        }

        public StorageModel GetStorage(string name)
        {
            var sql = $"select * from tab_storage where storage_name = '{name}';";
            var result = SelectQuery(sql);
            result.Read();

            var id = result.GetInt32("id");
            var storageName = result.GetString("storage_name");

            StorageModel storage = new StorageModel(id, storageName);

            return storage;
        }
    }
}

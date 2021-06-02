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

        public AuthorModel GetAuthor(string name)
        {
            var sql = $"select * from tab_author where author_name = '{name}';";
            var result = SelectQuery(sql);
            result.Read();

            var id = result.GetInt32("id");
            var authorName = result.GetString("author_name");
            var birthDate = result.GetString("birth_date");
            var deathDate = result.GetString("death_date");
            var birthCountry=result.GetString("birth_country")

            AuthorModel author = new AuthorModel(id, authorName, birthDate, deathDate, birthCountry);

            return author;
        }

        public ExhibitsModel GetExhibits(string name)
        {
            var sql = $"select * from create table tab_exhibits where exhibit_name = '{name}';";
            var result = SelectQuery(sql);
            result.Read();

            var id = result.GetInt32("id");
            var exhibitsName = result.GetString("exhibits_name");
            var idAuthor = result.GetInt32("id_author");
            var creationDate = result.GetString("creation_date");
            var artDirection = result.GetString("art_direction");
            var artForm = result.GetString("art_form");
            var materials = result.GetString("materials");

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
            var specialConditions = result.GetString("special_conditions");


            SpaceStorageModel spaceStorage = new SpaceStorageModel(id, idExhibits, idStorage, specialConditions);

            return spaceStorage;
        }

        public StorageModel GetStorage(string name)
        {
            var sql = $"select * from tab_storage where storage_name = '{name}';";
            var result = SelectQuery(sql);
            result.Read();

            var id = result.GetInt32("id");
            var storageName = result.GetInt32("storage_name");

            SpaceStorageModel storage = new SpaceStorageModel(id, storageName);

            return storage;
        }
    }
}


using Npgsql;
using Paging.common;
using Paging.Model;
using Paging.Repository.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Paging.common.Sorting;


namespace Paging.Repository
{
    public class UsersRepository : IUsersRepository
    {

        private static readonly string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=root;Database=playerdb;";
     

        public async Task<List<Users>> Get(PagingList paging, Filtering filter, Sorting sortingOrder)
        {
            List<Users> users = new List<Users>();
            Filtering filtering= new Filtering();
            StringBuilder builder = new StringBuilder("SELECT * FROM users ");
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                {
                   if(paging != null)
                    {
                        builder.Append("offset @offset ");
                        builder.Append("limit @limit ");

                    }
                   if(filter != null)
                    {
                        return users.Where(user =>
                            (string.IsNullOrEmpty(filter.Name) || user.Nameuser.Equals(filter.Name, StringComparison.OrdinalIgnoreCase))
                            && (string.IsNullOrEmpty(filter.LastName) || user.LastNameuser.Equals(filter.LastName, StringComparison.OrdinalIgnoreCase))
                            && (string.IsNullOrEmpty(filter.Email) || user.Email.Equals(filter.Email, StringComparison.OrdinalIgnoreCase))
                        ).ToList();
                    }
                    if (sortingOrder!= null)
                    {
                        if (sortingOrder.SortByField == SortBy.Nameuser)
                        {
                            if (sortingOrder.SortOrderType == SortOrder.Ascending)
                                return users.OrderBy(user => user.Nameuser).ToList();
                            else
                                return users.OrderByDescending(user => user.Nameuser).ToList();
                        }
                        else if (sortingOrder.SortByField == SortBy.LastNameuser)
                        {
                            if (sortingOrder.SortOrderType == SortOrder.Ascending)
                                return users.OrderBy(user => user.LastNameuser).ToList();
                            else
                                return users.OrderByDescending(user => user.LastNameuser).ToList();
                        }
                        else if (sortingOrder.SortByField == SortBy.Email)
                        {
                            if (sortingOrder.SortOrderType == SortOrder.Ascending)
                                return users.OrderBy(user => user.Email).ToList();
                            else
                                return users.OrderByDescending(user => user.Email).ToList();
                        }
                        else
                        {
                            // Default sorting by ID in ascending order
                            if (sortingOrder.SortOrderType == SortOrder.Descending)
                                return users.OrderByDescending(user => user.Id).ToList();

                            return users.OrderBy(user => user.Id).ToList();
                        }
                    }
                 

                    using (NpgsqlCommand command = new NpgsqlCommand(builder.ToString(), connection))
                    {
                        command.Parameters.AddWithValue("@offset", (paging.CurrentPageNumber-1)* paging.PageSize);
                        command.Parameters.AddWithValue("@limmit", paging.PageSize);
                        command.Parameters.AddWithValue( filter.Name );
                        command.Parameters.AddWithValue( filter.LastName );
                        command.Parameters.AddWithValue( filter.Email);
                        command.Parameters.AddWithValue(sortingOrder.SortByField);
                        command.Parameters.AddWithValue(sortingOrder.SortOrderType);
                        using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                int Id = reader.GetInt32(reader.GetOrdinal("id"));
                                string nameuser = reader.GetString(reader.GetOrdinal("nameuser"));
                                string lastnameuser = reader.GetString(reader.GetOrdinal("lastnameuser"));
                                string email = reader.GetString(reader.GetOrdinal("email"));


                                var leagueTeam = new Users

                                {
                                    Id = Id,
                                    Nameuser = nameuser,
                                    LastNameuser = lastnameuser,
                                    Email = email

                                };
                                users.Add(leagueTeam);
                            }
                        }
                    }
                }

            }
            return users;
        }
    }
}
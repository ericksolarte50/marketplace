// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Marketplace.Core.Model;
using Microsoft.Data.Sqlite;

namespace Marketplace.Dal
{
    internal class MarketplaceDb : IMarketplaceDb, IDisposable
    {
        private readonly SqliteConnection _connection;

        public MarketplaceDb()
        {
            var path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @".."));
            _connection = new SqliteConnection($@"Data Source={path}\Marketplace.Dal\marketplace.db");
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public async Task<User[]> GetUsersAsync()
        {
            await using var command = new SqliteCommand(
                "SELECT U.Id, U.Username, COUNT(O.Id) AS Offers\r\n" +
                "FROM User U LEFT JOIN Offer O ON U.Id = O.UserId\r\n" +
                "GROUP BY U.Id, U.Username;",
                _connection);

            try
            {
                await using var reader = await command.ExecuteReaderAsync();


                var results = new List<User>();

                while (await reader.ReadAsync())
                {
                    var user = new User
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Username = reader.GetString(reader.GetOrdinal("Username"))
                    };

                    results.Add(user);
                }

                return results.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<int> countOffers()
        {
            await using var command = new SqliteCommand("SELECT count(*) as count FROM Offer;", _connection);

            try
            {
                int count = 0;
                await using var reader = await command.ExecuteReaderAsync();
                if (reader.Read())
                {
                    count = reader.GetInt32(reader.GetOrdinal("count"));
                }

                return count;
            }
            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }

        }

        public async Task<List<Offer>> getPageOffersAsync(int page, int size)
        {
            await using var command = new SqliteCommand("SELECT O.Id, O.CategoryId, O.Description, O.Location, O.PictureUrl,\r\n"+
                         "O.PublishedOn, O.Title, O.UserId, C.Name, U.Username\r\n"+
                    "FROM Offer O JOIN User U ON O.UserId = u.Id\r\n"+
                    "JOIN Category C ON C.Id = O.CategoryId\r\n"+
                    "LIMIT @size OFFSET @page;",
                _connection);

            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@size", size);
            command.Parameters.AddWithValue("@page", page);

            try
            {
                await using var reader = await command.ExecuteReaderAsync();


                var results = new List<Offer>();

                while (await reader.ReadAsync())
                {
                    var offer = new Offer
                    {
                        Id = reader.GetGuid(reader.GetOrdinal("Id")),
                        Category = new Category
                        {
                            Id = reader.GetByte(reader.GetOrdinal("CategoryId")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        },
                        Description = reader.GetString(reader.GetOrdinal("Description")),
                        Location = reader.GetString(reader.GetOrdinal("Location")),
                        PictureUrl = reader.GetString(reader.GetOrdinal("PictureUrl")),
                        PublishedOn = reader.GetDateTime(reader.GetOrdinal("PublishedOn")),
                        Title = reader.GetString(reader.GetOrdinal("Title")),
                        User = new User
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("UserId")),
                            Username = reader.GetString(reader.GetOrdinal("Username"))
                        }
                    };

                    results.Add(offer);
                }

                return results;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Webapplication.Models;

namespace Webapplication.Repository
{
    public class Repository
    {

        public List<CalculationDto> GetCalculations()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["scheduling"].ConnectionString;
            var queryString = @"SELECT * FROM Calculations";
            var table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    connection.Open();
                    using (var ad = new SqlDataAdapter(command))
                    {
                        ad.Fill(table);
                    }
                }

            }

            return MapData(table);
        }

        private List<CalculationDto> MapData(DataTable table)
        {
            var calculations = new List<CalculationDto>();
            foreach (DataRow row in table.Rows)
            {
                var organisatie = new CalculationDto()
                {
                    Id = row[0] as int? ?? default(int),
                    A = row[1] as int? ?? default(int),
                    B = row[2] as int? ?? default(int),
                    Sum = row[3] as int?,
                    DateCreated = row[4] as DateTime? ?? default(DateTime),
                    DateProcessed = row[5] as DateTime? ?? null

                };

                calculations.Add(organisatie);
            }
            return calculations;
        }
    }
}
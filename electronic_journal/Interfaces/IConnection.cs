﻿using System.Data.SqlClient;

namespace electronic_journal.Interfaces
{
    public interface IConnection
    {
        SqlConnection ConnectionSQL();

        SqlDataAdapter SqlDataAdapter(SqlCommand sqlCommand);
    }
}

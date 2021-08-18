using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data.SqlConstants
{
    public class BooksSqlConstants
    {
        internal const string ADD_BOOK = @"insert into Books(Name, Title) values(@Name, @Title);";

        internal const string GET_BOOK = @"select * from Books where id=@id";
    }
}

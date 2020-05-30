using DataLibrary.Data_Access;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Business_Logic
{
    public static class HoroscopeProcessor
    {
        public static int CreateUser(string Name, string Gender, DateTime DateOfBirth)
        {
            DateModel data = new DateModel
            {
                Name = Name,
                Gender = Gender,
                DateOfBirth = DateOfBirth
                

            };

            string sql =

            @"
EXEC SP_clear;

insert into dbo.UsersTable(Id, Name, Gender, DateOfBirth)
                            values(Rand(1), @Name, @Gender, @DateOfBirth);";

            //@"update dbo.UsersTable set Id = @Id , Name = @Name , Gender = @Gender, DateOfBirth = @DateOfBirth, Horoscope = ' ';";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List <DateModel> LoadHoroscopes()
        {
            string sql = @"SELECT b.Id, b.Name, b.Gender, b.DateOfBirth, a.Horoscope, [prediction]
  FROM [HoroscopeDB].[dbo].[HoroscopesTable] a
  inner join(
  select Id,Name, Gender, DateOfBirth, 
   case 
WHEN (MONTH(DateOfBirth) = 3 AND DAY(DateOfBirth) >= 21) OR (MONTH(DateOfBirth) = 4 AND DAY(DateOfBirth) <= 19) THEN 'Aries'
WHEN (MONTH(DateOfBirth) = 4 AND DAY(DateOfBirth) >= 20) OR (MONTH(DateOfBirth) = 5 AND DAY(DateOfBirth) <= 20) THEN 'Taurus'
WHEN (MONTH(DateOfBirth) = 5 AND DAY(DateOfBirth) >= 21) OR (MONTH(DateOfBirth) = 6 AND DAY(DateOfBirth) <= 20) THEN 'Gemini'
WHEN (MONTH(DateOfBirth) = 6 AND DAY(DateOfBirth) >= 21) OR (MONTH(DateOfBirth) = 7 AND DAY(DateOfBirth) <= 20) THEN 'Cancer'
WHEN (MONTH(DateOfBirth) = 7 AND DAY(DateOfBirth) >= 21) OR (MONTH(DateOfBirth) = 8 AND DAY(DateOfBirth) <= 20) THEN 'Leo'
WHEN (MONTH(DateOfBirth) = 8 AND DAY(DateOfBirth) >= 21) OR (MONTH(DateOfBirth) = 9 AND DAY(DateOfBirth) <= 20) THEN 'Virgo'
WHEN (MONTH(DateOfBirth) = 9 AND DAY(DateOfBirth) >= 21) OR (MONTH(DateOfBirth) = 10 AND DAY(DateOfBirth) <= 20) THEN 'Libra'
WHEN (MONTH(DateOfBirth) = 10 AND DAY(DateOfBirth) >= 21) OR (MONTH(DateOfBirth) = 11 AND DAY(DateOfBirth) <= 20) THEN 'Scorpio'
WHEN (MONTH(DateOfBirth) = 11 AND DAY(DateOfBirth) >= 21) OR (MONTH(DateOfBirth) = 12 AND DAY(DateOfBirth) <= 20) THEN 'Sagittarius'
WHEN (MONTH(DateOfBirth) = 12 AND DAY(DateOfBirth) >= 21) OR (MONTH(DateOfBirth) = 1 AND DAY(DateOfBirth) <= 20) THEN 'Capricorn'
WHEN (MONTH(DateOfBirth) = 1 AND DAY(DateOfBirth) >= 21) OR (MONTH(DateOfBirth) = 2 AND DAY(DateOfBirth) <= 20) THEN 'Aquarius'
WHEN (MONTH(DateOfBirth) = 2 AND DAY(DateOfBirth) >= 21) OR (MONTH(DateOfBirth) = 3 AND DAY(DateOfBirth) <= 20) THEN 'Pisces'
end as Horoscope
from [dbo].[UsersTable]
  )b
  on a.Horoscope = b.Horoscope



";

            return SqlDataAccess.LoadData<DateModel>(sql);
        }


    }
}

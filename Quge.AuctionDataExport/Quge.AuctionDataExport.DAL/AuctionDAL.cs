using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Quge.AuctionDataExport.DAL
{
	public class AuctionDAL:BaseDAL
	{
		public static int MoreData()
		{
			using (var Conn = GetConn())
			{
				Conn.Open();
				string sql = "select count(0) from user_detail";
				return Conn.ExecuteScalar<int>(sql);
			}
		}

		public static List<int> LessData()
		{
			using (var Conn = GetConn())
			{
				Conn.Open();
				string sql = "select * from gameidloginipfilter where Id=@Id";
				return Conn.Query<int>(sql).ToList();
			}
		}
	}
}

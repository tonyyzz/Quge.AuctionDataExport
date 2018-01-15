using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.AuctionDataExport.Model
{
	public class MoreDataModel
	{
		public string pId { get; set; }
		public DateTime registTime { get; set; }
		public double rechargeMoney { get; set; }
		public DateTime firstRechargeTime { get; set; }
		public int rechargeCount { get; set; }
		public DateTime firstAuctionGoodsTime { get; set; }
		public string firstAuctionGoodsName { get; set; }
		public int firstAuctionGoodsCount { get; set; }
		public DateTime lastLoginTime { get; set; }
		public bool isWinPrizeForTheGoods { get; set; }
		public string channel { get; set; }
	}
}

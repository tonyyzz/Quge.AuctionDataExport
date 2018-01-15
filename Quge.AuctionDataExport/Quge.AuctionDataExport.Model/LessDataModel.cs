using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quge.AuctionDataExport.Model
{
	public class LessDataModel
	{
		public string pId { get; set; }
		public DateTime auctionGoodsTime { get; set; }
		public string auctionGoodsName { get; set; }
		public int auctionCount { get; set; }
		public bool isWinPrizeForTheGoods { get; set; }
	}
}

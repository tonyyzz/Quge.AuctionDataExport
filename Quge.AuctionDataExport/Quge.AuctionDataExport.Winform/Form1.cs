using NPOI.HSSF.UserModel;
using Quge.AuctionDataExport.DAL;
using Quge.AuctionDataExport.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quge.AuctionDataExport.Winform
{
	public partial class Form1 : Form
	{
		private string path = "";
		private HSSFWorkbook hssfworkbook = null;
		private HSSFSheet moreSheet = null;
		private HSSFSheet lessSheet = null;

		private static int dataCount = 10000;

		public Form1()
		{
			InitializeComponent();
			lblStateStr.Text = "";
			hssfworkbook = new HSSFWorkbook();
			moreSheet = hssfworkbook.CreateSheet("moreData") as HSSFSheet;
			lessSheet = hssfworkbook.CreateSheet("lessData") as HSSFSheet;
		}


		private void Form1_Load(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// 写入文件
		/// </summary>
		/// <param name="hssfworkbook"></param>
		/// <param name="path"></param>
		private void WriteXlsToFile(HSSFWorkbook hssfworkbook, string path)
		{
			using (FileStream file = new FileStream(path, FileMode.Create))
			{
				hssfworkbook.Write(file);
			}
		}

		private void btnSelectExportPath_Click(object sender, EventArgs e)
		{
			saveFileDialog1.InitialDirectory = @"D:\";
			saveFileDialog1.FileName = DateTime.Now.ToString($"{DateTime.Now.ToString("yyyyMMddHHmmss")}_{Guid.NewGuid().ToString("N")}");
			saveFileDialog1.DefaultExt = "xls";
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				path = saveFileDialog1.FileName;
			}
			if (string.IsNullOrWhiteSpace(path))
			{
				return;
			}

			lblStateStr.Text = "导出中...";

			var moreDataList = GetMoreDataList();
			var lessDataList = GetLessDataList();
			CreateMoreDataTableHeader(moreSheet);
			CreateLessDataTableHeader(lessSheet);
			MoreDataHandle(moreDataList);
			LessDataHandle(lessDataList);

			WriteXlsToFile(hssfworkbook, path);
			lblStateStr.Text = "导出完成！";
			MessageBox.Show("导出成功！");
		}

		/// <summary>
		/// moreData模拟数据
		/// </summary>
		/// <returns></returns>
		private List<MoreDataModel> GetMoreDataList()
		{
			List<MoreDataModel> list = new List<MoreDataModel>();
			for (int i = 0; i < dataCount; i++)
			{
				list.Add(new MoreDataModel()
				{
					pId = $"10000{(i + 1).ToString().PadLeft(5, '0')}",
					registTime = DateTime.Now.AddDays(-10).AddHours(i),
					rechargeMoney = 100 + i,
					firstRechargeTime = DateTime.Now.AddDays(-5).AddHours(i),
					rechargeCount = 5 + i % 5,
					firstAuctionGoodsTime = DateTime.Now.AddDays(-4).AddHours(i),
					firstAuctionGoodsName = $"Goods{i.ToString().PadLeft(5, '0')}",
					firstAuctionGoodsCount = 50 + i % 5,
					lastLoginTime = DateTime.Now.AddDays(-4).AddHours(i),
					isWinPrizeForTheGoods = i % 3 == 0 ? true : false,
					channel = i % 3 == 0 ? "小米" : i % 3 == 1 ? "华为" : "vivo"
				});
			}
			return list;
		}

		/// <summary>
		/// lessData模拟数据
		/// </summary>
		/// <returns></returns>
		private List<LessDataModel> GetLessDataList()
		{
			List<LessDataModel> list = new List<LessDataModel>();
			for (int i = 0; i < dataCount; i++)
			{
				list.Add(new LessDataModel()
				{
					pId = $"10000{(i + 1).ToString().PadLeft(5, '0')}",
					auctionGoodsTime = DateTime.Now.AddDays(-4).AddHours(i),
					auctionGoodsName = $"Goods{i.ToString().PadLeft(5, '0')}",
					auctionCount = 50 + i % 5,
					isWinPrizeForTheGoods = i % 3 == 0 ? true : false,
				});
			}
			return list;
		}

		/// <summary>
		/// MoreData导出
		/// </summary>
		private void MoreDataHandle(List<MoreDataModel> list)
		{
			int dataNum = list.Count(); //数据量
			HSSFSheet sheet = moreSheet;
			HSSFRow row;
			HSSFCell cell;
			HSSFCellStyle cellStyle = getCellStyle();
			HSSFCellStyle timeCellStyle = getTimeCellStyle();

			for (int i = 0; i < dataNum; i++)
			{
				var item = list[i];
				row = sheet.CreateRow(i + 1) as HSSFRow;

				cell = row.CreateCell(0) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.pId);

				cell = row.CreateCell(1) as HSSFCell;
				cell.CellStyle = timeCellStyle;
				cell.SetCellValue(item.registTime);

				cell = row.CreateCell(2) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.rechargeMoney);

				cell = row.CreateCell(3) as HSSFCell;
				cell.CellStyle = timeCellStyle;
				cell.SetCellValue(item.firstRechargeTime);

				cell = row.CreateCell(4) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.rechargeCount);

				cell = row.CreateCell(5) as HSSFCell;
				cell.CellStyle = timeCellStyle;
				cell.SetCellValue(item.firstAuctionGoodsTime);

				cell = row.CreateCell(6) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.firstAuctionGoodsName);

				cell = row.CreateCell(7) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.firstAuctionGoodsCount);

				cell = row.CreateCell(8) as HSSFCell;
				cell.CellStyle = timeCellStyle;
				cell.SetCellValue(item.lastLoginTime);

				cell = row.CreateCell(9) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.isWinPrizeForTheGoods ? "√" : "×");

				cell = row.CreateCell(10) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.channel);
			}
		}
		/// <summary>
		/// LessData导出
		/// </summary>
		private void LessDataHandle(List<LessDataModel> list)
		{
			int dataNum = list.Count(); //数据量
			HSSFSheet sheet = lessSheet;
			HSSFRow row;
			HSSFCell cell;
			HSSFCellStyle cellStyle = getCellStyle();
			HSSFCellStyle timeCellStyle = getTimeCellStyle();

			for (int i = 0; i < dataNum; i++)
			{
				var item = list[i];
				row = sheet.CreateRow(i + 1) as HSSFRow;

				cell = row.CreateCell(0) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.pId);

				cell = row.CreateCell(1) as HSSFCell;
				cell.CellStyle = timeCellStyle;
				cell.SetCellValue(item.auctionGoodsTime);

				cell = row.CreateCell(2) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.auctionGoodsName);

				cell = row.CreateCell(3) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.auctionCount);

				cell = row.CreateCell(4) as HSSFCell;
				cell.CellStyle = cellStyle;
				cell.SetCellValue(item.isWinPrizeForTheGoods ? "√" : "×");
			}
		}

		/// <summary>
		/// 创建moreData的表头数据
		/// </summary>
		/// <param name="sheet"></param>
		private void CreateMoreDataTableHeader(HSSFSheet sheet)
		{
			HSSFCellStyle celStyle = getCellStyle();
			HSSFRow row = sheet.CreateRow(0) as HSSFRow;

			sheet.SetColumnWidth(0, 20 * 256);
			var cell = row.CreateCell(0);
			cell.SetCellValue("用户id");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(1, 20 * 256);
			cell = row.CreateCell(1);
			cell.SetCellValue("用户注册时间");
			cell.CellStyle = celStyle;

			cell = row.CreateCell(2);
			cell.SetCellValue("充值额度");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(3, 20 * 256);
			cell = row.CreateCell(3);
			cell.SetCellValue("第一次充值时间");
			cell.CellStyle = celStyle;

			cell = row.CreateCell(4);
			cell.SetCellValue("充值次数");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(5, 20 * 256);
			cell = row.CreateCell(5);
			cell.SetCellValue("首次竞拍商品时间");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(6, 20 * 256);
			cell = row.CreateCell(6);
			cell.SetCellValue("首次竞拍商品名称");
			cell.CellStyle = celStyle;

			cell = row.CreateCell(7);
			cell.SetCellValue("次数");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(8, 20 * 256);
			cell = row.CreateCell(8);
			cell.SetCellValue("最后一次登录时间");
			cell.CellStyle = celStyle;

			cell = row.CreateCell(9);
			cell.SetCellValue("是否中奖");
			cell.CellStyle = celStyle;

			cell = row.CreateCell(10);
			cell.SetCellValue("渠道");
			cell.CellStyle = celStyle;
		}

		/// <summary>
		/// 创建lessData的表头数据
		/// </summary>
		/// <param name="sheet"></param>
		private void CreateLessDataTableHeader(HSSFSheet sheet)
		{
			HSSFCellStyle celStyle = getCellStyle();
			HSSFRow row = sheet.CreateRow(0) as HSSFRow;

			sheet.SetColumnWidth(0, 20 * 256);
			var cell = row.CreateCell(0);
			cell.SetCellValue("用户id");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(1, 20 * 256);
			cell = row.CreateCell(1);
			cell.SetCellValue("参与竞拍商品时间");
			cell.CellStyle = celStyle;

			sheet.SetColumnWidth(2, 20 * 256);
			cell = row.CreateCell(2);
			cell.SetCellValue("参与竞拍商品名称");
			cell.CellStyle = celStyle;

			cell = row.CreateCell(3);
			cell.SetCellValue("竞拍次数");
			cell.CellStyle = celStyle;

			cell = row.CreateCell(4);
			cell.SetCellValue("是否中奖");
			cell.CellStyle = celStyle;
		}

		/// <summary>
		/// 标准样式
		/// </summary>
		/// <param name="hssfworkbook"></param>
		/// <returns></returns>
		private HSSFCellStyle getCellStyle()
		{
			HSSFCellStyle cellStyle = hssfworkbook.CreateCellStyle() as HSSFCellStyle;
			cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
			cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
			cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
			cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
			return cellStyle;
		}

		private HSSFCellStyle getTimeCellStyle()
		{
			HSSFCellStyle cellStyle = getCellStyle();
			HSSFDataFormat format = hssfworkbook.CreateDataFormat() as HSSFDataFormat;
			cellStyle.DataFormat = format.GetFormat("yyyy.MM.dd HH:mm:ss");
			return cellStyle;
		}
	}
}

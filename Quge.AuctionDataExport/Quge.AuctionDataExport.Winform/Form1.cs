using NPOI.HSSF.UserModel;
using Quge.AuctionDataExport.DAL;
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

			CreateMoreDataTableHeader(moreSheet);
			CreateLessDataTableHeader(lessSheet);
			MoreDataHandle();
			LessDataHandle();

			WriteXlsToFile(hssfworkbook, path);
			MessageBox.Show("导出成功！");
		}

		/// <summary>
		/// MoreData导出
		/// </summary>
		private void MoreDataHandle()
		{
			var moreDataLi = AuctionDAL.MoreData();
			int colNum = 11;
			int dataNum = 10; //数据量
			HSSFSheet sheet = moreSheet;
			HSSFRow row;
			HSSFCell cell;
			HSSFCellStyle celStyle = getCellStyle();

			for (int i = 0; i < dataNum; i++)
			{
				row = sheet.CreateRow(i + 1) as HSSFRow;
				for (int j = 0; j < colNum; j++)
				{
					cell = row.CreateCell(j) as HSSFCell;
					cell.CellStyle = celStyle;
					cell.SetCellValue($"value{j}");
				}
			}
		}
		/// <summary>
		/// LessData导出
		/// </summary>
		private void LessDataHandle()
		{
			int colNum = 5;
			int dataNum = 10; //数据量
			HSSFSheet sheet = lessSheet;
			HSSFRow row;
			HSSFCell cell;
			HSSFCellStyle celStyle = getCellStyle();

			for (int i = 0; i < dataNum; i++)
			{
				row = sheet.CreateRow(i + 1) as HSSFRow;
				for (int j = 0; j < colNum; j++)
				{
					cell = row.CreateCell(j) as HSSFCell;
					cell.CellStyle = celStyle;
					cell.SetCellValue($"value{j}");
				}
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

			sheet.SetColumnWidth(0, 10 * 256);
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

			sheet.SetColumnWidth(0, 10 * 256);
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
	}
}

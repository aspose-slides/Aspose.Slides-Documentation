---
title: 建立並將 Excel 圖表嵌入為 OLE 物件
type: docs
weight: 70
url: /zh-hant/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
以下兩個程式碼範例因描述的任務較為複雜而較長且詳細。您會建立一個 Microsoft Excel 活頁簿，建立圖表，然後建立要嵌入圖表的 Microsoft PowerPoint 簡報。OLE 物件包含指向原始文件的連結，使用者雙擊嵌入的檔案時會啟動該檔案及其應用程式。

## **VSTO**
使用 VSTO 時，執行以下步驟：

1. 建立 Microsoft Excel ApplicationClass 物件的實例。
1. 建立一個僅包含一個工作表的新活頁簿。
1. 在工作表中加入圖表。
1. 儲存活頁簿。
1. 開啟包含圖表資料工作表的 Excel 活頁簿。
1. 取得該工作表的 ChartObjects 集合。
1. 取得要複製的圖表。
1. 建立 Microsoft PowerPoint 簡報。
1. 在簡報中加入一個空白投影片。
1. 將 Excel 工作表中的圖表複製到剪貼簿。
1. 將圖表貼上至 PowerPoint 簡報中。
1. 在投影片上定位圖表。
1. 儲存簡報。

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// 宣告一個 Excel ApplicationClass 實例的變數。
	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// 宣告用於 Workbooks.Open 方法參數的變數。
	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// 宣告用於 Chart.ChartWizard 方法的變數。
	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Sales by Quarter";

	object paramCategoryTitle = "Fiscal Quarter";

	object paramValueTitle = "Billions";

	try

	{

		// 建立 Excel ApplicationClass 物件的實例。
	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// 建立一個包含 1 個工作表的新活頁簿。
		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// 變更工作表的名稱。
		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Quarterly Sales";

		// 在工作表中插入圖表的資料。
		//              A       B       C       D       E
		//     1                Q1      Q2      Q3      Q4
		//     2    N. America  1.5     2       1.5     2.5
		//     3    S. America  2       1.75    2       2
		//     4    Europe      2.25    2       2.5     2
		//     5    Asia        2.5     2.5     2       2.75
		SetCellValue(targetSheet, "A2", "N. America");
		SetCellValue(targetSheet, "A3", "S. America");
		SetCellValue(targetSheet, "A4", "Europe");
		SetCellValue(targetSheet, "A5", "Asia");
		SetCellValue(targetSheet, "B1", "Q1");
		SetCellValue(targetSheet, "B2", 1.5);
		SetCellValue(targetSheet, "B3", 2);
		SetCellValue(targetSheet, "B4", 2.25);
		SetCellValue(targetSheet, "B5", 2.5);
		SetCellValue(targetSheet, "C1", "Q2");
		SetCellValue(targetSheet, "C2", 2);
		SetCellValue(targetSheet, "C3", 1.75);
		SetCellValue(targetSheet, "C4", 2);
		SetCellValue(targetSheet, "C5", 2.5);
		SetCellValue(targetSheet, "D1", "Q3");
		SetCellValue(targetSheet, "D2", 1.5);
		SetCellValue(targetSheet, "D3", 2);
		SetCellValue(targetSheet, "D4", 2.5);
		SetCellValue(targetSheet, "D5", 2);
		SetCellValue(targetSheet, "E1", "Q4");
		SetCellValue(targetSheet, "E2", 2.5);
		SetCellValue(targetSheet, "E3", 2);
		SetCellValue(targetSheet, "E4", 2);
		SetCellValue(targetSheet, "E5", 2.75);

		// 取得包含圖表資料的範圍。
		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// 取得該工作表的 ChartObjects 集合。
		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// 在集合中加入圖表。
		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Sales Chart";

		// 建立新圖表。
		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// 儲存活頁簿。
		newWorkbook.SaveAs(paramWorkbookPath, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, xlNS.XlSaveAsAccessMode.xlNoChange, paramMissing, paramMissing, paramMissing, paramMissing, paramMissing);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		if (excelApplication != null)

		{

			// 關閉 Excel。
			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// 宣告保留對 PowerPoint 物件參考的變數。
	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// 宣告保留對 Excel 物件參考的變數。
	xlNS.Application excelApplication = null;

	xlNS.Workbook excelWorkBook = null;

	xlNS.Worksheet targetSheet = null;

	xlNS.ChartObjects chartObjects = null;

	xlNS.ChartObject existingChartObject = null;

	string paramPresentationPath = System.Windows.Forms.Application.StartupPath + @"\ChartTest.pptx";

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath + @"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	try

	{

		// 建立 PowerPoint 的實例。
		powerpointApplication =new pptNS.Application();

		// 建立 Excel 的實例。
		excelApplication = new xlNS.Application();

		// 開啟包含圖表資料工作表的 Excel 活頁簿。
		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// 取得包含圖表的工作表。
		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

		// 取得該工作表的 ChartObjects 集合。
		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// 取得要複製的圖表。
		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

		// 建立 PowerPoint 簡報。
		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// 在簡報中加入空白投影片。
		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// 將圖表從 Excel 工作表複製到剪貼簿。
		existingChartObject.Copy();

		// 將圖表貼上至 PowerPoint 簡報。
		shapeRange = pptSlide.Shapes.Paste();

		// 在投影片上定位圖表。
		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// 儲存簡報。
		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// 釋放 PowerPoint 投影片物件。
		shapeRange = null;

		pptSlide = null;

		// 關閉並釋放 Presentation 物件。
		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// 退出 PowerPoint 並釋放 ApplicationClass 物件。
		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// 釋放 Excel 物件。
		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// 關閉並釋放 Excel 活頁簿物件。
		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// 退出 Excel 並釋放 ApplicationClass 物件。
		if (excelApplication != null)

		{

			excelApplication.Quit();

			excelApplication = null;

		}

		GC.Collect();

		GC.WaitForPendingFinalizers();

		GC.Collect();

		GC.WaitForPendingFinalizers();

	}

}

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	CreateNewChartInExcel();

	UseCopyPaste();

}

``` 
## **Aspose.Slides**
使用 Aspose.Slides for .NET 時，執行以下步驟：

1. 使用 Aspose.Cells for .NET 建立活頁簿。
1. 建立 Microsoft Excel 圖表。
1. 設定 Excel 圖表的 OLE 大小。
1. 取得圖表的影像。
1. 使用 Aspose.Slides for .NET 將 Excel 圖表作為 OLE 物件嵌入 PPTX 簡報。
1. 以第 3 步取得的影像取代變更物件的圖像，以解決物件變更問題。
1. 將輸出簡報以 PPTX 格式寫入磁碟。

``` csharp

 static void Main(string[] args)

{

	//建立活頁簿
	Workbook wb = new Workbook();

	//新增 Excel 圖表
	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);
	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//將活頁簿儲存至串流
	MemoryStream wbStream = wb.SaveToStream();

	//建立簡報
	PresentationEx pres = new PresentationEx();
	SlideEx sld = pres.Slides[0];

	//在投影片上加入活頁簿
	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//將輸出簡報寫入磁碟
	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//新增工作表以填入資料
	int dataSheetIdx = wb.Worksheets.Add();
	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
	string sheetName = "DataSheet";
	dataSheet.Name = sheetName;

	//為 DataSheet 填入資料
	dataSheet.Cells["A2"].PutValue("N. America");
	dataSheet.Cells["A3"].PutValue("S. America");
	dataSheet.Cells["A4"].PutValue("Europe");
	dataSheet.Cells["A5"].PutValue("Asia");
	dataSheet.Cells["B1"].PutValue("Q1");
	dataSheet.Cells["B2"].PutValue(1.5);
	dataSheet.Cells["B3"].PutValue(2);
	dataSheet.Cells["B4"].PutValue(2.25);
	dataSheet.Cells["B5"].PutValue(2.5);
	dataSheet.Cells["C1"].PutValue("Q2");
	dataSheet.Cells["C2"].PutValue(2);
	dataSheet.Cells["C3"].PutValue(1.75);
	dataSheet.Cells["C4"].PutValue(2);
	dataSheet.Cells["C5"].PutValue(2.5);
	dataSheet.Cells["D1"].PutValue("Q3");
	dataSheet.Cells["D2"].PutValue(1.5);
	dataSheet.Cells["D3"].PutValue(2);
	dataSheet.Cells["D4"].PutValue(2.5);
	dataSheet.Cells["D5"].PutValue(2);
	dataSheet.Cells["E1"].PutValue("Q4");
	dataSheet.Cells["E2"].PutValue(2.5);
	dataSheet.Cells["E3"].PutValue(2);
	dataSheet.Cells["E4"].PutValue(2);
	dataSheet.Cells["E5"].PutValue(2.75);

	//新增圖表工作表
	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);
	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
	chartSheet.Name = "ChartSheet";

	//在 ChartSheet 中加入圖表，資料系列來自 DataSheet
	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);
	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//設定圖表標題
	chart.Title.Text = "Sales by Quarter";

	//設定繪圖區前景色
	chart.PlotArea.Area.ForegroundColor = Color.White;

	//設定繪圖區背景色
	chart.PlotArea.Area.BackgroundColor = Color.White;

	//設定圖表區前景色
	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	//設定圖表類別軸標題
	chart.CategoryAxis.Title.Text = "Fiscal Quarter";

	//設定圖表數值軸標題
	chart.ValueAxis.Title.Text = "Billions";

	//設定 ChartSheet 為作用中工作表
	wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
	return chartSheetIdx;

}

private static void AddExcelChartInPresentation(PresentationEx pres, SlideEx sld, Stream wbStream, Bitmap imgChart)

{

	float oleWidth = pres.SlideSize.Size.Width;
	float oleHeight = pres.SlideSize.Size.Height;
	int x = 0;
	byte[] chartOleData = new byte[wbStream.Length];
	wbStream.Position = 0;
	wbStream.Read(chartOleData, 0, chartOleData.Length);
	OleObjectFrameEx oof = null;
	oof = sld.Shapes.AddOleObjectFrame(x, 0, oleWidth, oleHeight, "Excel.Sheet.8", chartOleData);
    using (MemoryStream imageStream = new MemoryStream())
    {
        imgChart.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
        imageStream.Position = 0;
        IPPImage ppImage = pres.Images.AddImage(imageStream);
        oof.SubstitutePictureFormat.Picture.Image = ppImage;
    }

}
``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object/)
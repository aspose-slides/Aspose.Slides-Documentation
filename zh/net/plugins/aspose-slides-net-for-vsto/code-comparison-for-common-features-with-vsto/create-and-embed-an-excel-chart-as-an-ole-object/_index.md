---
title: 创建并嵌入 Excel 图表作为 OLE 对象
type: docs
weight: 70
url: /zh/net/create-and-embed-an-excel-chart-as-an-ole-object/
---

下面的两个代码示例较长且详细，因为它们所描述的任务涉及多个步骤。您需要创建一个 Microsoft Excel 工作簿，创建一个图表，然后创建一个 Microsoft PowerPoint 演示文稿，将图表嵌入其中。OLE 对象包含指向原始文档的链接，因此双击嵌入文件的用户将启动该文件及其应用程序。
## **VSTO**
使用 VSTO，执行以下步骤：

1. 创建 Microsoft Excel ApplicationClass 对象的实例。
1. 创建一个包含一个工作表的新工作簿。
1. 将图表添加到工作表中。
1. 保存工作簿。
1. 打开包含图表数据的 Excel 工作簿。
1. 获取工作表的 ChartObjects 集合。
1. 获取要复制的图表。
1. 创建一个 Microsoft PowerPoint 演示文稿。
1. 向演示文稿添加一个空白幻灯片。
1. 将 Excel 工作表中的图表复制到剪贴板。
1. 将图表粘贴到 PowerPoint 演示文稿中。
1. 在幻灯片上定位图表。
1. 保存演示文稿。

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// 声明一个 Excel ApplicationClass 实例的变量。

	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// 声明 Workbooks.Open 方法参数的变量。

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// 声明 Chart.ChartWizard 方法的变量。

	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "按季度销售";

	object paramCategoryTitle = "财政季度";

	object paramValueTitle = "十亿";

	try

	{

		// 创建 Excel ApplicationClass 对象的实例。

	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// 创建一个包含 1 个工作表的新工作簿。

		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// 更改工作表名称。

		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "季度销售";

		// 在工作表中插入一些用于图表的数据。

		//              A       B       C       D       E

		//     1                Q1      Q2      Q3      Q4

		//     2    北美      1.5     2       1.5     2.5

		//     3    南美      2       1.75    2       2

		//     4    欧洲      2.25    2       2.5     2

		//     5    亚洲      2.5     2.5     2       2.75

		SetCellValue(targetSheet, "A2", "北美");

		SetCellValue(targetSheet, "A3", "南美");

		SetCellValue(targetSheet, "A4", "欧洲");

		SetCellValue(targetSheet, "A5", "亚洲");

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

		// 获取包含图表数据的范围。

		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// 获取工作表的 ChartObjects 集合。

		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// 向集合中添加图表。

		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "销售图表";

		// 创建数据的新图表。

		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// 保存工作簿。

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

			// 关闭 Excel。

			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// 声明变量以保存对 PowerPoint 对象的引用。

	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// 声明变量以保存对 Excel 对象的引用。

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

		// 创建 PowerPoint 实例。

		powerpointApplication =new pptNS.Application();

		// 创建 Excel 实例。

		excelApplication = new xlNS.Application();

		// 打开包含图表数据的工作表的 Excel 工作簿。

		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// 获取包含图表的工作表。

		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["季度销售"]);

		// 获取工作表的 ChartObjects 集合。

		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// 获取要复制的图表。

		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("销售图表"));

		// 创建 PowerPoint 演示文稿。

		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// 向演示文稿添加一张空白幻灯片。

		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// 将图表从 Excel 工作表复制到剪贴板。

		existingChartObject.Copy();

		// 将图表粘贴到 PowerPoint 演示文稿中。

		shapeRange = pptSlide.Shapes.Paste();

		// 在幻灯片上定位图表。

		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// 保存演示文稿。

		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// 释放 PowerPoint 幻灯片对象。

		shapeRange = null;

		pptSlide = null;

		// 关闭并释放演示文稿对象。

		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// 退出 PowerPoint 并释放 ApplicationClass 对象。

		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// 释放 Excel 对象。

		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// 关闭并释放 Excel 工作簿对象。

		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// 退出 Excel 并释放 ApplicationClass 对象。

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
使用 Aspose.Slides for .NET，执行以下步骤：

1. 使用 Aspose.Cells for .NET 创建一个工作簿。
1. 创建 Microsoft Excel 图表。
1. 设置 Excel 图表的 OLE 大小。
1. 获取图表的图像。
1. 使用 Aspose.Slides for .NET 将 Excel 图表嵌入为 PPTX 演示文稿中的 OLE 对象。
1. 用步骤 3 中获得的图像替换更改的对象图像，以解决对象更改问题。
1. 将输出演示文稿写入磁盘，以 PPTX 格式保存。

``` csharp

 static void Main(string[] args)

{

	// 创建一个工作簿

	Workbook wb = new Workbook();

	// 添加一个 Excel 图表

	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);

	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	// 将工作簿保存到流中

	MemoryStream wbStream = wb.SaveToStream();

	// 创建一个演示文稿

	PresentationEx pres = new PresentationEx();

	SlideEx sld = pres.Slides[0];

	// 在幻灯片上添加工作簿

	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	// 将输出演示文稿写入磁盘

	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	// 添加一个新工作表以填充数据

	int dataSheetIdx = wb.Worksheets.Add();

	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];

	string sheetName = "数据表";

	dataSheet.Name = sheetName;

	// 用数据填充数据表

	dataSheet.Cells["A2"].PutValue("北美");

	dataSheet.Cells["A3"].PutValue("南美");

	dataSheet.Cells["A4"].PutValue("欧洲");

	dataSheet.Cells["A5"].PutValue("亚洲");

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

	// 添加图表工作表

	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);

	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];

	chartSheet.Name = "图表工作表";

	// 在图表工作表中添加一个基于数据表的数据系列的图表

	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);

	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];

	chart.NSeries.Add(sheetName + "!A1:E5", false);

	// 设置图表标题

	chart.Title.Text = "按季度销售";

	// 设置图表区域的前景色

	chart.PlotArea.Area.ForegroundColor = Color.White;

	// 设置图表区域的背景色

	chart.PlotArea.Area.BackgroundColor = Color.White;

	// 设置图表区域的前景色

	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	// 设置图表类别轴的标题

	chart.CategoryAxis.Title.Text = "财政季度";

	// 设置图表值轴的标题

	chart.ValueAxis.Title.Text = "十亿";

	// 设置图表工作表为活动工作表

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
## **下载示例代码**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772950)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20\(Aspose.Slides\).zip)
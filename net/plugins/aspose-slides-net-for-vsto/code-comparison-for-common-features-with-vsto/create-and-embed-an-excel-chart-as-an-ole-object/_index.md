---
title: Create and Embed an Excel Chart as an OLE Object
type: docs
weight: 70
url: /net/create-and-embed-an-excel-chart-as-an-ole-object/
---

The two code examples below are long and detailed because the task they're describing is involved. You create a Microsoft Excel workbook, create a chart and then create the Microsoft PowerPoint presentation that you'll embed the chart into. OLE objects contain links to the original document so a user that double-clicks the embedded file will launch the file and it's application.
### **VSTO**
Using VSTO, the following steps are performed:

1. Create an instance of the Microsoft Excel ApplicationClass object.
1. Create a new workbook with one sheet in it.
1. Add chart to the sheet.
1. Save the workbook.
1. Open the Excel workbook containing the worksheet with the chart data.
1. Get the ChartObjects collection for the sheet.
1. Get the chart to copy.
1. Create a Microsoft PowerPoint presentation.
1. Add a blank slide to the presentation.
1. Copy the chart from the Excel worksheet to the clipboard.
1. Paste the chart into the PowerPoint presentation.
1. Position the chart on the slide.
1. Save the presentation.

```

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Declare a variable for the Excel ApplicationClass instance.

	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Declare variables for the Workbooks.Open method parameters.

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Declare variables for the Chart.ChartWizard method.

	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Sales by Quarter";

	object paramCategoryTitle = "Fiscal Quarter";

	object paramValueTitle = "Billions";

	try

	{

		// Create an instance of the Excel ApplicationClass object.

	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Create a new workbook with 1 sheet in it.

		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Change the name of the sheet.

		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Quarterly Sales";

		// Insert some data for the chart into the sheet.

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

		// Get the range holding the chart data.

		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// Get the ChartObjects collection for the sheet.

		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Add a Chart to the collection.

		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Sales Chart";

		// Create a new chart of the data.

		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// Save the workbook.

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

			// Close Excel.

			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// Declare variables to hold references to PowerPoint objects.

	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// Declare variables to hold references to Excel objects.

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

		// Create an instance of PowerPoint.

		powerpointApplication =new pptNS.Application();

		// Create an instance Excel.

		excelApplication = new xlNS.Application();

		// Open the Excel workbook containing the worksheet with the chart data.

		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// Get the worksheet that contains the chart.

		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

		// Get the ChartObjects collection for the sheet.

		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Get the chart to copy.

		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

		// Create a PowerPoint presentation.

		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// Add a blank slide to the presentation.

		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// Copy the chart from the Excel worksheet to the clipboard.

		existingChartObject.Copy();

		// Paste the chart into the PowerPoint presentation.

		shapeRange = pptSlide.Shapes.Paste();

		// Position the chart on the slide.

		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// Save the presentation.

		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// Release the PowerPoint slide object.

		shapeRange = null;

		pptSlide = null;

		// Close and release the Presentation object.

		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// Quit PowerPoint and release the ApplicationClass object.

		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// Release the Excel objects.

		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// Close and release the Excel Workbook object.

		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// Quit Excel and release the ApplicationClass object.

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
### **Aspose.Slides**
Using Aspose.Slides for .NET, the following steps are performed:

1. Create a workbook using Aspose.Cells for .NET.
1. Create a Microsoft Excel chart.
1. Set the OLE size of the Excel Chart.
1. Get an image of the chart.
1. Embed the Excel chart as an OLE Object inside PPTX presentation using Aspose.Slides for .NET.
1. Replace the object changed image with the image obtained in step 3 to cater for the object changed issue.
1. Write the output presentation to disk in PPTX format.

```

 static void Main(string[] args)

{

	//Create a workbook

	Workbook wb = new Workbook();

	//Add an excel chart

	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);

	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//Save the workbook to stream

	MemoryStream wbStream = wb.SaveToStream();

	//Create a presentation

	PresentationEx pres = new PresentationEx();

	SlideEx sld = pres.Slides[0];

	//Add the workbook on slide

	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//Write the output presentation on disk

	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//Add a new worksheet to populate cells with data

	int dataSheetIdx = wb.Worksheets.Add();

	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];

	string sheetName = "DataSheet";

	dataSheet.Name = sheetName;

	//Populate DataSheet with data

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

	//Add a chart sheet

	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);

	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];

	chartSheet.Name = "ChartSheet";

	//Add a chart in ChartSheet with data series from DataSheet

	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);

	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];

	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//Setting Chart's Title

	chart.Title.Text = "Sales by Quarter";

	//Setting the foreground color of the plot area

	chart.PlotArea.Area.ForegroundColor = Color.White;

	//Setting the background color of the plot area

	chart.PlotArea.Area.BackgroundColor = Color.White;

	//Setting the foreground color of the chart area

	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	//Setting the title of category axis of the chart

	chart.CategoryAxis.Title.Text = "Fiscal Quarter";

	//Setting the title of value axis of the chart

	chart.ValueAxis.Title.Text = "Billions";

	//Set ChartSheet an active sheet

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

	oof.Image = pres.Images.AddImage((System.Drawing.Image)imgChart);

}

}

```
## **Download Sample Code**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772950)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20\(Aspose.Slides\).zip)

---
title: Skapa och bädda in ett Excel-diagram som ett OLE-objekt
type: docs
weight: 70
url: /sv/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
De två kodexemplen nedan är långa och detaljerade eftersom uppgiften de beskriver är omfattande. Du skapar en Microsoft Excel-arbetsbok, skapar ett diagram och sedan skapar du Microsoft PowerPoint-presentationen som du ska bädda in diagrammet i. OLE-objekt innehåller länkar till originaldokumentet så en användare som dubbelklickar på den inbäddade filen kommer att öppna filen och dess program.
## **VSTO**
När du använder VSTO utförs följande steg:

1. Skapa en instans av Microsoft Excel ApplicationClass-objektet.
1. Skapa en ny arbetsbok med ett blad i.
1. Lägg till ett diagram på bladet.
1. Spara arbetsboken.
1. Öppna Excel-arbetsboken som innehåller kalkylbladet med diagramdata.
1. Hämta samlingen ChartObjects för bladet.
1. Hämta diagrammet som ska kopieras.
1. Skapa en Microsoft PowerPoint-presentation.
1. Lägg till en tom bild i presentationen.
1. Kopiera diagrammet från Excel-kalkylbladet till urklipp.
1. Klistra in diagrammet i PowerPoint-presentationen.
1. Placera diagrammet på bilden.
1. Spara presentationen.

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Deklarera en variabel för Excel ApplicationClass-instansen.

	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Deklarera variabler för Workbooks.Open-metodens parametrar.

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Deklarera variabler för Chart.ChartWizard-metoden.

	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Sales by Quarter";

	object paramCategoryTitle = "Fiscal Quarter";

	object paramValueTitle = "Billions";

	try

	{

		// Skapa en instans av Excel ApplicationClass-objektet.

	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Skapa en ny arbetsbok med 1 blad i.

		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Ändra bladets namn.

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

		// Hämta intervallet som innehåller diagramdata.

		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// Hämta ChartObjects-samlingen för bladet.

		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Lägg till ett diagram i samlingen.

		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Sales Chart";

		// Create a new chart of the data.

		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// Spara arbetsboken.

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

			// Stäng Excel.

			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// Deklarera variabler för att hålla referenser till PowerPoint-objekt.

	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// Deklarera variabler för att hålla referenser till Excel-objekt.

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

		// Skapa en instans av PowerPoint.

		powerpointApplication =new pptNS.Application();

		// Skapa en instans av Excel.

		excelApplication = new xlNS.Application();

		// Öppna Excel-arbetsboken som innehåller kalkylbladet med diagramdata.

		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// Hämta kalkylbladet som innehåller diagrammet.

		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

		// Hämta ChartObjects-samlingen för bladet.

		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Hämta diagrammet som ska kopieras.

		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

		// Skapa en PowerPoint-presentation.

		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// Lägg till en tom bild i presentationen.

		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// Kopiera diagrammet från Excel-kalkylbladet till urklipp.

		existingChartObject.Copy();

		// Klistra in diagrammet i PowerPoint-presentationen.

		shapeRange = pptSlide.Shapes.Paste();

		// Placera diagrammet på bilden.

		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// Spara presentationen.

		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// Frigör PowerPoint-bildobjektet.

		shapeRange = null;

		pptSlide = null;

		// Stäng och frigör Presentation-objektet.

		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// Avsluta PowerPoint och frigör ApplicationClass-objektet.

		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// Frigör Excel-objekten.

		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// Stäng och frigör Excel-arbetsboksobjektet.

		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// Avsluta Excel och frigör ApplicationClass-objektet.

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
När du använder Aspose.Slides för .NET utförs följande steg:

1. Skapa en arbetsbok med Aspose.Cells för .NET.
1. Skapa ett Microsoft Excel-diagram.
1. Ställ in OLE-storleken för Excel-diagrammet.
1. Hämta en bild av diagrammet.
1. Bädda in Excel-diagrammet som ett OLE-objekt i PPTX-presentationen med Aspose.Slides för .NET.
1. Byt ut objektändrade bilden mot bilden som erhölls i steg 3 för att hantera problemet med objektändring.
1. Skriv utdata-presentationen till disk i PPTX-format.

``` csharp

 static void Main(string[] args)

{

	//Skapa en arbetsbok
	Workbook wb = new Workbook();
	//Lägg till ett Excel-diagram
	int chartSheetIndex = AddExcelChartInWorkbook(wb);
	wb.Worksheets.SetOleSize(0, 5, 0, 5);
	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
	//Spara arbetsboken till en ström
	MemoryStream wbStream = wb.SaveToStream();
	//Skapa en presentation
	PresentationEx pres = new PresentationEx();
	SlideEx sld = pres.Slides[0];
	//Lägg till arbetsboken på bilden
	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
	//Skriv den resulterande presentationen till disk
	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//Lägg till ett nytt kalkylblad för att fylla celler med data
	int dataSheetIdx = wb.Worksheets.Add();
	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
	string sheetName = "DataSheet";
	dataSheet.Name = sheetName;
	//Fyll DataSheet med data
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
	//Lägg till ett diagramark
	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);
	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
	chartSheet.Name = "ChartSheet";
	//Lägg till ett diagram i ChartSheet med dataserier från DataSheet
	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);
	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
	chart.NSeries.Add(sheetName + "!A1:E5", false);
	//Ställer in diagrammets titel
	chart.Title.Text = "Sales by Quarter";
	//Ställer in förgrundsfärgen för plotområdet
	chart.PlotArea.Area.ForegroundColor = Color.White;
	//Ställer in bakgrundsfärgen för plotområdet
	chart.PlotArea.Area.BackgroundColor = Color.White;
	//Ställer in förgrundsfärgen för diagramområdet
	chart.ChartArea.Area.BackgroundColor = Color.White;
	chart.Title.TextFont.Size = 16;
	//Ställer in titeln för diagrammets kategoriska axel
	chart.CategoryAxis.Title.Text = "Fiscal Quarter";
	//Ställer in titeln för diagrammets värdeaxel
	chart.ValueAxis.Title.Text = "Billions";
	//Sätt ChartSheet som aktivt blad
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
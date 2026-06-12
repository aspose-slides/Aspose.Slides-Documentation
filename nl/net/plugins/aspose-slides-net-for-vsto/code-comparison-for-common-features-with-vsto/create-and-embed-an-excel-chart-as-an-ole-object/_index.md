---
title: Maak en embed een Excel‑grafiek als OLE‑object
type: docs
weight: 70
url: /nl/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
De twee onderstaande codevoorbeelden zijn lang en gedetailleerd omdat de taak die ze beschrijven omvangrijk is. Je maakt een Microsoft Excel‑werkmap, maakt een grafiek en maakt daarna de Microsoft PowerPoint‑presentatie waarin je de grafiek embedde. OLE‑objecten bevatten koppelingen naar het oorspronkelijke document, zodat een gebruiker die dubbelklikt op het ingebedde bestand het bestand en de bijbehorende applicatie opent.

## **VSTO**
Met VSTO worden de volgende stappen uitgevoerd:

1. Maak een instantie van het Microsoft Excel ApplicationClass‑object.
1. Maak een nieuwe werkmap met één werkblad.
1. Voeg een grafiek toe aan het werkblad.
1. Sla de werkmap op.
1. Open de Excel-werkmap die het werkblad met de grafiekgegevens bevat.
1. Haal de ChartObjects‑collectie op voor het werkblad.
1. Haal de te kopiëren grafiek op.
1. Maak een Microsoft PowerPoint‑presentatie.
1. Voeg een lege dia toe aan de presentatie.
1. Kopieer de grafiek van het Excel-werkblad naar het klembord.
1. Plak de grafiek in de PowerPoint‑presentatie.
1. Plaats de grafiek op de dia.
1. Sla de presentatie op.

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Declareer een variabele voor de Excel ApplicationClass‑instantie.

	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Declareer variabelen voor de parameters van de Workbooks.Open‑methode.

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Declareer variabelen voor de Chart.ChartWizard‑methode.

	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Sales by Quarter";

	object paramCategoryTitle = "Fiscal Quarter";

	object paramValueTitle = "Billions";

	try

	{

		// Maak een instantie van het Excel ApplicationClass‑object.

	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Maak een nieuwe werkmap met 1 werkblad.

		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Verander de naam van het werkblad.

		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Quarterly Sales";

		// Voeg wat gegevens voor de grafiek in het werkblad in.

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

		// Haal het bereik op dat de grafiekgegevens bevat.

		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// Haal de ChartObjects‑collectie op voor het werkblad.

		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Voeg een grafiek toe aan de collectie.

		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Sales Chart";

		// Maak een nieuwe grafiek van de gegevens.

		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// Sla de werkmap op.

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

			// Sluit Excel.

			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// Declareer variabelen om referenties naar PowerPoint‑objecten vast te houden.

	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// Declareer variabelen om referenties naar Excel‑objecten vast te houden.

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

		// Maak een instantie van PowerPoint.

		powerpointApplication =new pptNS.Application();

		// Maak een Excel‑instantie.

		excelApplication = new xlNS.Application();

		// Open de Excel‑werkmap die het werkblad met de grafiekgegevens bevat.

		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// Haal het werkblad op dat de grafiek bevat.

		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

		// Haal de ChartObjects‑collectie op voor het werkblad.

		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Haal de te kopiëren grafiek op.

		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

		// Maak een PowerPoint‑presentatie.

		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// Voeg een lege dia toe aan de presentatie.

		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// Kopieer de grafiek van het Excel‑werkblad naar het klembord.

		existingChartObject.Copy();

		// Plak de grafiek in de PowerPoint‑presentatie.

		shapeRange = pptSlide.Shapes.Paste();

		// Plaats de grafiek op de dia.

		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// Sla de presentatie op.

		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// Maak het PowerPoint‑dia‑object vrij.

		shapeRange = null;

		pptSlide = null;

		// Sluit en maak het Presentation‑object vrij.

		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// Sluit PowerPoint af en maak het ApplicationClass‑object vrij.

		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// Maak de Excel‑objecten vrij.

		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// Sluit en maak het Excel‑Workbook‑object vrij.

		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// Sluit Excel af en maak het ApplicationClass‑object vrij.

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
Met Aspose.Slides voor .NET worden de volgende stappen uitgevoerd:

1. Maak een werkmap met Aspose.Cells voor .NET.
1. Maak een Microsoft Excel‑grafiek.
1. Stel de OLE-grootte van de Excel‑grafiek in.
1. Haal een afbeelding van de grafiek op.
1. Embed de Excel‑grafiek als OLE‑object in de PPTX‑presentatie met Aspose.Slides voor .NET.
1. Vervang de afbeelding van het gewijzigde object door de afbeelding verkregen in stap 3 om het probleem met gewijzigde objecten op te lossen.
1. Schrijf de output‑presentatie naar schijf in PPTX‑formaat.

``` csharp

 static void Main(string[] args)

{

	// Maak een werkmap

	Workbook wb = new Workbook();

	// Voeg een Excel‑grafiek toe

	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);

	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	// Sla de werkmap op naar een stream

	MemoryStream wbStream = wb.SaveToStream();

	// Maak een presentatie

	PresentationEx pres = new PresentationEx();

	SlideEx sld = pres.Slides[0];

	// Voeg de werkmap toe aan de dia

	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	// Schrijf de uitvoer‑presentatie naar schijf

	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	// Voeg een nieuw werkblad toe om cellen met gegevens te vullen

	int dataSheetIdx = wb.Worksheets.Add();

	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];

	string sheetName = "DataSheet";

	dataSheet.Name = sheetName;

	// Vul DataSheet met gegevens

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

	// Voeg een grafiekblad toe

	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);

	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];

	chartSheet.Name = "ChartSheet";

	// Voeg een grafiek toe in ChartSheet met dataseries van DataSheet

	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);

	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];

	chart.NSeries.Add(sheetName + "!A1:E5", false);

	// Instellen van de titel van de grafiek

	chart.Title.Text = "Sales by Quarter";

	// Instellen van de voorgrondkleur van het plotgebied

	chart.PlotArea.Area.ForegroundColor = Color.White;

	// Instellen van de achtergrondkleur van het plotgebied

	chart.PlotArea.Area.BackgroundColor = Color.White;

	// Instellen van de voorgrondkleur van het grafiekgebied

	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	// Instellen van de titel van de categorie‑as van de grafiek

	chart.CategoryAxis.Title.Text = "Fiscal Quarter";

	// Instellen van de titel van de waarden‑as van de grafiek

	chart.ValueAxis.Title.Text = "Billions";

	// Maak ChartSheet het actieve werkblad

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
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object/)
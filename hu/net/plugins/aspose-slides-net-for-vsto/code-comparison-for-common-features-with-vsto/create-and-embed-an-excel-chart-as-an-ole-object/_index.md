---
title: Excel-diagram létrehozása és OLE objektumként beágyazása
type: docs
weight: 70
url: /hu/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
A lent látható két kódpélda hosszú és részletes, mivel a leírt feladat összetett. Létrehoz egy Microsoft Excel munkafüzetet, elkészít egy diagramot, majd létrehozza a Microsoft PowerPoint prezentációt, amelybe beágyazza a diagramot. Az OLE objektumok hivatkozásokat tartalmaznak az eredeti dokumentumra, ezért a beágyazott fájlt dupla kattintással megnyitó felhasználó elindítja a fájlt és annak alkalmazását.
## **VSTO**
A VSTO használatával a következő lépések hajtódnak végre:

1. Hozzon létre egy példányt a Microsoft Excel ApplicationClass objektumból.
1. Hozzon létre egy új munkafüzetet, amely egy lapot tartalmaz.
1. Adjon hozzá diagramot a munkalaphoz.
1. Mentse a munkafüzetet.
1. Nyissa meg azt az Excel munkafüzetet, amely a diagram adatait tartalmazó munkalapot tartalmazza.
1. Szerezze be a ChartObjects gyűjteményt a munkalaphoz.
1. Szerezze be a másolandó diagramot.
1. Hozzon létre egy Microsoft PowerPoint prezentációt.
1. Adjon hozzá egy üres diát a prezentációhoz.
1. Másolja a diagramot az Excel munkalapról a vágólapra.
1. Illessze be a diagramot a PowerPoint prezentációba.
1. Helyezze el a diagramot a dián.
1. Mentse a prezentációt.

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Deklarálja a változót az Excel ApplicationClass példányhoz.

	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Deklarálja a változókat a Workbooks.Open metódus paramétereihez.

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Deklarálja a változókat a Chart.ChartWizard metódushoz.

	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Sales by Quarter";

	object paramCategoryTitle = "Fiscal Quarter";

	object paramValueTitle = "Billions";

	try

	{

		// Létrehozza az Excel ApplicationClass objektum példányát.

	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Létrehoz egy új munkafüzetet, amely 1 lapot tartalmaz.

		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Megváltoztatja a lap nevét.

		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Quarterly Sales";

		// Beszúr néhány adatot a diagramhoz a munkalapra.

		//              A       B       C       D       E

		//     1                Q1      Q2      Q3      Q4

		//     2    Észak-Amerika  1.5     2       1.5     2.5

		//     3    Dél-Amerika    2       1.75    2       2

		//     4    Európa         2.25    2       2.5     2

		//     5    Ázsia          2.5     2.5     2       2.75

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

		// Lekéri a diagram adatokat tartalmazó tartományt.

		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// Lekéri a ChartObjects gyűjteményt a munkalaphoz.

		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Hozzáad egy diagramot a gyűjteményhez.

		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Sales Chart";

		// Létrehozza az adatból egy új diagramot.

		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// Elmenti a munkafüzetet.

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

			// Bezárja az Excelt.

			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// Deklarálja a változókat, amelyek PowerPoint objektumokra mutatnak.

	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// Deklarálja a változókat, amelyek Excel objektumokra mutatnak.

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

		// Létrehozza a PowerPoint példányt.

		powerpointApplication =new pptNS.Application();

		// Létrehozza az Excel példányt.

		excelApplication = new xlNS.Application();

		// Megnyitja azt az Excel munkafüzetet, amely a diagram adatokat tartalmazó munkalapot tartalmazza.

		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// Lekéri a diagramot tartalmazó munkalapot.

		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

		// Lekéri a ChartObjects gyűjteményt a munkalaphoz.

		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Lekéri a másolandó diagramot.

		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

		// Létrehozza a PowerPoint prezentációt.

		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// Hozzáad egy üres diát a prezentációhoz.

		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// Másolja a diagramot az Excel munkalapról a vágólapra.

		existingChartObject.Copy();

		// Beilleszti a diagramot a PowerPoint prezentációba.

		shapeRange = pptSlide.Shapes.Paste();

		// Elhelyezi a diagramot a dián.

		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// Elmenti a prezentációt.

		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// Felszabadítja a PowerPoint dia objektumot.

		shapeRange = null;

		pptSlide = null;

		// Bezárja és felszabadítja a Presentation objektumot.

		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// Kilép a PowerPointból és felszabadítja az ApplicationClass objektumot.

		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// Felszabadítja az Excel objektumokat.

		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// Bezárja és felszabadítja az Excel Workbook objektumot.

		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// Kilép az Excelből és felszabadítja az ApplicationClass objektumot.

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
Az Aspose.Slides for .NET használatával a következő lépések hajtódnak végre:

1. Hozzon létre egy munkafüzetet az Aspose.Cells for .NET segítségével.
1. Hozzon létre egy Microsoft Excel diagramot.
1. Állítsa be az Excel diagram OLE méretét.
1. Szerezzen képet a diagramról.
1. Ágyazza be az Excel diagramot OLE objektumként a PPTX prezentációba az Aspose.Slides for .NET használatával.
1. Cserélje le a módosított objektum képét a 3. lépésben kapott képre az objektum módosítási problémájának megoldásához.
1. Írja a kimeneti prezentációt lemezre PPTX formátumban.

``` csharp

 static void Main(string[] args)

{

	//Munkafüzet létrehozása
	Workbook wb = new Workbook();

	//Excel diagram hozzáadása
	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);

	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//Munkafüzet mentése adatfolyamra
	MemoryStream wbStream = wb.SaveToStream();

	//Prezentáció létrehozása
	PresentationEx pres = new PresentationEx();

	SlideEx sld = pres.Slides[0];

	//Munkafüzet hozzáadása a diára
	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//Kimeneti prezentáció írása lemezre
	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//Új munkalap hozzáadása a cellák adatokkal való feltöltéséhez
	int dataSheetIdx = wb.Worksheets.Add();

	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];

	string sheetName = "DataSheet";

	dataSheet.Name = sheetName;

	//DataSheet feltöltése adatokkal
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

	//Diagramlap hozzáadása
	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);

	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];

	chartSheet.Name = "ChartSheet";

	//Diagram hozzáadása a ChartSheet-be a DataSheet adatsorozataival
	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);

	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];

	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//Diagram címének beállítása
	chart.Title.Text = "Sales by Quarter";

	//A diagramterület előtérszínének beállítása
	chart.PlotArea.Area.ForegroundColor = Color.White;

	//A diagramterület háttérszínének beállítása
	chart.PlotArea.Area.BackgroundColor = Color.White;

	//A diagramterület előtérszínének beállítása
	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	//A diagram kategória tengelyének címének beállítása
	chart.CategoryAxis.Title.Text = "Fiscal Quarter";

	//A diagram értéktengelyének címének beállítása
	chart.ValueAxis.Title.Text = "Billions";

	//A ChartSheet beállítása aktív munkalappá
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
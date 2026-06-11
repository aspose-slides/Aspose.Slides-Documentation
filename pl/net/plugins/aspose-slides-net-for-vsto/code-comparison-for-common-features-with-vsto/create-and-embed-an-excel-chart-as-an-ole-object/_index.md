---
title: Utwórz i osadź wykres Excel jako obiekt OLE
type: docs
weight: 70
url: /pl/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
Poniższe dwa przykłady kodu są długie i szczegółowe, ponieważ opisują złożone zadanie. Tworzysz skoroszyt Microsoft Excel, tworzysz wykres, a następnie tworzysz prezentację Microsoft PowerPoint, w którą osadzisz wykres. Obiekty OLE zawierają odnośniki do oryginalnego dokumentu, więc użytkownik, który dwukrotnie kliknie osadzony plik, uruchomi go wraz z jego aplikacją.
## **VSTO**
Korzystając z VSTO, wykonuje się następujące kroki:

1. Utwórz instancję obiektu Microsoft Excel ApplicationClass.
1. Utwórz nowy skoroszyt z jedną arkuszem.
1. Dodaj wykres do arkusza.
1. Zapisz skoroszyt.
1. Otwórz skoroszyt Excel zawierający arkusz z danymi wykresu.
1. Pobierz kolekcję ChartObjects dla arkusza.
1. Pobierz wykres do skopiowania.
1. Utwórz prezentację Microsoft PowerPoint.
1. Dodaj pusty slajd do prezentacji.
1. Skopiuj wykres z arkusza Excel do schowka.
1. Wklej wykres do prezentacji PowerPoint.
1. Ustaw pozycję wykresu na slajdzie.
1. Zapisz prezentację.

```csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Zadeklaruj zmienną dla instancji obiektu Excel ApplicationClass.
	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Zadeklaruj zmienne dla parametrów metody Workbooks.Open.
	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";
	object paramMissing = Type.Missing;

	// Zadeklaruj zmienne dla metody Chart.ChartWizard.
	object paramChartFormat = 1;
	object paramCategoryLabels = 0;
	object paramSeriesLabels = 0;
	bool paramHasLegend = true;
	object paramTitle = "Sales by Quarter";
	object paramCategoryTitle = "Fiscal Quarter";
	object paramValueTitle = "Billions";

	try
	{
		// Utwórz instancję obiektu Excel ApplicationClass.
	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Utwórz nowy skoroszyt z 1 arkuszem.
		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Zmień nazwę arkusza.
		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
		targetSheet.Name = "Quarterly Sales";

		// Wstaw dane wykresu do arkusza.
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

		// Pobierz zakres zawierający dane wykresu.
		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// Pobierz kolekcję ChartObjects dla arkusza.
		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Dodaj wykres do kolekcji.
		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
		newChartObject.Name = "Sales Chart";

		// Utwórz nowy wykres na podstawie danych.
		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// Zapisz skoroszyt.
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
			// Zamknij Excel.
			excelApplication.Quit();
		}
	}
}

public void UseCopyPaste()
{
	// Zadeklaruj zmienne przechowujące odniesienia do obiektów PowerPoint.
	pptNS.Application powerpointApplication = null;
	pptNS.Presentation pptPresentation = null;
	pptNS.Slide pptSlide = null;
	pptNS.ShapeRange shapeRange = null;

	// Zadeklaruj zmienne przechowujące odniesienia do obiektów Excel.
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
		// Utwórz instancję PowerPoint.
		powerpointApplication =new pptNS.Application();

		// Utwórz instancję Excel.
		excelApplication = new xlNS.Application();

		// Otwórz skoroszyt Excel zawierający arkusz z danymi wykresu.
		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
			paramMissing, paramMissing, paramMissing, paramMissing);

		// Pobierz arkusz zawierający wykres.
		targetSheet =
			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

		// Pobierz kolekcję ChartObjects dla arkusza.
		chartObjects =
			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Pobierz wykres do skopiowania.
		existingChartObject =
			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

		// Utwórz prezentację PowerPoint.
		pptPresentation =
			powerpointApplication.Presentations.Add(
			Microsoft.Office.Core.MsoTriState.msoTrue);

		// Dodaj pusty slajd do prezentacji.
		pptSlide =
			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// Skopiuj wykres z arkusza Excel do schowka.
		existingChartObject.Copy();

		// Wklej wykres do prezentacji PowerPoint.
		shapeRange = pptSlide.Shapes.Paste();

		// Ustaw pozycję wykresu na slajdzie.
		shapeRange.Left = 60;
		shapeRange.Top = 100;

		// Zapisz prezentację.
		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
	finally
	{
		// Zwolnij obiekt slajdu PowerPoint.
		shapeRange = null;
		pptSlide = null;

		// Zamknij i zwolnij obiekt Presentation.
		if (pptPresentation != null)
		{
			pptPresentation.Close();
			pptPresentation = null;
		}

		// Zakończ PowerPoint i zwolnij obiekt ApplicationClass.
		if (powerpointApplication != null)
		{
			powerpointApplication.Quit();
			powerpointApplication = null;
		}

		// Zwolnij obiekty Excel.
		targetSheet = null;
		chartObjects = null;
		existingChartObject = null;

		// Zamknij i zwolnij obiekt skoroszytu Excel.
		if (excelWorkBook != null)
		{
			excelWorkBook.Close(false, paramMissing, paramMissing);
			excelWorkBook = null;
		}

		// Zakończ Excel i zwolnij obiekt ApplicationClass.
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
Korzystając z Aspose.Slides dla .NET, wykonuje się następujące kroki:

1. Utwórz skoroszyt przy użyciu Aspose.Cells dla .NET.
1. Utwórz wykres Microsoft Excel.
1. Ustaw rozmiar OLE wykresu Excel.
1. Uzyskaj obraz wykresu.
1. Osadź wykres Excel jako obiekt OLE w prezentacji PPTX przy użyciu Aspose.Slides dla .NET.
1. Zastąp zmieniony obraz obiektu obrazem uzyskanym w kroku 3, aby rozwiązać problem zmiany obiektu.
1. Zapisz wynikową prezentację na dysku w formacie PPTX.

```csharp

 static void Main(string[] args)
{
	//Utwórz skoroszyt
	Workbook wb = new Workbook();
	//Dodaj wykres Excel
	int chartSheetIndex = AddExcelChartInWorkbook(wb);
	wb.Worksheets.SetOleSize(0, 5, 0, 5);
	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
	//Zapisz skoroszyt do strumienia
	MemoryStream wbStream = wb.SaveToStream();
	//Utwórz prezentację
	PresentationEx pres = new PresentationEx();
	SlideEx sld = pres.Slides[0];
	//Dodaj skoroszyt na slajdzie
	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
	//Zapisz wyjściową prezentację na dysku
	pres.Write("chart.pptx");
}

static int AddExcelChartInWorkbook(Workbook wb)
{
	//Dodaj nowy arkusz, aby wypełnić komórki danymi
	int dataSheetIdx = wb.Worksheets.Add();
	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
	string sheetName = "DataSheet";
	dataSheet.Name = sheetName;
	//Wypełnij DataSheet danymi
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
	//Dodaj arkusz wykresu
	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);
	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
	chartSheet.Name = "ChartSheet";
	//Dodaj wykres w ChartSheet z serią danych z DataSheet
	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);
	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
	chart.NSeries.Add(sheetName + "!A1:E5", false);
	//Ustawienie tytułu wykresu
	chart.Title.Text = "Sales by Quarter";
	//Ustawienie koloru pierwszoplanowego obszaru wykresu
	chart.PlotArea.Area.ForegroundColor = Color.White;
	//Ustawienie koloru tła obszaru wykresu
	chart.PlotArea.Area.BackgroundColor = Color.White;
	//Ustawienie koloru pierwszoplanowego obszaru wykresu
	chart.ChartArea.Area.BackgroundColor = Color.White;
	chart.Title.TextFont.Size = 16;
	//Ustawienie tytułu osi kategorii wykresu
	chart.CategoryAxis.Title.Text = "Fiscal Quarter";
	//Ustawienie tytułu osi wartości wykresu
	chart.ValueAxis.Title.Text = "Billions";
	//Ustaw ChartSheet jako aktywny arkusz
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
## **Pobierz przykładowy kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object/)
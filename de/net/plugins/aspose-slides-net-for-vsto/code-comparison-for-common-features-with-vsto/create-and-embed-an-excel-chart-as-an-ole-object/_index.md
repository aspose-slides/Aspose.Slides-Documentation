---
title: Erstellen und Einfügen eines Excel-Diagramms als OLE-Objekt
type: docs
weight: 70
url: /de/net/create-and-embed-an-excel-chart-as-an-ole-object/
---

Die beiden Codebeispiele unten sind lang und detailliert, da die beschriebene Aufgabe komplex ist. Sie erstellen eine Microsoft Excel-Arbeitsmappe, erstellen ein Diagramm und dann die Microsoft PowerPoint-Präsentation, in die Sie das Diagramm einfügen werden. OLE-Objekte enthalten Links zum ursprünglichen Dokument, sodass ein Benutzer, der die eingebettete Datei doppelt anklickt, die Datei und die zugehörige Anwendung öffnet.
## **VSTO**
Mit VSTO werden die folgenden Schritte durchgeführt:

1. Erstellen Sie eine Instanz des Microsoft Excel ApplicationClass-Objekts.
1. Erstellen Sie eine neue Arbeitsmappe mit einem Arbeitsblatt.
1. Fügen Sie das Diagramm zum Arbeitsblatt hinzu.
1. Speichern Sie die Arbeitsmappe.
1. Öffnen Sie die Excel-Arbeitsmappe, die das Arbeitsblatt mit den Diagrammdaten enthält.
1. Holen Sie sich die ChartObjects-Sammlung für das Arbeitsblatt.
1. Holen Sie sich das zu kopierende Diagramm.
1. Erstellen Sie eine Microsoft PowerPoint-Präsentation.
1. Fügen Sie der Präsentation eine leere Folie hinzu.
1. Kopieren Sie das Diagramm aus dem Excel-Arbeitsblatt in die Zwischenablage.
1. Fügen Sie das Diagramm in die PowerPoint-Präsentation ein.
1. Positionieren Sie das Diagramm auf der Folie.
1. Speichern Sie die Präsentation.

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Deklarieren Sie eine Variable für die Excel ApplicationClass-Instanz.

	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Deklarieren Sie Variablen für die Workbooks.Open-Methodenparameter.

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Deklarieren Sie Variablen für die Chart.ChartWizard-Methode.

	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Umsatz nach Quartal";

	object paramCategoryTitle = "Fiskalquartal";

	object paramValueTitle = "Milliarden";

	try

	{

		// Erstellen Sie eine Instanz des Excel ApplicationClass-Objekts.

	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Erstellen Sie eine neue Arbeitsmappe mit 1 Blatt.

		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Ändern Sie den Namen des Arbeitsblatts.

		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Quartalsumsatz";

		// Fügen Sie einige Daten für das Diagramm in das Blatt ein.

		//              A       B       C       D       E

		//     1                Q1      Q2      Q3      Q4

		//     2    N. Amerika  1.5     2       1.5     2.5

		//     3    S. Amerika  2       1.75    2       2

		//     4    Europa      2.25    2       2.5     2

		//     5    Asien       2.5     2.5     2       2.75

		SetCellValue(targetSheet, "A2", "N. Amerika");

		SetCellValue(targetSheet, "A3", "S. Amerika");

		SetCellValue(targetSheet, "A4", "Europa");

		SetCellValue(targetSheet, "A5", "Asien");

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

		// Holen Sie sich den Bereich mit den Diagrammdaten.

		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// Holen Sie sich die ChartObjects-Sammlung für das Blatt.

		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Fügen Sie ein Diagramm zur Sammlung hinzu.

		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Umsatzdiagramm";

		// Erstellen Sie ein neues Diagramm aus den Daten.

		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// Speichern Sie die Arbeitsmappe.

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

			// Schließen Sie Excel.

			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// Deklarieren Sie Variablen, um Referenzen auf PowerPoint-Objekte zu halten.

	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// Deklarieren Sie Variablen, um Referenzen auf Excel-Objekte zu halten.

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

		// Erstellen Sie eine Instanz von PowerPoint.

		powerpointApplication =new pptNS.Application();

		// Erstellen Sie eine Instanz von Excel.

		excelApplication = new xlNS.Application();

		// Öffnen Sie die Excel-Arbeitsmappe, die das Arbeitsblatt mit den Diagrammdaten enthält.

		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// Holen Sie sich das Arbeitsblatt, das das Diagramm enthält.

		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quartalsumsatz"]);

		// Holen Sie sich die ChartObjects-Sammlung für das Blatt.

		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Holen Sie sich das zu kopierende Diagramm.

		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Umsatzdiagramm"));

		// Erstellen Sie eine PowerPoint-Präsentation.

		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// Fügen Sie der Präsentation eine leere Folie hinzu.

		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// Kopieren Sie das Diagramm aus dem Excel-Arbeitsblatt in die Zwischenablage.

		existingChartObject.Copy();

		// Fügen Sie das Diagramm in die PowerPoint-Präsentation ein.

		shapeRange = pptSlide.Shapes.Paste();

		// Positionieren Sie das Diagramm auf der Folie.

		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// Speichern Sie die Präsentation.

		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// Geben Sie das PowerPoint-Folienobjekt frei.

		shapeRange = null;

		pptSlide = null;

		// Schließen und geben Sie das Präsentationsobjekt frei.

		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// Beenden Sie PowerPoint und geben Sie das ApplicationClass-Objekt frei.

		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// Geben Sie die Excel-Objekte frei.

		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// Schließen und geben Sie das Excel-Arbeitsbuchobjekt frei.

		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// Beenden Sie Excel und geben Sie das ApplicationClass-Objekt frei.

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
Mit Aspose.Slides für .NET werden die folgenden Schritte durchgeführt:

1. Erstellen Sie eine Arbeitsmappe mit Aspose.Cells für .NET.
1. Erstellen Sie ein Microsoft Excel-Diagramm.
1. Setzen Sie die OLE-Größe des Excel-Diagramms.
1. Holen Sie sich ein Bild des Diagramms.
1. Betten Sie das Excel-Diagramm als OLE-Objekt in die PPTX-Präsentation mit Aspose.Slides für .NET ein.
1. Ersetzen Sie das Objekt, das das geänderte Bild enthält, durch das in Schritt 3 erhaltene Bild, um das Problem mit dem geänderten Objekt zu beheben.
1. Schreiben Sie die ausgegebene Präsentation auf die Festplatte im PPTX-Format.

``` csharp

 static void Main(string[] args)

{

	//Erstellen Sie eine Arbeitsmappe

	Workbook wb = new Workbook();

	//Fügen Sie ein Excel-Diagramm hinzu

	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);

	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//Speichern Sie die Arbeitsmappe im Stream

	MemoryStream wbStream = wb.SaveToStream();

	//Erstellen Sie eine Präsentation

	PresentationEx pres = new PresentationEx();

	SlideEx sld = pres.Slides[0];

	//Fügen Sie die Arbeitsmappe in die Folie ein

	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//Schreiben Sie die Ausgabpräsentation auf die Festplatte

	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//Fügen Sie ein neues Arbeitsblatt hinzu, um die Zellen mit Daten zu füllen

	int dataSheetIdx = wb.Worksheets.Add();

	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];

	string sheetName = "Datenblatt";

	dataSheet.Name = sheetName;

	//Füllen Sie das Datenblatt mit Daten

	dataSheet.Cells["A2"].PutValue("N. Amerika");

	dataSheet.Cells["A3"].PutValue("S. Amerika");

	dataSheet.Cells["A4"].PutValue("Europa");

	dataSheet.Cells["A5"].PutValue("Asien");

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

	//Fügen Sie ein Diagrammblatt hinzu

	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);

	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];

	chartSheet.Name = "Diagrammblatt";

	//Fügen Sie ein Diagramm im Diagrammblatt mit Datenserien aus dem Datenblatt hinzu

	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);

	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];

	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//Diagrammtitel festlegen

	chart.Title.Text = "Umsatz nach Quartal";

	//Vordergrundfarbe des Diagrammbereichs festlegen

	chart.PlotArea.Area.ForegroundColor = Color.White;

	//Hintergrundfarbe des Diagrammbereichs festlegen

	chart.PlotArea.Area.BackgroundColor = Color.White;

	//Hintergrundfarbe des Diagrammgebiets festlegen

	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	//Titel der Kategoriewerte festlegen

	chart.CategoryAxis.Title.Text = "Fiskalquartal";

	//Titel der Wertachse des Diagramms festlegen

	chart.ValueAxis.Title.Text = "Milliarden";

	//Aktives Arbeitsblatt auf das Diagrammblatt setzen

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
## **Beispielcode herunterladen**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772950)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20\(Aspose.Slides\).zip)
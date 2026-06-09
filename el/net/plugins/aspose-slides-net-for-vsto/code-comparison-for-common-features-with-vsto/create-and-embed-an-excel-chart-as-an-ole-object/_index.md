---
title: Δημιουργία και Ενσωμάτωση ενός Γραφήματος Excel ως Αντικείμενο OLE
type: docs
weight: 70
url: /el/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
Τα δύο παραδείγματα κώδικα παρακάτω είναι μακριά και λεπτομερή επειδή η εργασία που περιγράφουν είναι πολύπλοκη. Δημιουργείτε ένα βιβλίο εργασίας Microsoft Excel, δημιουργείτε ένα γράφημα και στη συνέχεια δημιουργείτε την παρουσίαση Microsoft PowerPoint στην οποία θα ενσωματώσετε το γράφημα. Τα αντικείμενα OLE περιέχουν συνδέσμους προς το αρχικό έγγραφο, έτσι ώστε ένας χρήστης που κάνει διπλό κλικ στο ενσωματωμένο αρχείο να εκκινήσει το αρχείο και την εφαρμογή του.
## **VSTO**
Χρησιμοποιώντας το VSTO, εκτελούνται τα παρακάτω βήματα:

1. Δημιουργήστε μια εμφάνιση του αντικειμένου Microsoft Excel ApplicationClass.
1. Δημιουργήστε ένα νέο βιβλίο εργασίας με ένα φύλλο.
1. Προσθέστε γράφημα στο φύλλο.
1. Αποθηκεύστε το βιβλίο εργασίας.
1. Ανοίξτε το βιβλίο εργασίας Excel που περιλαμβάνει το φύλλο εργασίας με τα δεδομένα του γραφήματος.
1. Αποκτήστε τη συλλογή ChartObjects για το φύλλο.
1. Αποκτήστε το γράφημα για αντιγραφή.
1. Δημιουργήστε μια παρουσίαση Microsoft PowerPoint.
1. Προσθέστε μια κενή διαφάνεια στην παρουσίαση.
1. Αντιγράψτε το γράφημα από το φύλλο εργασίας Excel στο πρόχειρο.
1. Επικολλήστε το γράφημα στην παρουσίαση PowerPoint.
1. Τοποθετήστε το γράφημα στη διαφάνεια.
1. Αποθηκεύστε την παρουσίαση.

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Δηλώστε μια μεταβλητή για την παρουσία της κλάσης Excel ApplicationClass.

	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Δηλώστε μεταβλητές για τις παραμέτρους της μεθόδου Workbooks.Open.

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Δηλώστε μεταβλητές για τη μέθοδο Chart.ChartWizard.

	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Sales by Quarter";

	object paramCategoryTitle = "Fiscal Quarter";

	object paramValueTitle = "Billions";

	try

	{

		// Δημιουργήστε μια εμφάνιση του αντικειμένου Excel ApplicationClass.

	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Δημιουργήστε ένα νέο βιβλίο εργασίας με 1 φύλλο.

		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Αλλαγή του ονόματος του φύλλου.

		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Quarterly Sales";

		// Εισάγετε μερικά δεδομένα για το γράφημα στο φύλλο.

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

		// Αποκτήστε το εύρος που περιέχει τα δεδομένα του γραφήματος.

		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// Αποκτήστε τη συλλογή ChartObjects για το φύλλο.

		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Προσθέστε ένα γράφημα στη συλλογή.

		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Sales Chart";

		// Δημιουργήστε ένα νέο γράφημα από τα δεδομένα.

		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// Αποθηκεύστε το βιβλίο εργασίας.

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

			// Κλείστε το Excel.

			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// Δηλώστε μεταβλητές που θα κρατούν αναφορές σε αντικείμενα PowerPoint.

	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// Δηλώστε μεταβλητές που θα κρατούν αναφορές σε αντικείμενα Excel.

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

		// Δημιουργήστε μια εμφάνιση του PowerPoint.

		powerpointApplication =new pptNS.Application();

		// Δημιουργήστε μια εμφάνιση του Excel.

		excelApplication = new xlNS.Application();

		// Ανοίξτε το βιβλίο εργασίας Excel που περιέχει το φύλλο με τα δεδομένα του γραφήματος.

		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// Αποκτήστε το φύλλο εργασίας που περιέχει το γράφημα.

		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

		// Αποκτήστε τη συλλογή ChartObjects για το φύλλο.

		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Αποκτήστε το γράφημα για αντιγραφή.

		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

		// Δημιουργήστε μια παρουσίαση PowerPoint.

		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// Προσθέστε μια κενή διαφάνεια στην παρουσίαση.

		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// Αντιγράψτε το γράφημα από το φύλλο εργασίας Excel στο πρόχειρο.

		existingChartObject.Copy();

		// Επικολλήστε το γράφημα στην παρουσίαση PowerPoint.

		shapeRange = pptSlide.Shapes.Paste();

		// Τοποθετήστε το γράφημα στη διαφάνεια.

		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// Αποθηκεύστε την παρουσίαση.

		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// Αποδεσμεύστε το αντικείμενο διαφάνειας PowerPoint.

		shapeRange = null;

		pptSlide = null;

		// Κλείστε και αποδεσμεύστε το αντικείμενο Παρουσίασης.

		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// Τερματίστε το PowerPoint και αποδεσμεύστε το αντικείμενο ApplicationClass.

		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// Αποδεσμεύστε τα αντικείμενα Excel.

		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// Κλείστε και αποδεσμεύστε το αντικείμενο Βιβλίου Εργασίας Excel.

		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// Τερματίστε το Excel και αποδεσμεύστε το αντικείμενο ApplicationClass.

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
Χρησιμοποιώντας το Aspose.Slides για .NET, εκτελούνται τα παρακάτω βήματα:

1. Δημιουργήστε ένα βιβλίο εργασίας χρησιμοποιώντας το Aspose.Cells για .NET.
1. Δημιουργήστε ένα γράφημα Microsoft Excel.
1. Ορίστε το μέγεθος OLE του γραφήματος Excel.
1. Αποκτήστε μια εικόνα του γραφήματος.
1. Ενσωματώστε το γράφημα Excel ως αντικείμενο OLE μέσα σε παρουσίαση PPTX χρησιμοποιώντας το Aspose.Slides για .NET.
1. Αντικαταστήστε την εικόνα αλλαγής αντικειμένου με την εικόνα που λαβήθηκε στο βήμα 3 για να αντιμετωπίσετε το ζήτημα αλλαγής αντικειμένου.
1. Γράψτε την παραγόμενη παρουσίαση στο δίσκο σε μορφή PPTX.

``` csharp

 static void Main(string[] args)

{

	// Δημιουργήστε ένα βιβλίο εργασίας

	Workbook wb = new Workbook();

	// Προσθέστε ένα γράφημα Excel

	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);

	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	// Αποθηκεύστε το βιβλίο εργασίας σε ροή

	MemoryStream wbStream = wb.SaveToStream();

	// Δημιουργήστε μια παρουσίαση

	PresentationEx pres = new PresentationEx();

	SlideEx sld = pres.Slides[0];

	// Προσθέστε το βιβλίο εργασίας στη διαφάνεια

	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	// Γράψτε την έξοδο της παρουσίασης στον δίσκο

	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	// Προσθέστε ένα νέο φύλλο εργασίας για να γεμίσετε τα κελιά με δεδομένα

	int dataSheetIdx = wb.Worksheets.Add();

	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];

	string sheetName = "DataSheet";

	dataSheet.Name = sheetName;

	// Γεμίστε το DataSheet με δεδομένα

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

	// Προσθέστε ένα φύλλο γραφήματος

	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);

	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];

	chartSheet.Name = "ChartSheet";

	// Προσθέστε ένα γράφημα στο ChartSheet με σειρές δεδομένων από το DataSheet

	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);

	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];

	chart.NSeries.Add(sheetName + "!A1:E5", false);

	// Ορισμός τίτλου του γραφήματος

	chart.Title.Text = "Sales by Quarter";

	// Ορισμός του χρώματος προσκηνίου της περιοχής σχεδίασης

	chart.PlotArea.Area.ForegroundColor = Color.White;

	// Ορισμός του χρώματος φόντου της περιοχής σχεδίασης

	chart.PlotArea.Area.BackgroundColor = Color.White;

	// Ορισμός του χρώματος προσκηνίου της περιοχής γραφήματος

	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	// Ορισμός τίτλου του άξονα κατηγοριών του γραφήματος

	chart.CategoryAxis.Title.Text = "Fiscal Quarter";

	// Ορισμός τίτλου του άξονα τιμών του γραφήματος

	chart.ValueAxis.Title.Text = "Billions";

	// Ορίστε το ChartSheet ως ενεργό φύλλο

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
## **Λήψη δείγματος κώδικα**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object/)
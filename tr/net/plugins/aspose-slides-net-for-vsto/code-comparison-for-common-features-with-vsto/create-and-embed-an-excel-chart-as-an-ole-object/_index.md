---
title: Excel Grafiğini OLE Nesnesi Olarak Oluşturma ve Gömme
type: docs
weight: 70
url: /tr/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
Aşağıdaki iki kod örneği uzun ve detaylıdır çünkü tarif ettikleri görev kapsamlıdır. Microsoft Excel çalışma kitabı oluşturur, bir grafik ekler ve ardından grafiği yerleştireceğiniz Microsoft PowerPoint sunumunu oluşturursunuz. OLE nesneleri orijinal belgeye bağlantılar içerir, bu yüzden gömülü dosyaya çift tıklayan kullanıcı dosyayı ve ilgili uygulamayı başlatır.

## **VSTO**
VSTO kullanarak aşağıdaki adımlar uygulanır:

1. Microsoft Excel ApplicationClass nesnesinin bir örneğini oluşturun.
1. Bir sayfası olan yeni bir çalışma kitabı oluşturun.
1. Sayfaya bir grafik ekleyin.
1. Çalışma kitabını kaydedin.
1. Grafik verilerini içeren çalışma sayfasına sahip Excel çalışma kitabını açın.
1. Sayfa için ChartObjects koleksiyonunu alın.
1. Kopyalanacak grafiği alın.
1. Microsoft PowerPoint sunumu oluşturun.
1. Sunuma boş bir slayt ekleyin.
1. Grafiği Excel çalışma sayfasından panoya kopyalayın.
1. Grafiği PowerPoint sunumuna yapıştırın.
1. Grafiği slayt üzerine konumlandırın.
1. Sunumu kaydedin.

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Excel ApplicationClass örneği için bir değişken bildir.

	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Workbooks.Open yöntemi parametreleri için değişkenler bildir.

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Chart.ChartWizard yöntemi için değişkenler bildir.

	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Sales by Quarter";

	object paramCategoryTitle = "Fiscal Quarter";

	object paramValueTitle = "Billions";

	try

	{

		// Excel ApplicationClass nesnesinin bir örneğini oluştur.

	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Bir sayfaya sahip yeni bir çalışma kitabı oluştur.

		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Sayfanın adını değiştir.

		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Quarterly Sales";

		// Grafik için bazı verileri sayfaya ekle.

		//              A       B       C       D       E

		//     1                Q1      Q2      Q3      Q4

		//     2    N. Amerika  1.5     2       1.5     2.5

		//     3    S. Amerika  2       1.75    2       2

		//     4    Avrupa      2.25    2       2.5     2

		//     5    Asya        2.5     2.5     2       2.75

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

		// Grafiği tutan aralığı al.

		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// Sayfa için ChartObjects koleksiyonunu al.

		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Koleksiyona bir grafik ekle.

		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Sales Chart";

		// Verilerden yeni bir grafik oluştur.

		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// Çalışma kitabını kaydet.

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

			// Excel'i kapat.

			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// PowerPoint nesnelerine referans tutacak değişkenleri bildir.

	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// Excel nesnelerine referans tutacak değişkenleri bildir.

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

		// PowerPoint örneği oluştur.

		powerpointApplication =new pptNS.Application();

		// Excel örneği oluştur.

		excelApplication = new xlNS.Application();

		// Grafik verilerini içeren çalışma sayfasına sahip Excel çalışma kitabını aç.

		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// Grafiği içeren çalışma sayfasını al.

		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

		// Sayfa için ChartObjects koleksiyonunu al.

		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// Kopyalanacak grafiği al.

		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

		// PowerPoint sunumu oluştur.

		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// Sunuma boş bir slayt ekle.

		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// Grafiği Excel çalışma sayfasından panoya kopyala.

		existingChartObject.Copy();

		// Grafiği PowerPoint sunumuna yapıştır.

		shapeRange = pptSlide.Shapes.Paste();

		// Grafiği slaytta konumlandır.

		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// Sunumu kaydet.

		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// PowerPoint slayt nesnesini serbest bırak.

		shapeRange = null;

		pptSlide = null;

		// Presentation nesnesini kapat ve serbest bırak.

		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// PowerPoint'i kapat ve ApplicationClass nesnesini serbest bırak.

		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// Excel nesnelerini serbest bırak.

		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// Excel Çalışma Kitabı nesnesini kapat ve serbest bırak.

		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// Excel'i kapat ve ApplicationClass nesnesini serbest bırak.

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
Aspose.Slides for .NET kullanarak aşağıdaki adımlar uygulanır:

1. Aspose.Cells for .NET kullanarak bir çalışma kitabı oluşturun.
1. Microsoft Excel grafiği oluşturun.
1. Excel grafiğinin OLE boyutunu ayarlayın.
1. Grafiğin bir görüntüsünü alın.
1. Aspose.Slides for .NET kullanarak Excel grafiğini PPTX sunumu içinde bir OLE nesnesi olarak gömün.
1. Nesne değişikliği sorununu gidermek için adım 3'te elde edilen görüntüyle nesne değiştirildiğinde oluşan resmi değiştirin.
1. Çıktı sunumunu PPTX formatında diske yazın.

``` csharp

 static void Main(string[] args)

{

	//Bir çalışma kitabı oluştur

	Workbook wb = new Workbook();

	//Excel grafiği ekle

	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);

	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//Çalışma kitabını akışa kaydet

	MemoryStream wbStream = wb.SaveToStream();

	//Bir sunum oluştur

	PresentationEx pres = new PresentationEx();

	SlideEx sld = pres.Slides[0];

	//Çalışma kitabını slayta ekle

	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//Çıktı sunumunu diske yaz

	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//Veriyle hücreleri doldurmak için yeni bir çalışma sayfası ekle

	int dataSheetIdx = wb.Worksheets.Add();

	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];

	string sheetName = "DataSheet";

	dataSheet.Name = sheetName;

	//DataSheet'i veriyle doldur

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

	//Bir grafik sayfası ekle

	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);

	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];

	chartSheet.Name = "ChartSheet";

	//ChartSheet içinde DataSheet'ten veri serileriyle bir grafik ekle

	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);

	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];

	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//Grafiğin Başlığını Ayarlama

	chart.Title.Text = "Sales by Quarter";

	//Grafik alanının ön plan rengini ayarlama

	chart.PlotArea.Area.ForegroundColor = Color.White;

	//Grafik alanının arka plan rengini ayarlama

	chart.PlotArea.Area.BackgroundColor = Color.White;

	//Grafik alanının ön plan rengini ayarlama

	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	//Grafiğin kategori ekseninin başlığını ayarlama

	chart.CategoryAxis.Title.Text = "Fiscal Quarter";

	//Grafiğin değer ekseninin başlığını ayarlama

	chart.ValueAxis.Title.Text = "Billions";

	//ChartSheet'i aktif sayfa olarak ayarla

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
## **Örnek Kodu İndir**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object/)
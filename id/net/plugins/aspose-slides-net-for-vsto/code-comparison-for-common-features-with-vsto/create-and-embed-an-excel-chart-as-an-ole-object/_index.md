---
title: Buat dan Sematkan Diagram Excel sebagai Objek OLE
type: docs
weight: 70
url: /id/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
Dua contoh kode di bawah ini panjang dan terperinci karena tugas yang dijelaskannya cukup rumit. Anda membuat sebuah workbook Microsoft Excel, membuat sebuah diagram, kemudian membuat presentasi Microsoft PowerPoint yang akan Anda sematkan diagram tersebut. Objek OLE berisi tautan ke dokumen asli sehingga pengguna yang mengeklik ganda file yang disematkan akan membuka file tersebut beserta aplikasinya.
## **VSTO**
Menggunakan VSTO, langkah‑langkah berikut dilakukan:

1. Buat instance dari objek Microsoft Excel ApplicationClass.
2. Buat workbook baru dengan satu lembar di dalamnya.
3. Tambahkan diagram ke lembar tersebut.
4. Simpan workbook.
5. Buka workbook Excel yang berisi lembar kerja dengan data diagram.
6. Dapatkan koleksi ChartObjects untuk lembar tersebut.
7. Ambil diagram yang akan disalin.
8. Buat presentasi Microsoft PowerPoint.
9. Tambahkan slide kosong ke presentasi.
10. Salin diagram dari lembar kerja Excel ke clipboard.
11. Tempelkan diagram ke dalam presentasi PowerPoint.
12. Posisikan diagram pada slide.
13. Simpan presentasi.

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Deklarasikan variabel untuk instance Excel ApplicationClass.
	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Deklarasikan variabel untuk parameter metode Workbooks.Open.
	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Deklarasikan variabel untuk metode Chart.ChartWizard.
	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Sales by Quarter";

	object paramCategoryTitle = "Fiscal Quarter";

	object paramValueTitle = "Billions";

	try

	{

		// Buat instance dari objek Excel ApplicationClass.
	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Buat workbook baru dengan 1 lembar di dalamnya.
		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Ubah nama lembar.
		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Quarterly Sales";

		// Sisipkan beberapa data untuk diagram ke dalam lembar.
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
		// Dapatkan rentang yang berisi data diagram.
		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");
		// Dapatkan koleksi ChartObjects untuk lembar tersebut.
		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));
		// Tambahkan Diagram ke koleksi.
		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
		newChartObject.Name = "Sales Chart";
		// Buat diagram baru dari data.
		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);
		// Simpan workbook.
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
			// Tutup Excel.
			excelApplication.Quit();
		}
	}
}

public void UseCopyPaste()
{
	// Deklarasikan variabel untuk menyimpan referensi ke objek PowerPoint.
	pptNS.Application powerpointApplication = null;
	// Deklarasikan variabel untuk menyimpan referensi ke objek Excel.
	pptNS.Presentation pptPresentation = null;
	pptNS.Slide pptSlide = null;
	pptNS.ShapeRange shapeRange = null;
	// Deklarasikan variabel untuk menyimpan referensi ke objek Excel.
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
		// Buat instance PowerPoint.
		powerpointApplication =new pptNS.Application();
		// Buat instance Excel.
		excelApplication = new xlNS.Application();
		// Buka workbook Excel yang berisi lembar kerja dengan data diagram.
		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
			paramMissing, paramMissing, paramMissing, paramMissing);
		// Dapatkan lembar kerja yang berisi diagram.
		targetSheet =
			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);
		// Dapatkan koleksi ChartObjects untuk lembar tersebut.
		chartObjects =
			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));
		// Dapatkan diagram yang akan disalin.
		existingChartObject =
			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));
		// Buat presentasi PowerPoint.
		pptPresentation =
			powerpointApplication.Presentations.Add(
			Microsoft.Office.Core.MsoTriState.msoTrue);
		// Tambahkan slide kosong ke presentasi.
		pptSlide =
			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);
		// Salin diagram dari lembar kerja Excel ke clipboard.
		existingChartObject.Copy();
		// Tempelkan diagram ke dalam presentasi PowerPoint.
		shapeRange = pptSlide.Shapes.Paste();
		// Posisikan diagram pada slide.
		shapeRange.Left = 60;
		shapeRange.Top = 100;
		// Simpan presentasi.
		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
	finally
	{
		// Lepaskan objek slide PowerPoint.
		shapeRange = null;
		pptSlide = null;
		// Tutup dan lepaskan objek Presentation.
		if (pptPresentation != null)
		{
			pptPresentation.Close();
			pptPresentation = null;
		}
		// Keluar dari PowerPoint dan lepaskan objek ApplicationClass.
		if (powerpointApplication != null)
		{
			powerpointApplication.Quit();
			powerpointApplication = null;
		}
		// Lepaskan objek Excel.
		targetSheet = null;
		chartObjects = null;
		existingChartObject = null;
		// Tutup dan lepaskan objek Workbook Excel.
		if (excelWorkBook != null)
		{
			excelWorkBook.Close(false, paramMissing, paramMissing);
			excelWorkBook = null;
		}
		// Keluar dari Excel dan lepaskan objek ApplicationClass.
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
Menggunakan Aspose.Slides untuk .NET, langkah‑langkah berikut dilakukan:

1. Buat workbook menggunakan Aspose.Cells untuk .NET.
2. Buat diagram Microsoft Excel.
3. Atur ukuran OLE dari diagram Excel.
4. Dapatkan gambar dari diagram tersebut.
5. Sematkan diagram Excel sebagai Objek OLE di dalam presentasi PPTX menggunakan Aspose.Slides untuk .NET.
6. Ganti gambar objek yang berubah dengan gambar yang diperoleh pada langkah 3 untuk mengatasi masalah objek yang berubah.
7. Tuliskan presentasi hasil ke disk dalam format PPTX.

``` csharp

 static void Main(string[] args)

{

	//Buat sebuah workbook
	Workbook wb = new Workbook();

	//Tambahkan diagram excel
	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);
	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//Simpan workbook ke stream
	MemoryStream wbStream = wb.SaveToStream();

	//Buat sebuah presentasi
	PresentationEx pres = new PresentationEx();
	SlideEx sld = pres.Slides[0];

	//Tambahkan workbook ke slide
	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//Tuliskan presentasi output ke disk
	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//Tambahkan lembar kerja baru untuk mengisi sel dengan data
	int dataSheetIdx = wb.Worksheets.Add();
	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
	string sheetName = "DataSheet";
	dataSheet.Name = sheetName;

	//Isi DataSheet dengan data
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

	//Tambahkan lembar chart
	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);
	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
	chartSheet.Name = "ChartSheet";

	//Tambahkan chart di ChartSheet dengan seri data dari DataSheet
	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);
	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//Mengatur Judul Chart
	chart.Title.Text = "Sales by Quarter";

	//Mengatur warna latar depan area plot
	chart.PlotArea.Area.ForegroundColor = Color.White;

	//Mengatur warna latar belakang area plot
	chart.PlotArea.Area.BackgroundColor = Color.White;

	//Mengatur warna latar depan area chart
	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	//Mengatur judul sumbu kategori chart
	chart.CategoryAxis.Title.Text = "Fiscal Quarter";

	//Mengatur judul sumbu nilai chart
	chart.ValueAxis.Title.Text = "Billions";

	//Atur ChartSheet sebagai lembar aktif
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
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object/)
---
title: Membuat Diagram
type: docs
weight: 60
url: /id/net/create-a-chart/
---
Contoh kode di bawah ini menjelaskan proses menambahkan diagram kolom berkelompok 3D sederhana menggunakan VSTO. Anda membuat instance presentasi, menambahkan diagram default ke dalamnya. Kemudian menggunakan workbook Microsoft Excel untuk mengakses dan memodifikasi data diagram beserta mengatur properti diagram. Terakhir, simpan presentasi.
## **VSTO**
Menggunakan VSTO, langkah‑langkah berikut dilakukan:

1. Buat instance presentasi Microsoft PowerPoint.
1. Tambahkan slide kosong ke presentasi.
1. Tambahkan diagram kolom berkelompok 3D dan akses diagram tersebut.
1. Buat instance Microsoft Excel Workbook baru dan muat data diagram.
1. Akses worksheet data diagram menggunakan instance Microsoft Excel Workbook dari workbook.
1. Tetapkan rentang diagram di worksheet dan hapus seri 2 dan 3 dari diagram.
1. Ubah data kategori diagram di worksheet data diagram.
1. Ubah data seri 1 diagram di worksheet data diagram.
1. Sekarang, akses judul diagram dan atur properti terkait font.
1. Akses sumbu nilai diagram dan atur unit utama, unit minor, nilai maksimum, dan nilai minimum.
1. Akses kedalaman diagram atau sumbu seri dan hapus karena dalam contoh ini hanya satu seri yang digunakan.
1. Sekarang, atur sudut rotasi diagram pada arah X dan Y.
1. Simpan presentasi.
1. Tutup instance Microsoft Excel dan PowerPoint.

``` csharp

 //Variabel Global

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);
	//Instansiasi objek slide
	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
	//Akses slide pertama presentasi
	objSlide = objPres.Slides[1];
	//Pilih slide pertama dan atur tata letaknya
	objSlide.Select();
	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;
	//Tambahkan diagram default di slide
	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);
	//Akses diagram yang ditambahkan
	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;
	//Akses data diagram
	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;
	//Buat instance workbook Excel untuk bekerja dengan data diagram
	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;
	//Mengakses worksheet data untuk diagram
	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];
	//Menetapkan rentang diagram
	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");
	//Menerapkan rentang yang ditetapkan pada tabel data diagram
	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
	tbl1.Resize(tRange);
	//Menetapkan nilai untuk kategori dan data seri yang bersangkutan
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//Menetapkan judul diagram
	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 Sales";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//Mengakses sumbu nilai diagram
	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
	//Menetapkan satuan sumbu nilai
	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//Mengakses sumbu kedalaman diagram
	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
	Depthaxis.Delete();
	//Menetapkan rotasi diagram
	ppChart.Rotation = 20; //Nilai Y
	ppChart.Elevation = 15; //Nilai X
	ppChart.RightAngleAxes = false;
	//Simpan presentasi sebagai PPTX
	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
	//Tutup Workbook dan presentasi
	dataWorkbook.Application.Quit();

	objPres.Application.Quit();

}

//Supplementary methods

public static void StartPowerPoint()

{

	objPPT = new Microsoft.Office.Interop.PowerPoint.Application();

	objPPT.Visible = MsoTriState.msoTrue;

	//  objPPT.WindowState = PowerPoint.PpWindowState.ppWindowMaximized

}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation)

{

	EnsurePowerPointIsRunning(blnAddPresentation, false);

}

public static void EnsurePowerPointIsRunning()

{

	EnsurePowerPointIsRunning(false, false);

}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)

{

	string strName = null;

	//

	//Coba mengakses properti nama. Jika menyebabkan pengecualian maka
	//mulai instance baru PowerPoint
	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation digunakan untuk memastikan ada presentasi yang dimuat
	if (blnAddPresentation == true)

	{

		try

		{

			strName = objPres.Name;

		}

		catch (Exception ex)

		{

			objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);

		}

	}

	//

	//BlnAddSlide digunakan untuk memastikan ada setidaknya satu slide dalam
	//presentasi
	if (blnAddSlide)

	{

		try

		{

			strName = objPres.Slides[1].Name;

		}

		catch (Exception ex)

		{

			Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

			Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;

			objCustomLayout = objPres.SlideMaster.CustomLayouts[1];

			objSlide = objPres.Slides.AddSlide(1, objCustomLayout);

			objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;

			objCustomLayout = null;

			objSlide = null;

		}

	}

}
``` 
## **Aspose.Slides**
Menggunakan Aspose.Slides untuk .NET, langkah‑langkah berikut dilakukan:

1. Buat instance presentasi Microsoft PowerPoint.
1. Tambahkan slide kosong ke presentasi.
1. Tambahkan diagram kolom berkelompok 3D dan akses diagram tersebut.
1. Akses worksheet data diagram menggunakan instance Microsoft Excel Workbook dari workbook.
1. Hapus seri 2 dan 3 yang tidak digunakan.
1. Akses kategori diagram dan ubah label.
1. Akses seri 1 dan ubah nilai seri.
1. Sekarang, akses judul diagram dan atur properti font.
1. Akses sumbu nilai diagram dan atur unit utama, unit minor, nilai maksimum, dan nilai minimum.
1. Sekarang, atur sudut rotasi diagram pada arah X dan Y.
1. Simpan presentasi ke format PPTX.

``` csharp

 public static void GEN_ASPOSE_Chart()

{

	//Buat presentasi kosong

	using (PresentationEx pres = new PresentationEx())

	{

		//Mengakses slide pertama

		SlideEx slide = pres.Slides[0];

		//Menambahkan diagram default

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//Mendapatkan data diagram

		ChartDataEx chartData = ppChart.ChartData;

		//Menghapus seri default tambahan

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//Mengubah nama kategori diagram

		chartData.Categories[0].ChartDataCell.Value = "Bikes";

		chartData.Categories[1].ChartDataCell.Value = "Accessories";

		chartData.Categories[2].ChartDataCell.Value = "Repairs";

		chartData.Categories[3].ChartDataCell.Value = "Clothing";

		//Mengubah nilai seri diagram untuk kategori pertama

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//Menetapkan judul diagram

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "2007 Sales";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//Menetapkan nilai sumbu

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//Menetapkan rotasi diagram

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//Menyimpan presentasi

		pres.Write("AsposeSampleChart.pptx");

	}

``` 
## **Unduh Kode Contoh**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)
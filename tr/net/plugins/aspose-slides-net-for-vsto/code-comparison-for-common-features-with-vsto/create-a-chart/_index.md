---
title: Grafik Oluştur
type: docs
weight: 60
url: /tr/net/create-a-chart/
---
Aşağıdaki kod örnekleri, VSTO kullanarak basit bir 3B kümeleme sütun grafiği ekleme sürecini açıklar. Bir sunum örneği oluşturur, ona varsayılan bir grafik eklersiniz. Ardından Microsoft Excel çalışma kitabını kullanarak grafik verilerine erişir ve bu verileri değiştirirken grafik özelliklerini ayarlarsınız. Son olarak, sunumu kaydedersiniz.
## **VSTO**
VSTO kullanarak aşağıdaki adımlar uygulanır:

1. Microsoft PowerPoint sunumu için bir örnek oluşturun.  
2. Sunuma boş bir slayt ekleyin.  
3. 3B kümeleme sütun grafiği ekleyin ve ona erişin.  
4. Yeni bir Microsoft Excel Çalışma Kitabı örneği oluşturun ve grafik verilerini yükleyin.  
5. Çalışma kitabından Microsoft Excel Çalışma Kitabı örneğini kullanarak grafik veri çalışma sayfasına erişin.  
6. Çalışma sayfasında grafik aralığını ayarlayın ve grafikten 2 ve 3. serileri kaldırın.  
7. Grafik veri çalışma sayfasında grafik kategori verilerini değiştirin.  
8. Grafik veri çalışma sayfasında 1. seri verilerini değiştirin.  
9. Şimdi, grafik başlığına erişin ve yazı tipiyle ilgili özellikleri ayarlayın.  
10. Grafik değer eksenine erişin ve ana birim, yan birimler, maksimum değer ve minimum değerleri ayarlayın.  
11. Grafik derinlik ya da seri eksenine erişin ve bu örnekte sadece bir seri kullanıldığı için onu kaldırın.  
12. Şimdi, grafik döndürme açılarını X ve Y yönünde ayarlayın.  
13. Sunumu kaydedin.  
14. Microsoft Excel ve PowerPoint örneklerini kapatın.

``` csharp

 //Genel Değişkenler

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//Slayt nesnesi oluştur

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//Sunumun ilk slaytına eriş

	objSlide = objPres.Slides[1];

	//İlk slaytı seç ve düzenini ayarla

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//Slayta varsayılan bir grafik ekle

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//Eklenen grafige eriş

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//Grafik verisine eriş

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//Grafik verisiyle çalışmak için bir Excel çalışma kitabı örneği oluştur

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//Grafik için veri çalışma sayfasına eriş

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//Grafiğin aralığını ayarla

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//Belirlenen aralığı grafik veri tablosuna uygula

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//Kategoriler ve ilgili seri verileri için değerleri ayarla

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//Grafik başlığını ayarla

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 Sales";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//Grafik değer eksenine eriş

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//Değer ekseni birimlerini ayarla

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//Grafik derinlik eksenine eriş

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//Grafik döndürme açılarını ayarla

	ppChart.Rotation = 20; //Y-Değeri

	ppChart.Elevation = 15; //X-Değeri

	ppChart.RightAngleAxes = false;

	//Sunumu PPTX olarak kaydet

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//Çalışma kitabını ve sunumu kapat

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

	//İsim özelliğine erişmeyi dene. Bir istisna oluşursa

	//PowerPoint'in yeni bir örneğini başlat

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation, bir sunumun yüklü olduğundan emin olmak için kullanılır

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

	//BlnAddSlide, en az bir slaytın olduğundan emin olmak için kullanılır

	//sunum

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
Aspose.Slides for .NET kullanarak aşağıdaki adımlar uygulanır:

1. Microsoft PowerPoint sunumu için bir örnek oluşturun.  
2. Sunuma boş bir slayt ekleyin.  
3. 3B kümeleme sütun grafiği ekleyin ve ona erişin.  
4. Çalışma kitabından bir Microsoft Excel Çalışma Kitabı örneğini kullanarak grafik veri çalışma sayfasına erişin.  
5. Kullanılmayan 2 ve 3. serileri kaldırın.  
6. Grafik kategorilerine erişin ve etiketleri değiştirin.  
7. 1. seriye erişin ve seri değerlerini değiştirin.  
8. Şimdi, grafik başlığına erişin ve yazı tipi özelliklerini ayarlayın.  
9. Grafik değer eksenine erişin ve ana birim, yan birimler, maksimum değer ve minimum değerleri ayarlayın.  
10. Şimdi, grafik döndürme açılarını X ve Y yönünde ayarlayın.  
11. Sunumu PPTX formatında kaydedin.

``` csharp

 public static void GEN_ASPOSE_Chart()
{
	//Boş sunum oluştur
	using (PresentationEx pres = new PresentationEx())
	{
		//İlk slayta eriş
		SlideEx slide = pres.Slides[0];
		//Varsayılan grafik ekle
		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);
		//Grafik verisini al
		ChartDataEx chartData = ppChart.ChartData;
		//Ekstra varsayılan serileri kaldır
		chartData.Series.RemoveAt(1);
		chartData.Series.RemoveAt(1);
		//Grafik kategori adlarını değiştir
		chartData.Categories[0].ChartDataCell.Value = "Bikes";
		chartData.Categories[1].ChartDataCell.Value = "Accessories";
		chartData.Categories[2].ChartDataCell.Value = "Repairs";
		chartData.Categories[3].ChartDataCell.Value = "Clothing";
		//İlk kategori için grafik seri değerlerini değiştir
		chartData.Series[0].Values[0].Value = 1000;
		chartData.Series[0].Values[1].Value = 2500;
		chartData.Series[0].Values[2].Value = 4000;
		chartData.Series[0].Values[3].Value = 3000;
		//Grafik başlığını ayarla
		ppChart.HasTitle = true;
		ppChart.ChartTitle.Text.Text = "2007 Sales";
		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;
		format.FontItalic = NullableBool.True;
		format.FontHeight = 18;
		format.FillFormat.FillType = FillTypeEx.Solid;
		format.FillFormat.SolidFillColor.Color = Color.Black;
		//Eksen değerlerini ayarla
		ppChart.ValueAxis.IsAutomaticMaxValue = false;
		ppChart.ValueAxis.IsAutomaticMinValue = false;
		ppChart.ValueAxis.IsAutomaticMajorUnit = false;
		ppChart.ValueAxis.IsAutomaticMinorUnit = false;
		ppChart.ValueAxis.MaxValue = 4000.0F;
		ppChart.ValueAxis.MinValue = 0.0F;
		ppChart.ValueAxis.MajorUnit = 2000.0F;
		ppChart.ValueAxis.MinorUnit = 1000.0F;
		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;
		//Grafik döndürmesini ayarla
		ppChart.Rotation3D.RotationX = 15;
		ppChart.Rotation3D.RotationY = 20;
		//Sunumu kaydet
		pres.Write("AsposeSampleChart.pptx");
	}
}
``` 
## **Download Sample Code**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)
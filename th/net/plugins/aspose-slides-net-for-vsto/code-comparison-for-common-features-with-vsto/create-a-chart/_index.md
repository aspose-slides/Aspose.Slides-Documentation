---
title: สร้างแผนภูมิ
type: docs
weight: 60
url: /th/net/create-a-chart/
---
ตัวอย่างโค้ดด้านล่างอธิบายกระบวนการเพิ่มแผนภูมิคอลัมน์แบบกลุ่ม 3D อย่างง่ายโดยใช้ VSTO คุณสร้างอินสแตนซ์ของการพรีเซนเทชัน เพิ่มแผนภูมิโดยค่าเริ่มต้น จากนั้นใช้ Microsoft Excel workbook เพื่อเข้าถึงและแก้ไขข้อมูลแผนภูมิพร้อมตั้งค่าคุณสมบัติของแผนภูมิ สุดท้ายบันทึกการพรีเซนเทชัน
## **VSTO**
โดยใช้ VSTO ขั้นตอนต่อไปนี้จะถูกดำเนินการ:

1. สร้างอินสแตนซ์ของการพรีเซนเทชัน Microsoft PowerPoint  
1. เพิ่มสไลด์เปล่าไปยังการพรีเซนเทชัน  
1. เพิ่มแผนภูมิคอลัมน์แบบกลุ่ม 3D แล้วเข้าถึงมัน  
1. สร้างอินสแตนซ์ของ Microsoft Excel Workbook ใหม่และโหลดข้อมูลแผนภูมิ  
1. เข้าถึงแผ่นงานข้อมูลแผนภูมิโดยใช้อินสแตนซ์ Microsoft Excel Workbook จากเวิร์กบุ๊ก  
1. ตั้งค่าช่วงของแผนภูมิในแผ่นงานและลบซีรีส์ 2 และ 3 ออกจากแผนภูมิ  
1. แก้ไขข้อมูลหมวดหมู่ของแผนภูมิในแผ่นงานข้อมูลแผนภูมิ  
1. แก้ไขข้อมูลซีรีส์ 1 ของแผนภูมิในแผ่นงานข้อมูลแผนภูมิ  
1. ตอนนี้เข้าถึงชื่อแผนภูมิและตั้งค่าคุณสมบัติเกี่ยวกับฟอนต์  
1. เข้าถึงแกนค่าของแผนภูมิและตั้งค่าหน่วยหลัก หน่วยย่อย ค่าสูงสุดและค่าต่ำสุด  
1. เข้าถึงความลึกของแผนภูมิหรือแกนซีรีส์และลบออกตามตัวอย่างนี้ เนื่องจากใช้เพียงซีรีส์เดียว  
1. ตอนนี้ตั้งค่ามุมการหมุนของแผนภูมิในทิศทาง X และ Y  
1. บันทึกการพรีเซนเทชัน  
1. ปิดอินสแตนซ์ของ Microsoft Excel และ PowerPoint  

``` csharp

 //ตัวแปรทั่วไป

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//สร้างอ็อบเจ็กต์สไลด์
	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//เข้าถึงสไลด์แรกของการพรีเซนเทชัน
	objSlide = objPres.Slides[1];

	//เลือกสไลด์แรกและตั้งค่าเลย์เอาต์
	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//เพิ่มแผนภูมิโดยค่าเริ่มต้นในสไลด์
	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//เข้าถึงแผนภูมิที่เพิ่ม
	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//เข้าถึงข้อมูลแผนภูมิ
	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//สร้างอินสแตนซ์ของ Excel workbook เพื่อทำงานกับข้อมูลแผนภูมิ
	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//กำลังเข้าถาถึงแผ่นงานข้อมูลสำหรับแผนภูมิ
	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//ตั้งค่าช่วงของแผนภูมิ
	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//ใช้ช่วงที่ตั้งค่าไว้กับตารางข้อมูลแผนภูมิ
	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//ตั้งค่าค่าของหมวดหมู่และข้อมูลซีรีส์ที่สอดคล้องกัน
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//ตั้งค่าชื่อแผนภูมิ
	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 Sales";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//เข้าถึงแกนค่าของแผนภูมิ
	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//ตั้งค่าหน่วยของแกนค่า
	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//เข้าถึงแกนความลึกของแผนภูมิ
	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//ตั้งค่าการหมุนของแผนภูมิ
	ppChart.Rotation = 20; //Y-Value

	ppChart.Elevation = 15; //X-Value

	ppChart.RightAngleAxes = false;

	//บันทึกการพรีเซนเทชันเป็นไฟล์ PPTX
	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//ปิด Workbook และการพรีเซนเทชัน
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

	//ลองเข้าถึงคุณสมบัติชื่อ หากทำให้เกิดข้อยกเว้นแล้ว
	//เริ่มอินสแตนซ์ใหม่ของ PowerPoint
	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation ถูกใช้เพื่อให้แน่ใจว่ามีการโหลดพรีเซนเทชัน
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

	//BlnAddSlide ถูกใช้เพื่อให้แน่ใจว่ามีอย่างน้อยหนึ่งสไลด์ใน
	//การพรีเซนเทชัน
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
โดยใช้ Aspose.Slides สำหรับ .NET ขั้นตอนต่อไปนี้จะถูกดำเนินการ:

1. สร้างอินสแตนซ์ของการพรีเซนเทชัน Microsoft PowerPoint  
1. เพิ่มสไลด์เปล่าไปยังการพรีเซนเทชัน  
1. เพิ่มแผนภูมิคอลัมน์แบบกลุ่ม 3D และเข้าถึงมัน  
1. เข้าถึงแผ่นงานข้อมูลแผนภูมิโดยใช้อินสแตนซ์ Microsoft Excel Workbook จากเวิร์กบุ๊ก  
1. ลบซีรีส์ 2 และ 3 ที่ไม่ได้ใช้  
1. เข้าถึงหมวดหมู่ของแผนภูมิและแก้ไขป้ายกำกับ  
1. เข้าถึงซีรีส์ 1 และแก้ไขค่าของซีรีส์  
1. ตอนนี้เข้าถึงชื่อแผนภูมิและตั้งค่าคุณสมบัติฟอนต์  
1. เข้าถึงแกนค่าของแผนภูมิและตั้งค่าหน่วยหลัก หน่วยย่อย ค่าสูงสุดและค่าต่ำสุด  
1. ตอนนี้ตั้งค่ามุมการหมุนของแผนภูมิในทิศทาง X และ Y  
1. บันทึกการพรีเซนเทชันเป็นรูปแบบ PPTX  

``` csharp

 public static void GEN_ASPOSE_Chart()

{

	//สร้างพรีเซนเทชันว่าง

	using (PresentationEx pres = new PresentationEx())

	{

		//เข้าถึงสไลด์แรก

		SlideEx slide = pres.Slides[0];

		//เพิ่มแผนภูมิโดยค่าเริ่มต้น

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//ดึงข้อมูลแผนภูมิ

		ChartDataEx chartData = ppChart.ChartData;

		//ลบซีรีส์เริ่มต้นที่เกิน

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//แก้ไขชื่อหมวดหมู่ของแผนภูมิ

		chartData.Categories[0].ChartDataCell.Value = "Bikes";

		chartData.Categories[1].ChartDataCell.Value = "Accessories";

		chartData.Categories[2].ChartDataCell.Value = "Repairs";

		chartData.Categories[3].ChartDataCell.Value = "Clothing";

		//แก้ไขค่าของซีรีส์แผนภูมิสำหรับหมวดแรก

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//ตั้งค่าชื่อแผนภูมิ

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "2007 Sales";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//ตั้งค่าค่าแกน

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//ตั้งค่าการหมุนของแผนภูมิ

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//บันทึกพรีเซนเทชัน

		pres.Write("AsposeSampleChart.pptx");

	}

``` 
## **Download Sample Code**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)
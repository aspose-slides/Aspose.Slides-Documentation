---
title: สร้างและฝังแผนภูมิ Excel เป็นอ็อบเจ็กต์ OLE
type: docs
weight: 70
url: /th/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
ตัวอย่างโค้ดสองชุดด้านล่างค่อนข้างยาวและละเอียด เนื่องจากงานที่อธิบายมีความซับซ้อน คุณสร้างเวิร์กบุ๊ก Microsoft Excel, สร้างแผนภูมิและจากนั้นสร้างงานนำเสนอ Microsoft PowerPoint ที่คุณจะฝังแผนภูมินั้นเข้าไป วัตถุ OLE มีลิงก์ไปยังเอกสารต้นฉบับ ดังนั้นผู้ใช้ที่ดับเบิลคลิกไฟล์ที่ฝังไว้จะเปิดไฟล์และแอปพลิเคชันของมัน
## **VSTO**
Using VSTO, the following steps are performed:

1. สร้างอินสแตนซ์ของอ็อบเจ็กต์ Microsoft Excel ApplicationClass
1. สร้างเวิร์กบุ๊กใหม่ที่มีแผ่นงานหนึ่งแผ่น
1. เพิ่มแผนภูมิในแผ่นงาน
1. บันทึกเวิร์กบุ๊ก
1. เปิดเวิร์กบุ๊ก Excel ที่มีแผ่นงานที่มีข้อมูลแผนภูมิ
1. ดึงคอลเลกชัน ChartObjects สำหรับแผ่นงาน
1. ดึงแผนภูมิเพื่อคัดลอก
1. สร้างงานนำเสนอ Microsoft PowerPoint
1. เพิ่มสไลด์เปล่าไปยังงานนำเสนอ
1. คัดลอกแผนภูมิจากแผ่นงาน Excel ไปยังคลิปบอร์ด
1. วางแผนภูมิลงในงานนำเสนอ PowerPoint
1. กำหนดตำแหน่งแผนภูมิบนสไลด์
1. บันทึกงานนำเสนอ

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// ประกาศตัวแปรสำหรับอินสแตนซ์ของ Excel ApplicationClass อินสแตนซ์
	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// ประกาศตัวแปรสำหรับพารามิเตอร์ของเมธอด Workbooks.Open
	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// ประกาศตัวแปรสำหรับเมธอด Chart.ChartWizard
	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Sales by Quarter";

	object paramCategoryTitle = "Fiscal Quarter";

	object paramValueTitle = "Billions";

	try

	{

		// สร้างอินสแตนซ์ของอ็อบเจ็กต์ Excel ApplicationClass
	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// สร้างเวิร์กบุ๊กใหม่ที่มีแผ่นงาน 1 แผ่น
		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// เปลี่ยนชื่อของแผ่นงาน
		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Quarterly Sales";

		// แทรกข้อมูลบางส่วนสำหรับแผนภูมิเข้าสู่แผ่นงาน
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

		// รับช่วงที่บรรจุข้อมูลแผนภูมิ
		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// รับคอลเลกชัน ChartObjects ของแผ่นงาน
		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// เพิ่มแผนภูมิลงในคอลเลกชัน
		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Sales Chart";

		// สร้างแผนภูมิใหม่จากข้อมูล
		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// บันทึกเวิร์กบุ๊ก
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

			// ปิด Excel.
			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// ประกาศตัวแปรเพื่อเก็บการอ้างอิงไปยังอ็อบเจ็กต์ของ PowerPoint.
	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// ประกาศตัวแปรเพื่อเก็บการอ้างอิงไปยังอ็อบเจ็กต์ของ Excel.
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

		// สร้างอินสแตนซ์ของ PowerPoint.
		powerpointApplication =new pptNS.Application();

		// สร้างอินสแตนซ์ของ Excel.
		excelApplication = new xlNS.Application();

		// เปิดเวิร์กบุ๊ก Excel ที่มีแผ่นงานที่บรรจุข้อมูลแผนภูมิ
		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// รับแผ่นงานที่มีแผนภูมิ
		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

		// รับคอลเลกชัน ChartObjects ของแผ่นงาน
		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// รับแผนภูมิที่จะคัดลอก
		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

		// สร้างงานนำเสนอ PowerPoint.
		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// เพิ่มสไลด์เปล่าไปยังงานนำเสนอ.
		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// คัดลอกแผนภูมิจากแผ่นงาน Excel ไปยังคลิปบอร์ด.
		existingChartObject.Copy();

		// วางแผนภูมิลงในงานนำเสนอ PowerPoint.
		shapeRange = pptSlide.Shapes.Paste();

		// กำหนดตำแหน่งของแผนภูมิบนสไลด์.
		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// บันทึกงานนำเสนอ.
		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// ปล่อยอ็อบเจ็กต์สไลด์ของ PowerPoint.
		shapeRange = null;

		pptSlide = null;

		// ปิดและปล่อยอ็อบเจ็กต์ Presentation.
		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// ออกจาก PowerPoint และปล่อยอ็อบเจ็กต์ ApplicationClass.
		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// ปล่อยอ็อบเจ็กต์ของ Excel.
		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// ปิดและปล่อยอ็อบเจ็กต์ Excel Workbook.
		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// ออกจาก Excel และปล่อยอ็อบเจ็กต์ ApplicationClass.
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
Using Aspose.Slides for .NET, the following steps are performed:

1. สร้างเวิร์กบุ๊กโดยใช้ Aspose.Cells for .NET
1. สร้างแผนภูมิ Microsoft Excel
1. ตั้งค่าขนาด OLE ของแผนภูมิ Excel
1. ดึงภาพของแผนภูมิ
1. ฝังแผนภูมิ Excel เป็นวัตถุ OLE ภายในงานนำเสนอ PPTX โดยใช้ Aspose.Slides for .NET
1. แทนที่ภาพวัตถุที่เปลี่ยนแปลงด้วยภาพที่ได้จากขั้นตอนที่ 3 เพื่อตอบสนองปัญหาวัตถุที่เปลี่ยนแปลง
1. เขียนงานนำเสนอผลลัพธ์ลงดิสก์ในรูปแบบ PPTX

``` csharp

 static void Main(string[] args)

{

	//สร้างเวิร์กบุ๊ก
	Workbook wb = new Workbook();

	//เพิ่มแผนภูมิ Excel
	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);
	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//บันทึกเวิร์กบุ๊กเป็นสตรีม
	MemoryStream wbStream = wb.SaveToStream();

	//สร้างงานนำเสนอ
	PresentationEx pres = new PresentationEx();
	SlideEx sld = pres.Slides[0];

	//เพิ่มเวิร์กบุ๊กลงบนสไลด์
	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//เขียนงานนำเสนอผลลัพธ์ลงดิสก์
	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//เพิ่มแผ่นงานใหม่เพื่อใส่ข้อมูลในเซลล์
	int dataSheetIdx = wb.Worksheets.Add();
	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
	string sheetName = "DataSheet";
	dataSheet.Name = sheetName;

	//ใส่ข้อมูลลงใน DataSheet
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

	//เพิ่มแผ่นงานแผนภูมิ
	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);
	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
	chartSheet.Name = "ChartSheet";

	//เพิ่มแผนภูมิใน ChartSheet โดยใช้ซีรีส์ข้อมูลจาก DataSheet
	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);
	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//ตั้งค่าชื่อแผนภูมิ
	chart.Title.Text = "Sales by Quarter";

	//ตั้งค่าสีพื้นหน้าของพื้นที่พล็อต
	chart.PlotArea.Area.ForegroundColor = Color.White;

	//ตั้งค่าสีพื้นหลังของพื้นที่พล็อต
	chart.PlotArea.Area.BackgroundColor = Color.White;

	//ตั้งค่าสีพื้นหน้าของพื้นที่แผนภูมิ
	chart.ChartArea.Area.BackgroundColor = Color.White;
	chart.Title.TextFont.Size = 16;

	//ตั้งค่าชื่อของแกนหมวดหมู่ของแผนภูมิ
	chart.CategoryAxis.Title.Text = "Fiscal Quarter";

	//ตั้งค่าชื่อของแกนค่าของแผนภูมิ
	chart.ValueAxis.Title.Text = "Billions";

	//ตั้งค่า ChartSheet เป็นแผ่นงานที่ใช้งานอยู่
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
## **ดาวน์โหลดตัวอย่างโค้ด**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object/)
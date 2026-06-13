---
title: ایجاد و جاسازی یک نمودار Excel به عنوان شیء OLE
type: docs
weight: 70
url: /fa/net/create-and-embed-an-excel-chart-as-an-ole-object/
---
دو مثال کد زیر طولانی و جزئیات‌دار هستند زیرا کاری که توضیح می‌دهند پیچیده است. شما یک کتاب کار Microsoft Excel ایجاد می‌کنید، یک نمودار می‌سازید و سپس ارائه Microsoft PowerPoint را که نمودار را در آن جاسازی می‌کنید، ایجاد می‌کنید. اشیای OLE حاوی لینک‌هایی به سند اصلی هستند به طوری که کاربری که بر روی فایل جاسازی‌شده دوبار کلیک می‌کند، فایل و برنامهٔ مربوطه را اجرا می‌کند.
## **VSTO**
با استفاده از VSTO، مراحل زیر انجام می‌شود:

1. یک نمونه از شیء Microsoft Excel ApplicationClass ایجاد کنید.
1. یک کتاب کار جدید با یک صفحه ایجاد کنید.
1. یک نمودار به صفحه اضافه کنید.
1. کتاب کار را ذخیره کنید.
1. کتاب کار Excel حاوی صفحه‌کاری که داده‌های نمودار در آن قرار دارد را باز کنید.
1. مجموعه ChartObjects را برای صفحه دریافت کنید.
1. نمودار مورد نظر برای کپی را دریافت کنید.
1. یک ارائه Microsoft PowerPoint ایجاد کنید.
1. یک اسلاید خالی به ارائه اضافه کنید.
1. نمودار را از صفحه‌کار Excel به کلیپ‌بورد کپی کنید.
1. نمودار را در ارائه PowerPoint بچسبانید.
1. نمودار را در اسلاید موقعیت‌دهی کنید.
1. ارائه را ذخیره کنید.

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// یک متغیر برای نمونهٔ Excel ApplicationClass اعلام کنید.

	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// متغیرهای مربوط به پارامترهای متد Workbooks.Open را اعلام کنید.

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// متغیرهای مربوط به متد Chart.ChartWizard را اعلام کنید.

	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "Sales by Quarter";

	object paramCategoryTitle = "Fiscal Quarter";

	object paramValueTitle = "Billions";

	try

	{

		// یک نمونه از شیء Excel ApplicationClass ایجاد کنید.

	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// یک کتاب کار جدید با 1 شیت در آن ایجاد کنید.

		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// نام شیت را تغییر دهید.

		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Quarterly Sales";

		// برخی داده‌ها را برای نمودار در شیت درج کنید.

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

		// محدوده‌ای که داده‌های نمودار را شامل می‌شود دریافت کنید.

		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// مجموعهٔ ChartObjects مربوط به شیت را دریافت کنید.

		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// یک نمودار به مجموعه اضافه کنید.

		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "Sales Chart";

		// یک نمودار جدید بر پایه داده‌ها ایجاد کنید.

		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// کتاب کار را ذخیره کنید.

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

			// Excel را ببندید.

			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// متغیرهایی برای نگهداری ارجاع به اشیای PowerPoint اعلام کنید.

	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// متغیرهایی برای نگهداری ارجاع به اشیای Excel اعلام کنید.

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

		// یک نمونه از PowerPoint ایجاد کنید.

		powerpointApplication =new pptNS.Application();

		// یک نمونه از Excel ایجاد کنید.

		excelApplication = new xlNS.Application();

		// کتاب کار Excel حاوی شیت با داده‌های نمودار را باز کنید.

		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// شیتی که شامل نمودار است دریافت کنید.

		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

		// مجموعهٔ ChartObjects مربوط به شیت را دریافت کنید.

		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// نمودار را برای کپی دریافت کنید.

		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

		// یک ارائه PowerPoint ایجاد کنید.

		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// یک اسلاید خالی به ارائه اضافه کنید.

		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// نمودار را از شیت Excel به کلیپ‌بورد کپی کنید.

		existingChartObject.Copy();

		// نمودار را در ارائه PowerPoint بچسبانید.

		shapeRange = pptSlide.Shapes.Paste();

		// موقعیت نمودار را روی اسلاید تنظیم کنید.

		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// ارائه را ذخیره کنید.

		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// شیء اسلاید PowerPoint را آزاد کنید.

		shapeRange = null;

		pptSlide = null;

		// شیء Presentation را ببندید و آزاد کنید.

		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// PowerPoint را ببندید و شیء ApplicationClass را آزاد کنید.

		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// اشیای Excel را آزاد کنید.

		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// شیء Workbook Excel را ببندید و آزاد کنید.

		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// Excel را ببندید و شیء ApplicationClass را آزاد کنید.

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
با استفاده از Aspose.Slides برای .NET، مراحل زیر انجام می‌شود:

1. یک کتاب کار با استفاده از Aspose.Cells برای .NET ایجاد کنید.
1. یک نمودار Microsoft Excel ایجاد کنید.
1. اندازه OLE نمودار Excel را تنظیم کنید.
1. یک تصویر از نمودار به‌دست آورید.
1. نمودار Excel را به‌عنوان یک شیء OLE داخل ارائه PPTX با استفاده از Aspose.Slides برای .NET جاسازی کنید.
1. تصویر تغییر یافتهٔ شیء را با تصویری که در مرحله 3 به‌دست آمده است، جایگزین کنید تا مشکل تغییر شیء رفع شود.
1. نمایش خروجی را به‌صورت فایل PPTX روی دیسک بنویسید.

``` csharp

 static void Main(string[] args)

{

	//یک کتاب کار ایجاد کنید
	Workbook wb = new Workbook();
	//یک نمودار اکسل اضافه کنید
	int chartSheetIndex = AddExcelChartInWorkbook(wb);
	wb.Worksheets.SetOleSize(0, 5, 0, 5);
	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
	//کتاب کار را به جریان ذخیره کنید
	MemoryStream wbStream = wb.SaveToStream();
	//یک ارائه ایجاد کنید
	PresentationEx pres = new PresentationEx();
	SlideEx sld = pres.Slides[0];
	//کتاب کار را بر روی اسلاید اضافه کنید
	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
	//ارائهٔ خروجی را بر روی دیسک بنویسید
	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//یک شیت جدید اضافه کنید تا سلول‌ها را با داده پر کنید
	int dataSheetIdx = wb.Worksheets.Add();
	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
	string sheetName = "DataSheet";
	dataSheet.Name = sheetName;
	//DataSheet را با داده‌ها پر کنید
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
	//یک شیت نمودار اضافه کنید
	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);
	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
	chartSheet.Name = "ChartSheet";
	//یک نمودار در ChartSheet اضافه کنید با سری داده‌ها از DataSheet
	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);
	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
	chart.NSeries.Add(sheetName + "!A1:E5", false);
	//تنظیم عنوان نمودار
	chart.Title.Text = "Sales by Quarter";
	//تنظیم رنگ پیش‌زمینه ناحیهٔ نمودار
	chart.PlotArea.Area.ForegroundColor = Color.White;
	//تنظیم رنگ پس‌زمینه ناحیهٔ نمودار
	chart.PlotArea.Area.BackgroundColor = Color.White;
	//تنظیم رنگ پیش‌زمینه ناحیهٔ چارت
	chart.ChartArea.Area.BackgroundColor = Color.White;
	chart.Title.TextFont.Size = 16;
	//تنظیم عنوان محور دسته‌بندی نمودار
	chart.CategoryAxis.Title.Text = "Fiscal Quarter";
	//تنظیم عنوان محور مقدار نمودار
	chart.ValueAxis.Title.Text = "Billions";
	//ChartSheet را به عنوان شیت فعال تنظیم کنید
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
## **کد نمونه را بارگیری کنید**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object/)
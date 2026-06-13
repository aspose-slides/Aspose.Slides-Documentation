---
title: ساخت یک نمودار
type: docs
weight: 60
url: /fa/net/create-a-chart/
---
مثال‌های کد زیر فرایند اضافه‌کردن یک نمودار ستونی خوشه‌ای سه‌بعدی ساده با استفاده از VSTO را توضیح می‌دهند. شما یک نمونه ارائه ایجاد می‌کنید، یک نمودار پیش‌فرض به آن اضافه می‌کنید. سپس از دفتر کار Microsoft Excel برای دسترسی و اصلاح داده‌های نمودار به همراه تنظیم ویژگی‌های نمودار استفاده می‌کنید. در نهایت، ارائه را ذخیره می‌کنید.

## **VSTO**
با استفاده از VSTO، مراحل زیر انجام می‌شود:

1. یک نمونه از ارائه Microsoft PowerPoint ایجاد کنید.
1. یک اسلاید خالی به ارائه اضافه کنید.
1. یک نمودار ستونی خوشه‌ای سه‌بعدی اضافه کنید و به آن دسترسی پیدا کنید.
1. یک نمونه جدید از Microsoft Excel Workbook ایجاد کنید و داده‌های نمودار را بارگذاری کنید.
1. با استفاده از نمونه Microsoft Excel Workbook، به کاربرگ داده‌های نمودار دسترسی پیدا کنید.
1. محدوده نمودار را در کاربرگ تنظیم کنید و سری‌های 2 و 3 را از نمودار حذف کنید.
1. داده‌های دسته‌بندی نمودار را در کاربرگ داده‌های نمودار اصلاح کنید.
1. داده‌های سری 1 نمودار را در کاربرگ داده‌های نمودار اصلاح کنید.
1. حالا، به عنوان نمودار دسترسی پیدا کنید و ویژگی‌های مربوط به فونت را تنظیم کنید.
1. به محور مقدار نمودار دسترسی پیدا کنید و واحد اصلی، واحدهای فرعی، حداکثر مقدار و حداقل مقدار را تنظیم کنید.
1. به محور عمق یا محور سری‌ها دسترسی پیدا کنید و همان‌طور که در این مثال فقط یک سری استفاده شده، آن را حذف کنید.
1. حالا، زاویه‌های چرخش نمودار را در جهت X و Y تنظیم کنید.
1. ارائه را ذخیره کنید.
1. نمونه‌های Microsoft Excel و PowerPoint را ببندید.

```csharp

 //متغیرهای سراسری

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//اشیاء اسلاید را نمونه‌سازی کنید
	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//دسترسی به اولین اسلاید ارائه
	objSlide = objPres.Slides[1];

	//اسلاید اول را انتخاب کنید و چیدمان آن را تنظیم کنید
	objSlide.Select();
	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//یک نمودار پیش‌فرض به اسلاید اضافه کنید
	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//دسترسی به نمودار اضافه شده
	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//دسترسی به داده‌های نمودار
	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//یک نمونه از کتاب کار Excel ایجاد کنید تا با داده‌های نمودار کار کنید
	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//دسترسی به کاربرگ داده‌ها برای نمودار
	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//تنظیم بازه نمودار
	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//اعمال بازه تنظیم‌شده بر جدول داده‌های نمودار
	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
	tbl1.Resize(tRange);

	//تنظیم مقادیر برای دسته‌ها و داده‌های سری‌های مربوطه
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//تنظیم عنوان نمودار
	ppChart.ChartTitle.Font.Italic = true;
	ppChart.ChartTitle.Text = "2007 Sales";
	ppChart.ChartTitle.Font.Size = 18;
	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//دسترسی به محور مقدار نمودار
	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//تنظیم واحدهای محور مقدار
	valaxis.MajorUnit = 2000.0F;
	valaxis.MinorUnit = 1000.0F;
	valaxis.MinimumScale = 0.0F;
	valaxis.MaximumScale = 4000.0F;

	//دسترسی به محور عمق نمودار
	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
	Depthaxis.Delete();

	//تنظیم چرخش نمودار
	ppChart.Rotation = 20; //مقدار Y
	ppChart.Elevation = 15; //مقدار X
	ppChart.RightAngleAxes = false;

	//ذخیره ارائه به‌صورت PPTX
	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//بستن کتاب کار و ارائه
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
	//دسترسی به ویژگی Name را امتحان کنید. اگر استثنایی ایجاد شود
	//یک نمونه جدید از PowerPoint را شروع کنید
	try
	{
		strName = objPPT.Name;
	}
	catch (Exception ex)
	{
		StartPowerPoint();
	}
	//
	//blnAddPresentation برای اطمینان از بارگذاری یک ارائه استفاده می‌شود
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
	//BlnAddSlide برای اطمینان از وجود حداقل یک اسلاید در
	//ارائه
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
با استفاده از Aspose.Slides برای .NET، مراحل زیر انجام می‌شود:

1. یک نمونه از ارائه Microsoft PowerPoint ایجاد کنید.
1. یک اسلاید خالی به ارائه اضافه کنید.
1. یک نمودار ستونی خوشه‌ای سه‌بعدی اضافه کنید و به آن دسترسی پیدا کنید.
1. با استفاده از یک نمونه Microsoft Excel Workbook، به کاربرگ داده‌های نمودار دسترسی پیدا کنید.
1. سری‌های 2 و 3 که استفاده نشده‌اند را حذف کنید.
1. دسته‌بندی‌های نمودار را دسترسی پیدا کنید و برچسب‌ها را اصلاح کنید.
1. به سری 1 دسترسی پیدا کنید و مقادیر سری را اصلاح کنید.
1. حالا، به عنوان نمودار دسترسی پیدا کنید و ویژگی‌های فونت را تنظیم کنید.
1. به محور مقدار نمودار دسترسی پیدا کنید و واحد اصلی، واحدهای فرعی، حداکثر مقدار و حداقل مقدار را تنظیم کنید.
1. حالا، زاویه‌های چرخش نمودار را در جهت X و Y تنظیم کنید.
1. ارائه را در قالب PPTX ذخیره کنید.

```csharp

 public static void GEN_ASPOSE_Chart()

{

	//ایجاد ارائه خالی
	using (PresentationEx pres = new PresentationEx())

	{

		//دسترسی به اولین اسلاید
		SlideEx slide = pres.Slides[0];

		//افزودن نمودار پیش‌فرض
		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//دریافت داده‌های نمودار
		ChartDataEx chartData = ppChart.ChartData;

		//حذف سری‌های پیش‌فرض اضافی
		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//اصلاح نام‌های دسته‌های نمودار
		chartData.Categories[0].ChartDataCell.Value = "Bikes";

		chartData.Categories[1].ChartDataCell.Value = "Accessories";

		chartData.Categories[2].ChartDataCell.Value = "Repairs";

		chartData.Categories[3].ChartDataCell.Value = "Clothing";

		//اصلاح مقادیر سری نمودار برای اولین دسته
		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//تنظیم عنوان نمودار
		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "2007 Sales";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//تنظیم مقادیر محور
		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//تنظیم چرخش نمودار
		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//ذیره ارائه
		pres.Write("AsposeSampleChart.pptx");

	}

}
``` 
## **دریافت کد نمونه**
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart/)
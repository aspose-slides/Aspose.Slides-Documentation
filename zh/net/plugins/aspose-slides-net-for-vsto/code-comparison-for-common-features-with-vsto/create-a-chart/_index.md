---
title: 创建图表
type: docs
weight: 60
url: /zh/net/create-a-chart/
---

下面的代码示例描述了使用 VSTO 添加简单的 3D 聚类柱状图的过程。您创建一个演示实例，添加一个默认图表。然后使用 Microsoft Excel 工作簿访问和修改图表数据，同时设置图表属性。最后，保存演示文稿。
## **VSTO**
使用 VSTO，执行以下步骤：

1. 创建一个 Microsoft PowerPoint 演示文稿实例。
1. 向演示文稿添加一个空白幻灯片。
1. 添加一个 3D 聚类柱状图并访问它。
1. 创建一个新的 Microsoft Excel 工作簿实例并加载图表数据。
1. 使用 Microsoft Excel 工作簿实例访问图表数据工作表。
1. 设置工作表中的图表范围，并从图表中删除系列 2 和 3。
1. 修改图表数据工作表中的图表类别数据。
1. 修改图表数据工作表中的系列 1 数据。
1. 现在，访问图表标题并设置与字体相关的属性。
1. 访问图表值轴，设置主要单位、次要单位、最大值和最小值。
1. 访问图表深度或系列轴并将其删除，因为在此示例中仅使用一个系列。
1. 现在，设置图表在 X 和 Y 方向的旋转角度。
1. 保存演示文稿。
1. 关闭 Microsoft Excel 和 PowerPoint 的实例。

``` csharp

 //全局变量

public static Microsoft.Office.Interop.PowerPoint.Application objPPT;

public static Microsoft.Office.Interop.PowerPoint.Presentation objPres;

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	GEN_VSTO_Chart();

}

public static void GEN_VSTO_Chart()

{


	EnsurePowerPointIsRunning(true, true);

	//实例化幻灯片对象

	Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

	//访问演示文稿的第一张幻灯片

	objSlide = objPres.Slides[1];

	//选择第一张幻灯片并设置其布局

	objSlide.Select();

	objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

	//在幻灯片中添加默认图表

	objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

	//访问添加的图表

	Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

	//访问图表数据

	Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

	//创建 Excel 工作簿实例以处理图表数据

	Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

	//访问图表的数据工作表

	Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

	//设置图表的范围

	Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

	//将设置的范围应用于图表数据表

	Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];

	tbl1.Resize(tRange);

	//为类别和各自系列数据设置值

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "自行车";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "配件";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "维修";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "服装";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";

	((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

	//设置图表标题

	ppChart.ChartTitle.Font.Italic = true;

	ppChart.ChartTitle.Text = "2007 销售";

	ppChart.ChartTitle.Font.Size = 18;

	ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();

	ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;

	ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

	//访问图表值轴

	Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	//设置值轴单位

	valaxis.MajorUnit = 2000.0F;

	valaxis.MinorUnit = 1000.0F;

	valaxis.MinimumScale = 0.0F;

	valaxis.MaximumScale = 4000.0F;

	//访问图表深度轴

	Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

	Depthaxis.Delete();

	//设置图表旋转

	ppChart.Rotation = 20; //Y 值

	ppChart.Elevation = 15; //X 值

	ppChart.RightAngleAxes = false;

	//将演示文稿保存为 PPTX

	objPres.SaveAs("VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

	//关闭工作簿和演示文稿

	dataWorkbook.Application.Quit();

	objPres.Application.Quit();

}

//补充方法

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

	//尝试访问名称属性。如果导致异常，则

	//启动 PowerPoint 的新实例

	try

	{

		strName = objPPT.Name;

	}

	catch (Exception ex)

	{

		StartPowerPoint();

	}

	//

	//blnAddPresentation 用于确保加载了演示文稿

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

	//BlnAddSlide 用于确保演示文稿中至少有一张幻灯片

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
使用 Aspose.Slides for .NET，执行以下步骤：

1. 创建一个 Microsoft PowerPoint 演示文稿实例。
1. 向演示文稿添加一个空白幻灯片。
1. 添加一个 3D 聚类柱状图并访问该图表。
1. 使用 Microsoft Excel 工作簿实例访问图表数据工作表。
1. 删除未使用的系列 2 和 3。
1. 访问图表类别并修改标签。
1. 访问系列 1 并修改系列值。
1. 现在，访问图表标题并设置字体属性。
1. 访问图表值轴，设置主要单位、次要单位、最大值和最小值。
1. 现在，设置图表在 X 和 Y 方向的旋转角度。
1. 将演示文稿保存为 PPTX 格式。

``` csharp

 public static void GEN_ASPOSE_Chart()

{

	//创建空演示文稿

	using (PresentationEx pres = new PresentationEx())

	{

		//访问第一张幻灯片

		SlideEx slide = pres.Slides[0];

		//添加默认图表

		ChartEx ppChart = slide.Shapes.AddChart(ChartTypeEx.ClusteredColumn3D, 20F, 30F, 400F, 300F);

		//获取图表数据

		ChartDataEx chartData = ppChart.ChartData;

		//移除额外的默认系列

		chartData.Series.RemoveAt(1);

		chartData.Series.RemoveAt(1);

		//修改图表类别名称

		chartData.Categories[0].ChartDataCell.Value = "自行车";

		chartData.Categories[1].ChartDataCell.Value = "配件";

		chartData.Categories[2].ChartDataCell.Value = "维修";

		chartData.Categories[3].ChartDataCell.Value = "服装";

		//修改第一个类别的图表系列值

		chartData.Series[0].Values[0].Value = 1000;

		chartData.Series[0].Values[1].Value = 2500;

		chartData.Series[0].Values[2].Value = 4000;

		chartData.Series[0].Values[3].Value = 3000;

		//设置图表标题

		ppChart.HasTitle = true;

		ppChart.ChartTitle.Text.Text = "2007 销售";

		PortionFormatEx format = ppChart.ChartTitle.Text.Paragraphs[0].Portions[0].PortionFormat;

		format.FontItalic = NullableBool.True;

		format.FontHeight = 18;

		format.FillFormat.FillType = FillTypeEx.Solid;

		format.FillFormat.SolidFillColor.Color = Color.Black;


		//设置轴值

		ppChart.ValueAxis.IsAutomaticMaxValue = false;

		ppChart.ValueAxis.IsAutomaticMinValue = false;

		ppChart.ValueAxis.IsAutomaticMajorUnit = false;

		ppChart.ValueAxis.IsAutomaticMinorUnit = false;

		ppChart.ValueAxis.MaxValue = 4000.0F;

		ppChart.ValueAxis.MinValue = 0.0F;

		ppChart.ValueAxis.MajorUnit = 2000.0F;

		ppChart.ValueAxis.MinorUnit = 1000.0F;

		ppChart.ValueAxis.TickLabelPosition = TickLabelPositionType.NextTo;

		//设置图表旋转

		ppChart.Rotation3D.RotationX = 15;

		ppChart.Rotation3D.RotationY = 20;

		//保存演示文稿

		pres.Write("AsposeSampleChart.pptx");

	}

``` 
## **下载示例代码**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772948)
- [Github](https://github.com/asposemarketplace/Aspose_for_VSTO/releases/download/3/Create.a.Chart.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20Chart%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20a%20Chart%20\(Aspose.Slides\).zip)
---
title: 在 Microsoft PowerPoint 演示文稿中创建图表
type: docs
weight: 80
url: /net/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 图表是数据的可视化表示，广泛用于演示文稿。本文展示了如何通过使用 [VSTO](/slides/net/create-a-chart-in-a-microsoft-powerpoint-presentation/) 和 [Aspose.Slides for .NET](/slides/net/create-a-chart-in-a-microsoft-powerpoint-presentation/) 程序化地在 Microsoft PowerPoint 中创建图表的代码。

{{% /alert %}} 
## **创建图表**
以下代码示例描述了使用 VSTO 添加简单的 3D 分组柱形图的过程。您创建一个演示文稿实例，并向其中添加一个默认图表。然后使用 Microsoft Excel 工作簿访问和修改图表数据，并设置图表属性。最后，保存演示文稿。
## **VSTO 示例**
使用 VSTO，执行以下步骤：

1. 创建一个 Microsoft PowerPoint 演示文稿实例。
1. 向演示文稿中添加一个空白幻灯片。
1. 添加一个 **3D 分组柱形** 图表并访问它。
1. 创建一个新的 Microsoft Excel 工作簿实例并加载图表数据。
1. 使用 workbook 中的 Microsoft Excel 工作簿实例访问图表数据工作表。
1. 在工作表中设置图表范围并从图表中删除系列 2 和 3。
1. 修改图表数据工作表中的图表类别数据。
1. 修改图表数据工作表中的图表系列 1 数据。
1. 现在，访问图表标题并设置与字体相关的属性。
1. 访问图表值轴并设置主要单位、次要单位、最大值和最小值。
1. 访问图表深度或系列轴并删除，因为在本示例中仅使用一个系列。
1. 现在，在 X 和 Y 方向上设置图表旋转角度。
1. 保存演示文稿。
1. 关闭 Microsoft Excel 和 PowerPoint 的实例。

**使用 VSTO 创建的输出演示文稿** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)

```c#
EnsurePowerPointIsRunning(true, true);

//Instantiate slide object
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

//Access the first slide of presentation
objSlide = objPres.Slides[1];

//Select firs slide and set its layout
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

//Add a default chart in slide
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

//Access the added chart
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

//Access the chart data
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

//Create instance to Excel workbook to work with chart data
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

//Accessing the data worksheet for chart
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

//Setting the range of chart
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

//Applying the set range on chart data table
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

//Setting values for categories and respective series data

((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "自行车";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "配件";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "维修";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "服装";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

//Setting chart title
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 年销售额";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

//Accessing Chart value axis
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

//Setting values axis units
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

//Accessing Chart Depth axis
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

//Setting chart rotation
ppChart.Rotation = 20; //Y-Value
ppChart.Elevation = 15; //X-Value
ppChart.RightAngleAxes = false;

// Save the presentation as a PPTX
objPres.SaveAs("C:\\VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
//objPres.SaveAs(@"..\..\..\VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

//Close Workbook and presentation
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
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
    //Try accessing the name property. If it causes an exception then
    //start a new instance of PowerPoint
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }
    //
    //blnAddPresentation is used to ensure there is a presentation loaded
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
    //BlnAddSlide is used to ensure there is at least one slide in the
    //presentation
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

## **Aspose.Slides for .NET 示例**
使用 Aspose.Slides for .NET，执行以下步骤：

1. 创建一个 Microsoft PowerPoint 演示文稿实例。
1. 向演示文稿中添加一个空白幻灯片。
1. 添加一个 **3D 分组柱形** 图表并访问它。
1. 使用 workbook 中的 Microsoft Excel 工作簿实例访问图表数据工作表。
1. 删除未使用的系列 2 和 3。
1. 访问图表类别并修改标签。
1. 访问系列 1 并修改系列值。
1. 现在，访问图表标题并设置字体属性。
1. 访问图表值轴并设置主要单位、次要单位、最大值和最小值。
1. 现在，在 X 和 Y 方向上设置图表旋转角度。
1. 将演示文稿保存为 PPTX 格式。

**使用 Aspose.Slides 创建的输出演示文稿**

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

```csharp
//Create empty presentation
using (Presentation pres = new Presentation())
{

    //Accessing first slide
    ISlide slide = pres.Slides[0];

    //Addding default chart
    IChart ppChart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20F, 30F, 400F, 300F);

    //Getting Chart data
    IChartData chartData = ppChart.ChartData;

    //Removing Extra default series
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    //Modifying chart categories names
    chartData.Categories[0].AsCell.Value = "自行车";
    chartData.Categories[1].AsCell.Value = "配件";
    chartData.Categories[2].AsCell.Value = "维修";
    chartData.Categories[3].AsCell.Value = "服装";

    //Setting the index of chart data sheet
    int defaultWorksheetIndex = 0;


    //Getting the chart data worksheet
    IChartDataWorkbook fact = ppChart.ChartData.ChartDataWorkbook;

    //Modifying chart series values for first category
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, 3000));

    //Setting Chart title
    ppChart.HasTitle = true;
    ppChart.ChartTitle.AddTextFrameForOverriding("2007 年销售额");
    IPortionFormat format = ppChart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;


    ////Setting Axis values
    ppChart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    ppChart.Axes.VerticalAxis.MaxValue = 4000.0F;
    ppChart.Axes.VerticalAxis.MinValue = 0.0F;
    ppChart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    ppChart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    ppChart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    //Setting Chart rotation
    ppChart.Rotation3D.RotationX = 15;
    ppChart.Rotation3D.RotationY = 20;

    //Saving Presentation
    pres.Save("AsposeSampleChart.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

## **资源**
本文中使用的项目和文件可以从我们的网站下载：

- [下载 VSTO 生成的演示文稿](http://docs.aspose.com:8082/docs/download/attachments/87523560/VSTOSampleChart.pptx)。
- [下载 Aspose.Slides 生成的示例图表](http://docs.aspose.com:8082/docs/download/attachments/87523560/AsposeSampleChart.pptx)。

{{% /alert %}}
---
title: 使用 VSTO 和 Aspose.Slides for .NET 创建图表
linktitle: 创建图表
type: docs
weight: 80
url: /zh/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- 创建图表
- 迁移
- VSTO
- Office 自动化
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 C# 自动化 PowerPoint 图表创建。本分步指南展示了为何 Aspose.Slides for .NET 是比 Microsoft.Office.Interop 更快、更强大的替代方案。"
---

## **概述**

本文演示如何使用 C# 在 Microsoft PowerPoint 演示文稿中以编程方式创建和自定义图表。借助 Aspose.Slides for .NET，您可以在无需 Microsoft Office 或 Interop 库的情况下自动生成专业的、数据驱动的图表。该 API 提供了丰富的功能，可构建柱形图、饼图、折线图等多种图表——全面控制外观、数据和布局。无论是生成报告、仪表板还是业务演示文稿，Aspose.Slides 都能帮助您直接从 .NET 应用程序中交付高质量的可视化效果。

## **VSTO 示例**

本节演示如何使用 **VSTO (Visual Studio Tools for Office)** 在 Microsoft PowerPoint 演示文稿中创建图表。通过 VSTO，您可以结合 PowerPoint 与 Excel 自动化，以编程方式生成并自定义图表。示例展示了如何添加 **3D 分组柱形图**、从 Excel 工作表加载数据、调整格式和布局，并保存最终的演示文稿——全部在 .NET 应用程序内部完成。

1. 创建一个 Microsoft PowerPoint 演示文稿实例。  
2. 向演示文稿添加一个空白幻灯片。  
3. 添加一个 3D 分组柱形图并获取该图表对象。  
4. 创建一个新的 Microsoft Excel 工作簿实例并加载图表数据。  
5. 使用 Excel 工作簿实例访问图表数据工作表。  
6. 在工作表中设置图表范围并删除系列 2 和系列 3。  
7. 在图表数据工作表中修改图表类别数据。  
8. 在图表数据工作表中修改系列 1 数据。  
9. 访问图表标题并设置其字体相关属性。  
10. 访问图表的数值轴并设置主单位、次单位、最大值和最小值。  
11. 访问图表的深度（系列）轴并将其删除——本示例只使用一个系列。  
12. 设置图表在 X 轴和 Y 轴方向的旋转角度。  
13. 保存演示文稿。  
14. 关闭 Microsoft Excel 和 PowerPoint 实例。  

```c#
EnsurePowerPointIsRunning(true, true);

// 实例化幻灯片对象。
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// 访问第一张演示文稿幻灯片。
objSlide = objPres.Slides[1];

// 选择第一张幻灯片并设置其布局。
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// 向幻灯片添加默认图表。
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// 访问已添加的图表。
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// 访问图表数据。
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// 创建 Excel 工作簿实例以处理图表数据。
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// 访问图表的数据工作表。
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// 设置图表的数据范围。
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// 将指定范围应用于图表数据表。
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// 设置类别及相应系列数据的值。
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// 设置图表标题。
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// 访问图表数值轴。
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// 设置轴单位的数值。
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// 访问图表深度轴。
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// 设置图表旋转。
ppChart.Rotation = 20;   // Y 值
ppChart.Elevation = 15;  // X 值
ppChart.RightAngleAxes = false;

// 保存演示文稿为 PPTX 文件。
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// 关闭工作簿和演示文稿。
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

    // 尝试访问 Name 属性。如果抛出异常，则启动一个新的 PowerPoint 实例。
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation 用于确保已加载演示文稿。
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

    // blnAddSlide 用于确保演示文稿中至少有一张幻灯片。
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


结果：

![使用 VSTO 创建的图表](chart-created-using-VSTO.png)

## **Aspose.Slides for .NET 示例**

下面的示例展示如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中创建一个简单的图表。代码演示了如何添加 **3D 分组柱形图**、填充示例数据并自定义外观。仅需几行代码，您即可动态生成图表并将其集成到演示文稿中，无需使用 Microsoft Office。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。  
2. 获取第一张幻灯片的引用。  
3. 添加一个 3D 分组柱形图并获取该图表对象。  
4. 访问图表数据。  
5. 删除未使用的系列 2 和系列 3。  
6. 通过更新标签修改图表类别。  
7. 更新系列 1 的数值。  
8. 访问图表标题并设置其字体属性。  
9. 配置图表的数值轴，包括主单位、次单位、最大值和最小值。  
10. 设置图表在 X 轴和 Y 轴方向的旋转角度。  
11. 以 PPTX 格式保存演示文稿。  

```cs
// 创建一个空的演示文稿。
using (Presentation presentation = new Presentation())
{
    // 访问第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 添加默认图表。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // 获取图表数据。
    IChartData chartData = chart.ChartData;

    // 移除多余的默认系列。
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // 修改图表类别名称。
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // 设置图表数据工作表的索引。
    int worksheetIndex = 0;

    // 获取图表数据工作簿。
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // 修改图表系列值。
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // 设置图表标题。
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // 设置坐标轴选项。
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // 设置图表旋转。
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // 将演示文稿保存为 PPTX 文件。
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```


结果：

![使用 Aspose.Slides for .NET 创建的图表](chart-created-using-aspose-slides.png)

## **常见问题**

**我可以使用 Aspose.Slides 创建饼图、折线图或条形图等其他类型的图表吗？**

是的。Aspose.Slides for .NET 支持广泛的 [图表类型](https://docs.aspose.com/slides/net/create-chart/)，包括饼图、折线图、条形图、散点图、气泡图等。添加图表时可以使用 [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) 枚举指定所需的图表类型。

**我可以为图表应用自定义样式或主题吗？**

可以。您可以完全自定义图表的外观，包括颜色、字体、填充、轮廓、网格线和布局。不过，要完全复制 PowerPoint 中的 Office 主题，需要手动设置各个样式属性。

**我能将图表单独导出为图像吗？**

可以，Aspose.Slides 允许您使用图表 [shape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 的 `GetImage` 方法将任何形状（包括图表）导出为独立的图像（如 PNG、JPEG）。
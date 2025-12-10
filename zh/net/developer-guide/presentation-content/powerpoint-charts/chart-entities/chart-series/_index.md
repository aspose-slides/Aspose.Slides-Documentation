---
title: 在 .NET 中管理演示文稿的图表数据系列
linktitle: 数据系列
type: docs
url: /zh/net/chart-series/
keywords:
- 图表系列
- 系列重叠
- 系列颜色
- 类别颜色
- 系列名称
- 数据点
- 系列间隙
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "学习如何在 C# 中为 PowerPoint (PPT/PPTX) 管理图表系列，提供实用代码示例和最佳实践，以提升您的数据演示。"
---

## **概述**

本文描述了 [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) 在 Aspose.Slides for .NET 中的作用，重点关注数据在演示文稿中的结构化和可视化方式。这些对象提供了定义图表中单个数据点集合、类别和外观参数的基础元素。通过使用 [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/)，开发人员可以无缝集成底层数据源，并完全控制信息的展示方式，从而生成动态、数据驱动的演示文稿，清晰传达洞察和分析。

系列是绘制在图表中的一行或一列数字。

![图表系列-PowerPoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

[IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) 属性通过指定 -100 到 100 的范围来控制 2D 图表中柱形和条形的重叠方式。由于此属性与系列组而非单个图表系列关联，因此在系列级别上为只读。若要配置重叠值，请使用 `ParentSeriesGroup.Overlap` 读写属性，该属性将指定的重叠应用于该组中的所有系列。

下面是一个 C# 示例，演示如何创建演示文稿、添加聚簇柱形图、访问第一个图表系列、配置重叠设置，然后将结果保存为 PPTX 文件：
```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个带默认数据的聚簇柱形图。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // 设置系列重叠。
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // 将演示文稿文件保存到磁盘。
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```


结果：

![系列重叠](series_overlap.png)

## **更改系列填充颜色**

Aspose.Slides 使自定义图表系列的填充颜色变得简单，您可以突出显示特定数据点并创建视觉上更具吸引力的图表。这通过 [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/) 对象实现，支持各种填充类型、颜色配置以及其他高级样式选项。将图表添加到幻灯片并访问所需系列后，只需获取该系列并应用相应的填充颜色。除了纯色填充，您还可以利用渐变或图案填充以获得更灵活的设计。一旦根据需求设置好颜色，保存演示文稿即可完成更新。

以下 C# 代码示例展示了如何更改第一个系列的颜色：
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个带默认数据的聚簇柱形图。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 设置第一个系列的颜色。
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // 将演示文稿文件保存到磁盘。
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```


结果：

![系列颜色](series_color.png)

## **更改系列名称**

Aspose.Slides 提供了一种简便的方法来修改图表系列的名称，从而更清晰、有意义地标注数据。通过访问图表数据中的相关工作表单元格，开发人员可以自定义数据的呈现方式。当需要根据数据上下文更新或澄清系列名称时，此修改尤为有用。重命名系列后，保存演示文稿以持久化更改。

下面是一个 C# 代码片段，演示此过程的实际操作。
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个带默认数据的聚簇柱形图。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 设置第一个系列的名称。
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // 将演示文稿文件保存到磁盘。
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


下面的 C# 代码展示了另一种更改系列名称的方法：
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个带默认数据的聚簇柱形图。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 设置第一个系列的名称。
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // 将演示文稿文件保存到磁盘。
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


结果：

![系列名称](series_name.png)

## **获取自动系列填充颜色**

Aspose.Slides for .NET 允许您获取绘图区域内图表系列的自动填充颜色。创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例后，您可以按索引获取所需幻灯片的引用，然后使用首选类型（例如 `ChartType.ClusteredColumn`）添加图表。通过访问图表中的系列，即可获取自动填充颜色。

以下 C# 代码详细演示了此过程。
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个带默认数据的聚簇柱形图。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // 获取系列的填充颜色。
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```


输出：
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **为图表系列设置反转填充颜色**

当您的数据系列包含正值和负值时，使用相同颜色为所有柱形或条形着色会导致图表难以阅读。Aspose.Slides for .NET 允许您指定反转填充颜色——一种自动应用于低于零的数据点的独立填充，使负值一目了然。本节将教您如何启用此选项、选择合适的颜色并保存更新后的演示文稿。

以下代码示例演示了该操作：
```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // 添加新分类。
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // 添加新系列。
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // 填充系列数据。
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // 为系列设置颜色。
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```


结果：

![反转实色填充](inverted_solid_fill_color.png)

您可以为单个数据点而非整个系列反转填充颜色。只需访问所需的 `IChartDataPoint` 并将其 `InvertIfNegative` 属性设为 true。

以下代码示例展示了实现方法：
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // 如果索引 2 的数据点为负，则反转颜色。
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```


## **清除特定数据点值**

有时图表中会包含测试值、异常值或已失效的条目，您需要在不重建整个系列的情况下将其移除。Aspose.Slides for .NET 允许您按索引定位任意数据点，清除其内容，并立即刷新绘图，使其余点自动移动且轴线自动重新缩放。

以下代码示例演示了该操作：
```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```


## **设置系列间隙宽度**

间隙宽度控制相邻柱形或条形之间的空白大小——更宽的间隙突出显示单个类别，而更窄的间隙则营造更紧凑的外观。通过 Aspose.Slides for .NET，您可以为整个系列微调此参数，实现演示文稿所需的视觉平衡，而无需更改底层数据。

以下代码示例展示了如何为系列设置间隙宽度：
```cs
ushort gapWidth = 30;

// 创建空的演示文稿。
using (Presentation presentation = new Presentation())
{
    // 访问第一张幻灯片。
    ISlide slide = presentation.Slides[0];

    // 添加一个带默认数据的图表。
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // 将演示文稿保存到磁盘。
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // 设置 GapWidth 值。
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // 将演示文稿保存到磁盘。
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```


结果：

![间隙宽度](gap_width.png)

## **常见问题**

**单个图表能够包含的系列数量是否有限制？**

Aspose.Slides 对您添加的系列数量没有固定上限。实际的限制取决于图表的可读性以及应用程序可用的内存。

**如果簇内的列太靠近或太分散怎么办？**

调整该系列（或其父系列组）的 `GapWidth` 设置。增加该值会扩大柱形之间的间距，减少该值则会使它们更靠近。
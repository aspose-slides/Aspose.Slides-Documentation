---
title: 在 C# 中管理图表系列
linktitle: 图表系列
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
- C#
- .NET
- Aspose.Slides
description: "了解如何在 C# 中管理 PowerPoint (PPT/PPTX) 的图表系列，提供实用代码示例和最佳实践，以提升数据演示效果。"
---

## **概述**

本文描述了 Aspose.Slides for .NET 中 [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) 的作用，重点关注数据在演示文稿中的结构和可视化方式。这些对象提供了定义图表中单个数据点、类别和外观参数的基础元素。通过使用 [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/)，开发人员可以无缝集成底层数据源，并完全控制信息的显示方式，从而生成动态、数据驱动的演示文稿，清晰传达洞察和分析。

系列是一行或一列在图表中绘制的数字。

![图表系列示例](chart-series-powerpoint.png)

## **设置图表系列重叠**

[IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) 属性通过指定 -100 到 100 的范围来控制二维图表中条形和柱形的重叠方式。由于此属性与系列组关联，而非单个图表系列，在系列层面上是只读的。若要配置重叠值，请使用 `ParentSeriesGroup.Overlap` 可读写属性，它会将指定的重叠应用于该组中的所有系列。

以下 C# 示例演示了如何创建演示文稿，添加簇状柱形图，访问第一个图表系列，配置重叠设置，然后将结果保存为 PPTX 文件：
```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个带默认数据的聚类柱形图。
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

Aspose.Slides 使自定义图表系列的填充颜色变得直观，帮助您突出特定数据点并创建视觉上吸引人的图表。这通过 [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/) 对象实现，该对象支持多种填充类型、颜色配置以及其他高级样式选项。向幻灯片添加图表并访问所需系列后，只需获取系列并应用相应的填充颜色。除了纯色填充，您还可以利用渐变或图案填充来增强设计灵活性。根据需求设置颜色后，保存演示文稿即可完成更新。

以下 C# 代码示例展示了如何更改第一个系列的颜色：
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个默认数据的簇状柱形图。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 设置第一系列的颜色。
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

Aspose.Slides 提供了一种简便的方法来修改图表系列的名称，使得对数据进行清晰且有意义的标注更加容易。通过访问图表数据中相关工作表单元格，开发人员可以自定义数据的呈现方式。当需要根据数据上下文更新或澄清系列名称时，此修改尤为有用。重命名系列后，可保存演示文稿以保持更改。

以下 C# 代码片段演示了此过程的实际操作：
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个默认数据的聚类柱形图。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 设置第一系列的名称。
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // 将演示文稿文件保存到磁盘。
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


以下 C# 代码展示了更改系列名称的另一种方式：
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个默认数据的聚类柱形图。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 设置第一系列的名称。
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // 将演示文稿文件保存到磁盘。
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


结果：

![系列名称](series_name.png)

## **获取系列自动填充颜色**

Aspose.Slides for .NET 允许您获取绘图区域内图表系列的自动填充颜色。创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例后，您可以按索引获取所需幻灯片的引用，然后使用首选类型（如 `ChartType.ClusteredColumn`）添加图表。通过访问图表中的系列，即可获取自动填充颜色。

下面的 C# 代码详细演示了此过程：
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 添加一个带默认数据的簇状柱形图。
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

当您的数据系列包含正负值时，统一为每个柱形或条形着色会导致图表难以阅读。Aspose.Slides for .NET 允许您分配反转填充颜色——一种自动应用于低于零的数据点的独立填充，使负值一目了然。本节将教您如何启用此选项、选择合适的颜色并保存更新后的演示文稿。

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

    // 添加新类别。
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // 添加新系列。
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // 填充系列数据。
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // 设置系列的颜色设置。
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```


结果：

![反转实心填充颜色](inverted_solid_fill_color.png)

您可以对单个数据点而非整个系列进行填充颜色反转。只需访问所需的 `IChartDataPoint` 并将其 `InvertIfNegative` 属性设为 true。

以下代码示例展示了具体实现方法：
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

    // 如果索引为 2 的数据点为负，则反转颜色。
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```


## **清除特定数据点的值**

有时图表中会包含测试值、离群值或已废弃的条目，需要在不重建整个系列的情况下将其移除。Aspose.Slides for .NET 允许您按索引定位任意数据点，清除其内容，并即时刷新绘图，使其余点自动移动，坐标轴也会重新缩放。

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

Gap width 控制相邻柱形或条形之间的空白量——更大的间隙突出单个类别，而更窄的间隙则营造更密集、更紧凑的外观。通过 Aspose.Slides for .NET，您可以为整个系列微调此参数，实现演示文稿所需的视觉平衡，而无需更改底层数据。

以下代码示例展示了如何为系列设置间隙宽度：
```cs
ushort gapWidth = 30;

// 创建一个空的演示文稿。
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

## **FAQ**

**单个图表可以包含的系列数量是否有限制？**

Aspose.Slides 对您添加的系列数量没有固定上限。实际限制取决于图表的可读性以及应用程序可用的内存。

**如果簇内的柱子之间太近或太远怎么办？**

调整该系列（或其父系列组）的 `GapWidth` 设置。增大该值会扩大柱子之间的间距，减小则会使它们更靠近。
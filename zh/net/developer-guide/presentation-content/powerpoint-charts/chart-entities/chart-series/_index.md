---
title: 图表系列
type: docs
url: /zh/net/chart-series/
keywords: "图表系列，系列颜色，PowerPoint演示文稿，C#，Csharp，Aspose.Slides for .NET"
description: "C#或.NET中的PowerPoint演示文稿中的图表系列"
---

系列是绘制在图表中的一行或一列数字。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **设置图表系列重叠**

使用 [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) 属性，您可以指定在2D图表上条形图和柱形图的重叠程度（范围：-100到100）。此属性适用于父系列组的所有系列：这是适当组属性的投影。因此，此属性是只读的。

使用 `ParentSeriesGroup.Overlap` 可读写属性设置您首选的 `Overlap` 值。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 在幻灯片上添加一个簇状柱形图。
1. 访问第一个图表系列。
1. 访问图表系列的 `ParentSeriesGroup`并为该系列设置首选的重叠值。
1. 将修改后的演示文稿写入PPTX文件。

以下C#代码演示如何为图表系列设置重叠：

```c#
using (Presentation presentation = new Presentation())
{
    // 添加图表
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.ChartData.Series;
    if (series[0].Overlap == 0)
    {
        // 设置系列重叠
        series[0].ParentSeriesGroup.Overlap = -30;
    }

    // 将演示文稿文件写入磁盘
    presentation.Save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
}
```

## **更改系列颜色**
Aspose.Slides for .NET允许您以如下方式更改系列的颜色：

1. 创建 `Presentation` 类的实例。
1. 在幻灯片上添加图表。
1. 访问您想要更改颜色的系列。
1. 设置您首选的填充类型和填充颜色。
1. 保存修改后的演示文稿。

以下C#代码演示如何更改系列的颜色：

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 600, 400);
	IChartDataPoint point = chart.ChartData.Series[0].DataPoints[1];
	
	point.Explosion = 30;
	point.Format.Fill.FillType = FillType.Solid;
	point.Format.Fill.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **更改系列类别的颜色**
Aspose.Slides for .NET允许您以如下方式更改系列类别的颜色：

1. 创建 `Presentation` 类的实例。
1. 在幻灯片上添加图表。
1. 访问您想要更改颜色的系列类别。
1. 设置您首选的填充类型和填充颜色。
1. 保存修改后的演示文稿。

以下C#代码演示如何更改系列类别的颜色：

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartDataPoint point = chart.ChartData.Series[0].DataPoints[0];
	
	point.Format.Fill.FillType = FillType.Solid;
	point.Format.Fill.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **更改系列名称** 

默认情况下，图表的图例名称是每个数据列或数据行上方单元格的内容。

在我们的示例中（示例图像），

* 列是 *系列1，系列2* 和 *系列3*；
* 行是 *类别1，类别2，类别3* 和 *类别4*。

Aspose.Slides for .NET允许您在其图表数据和图例中更新或更改系列名称。

以下C#代码演示如何在图表数据 `ChartDataWorkbook` 中更改系列名称：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = "新名称";
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

以下C#代码演示如何通过 `Series` 在其图例中更改系列名称：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.ChartData.Series[0];
    
    IStringChartValue name = series.Name;
    name.AsCells[0].Value = "新名称";   
}
```

## **设置图表系列填充颜色**

Aspose.Slides for .NET允许您以如下方式设置图表系列内绘图区的自动填充颜色：

1. 创建 `Presentation` 类的实例。
1. 通过其索引获取幻灯片的引用。
1. 根据您首选的类型（在以下示例中，我们使用 `ChartType.ClusteredColumn`）添加具有默认数据的图表。
1. 访问图表系列并将填充颜色设置为自动。
1. 将演示文稿保存为PPTX文件。

以下C#代码演示如何为图表系列设置自动填充颜色：

```c#
using (Presentation presentation = new Presentation())
{
    // 创建簇状柱形图
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // 将系列填充格式设置为自动
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series[i].GetAutomaticSeriesColor();
    }

    // 将演示文稿文件写入磁盘
    presentation.Save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
}
```

## **设置图表系列反转填充颜色**
Aspose.Slides允许您以如下方式设置图表系列内绘图区的反转填充颜色：

1. 创建 `Presentation` 类的实例。
1. 通过其索引获取幻灯片的引用。
1. 根据您首选的类型（在以下示例中，我们使用 `ChartType.ClusteredColumn`）添加具有默认数据的图表。
1. 访问图表系列并将填充颜色设置为反转。
1. 将演示文稿保存为PPTX文件。

以下C#代码演示此操作：

```c#
Color inverColor = Color.Red;
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // 添加新系列和类别
    chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "系列1"), chart.Type);
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "类别1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "类别2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "类别3"));

    // 取第一个图表系列并填充其系列数据。
    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;
    pres.Save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);               
}
```

## **当值为负时设置系列反转**
Aspose.Slides允许您通过 `IChartDataPoint.InvertIfNegative` 和 `ChartDataPoint.InvertIfNegative` 属性设置反转。当使用这些属性设置反转时，数据点在获得负值时会反转其颜色。

以下C#代码演示此操作：

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
	IChartSeriesCollection series = chart.ChartData.Series;
	chart.ChartData.Series.Clear();

	series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -2));
	series[0].DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

	series[0].InvertIfNegative = false;

	series[0].DataPoints[2].InvertIfNegative = true;

	pres.Save("out.pptx", SaveFormat.Pptx);
}
```

## **清除特定数据点的数据**
Aspose.Slides for .NET允许您以如下方式清除特定图表系列的 `DataPoints` 数据：

1. 创建 `Presentation` 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 通过其索引获取图表的引用。
4. 遍历所有图表 `DataPoints` 并将 `XValue` 和 `YValue` 设置为 null。
5. 清除特定图表系列的所有 `DataPoints`。
6. 将修改后的演示文稿写入PPTX文件。

以下C#代码演示此操作：

```c#
using (Presentation pres = new Presentation("TestChart.pptx"))
{
	ISlide sl = pres.Slides[0];

	IChart chart = (IChart)sl.Shapes[0];

	foreach (IChartDataPoint dataPoint in chart.ChartData.Series[0].DataPoints)
	{
		dataPoint.XValue.AsCell.Value = null;
		dataPoint.YValue.AsCell.Value = null;
	}

	chart.ChartData.Series[0].DataPoints.Clear();

	pres.Save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
}
```

## **设置系列间距宽度**
Aspose.Slides for .NET允许您通过 **`GapWidth`** 属性设置系列的间距宽度，如下所示：

1. 创建 `Presentation` 类的实例。
2. 访问第一张幻灯片。
3. 添加具有默认数据的图表。
4. 访问任何图表系列。
5. 设置 `GapWidth` 属性。
6. 将修改后的演示文稿写入PPTX文件。

以下C#代码演示如何设置系列的间距宽度：

```c#
// 创建空演示文稿 
Presentation presentation = new Presentation();

// 访问演示文稿的第一张幻灯片
ISlide slide = presentation.Slides[0];

// 添加具有默认数据的图表
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 0, 0, 500, 500);

// 设置图表数据表的索引
int defaultWorksheetIndex = 0;

// 获取图表数据工作表
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// 添加系列
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "系列1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "系列2"), chart.Type);

// 添加类别
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "分类1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "分类2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "分类3"));

// 取第二个图表系列
IChartSeries series = chart.ChartData.Series[1];

// 填充系列数据
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// 设置间距宽度值
series.ParentSeriesGroup.GapWidth = 50;

// 将演示文稿保存到磁盘
presentation.Save("GapWidth_out.pptx", SaveFormat.Pptx);
```
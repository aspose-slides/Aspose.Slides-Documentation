---
title: 图表格式化
type: docs
weight: 60
url: /zh/net/chart-formatting/
keywords: "图表实体, 图表属性, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中格式化 PowerPoint 演示文稿中的图表实体"
---

## **格式化图表实体**
Aspose.Slides for .NET 允许开发人员从头开始将自定义图表添加到他们的幻灯片。本文解释了如何格式化不同的图表实体，包括图表类别轴和数值轴。

Aspose.Slides for .NET 提供了一个简单的 API，用于管理不同的图表实体并使用自定义值进行格式设置：

1. 创建一个 **Presentation** 类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加具有默认数据的任意类型图表（在此示例中我们将使用 ChartType.LineWithMarkers）。
1. 访问图表的值轴并设置以下属性：
   1. 设置值轴主网格线的 **线条格式**
   1. 设置值轴次网格线的 **线条格式**
   1. 设置值轴的 **数字格式**
   1. 设置值轴的 **最小值、最大值、主要单位和次单位**
   1. 设置值轴数据的 **文本属性**
   1. 设置值轴的 **标题**
   1. 设置值轴的 **线条格式**
1. 访问图表的类别轴并设置以下属性：
   1. 设置类别轴主网格线的 **线条格式**
   1. 设置类别轴次网格线的 **线条格式**
   1. 设置类别轴数据的 **文本属性**
   1. 设置类别轴的 **标题**
   1. 设置类别轴的 **标签定位**
   1. 设置类别轴标签的 **旋转角度**
1. 访问图表的图例并设置 **文本属性**
1. 设置图表图例显示而不重叠图表
1. 访问图表的 **次值轴** 并设置以下属性：
   1. 启用次 **值轴**
   1. 设置次值轴的 **线条格式**
   1. 设置次值轴的 **数字格式**
   1. 设置次值轴的 **最小值、最大值、主要单位和次单位**
1. 现在在次值轴上绘制第一条图表系列
1. 设置图表后墙填充颜色
1. 设置图表绘图区域填充颜色
1. 将修改后的演示文稿写入 PPTX 文件

```c#
// 实例化演示文稿
Presentation pres = new Presentation();

// 访问第一个幻灯片
ISlide slide = pres.Slides[0];

// 添加示例图表
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// 设置图表标题
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "示例图表";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// 设置值轴主网格线格式
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// 设置值轴次网格线格式
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// 设置值轴数字格式
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// 设置图表最大值、最小值
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// 设置值轴文本属性
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// 设置值轴标题
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "主轴";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// 设置值轴线条格式：现已过时
// chart.Axes.VerticalAxis.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// 设置类别轴主网格线格式
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// 设置类别轴次网格线格式
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// 设置类别轴文本属性
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// 设置类别标题
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "示例类别";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// 设置类别轴标签位置
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// 设置类别轴标签旋转角度
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// 设置图例文本属性
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// 设置图表图例显示而不重叠图表

chart.Legend.Overlay = true;
            
// 在次值轴上绘制第一系列
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// 设置图表后墙颜色
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// 设置绘图区域颜色
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// 保存演示文稿
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```



## **设置图表的字体属性**
Aspose.Slides for .NET 提供了设置图表字体相关属性的支持。请遵循以下步骤为图表设置字体属性。

- 实例化 Presentation 类对象。
- 在幻灯片上添加图表。
- 设置字体高度。
- 保存修改后的演示文稿。

下面给出了示例。

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```




## **设置数字格式**
Aspose.Slides for .NET 提供了一个简单的 API 来管理图表数据格式：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 通过其索引获取幻灯片的引用。
1. 添加具有默认数据的任意类型图表（此示例使用 **ChartType.ClusteredColumn**）。
1. 从可能的预设值中设置预设数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置图表数据数字格式。
1. 保存演示文稿。
1. 设置自定义数字格式。
1. 遍历每个图表系列中的图表数据单元格并设置不同的图表数据数字格式。
1. 保存演示文稿。

```c#
// 实例化演示文稿
Presentation pres = new Presentation();

// 访问第一个演示文稿幻灯片
ISlide slide = pres.Slides[0];

// 添加默认聚类柱形图
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// 访问图表系列集合
IChartSeriesCollection series = chart.ChartData.Series;

// 设置预设数字格式
// 遍历每个图表系列
foreach (ChartSeries ser in series)
{
    // 遍历系列中的每个数据单元格
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // 设置数字格式
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// 保存演示文稿
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

可以使用的预设数字格式值及其预设索引如下：

|**0**|一般|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;红色$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;红色$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;红色-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;红色-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **设置图表区域的圆角边框**
Aspose.Slides for .NET 提供了设置图表区域的支持。**IChart.HasRoundedCorners** 和 **Chart.HasRoundedCorners** 属性已在 Aspose.Slides 中添加。

1. 实例化 `Presentation` 类对象。
1. 在幻灯片上添加图表。
1. 设置图表的填充类型和填充颜色
1. 设置圆角属性为真。
1. 保存修改后的演示文稿。

下面给出了示例。

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```
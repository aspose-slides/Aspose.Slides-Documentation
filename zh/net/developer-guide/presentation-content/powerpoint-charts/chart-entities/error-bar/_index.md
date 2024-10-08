---
title: 错误条
type: docs
url: /net/error-bar/
keywords: "错误条, 错误条值 PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中向 PowerPoint 演示文稿添加错误条"
---

## **添加错误条**
Aspose.Slides for .NET 提供了一个简单的 API 用于管理错误条值。本示例代码适用于使用自定义值类型的情况。要指定一个值，请使用特定数据点在系列的 **DataPoints** 集合中的 **ErrorBarCustomValues** 属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 在所需幻灯片上添加气泡图表。
1. 访问第一个图表系列并设置错误条 X 格式。
1. 访问第一个图表系列并设置错误条 Y 格式。
1. 设置条形值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。

```c#
// 创建空演示文稿
using (Presentation presentation = new Presentation())
{
    // 创建气泡图表
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // 添加错误条并设置其格式
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // 保存演示文稿
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```



## **添加自定义错误条值**
Aspose.Slides for .NET 提供了一个简单的 API 用于管理自定义错误条值。本示例代码适用于 **IErrorBarsFormat.ValueType** 属性等于 **Custom** 的情况。要指定一个值，请使用特定数据点在系列的 **DataPoints** 集合中的 **ErrorBarCustomValues** 属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 在所需幻灯片上添加气泡图表。
1. 访问第一个图表系列并设置错误条 X 格式。
1. 访问第一个图表系列并设置错误条 Y 格式。
1. 访问图表系列的各个数据点，并为各个系列数据点设置错误条值。
1. 设置条形值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。

```c#
// 创建空演示文稿
using (Presentation presentation = new Presentation())
{
    // 创建气泡图表
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // 添加自定义错误条并设置其格式
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // 访问图表系列数据点并为各个点设置错误条值
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // 为图表系列点设置错误条
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // 保存演示文稿
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```
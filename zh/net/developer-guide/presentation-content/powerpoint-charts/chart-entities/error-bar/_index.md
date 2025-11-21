---
title: 在 .NET 中自定义演示文稿图表的误差线
linktitle: 误差线
type: docs
url: /zh/net/error-bar/
keywords:
- 误差线
- 自定义数值
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在图表中添加和自定义误差线——优化 PowerPoint 演示文稿中的数据可视化。"
---

## **添加误差线**
Aspose.Slides for .NET 提供了用于管理误差线数值的简易 API。示例代码适用于使用自定义数值类型的情况。要指定数值，请使用系列 **DataPoints** 集合中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 在所需幻灯片上添加气泡图。
1. 访问第一个图表系列并设置误差线 X 方向格式。
1. 访问第一个图表系列并设置误差线 Y 方向格式。
1. 设置误差线的数值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。
```c#
// 创建空演示文稿
using (Presentation presentation = new Presentation())
{
    // 创建气泡图表
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // 添加误差线并设置其格式
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


## **添加自定义误差线数值**
Aspose.Slides for .NET 提供了用于管理自定义误差线数值的简易 API。当 **IErrorBarsFormat.ValueType** 属性等于 **Custom** 时，示例代码适用。要指定数值，请使用系列 **DataPoints** 集合中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 在所需幻灯片上添加气泡图。
1. 访问第一个图表系列并设置误差线 X 方向格式。
1. 访问第一个图表系列并设置误差线 Y 方向格式。
1. 访问图表系列的各个数据点并为单个系列数据点设置误差线数值。
1. 设置误差线的数值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。
```c#
 // 创建空演示文稿
 using (Presentation presentation = new Presentation())
 {
     // 创建气泡图表
     IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);
 
     // 添加自定义误差线并设置其格式
     IChartSeries series = chart.ChartData.Series[0];
     IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
     IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
     errBarX.IsVisible = true;
     errBarY.IsVisible = true;
     errBarX.ValueType = ErrorBarValueType.Custom;
     errBarY.ValueType = ErrorBarValueType.Custom;
 
     // 访问图表系列数据点并为单个点设置误差线数值
     IChartDataPointCollection points = series.DataPoints;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;
 
     // 为图表系列数据点设置误差线
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


## **常见问题**

**将演示文稿导出为 PDF 或图像时，误差线会如何？**

它们作为图表的一部分进行渲染，并在转换过程中与图表的其他格式一起保留下来，前提是使用兼容的版本或渲染器。

**误差线可以与标记和数据标签组合使用吗？**

可以。误差线是独立的元素，与标记和数据标签兼容；如果元素重叠，可能需要调整格式。

**在哪里可以找到 API 中用于处理误差线的属性和枚举列表？**

在 API 参考中：[ErrorBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarsformat/) 类以及相关枚举 [ErrorBarType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbartype/) 和 [ErrorBarValueType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarvaluetype/)。
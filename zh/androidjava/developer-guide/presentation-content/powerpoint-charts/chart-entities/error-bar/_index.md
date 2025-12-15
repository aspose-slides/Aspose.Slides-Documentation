---
title: 在 Android 上的演示文稿图表中自定义误差条
linktitle: 误差条
type: docs
url: /zh/androidjava/error-bar/
keywords:
- 误差条
- 自定义值
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 在图表中添加和自定义误差条——优化 PowerPoint 演示文稿中的数据可视化。"
---

## **添加误差线**
Aspose.Slides for Android via Java 提供了管理误差线值的简易 API。以下示例代码适用于使用自定义值类型的情况。要指定值，请使用系列的 [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection) 集合中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 在所需幻灯片上添加气泡图。
1. 访问第一条图表系列并设置误差条 X 格式。
1. 访问第一条图表系列并设置误差条 Y 格式。
1. 设置误差条的值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 创建气泡图
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // 添加误差线并设置其格式
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // 保存演示文稿
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **添加自定义误差条值**
Aspose.Slides for Android via Java 提供了管理自定义误差条值的简易 API。当 [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) 属性等于 **Custom** 时，使用以下示例代码。要指定值，请使用系列的 [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection) 集合中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 在所需幻灯片上添加气泡图。
1. 访问第一条图表系列并设置误差条 X 格式。
1. 访问第一条图表系列并设置误差条 Y 格式。
1. 访问图表系列的各个数据点，并为各个系列数据点设置误差条值。
1. 设置误差条的值和格式。
1. 将修改后的演示文稿写入 PPTX 文件。
```java
// 创建 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 创建气泡图
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // 添加自定义误差线并设置其格式
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // 访问图表系列数据点并设置误差线值
    // 单个点
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // 为图表系列点设置误差线
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // 保存演示文稿
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**将演示文稿导出为 PDF 或图像时，误差条会怎样？**

它们作为图表的一部分进行渲染，并在转换过程中与图表的其他格式一起保留，前提是使用兼容的版本或渲染器。

**误差条可以与标记和数据标签组合使用吗？**

可以。误差条是独立的元素，能够与标记和数据标签兼容；如果元素重叠，可能需要调整格式。

**在哪里可以找到 API 中用于处理误差条的属性和类列表？**

在 API 参考中：[ErrorBarsFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/errorbarsformat/) 类以及相关的 [ErrorBarType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/errorbartype/) 和 [ErrorBarValueType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/errorbarvaluetype/) 类。
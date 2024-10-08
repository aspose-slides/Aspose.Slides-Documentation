---
title: 误差线
type: docs
url: /zh/java/error-bar/
---

## **添加误差线**
Aspose.Slides for Java 提供了一个简单的 API 来管理误差线值。示例代码适用于使用自定义值类型的情况。要指定一个值，请使用 [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) 系列中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 在所需幻灯片上添加气泡图。
1. 访问第一个图表系列并设置误差线 X 格式。
1. 访问第一个图表系列并设置误差线 Y 格式。
1. 设置误差线值和格式。
1. 将修改后的演示保存为 PPTX 文件。

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

## **添加自定义误差线值**
Aspose.Slides for Java 提供了一个简单的 API 来管理自定义误差线值。示例代码适用于 [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/java/com.aspose.slides/IErrorBarsFormat#getValue--) 属性等于 **Custom** 的情况。要指定一个值，请使用 [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) 系列中特定数据点的 **ErrorBarCustomValues** 属性：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
1. 在所需幻灯片上添加气泡图。
1. 访问第一个图表系列并设置误差线 X 格式。
1. 访问第一个图表系列并设置误差线 Y 格式。
1. 访问图表系列的单个数据点并为单个系列数据点设置误差线值。
1. 设置误差线值和格式。
1. 将修改后的演示保存为 PPTX 文件。

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

    // 访问图表系列数据点并为单个点设置误差线值
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
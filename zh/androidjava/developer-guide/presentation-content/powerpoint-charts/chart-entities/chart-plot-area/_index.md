---
title: 图表绘图区域
type: docs
url: /zh/androidjava/chart-plot-area/
---


## **获取图表绘图区域的宽度和高度**
Aspose.Slides for Android via Java 提供了一个简单的 API。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加带有默认数据的图表。
1. 在获取实际值之前调用方法 [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--)。
1. 获取图表元素相对于图表左上角的实际 X 位置（左）。
1. 获取图表元素相对于图表左上角的实际顶部位置。
1. 获取图表元素的实际宽度。
1. 获取图表元素的实际高度。

```java
// 创建一个 Presentation 类的实例
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置图表绘图区域的布局模式**
Aspose.Slides for Android via Java 提供了一个简单的 API 来设置图表绘图区域的布局模式。方法 [**setLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) 和 [**getLayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) 已添加到 [**ChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ChartPlotArea) 类和 [**IChartPlotArea**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartPlotArea) 接口。如果绘图区域的布局是手动定义的，则该属性指示是根据其内部（不包括轴和轴标签）还是外部（包括轴和轴标签）来布局绘图区域。存在两种可能的值，这在 [**LayoutTargetType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType) 枚举中定义。

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Inner) - 指定绘图区域的大小应确定绘图区域的大小，不包括刻度标记和轴标签。
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LayoutTargetType#Outer) - 指定绘图区域的大小应确定绘图区域的大小、刻度标记和轴标签。

下面是示例代码。

```java
// 创建一个 Presentation 类的实例
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
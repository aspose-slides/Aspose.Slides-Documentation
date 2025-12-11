---
title: 在 Android 上优化演示文稿的图表计算
linktitle: 图表计算
type: docs
weight: 50
url: /zh/androidjava/chart-calculations/
keywords:
- 图表计算
- 图表元素
- 元素位置
- 实际位置
- 子元素
- 父元素
- 图表数值
- 实际数值
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解在 Android 上的 Aspose.Slides 中图表计算、数据更新和精度控制，适用于 PPT 和 PPTX，并提供实用的 Java 代码示例。"
---

## **计算图表元素的实际值**
Aspose.Slides for Android via Java 提供了一个简单的 API 来获取这些属性。[IAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis) 接口的属性提供有关轴图表元素实际位置的信息（[IAxis.getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMaxValue--)、[IAxis.getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinValue--)、[IAxis.getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnit--)、[IAxis.getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnit--)、[IAxis.getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMajorUnitScale--)、[IAxis.getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAxis#getActualMinorUnitScale--)）。需要先调用方法 [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) 来填充属性的实际值。
```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    
    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    
    double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) pres.dispose();
}
```


## **计算父图表元素的实际位置**
Aspose.Slides for Android via Java 提供了一个简单的 API 来获取这些属性。Properties of [IActualLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout) interface provide information about actual position of parent chart element ([IActualLayout.getActualX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualX--), [IActualLayout.getActualY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualY--), [IActualLayout.getActualWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualWidth--), [IActualLayout.getActualHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IActualLayout#getActualHeight--)). It is necessary to call method [IChart.validateChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChart#validateChartLayout--) previously to fill properties with actual values.
```java
Presentation pres = new Presentation();
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```


## **隐藏图表元素**
本主题帮助您了解如何隐藏图表中的信息。使用 Aspose.Slides for Android via Java，您可以隐藏图表中的 **标题、垂直轴、水平轴** 和 **网格线**。下面的代码示例展示了如何使用这些属性。
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //隐藏图表标题
    chart.setTitle(false);

    ///隐藏数值轴
    chart.getAxes().getVerticalAxis().setVisible(false);

    //类别轴可见性
    chart.getAxes().getHorizontalAxis().setVisible(false);

    //隐藏图例
    chart.setLegend(false);

    //隐藏主网格线
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().removeAt(i);
    }

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getMarker().setSymbol(MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);

    //Setting series line color
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid);

    pres.save("HideInformationFromChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**外部 Excel 工作簿可以作为数据源吗？这会如何影响重新计算？**

是的。图表可以引用外部工作簿：当您连接或刷新外部源时，公式和数值会从该工作簿中获取，图表在打开/编辑操作期间会实时反映更新。API 允许您 [指定外部工作簿](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-) 路径并管理链接的数据。

**我可以在不自行实现回归的情况下计算和显示趋势线吗？**

是的。[趋势线](/slides/zh/androidjava/trend-line/)（线性、指数等）由 Aspose.Slides 添加并自动更新；其参数会根据系列数据自动重新计算，您无需自行实现计算。

**如果演示文稿中有多个带有外部链接的图表，我能控制每个图表使用哪个工作簿进行计算吗？**

是的。每个图表都可以指向其自己的 [外部工作簿](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setExternalWorkbook-java.lang.String-boolean-)，或者您可以为每个图表独立创建/替换外部工作簿，而不影响其他图表。
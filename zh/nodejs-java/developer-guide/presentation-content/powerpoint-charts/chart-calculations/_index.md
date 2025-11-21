---
title: 图表计算
type: docs
weight: 50
url: /zh/nodejs-java/chart-calculations/
---

## **计算图表元素的实际值**

Aspose.Slides for Node.js via Java 提供了一个简单的 API 用于获取这些属性。[Axis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis) 类的属性提供了轴图表元素实际位置的信息（[Axis.getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMaxValue--)、[Axis.getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinValue--)、[Axis.getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnit--)、[Axis.getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnit--)、[Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--)、[Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)。需要先调用方法[Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--)来填充属性的实际值。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **计算父图表元素的实际位置**

Aspose.Slides for Node.js via Java 提供了一个简单的 API 用于获取这些属性。[ActualLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout) 类的属性提供了父图表元素实际位置的信息（[ActualLayout.getActualX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualX--)、[ActualLayout.getActualY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualY--)、[ActualLayout.getActualWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualWidth--)、[ActualLayout.getActualHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualHeight--)）。需要先调用方法[Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--)来填充属性的实际值。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **隐藏图表信息**

本主题帮助您了解如何隐藏图表中的信息。使用 Aspose.Slides for Node.js via Java，您可以隐藏 **标题, 垂直轴, 水平轴** 和 **网格线**。下面的代码示例展示了如何使用这些属性。
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // 隐藏图表标题
    chart.setTitle(false);
    // /隐藏数值轴
    chart.getAxes().getVerticalAxis().setVisible(false);
    // 类别轴可见性
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // 隐藏图例
    chart.setLegend(false);
    // 隐藏主网格线
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // 设置系列线颜色
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**外部 Excel 工作簿可以作为数据源吗？这会如何影响重新计算？**

是的。图表可以引用外部工作簿：当您连接或刷新外部源时，公式和数值会从该工作簿中获取，图表在打开/编辑操作期间会反映更新。API 允许您[指定外部工作簿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/)路径并管理链接的数据。

**我可以在不自行实现回归的情况下计算并显示趋势线吗？**

是的。[趋势线](/slides/zh/nodejs-java/trend-line/)（线性、指数等）由 Aspose.Slides 添加和更新；其参数会根据系列数据自动重新计算，您无需自行实现计算。

**如果演示文稿中有多个带外部链接的图表，我可以控制每个图表使用哪本工作簿进行计算吗？**

是的。每个图表可以指向其自己的[外部工作簿](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/)，或者您可以为每个图表独立创建/替换外部工作簿，而不影响其他图表。
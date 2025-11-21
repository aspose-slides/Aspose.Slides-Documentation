---
title: 图表绘图区
type: docs
url: /zh/nodejs-java/chart-plot-area/
---

## **获取图表绘图区的宽度和高度**

Aspose.Slides for Node.js via Java 提供了一个简单的 API 用于 .

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 使用默认数据添加图表。
1. 在获取实际值之前调用方法 [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--)。
1. 获取图表元素相对于图表左上角的实际 X 位置（左）。
1. 获取图表元素相对于图表左上角的实际顶部位置。
1. 获取图表元素的实际宽度。
1. 获取图表元素的实际高度。
```javascript
// 创建 Presentation 类的实例
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


## **设置图表绘图区的布局模式**

Aspose.Slides for Node.js via Java 提供了一个简单的 API 来设置图表绘图区的布局模式。已在 [**ChartPlotArea**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea) 类中添加了方法 [**setLayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) 和 [**getLayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--)。如果绘图区的布局是手动定义的，此属性指定是按内部（不包括坐标轴和坐标轴标签）还是外部（包括坐标轴和坐标轴标签）进行布局。共有两个可能的值，定义在 [**LayoutTargetType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType) 枚举中。

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType#Inner) - 指定绘图区的大小由绘图区的尺寸决定，不包括刻度线和坐标轴标签。
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LayoutTargetType#Outer) - 指定绘图区的大小由绘图区的尺寸、刻度线和坐标轴标签决定。

示例代码如下。
```javascript
// 创建 Presentation 类的实例
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**实际 X、实际 Y、实际宽度和实际高度以什么单位返回？**

以点为单位；1 英寸 = 72 点。这些是 Aspose.Slides 的坐标单位。

**绘图区在内容上与图表区域有何不同？**

绘图区是数据绘制区域（系列、网格线、趋势线等）；图表区域包括周围的元素（标题、图例等）。在 3D 图表中，绘图区还包括墙/地板和坐标轴。

**当布局为手动时，绘图区的 X、Y、宽度和高度如何解释？**

它们是图表整体尺寸的比例（0–1）；在此模式下，自动定位被禁用，使用您设置的比例值。

**为什么在添加/移动图例后绘图区的位置会变化？**

图例位于图表区域的绘图区之外，但会影响布局和可用空间，因此在自动定位生效时绘图区可能会移动。（这是 PowerPoint 图表的标准行为。）
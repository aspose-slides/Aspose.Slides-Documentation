---
title: 气泡图
type: docs
url: /zh/nodejs-java/bubble-chart/
---

## **Bubble Chart Size Scaling**
Aspose.Slides for Node.js via Java 提供对气泡图大小缩放的支持。在 Aspose.Slides for Node.js via Java 中已添加了[**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--)、[**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--)和[**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-)方法。下面给出示例代码。  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Represent Data as Bubble Chart Sizes**
已在[ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeries)、[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup)类及相关类中添加了方法[**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-)和[**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--)。**BubbleSizeRepresentation** 指定气泡图中气泡大小值的表示方式。可能的取值包括：[**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area)和[**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width)。因此，已添加[**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BubbleSizeRepresentationType)枚举以指定将数据表示为气泡图大小的可能方式。下面给出示例代码。  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Is a "bubble chart with 3-D effect" supported, and how does it differ from a regular one?**  
是的。存在一种单独的图表类型 “Bubble with 3-D”。它对气泡进行 3D 样式化，但不会添加额外的坐标轴；数据仍保持 X‑Y‑S（大小）形式。该类型可在[chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)枚举中找到。

**Is there a limit on the number of series and points in a bubble chart?**  
在 API 层面没有硬性限制；受性能和目标 PowerPoint 版本的约束。建议将数据点数量保持在合理范围，以便于阅读和渲染速度。

**How will export affect the appearance of a bubble chart (PDF, images)?**  
导出到受支持的格式会保留图表外观，渲染由 Aspose.Slides 引擎完成。对于栅格或矢量格式，遵循通用的图表渲染规则（分辨率、抗锯齿），因此请为打印选择足够的 DPI。
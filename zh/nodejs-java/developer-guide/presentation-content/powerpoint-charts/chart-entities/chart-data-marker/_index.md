---
title: 图表数据标记
type: docs
url: /zh/nodejs-java/chart-data-marker/
---

## **设置图表标记选项**

可以在特定系列的图表数据点上设置标记。要设置图表标记选项，请按照以下步骤操作：

- 实例化[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类。
- 创建默认图表。
- 设置图片。
- 获取第一个图表系列。
- 添加新数据点。
- 将演示文稿写入磁盘。

在下面的示例中，我们已在数据点级别设置图表标记选项。
```javascript
// 创建空演示文稿
var pres = new aspose.slides.Presentation();
try {
    // 访问第一张幻灯片
    var slide = pres.getSlides().get_Item(0);
    // 创建默认图表
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // 获取默认图表数据工作表索引
    var defaultWorksheetIndex = 0;
    // 获取图表数据工作表
    var fact = chart.getChartData().getChartDataWorkbook();
    // 删除示例系列
    chart.getChartData().getSeries().clear();
    // 添加新系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // 加载图片 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // 加载图片 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // 获取第一个图表系列
    var series = chart.getChartData().getSeries().get_Item(0);
    // 在此处添加新数据点 (1:3)。
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // 更改图表系列标记
    series.getMarker().setSize(15);
    // 保存带图表的演示文稿
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**有哪些标记形状是开箱即用的？**

提供标准形状（圆形、方形、菱形、三角形等）；这些形状的列表由[MarkerStyleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markerstyletype/)枚举定义。如果需要非标准形状，请使用带图片填充的标记来模拟自定义视觉效果。

**在将图表导出为图像或 SVG 时，标记会被保留吗？**

是的。在将图表渲染为[raster formats](/slides/zh/nodejs-java/convert-powerpoint-to-png/)或保存为[shapes as SVG](/slides/zh/nodejs-java/render-a-slide-as-an-svg-image/)时，标记会保留其外观和设置，包括大小、填充和轮廓。
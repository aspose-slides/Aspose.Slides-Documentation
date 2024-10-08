---
title: 图表数据标记
type: docs
url: /java/chart-data-marker/
---

## **设置图表标记选项**
可以在特定系列的图表数据点上设置标记。为了设置图表标记选项，请按照以下步骤操作：

- 实例化 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类。
- 创建默认图表。
- 设置图片。
- 取第一个图表系列。
- 添加新数据点。
- 将演示文稿写入磁盘。

在下面给出的示例中，我们在数据点级别设置了图表标记选项。

```java
// 创建空的演示文稿
Presentation pres = new Presentation();
try {
    // 访问第一个幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 创建默认图表
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // 获取默认图表数据工作表索引
    int defaultWorksheetIndex = 0;
    
    // 获取图表数据工作表
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // 删除演示系列
    chart.getChartData().getSeries().clear();
    
    // 添加新系列
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "系列 1"), chart.getType());

    // 加载图片 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // 加载图片 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // 取第一个图表系列
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // 在此添加新点 (1:3)
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // 改变图表系列标记
    series.getMarker().setSize(15);
    
    // 保存带有图表的演示文稿
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
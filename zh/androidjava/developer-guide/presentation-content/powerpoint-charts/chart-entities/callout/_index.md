---
title: 在 Android 上管理演示文稿图表中的标注
linktitle: 标注
type: docs
url: /zh/androidjava/callout/
keywords:
- 图表标注
- 使用标注
- 数据标签
- 标签格式
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用简洁的 Java 示例代码在 Aspose.Slides for Android 中创建和设置标注，兼容 PPT 和 PPTX，以实现演示文稿工作流的自动化。"
---

## **使用标注**
已向 [DataLabelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datalabelformat) 类和 [IDataLabelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat) 接口添加了新方法 [**getShowLabelAsDataCallout()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDataLabelFormat#getShowLabelAsDataCallout--) 和 [**setShowLabelAsDataCallout()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDataLabelFormat#setShowLabelAsDataCallout-boolean-)。这些方法决定指定图表的数据标签是以数据标注的形式显示还是以数据标签的形式显示。
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 500, 400);
    
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowLabelAsDataCallout(true);
    chart.getChartData().getSeries().get_Item(0).getLabels().get_Item(2).getDataLabelFormat().setShowLabelAsDataCallout(false);
    
    pres.save("DisplayCharts.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **为环形图设置标注**
Aspose.Slides for Android via Java 提供对环形图系列数据标签标注形状的设置支持。以下示例代码给出。 
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Doughnut, 10, 10, 500, 500, false);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(false);
    int seriesIndex = 0;
    while (seriesIndex < 15)
    {
        IChartSeries series = chart.getChartData().getSeries().add(workBook.getCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.getType());
        series.setExplosion(0);
        series.getParentSeriesGroup().setDoughnutHoleSize((byte)20);
        series.getParentSeriesGroup().setFirstSliceAngle(351);
        seriesIndex++;
    }
    int categoryIndex = 0;
    while (categoryIndex < 15)
    {
        chart.getChartData().getCategories().add(workBook.getCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
        int i = 0;
        while (i < chart.getChartData().getSeries().size())
        {
            IChartSeries iCS = chart.getChartData().getSeries().get_Item(i);
            IChartDataPoint dataPoint = iCS.getDataPoints().addDataPointForDoughnutSeries(workBook.getCell(0, categoryIndex + 1, i + 1, 1));
            dataPoint.getFormat().getFill().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
            dataPoint.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
            dataPoint.getFormat().getLine().setWidth(1);
            dataPoint.getFormat().getLine().setStyle(LineStyle.Single);
            dataPoint.getFormat().getLine().setDashStyle(LineDashStyle.Solid);
            if (i == chart.getChartData().getSeries().size() - 1)
            {
                IDataLabel lbl = dataPoint.getLabel();
                lbl.getTextFormat().getTextBlockFormat().setAutofitType(TextAutofitType.Shape);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setLatinFont(new FontData("DINPro-Bold"));
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                lbl.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.LIGHT_GRAY);
                lbl.getDataLabelFormat().getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.awt.Color.WHITE);
                lbl.getDataLabelFormat().setShowValue(false);
                lbl.getDataLabelFormat().setShowCategoryName(true);
                lbl.getDataLabelFormat().setShowSeriesName(false);
                lbl.getDataLabelFormat().setShowLeaderLines(true);
                lbl.getDataLabelFormat().setShowLabelAsDataCallout(false);
                chart.validateChartLayout();
                lbl.setX((float) lbl.getX()+ (float)0.5);
                lbl.setY((float)lbl.getY()+ (float)0.5);
            }
            i++;
        }
        categoryIndex++;
    }
    pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**Are callouts preserved when converting a presentation to PDF, HTML5, SVG, or images?**

是的。标注是图表渲染的一部分，因此在导出为 [PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/)、[HTML5](/slides/zh/androidjava/export-to-html5/)、[SVG](/slides/zh/androidjava/render-a-slide-as-an-svg-image/) 或 [栅格图像](/slides/zh/androidjava/convert-powerpoint-to-png/) 时，它们会与幻灯片的格式一起被保留。

**Do custom fonts work in callouts, and can their appearance be preserved on export?**

是的。Aspose.Slides 支持将[嵌入字体](/slides/zh/androidjava/embedded-font/)嵌入到演示文稿中，并在导出为如 [PDF](/slides/zh/androidjava/convert-powerpoint-to-pdf/) 等格式时控制字体嵌入，确保标注在不同系统上保持相同的外观。
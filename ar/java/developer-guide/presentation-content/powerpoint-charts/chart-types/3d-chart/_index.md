---
title: رسم بياني ثلاثي الأبعاد
type: docs
url: /java/3d-chart/
---

## **تعيين خصائص RotationX وRotationY وDepthPercents للرسم البياني ثلاثي الأبعاد**
يوفر Aspose.Slides لJava واجهة برمجة تطبيقات بسيطة لتعيين هذه الخصائص. ستساعدك هذه المقالة في كيفية تعيين خصائص مختلفة مثل **دواران X وY ، ونسب العمق** وما إلى ذلك. يقوم الكود المصدري بتطبيق تعيين الخصائص المذكورة أعلاه.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 
1. الوصول إلى الشريحة الأولى.
1. إضافة رسم بياني ببيانات افتراضية.
1. تعيين خصائص Rotation3D.
1. كتابة العرض المعدل إلى ملف PPTX.

```java
Presentation pres = new Presentation();
try {
    // Access first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Add chart with default data
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Setting the index of chart data sheet
    int defaultWorksheetIndex = 0;
    
    // Getting the chart data worksheet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Add series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Add Catrgories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Set Rotation3D properties
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Take second chart series
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Now populating series data
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Set OverLap value
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Write presentation to disk
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
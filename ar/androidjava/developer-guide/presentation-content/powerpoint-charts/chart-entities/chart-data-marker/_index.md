---
title: خيارات علامة البيانات في الرسم البياني
type: docs
url: /ar/androidjava/chart-data-marker/
---

## **تعيين خيارات علامة الرسم البياني**
يمكن تعيين العلامات على نقاط بيانات الرسم البياني داخل سلسلة معينة. من أجل تعيين خيارات علامة الرسم البياني، يرجى اتباع الخطوات أدناه:

- إنشاء فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- إنشاء الرسم البياني الافتراضي.
- تعيين الصورة.
- أخذ أول سلسلة رسم بياني.
- إضافة نقطة بيانات جديدة.
- كتابة العرض التقديمي إلى القرص.

في المثال المعطى أدناه، قمنا بتعيين خيارات علامة الرسم البياني على مستوى نقاط البيانات.

```java
// إنشاء عرض تقديمي فارغ
Presentation pres = new Presentation();
try {
    // الوصول الى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إنشاء الرسم البياني الافتراضي
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // الحصول على فهرس ورقة العمل الافتراضية لبيانات الرسم البياني
    int defaultWorksheetIndex = 0;
    
    // الحصول على ورقة العمل الخاصة ببيانات الرسم البياني
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // حذف السلاسل التجريبية
    chart.getChartData().getSeries().clear();
    
    // إضافة سلسلة جديدة
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // تحميل الصورة 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // تحميل الصورة 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // أخذ أول سلسلة رسم بياني
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // إضافة نقطة جديدة (1:3) هناك.
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
    
    // تغيير علامة سلسلة الرسم البياني
    series.getMarker().setSize(15);
    
    // حفظ العرض التقديمي مع الرسم البياني
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
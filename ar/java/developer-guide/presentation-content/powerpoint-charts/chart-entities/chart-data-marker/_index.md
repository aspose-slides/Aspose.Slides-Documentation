---
title: إدارة علامات بيانات المخطط في العروض التقديمية باستخدام Java
linktitle: علامة البيانات
type: docs
url: /ar/java/chart-data-marker/
keywords:
- مخطط
- نقطة بيانات
- علامة
- خيارات العلامة
- حجم العلامة
- نوع التعبئة
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية تخصيص علامات بيانات المخطط في Aspose.Slides للغة Java، مما يعزز تأثير العرض التقديمي عبر صيغ PPT و PPTX مع أمثلة واضحة على شفرة Java."
---

## **ضبط خيارات علامة الرسم البياني**
يمكن تعيين العلامات على نقاط بيانات الرسم البياني داخل سلاسل معينة. من أجل ضبط خيارات علامة الرسم البياني. يرجى اتباع الخطوات أدناه:

- إنشاء كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
- إنشاء الرسم البياني الافتراضي.
- تعيين الصورة.
- أخذ أول سلسلة في الرسم البياني.
- إضافة نقطة بيانات جديدة.
- كتابة العرض التقديمي إلى القرص.

في المثال المعطى أدناه، قمنا بضبط خيارات علامة الرسم البياني على مستوى نقاط البيانات.
```java
// إنشاء عرض تقديمي فارغ
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إنشاء المخطط الافتراضي
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // الحصول على فهرس ورقة عمل بيانات المخطط الافتراضية
    int defaultWorksheetIndex = 0;
    
    // الحصول على ورقة عمل بيانات المخطط
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // حذف سلسلة العرض التجريبية
    chart.getChartData().getSeries().clear();
    
    // إضافة سلسلة جديدة
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // تحميل الصورة 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // تحميل الصورة 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // أخذ أول سلسلة مخطط
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
    
    // تغيير علامة سلسلة المخطط
    series.getMarker().setSize(15);
    
    // حفظ العرض التقديمي مع المخطط
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**ما الأشكال المتاحة للعلامات بشكل افتراضي؟**

الأشكال القياسية متاحة (دائرة، مربع، ماسة، مثلث، إلخ)؛ القائمة معرفة بواسطة فئة [MarkerStyleType](https://reference.aspose.com/slides/java/com.aspose.slides/markerstyletype/) . إذا كنت بحاجة إلى شكل غير قياسي، استخدم علامة مع تعبئة صورة لمحاكاة المرئيات المخصصة.

**هل تُحافظ العلامات على وجودها عند تصدير الرسم البياني إلى صورة أو SVG؟**

نعم. عند تصيير الرسوم البيانية إلى [raster formats](/slides/ar/java/convert-powerpoint-to-png/) أو حفظ [shapes as SVG](/slides/ar/java/render-a-slide-as-an-svg-image/)، تحتفظ العلامات بمظهرها وإعداداتها، بما في ذلك الحجم، التعبئة، والحدود.
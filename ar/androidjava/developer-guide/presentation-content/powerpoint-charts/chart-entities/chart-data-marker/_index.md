---
title: إدارة علامات بيانات المخطط في العروض التقديمية على Android
linktitle: علامة البيانات
type: docs
url: /ar/androidjava/chart-data-marker/
keywords:
- مخطط
- نقطة بيانات
- علامة
- خيارات العلامة
- حجم العلامة
- نوع التعبئة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تخصيص علامات بيانات المخطط في Aspose.Slides لنظام Android، تعزيز تأثير العروض التقديمية عبر صيغ PPT و PPTX مع أمثلة واضحة لكود Java."
---

## **ضبط خيارات علامة المخطط**
يمكن ضبط العلامات على نقاط بيانات المخطط داخل السلاسل المحددة. لضبط خيارات علامة المخطط، يرجى اتباع الخطوات التالية:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- إنشاء المخطط الافتراضي.
- تعيين الصورة.
- أخذ أول سلسلة في المخطط.
- إضافة نقطة بيانات جديدة.
- كتابة العرض إلى القرص.

في المثال المذكور أدناه، قمنا بضبط خيارات علامة المخطط على مستوى نقاط البيانات.
```java
    // إنشاء عرض تقديمي فارغ
    Presentation pres = new Presentation();
    try {
        // الوصول إلى الشريحة الأولى
        ISlide slide = pres.getSlides().get_Item(0);
    
        // إنشاء المخطط الافتراضي
        IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
        // الحصول على فهرس ورقة العمل الافتراضية لبيانات المخطط
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
    
        // أخذ السلسلة الأولى للمخطط
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

**ما هي أشكال العلامات المتوفرة مباشرة؟**

الأشكال القياسية متوفرة (دائرة، مربع، ماسي، مثلث، إلخ)؛ وتُعرف القائمة عبر الفئة [MarkerStyleType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/markerstyletype/). إذا كنت بحاجة إلى شكل غير قياسي، استخدم علامة مع تعبئة بصورة لمحاكاة رسومات مخصصة.

**هل تُحافظ العلامات عند تصدير المخطط إلى صورة أو SVG؟**

نعم. عند تصيير المخططات إلى [raster formats](/slides/ar/androidjava/convert-powerpoint-to-png/) أو حفظ [shapes as SVG](/slides/ar/androidjava/render-a-slide-as-an-svg-image/)، تحتفظ العلامات بمظهرها وإعداداتها، بما في ذلك الحجم، التعبئة، والحدود.
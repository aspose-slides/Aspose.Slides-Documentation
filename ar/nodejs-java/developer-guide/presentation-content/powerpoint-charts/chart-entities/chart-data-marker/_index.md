---
title: علامة بيانات المخطط
type: docs
url: /ar/nodejs-java/chart-data-marker/
---

## **تعيين خيارات علامات المخطط**

يمكن تعيين العلامات على نقاط بيانات المخطط داخل السلاسل المعينة. لإعداد خيارات علامات المخطط، يرجى اتباع الخطوات التالية:

- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- إنشاء المخطط الافتراضي.
- تعيين الصورة.
- أخذ السلسلة الأولى من المخطط.
- إضافة نقطة بيانات جديدة.
- كتابة العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتعيين خيارات علامات المخطط على مستوى نقاط البيانات.
```javascript
// إنشاء عرض تقديمي فارغ
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إنشاء المخطط الافتراضي
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // الحصول على فهرس ورقة عمل بيانات المخطط الافتراضية
    var defaultWorksheetIndex = 0;
    // الحصول على ورقة عمل بيانات المخطط
    var fact = chart.getChartData().getChartDataWorkbook();
    // حذف السلسلة التجريبية
    chart.getChartData().getSeries().clear();
    // إضافة سلسلة جديدة
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // تحميل الصورة 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // تحميل الصورة 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // أخذ السلسلة الأولى للمخطط
    var series = chart.getChartData().getSeries().get_Item(0);
    // إضافة نقطة جديدة (1:3) هناك.
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
    // تغيير علامة سلسلة المخطط
    series.getMarker().setSize(15);
    // حفظ العرض التقديمي مع المخطط
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**ما هي أشكال العلامات المتاحة مباشرةً؟**

الأشكال القياسية متاحة (دائرة، مربع، ماسة، مثلث، إلخ)؛ يتم تعريف القائمة بواسطة تعداد [MarkerStyleType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/markerstyletype/). إذا كنت بحاجة إلى شكل غير قياسي، استخدم علامة بملء صورة لمحاكاة رسومات مخصصة.

**هل تُحفظ العلامات عند تصدير المخطط إلى صورة أو SVG؟**

نعم. عند تصيير المخططات إلى [raster formats](/slides/ar/nodejs-java/convert-powerpoint-to-png/) أو حفظ [shapes as SVG](/slides/ar/nodejs-java/render-a-slide-as-an-svg-image/)، تحتفظ العلامات بمظهرها وإعداداتها، بما في ذلك الحجم والملء والحد الخارجي.
---
title: مخطط ثلاثي الأبعاد
type: docs
url: /ar/nodejs-java/3d-chart/
---

## **ضبط خصائص RotationX و RotationY و DepthPercents لرسمة بيانية ثلاثية الأبعاد**

توفر Aspose.Slides for Node.js عبر Java واجهة برمجة تطبيقات بسيطة لضبط هذه الخصائص. سيساعدك المقال التالي على كيفية ضبط خصائص مختلفة مثل **X,Y Rotation، DepthPercents** وغيرها. يوضح الكود النموذجي كيفية تعيين الخصائص المذكورة أعلاه.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. الوصول إلى الشريحة الأولى.
1. إضافة رسم بياني ببيانات افتراضية.
1. ضبط خصائص Rotation3D.
1. كتابة العرض المعدل إلى ملف PPTX.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى
    var slide = pres.getSlides().get_Item(0);
    // إضافة مخطط ببيانات افتراضية
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // تحديد فهرس ورقة بيانات المخطط
    var defaultWorksheetIndex = 0;
    // جلب ورقة عمل بيانات المخطط
    var fact = chart.getChartData().getChartDataWorkbook();
    // إضافة سلسلة
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // إضافة فئات
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // ضبط خصائص Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // أخذ السلسلة الثانية للمخطط
    var series = chart.getChartData().getSeries().get_Item(1);
    // الآن يتم تعبئة بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // تعيين قيمة OverLap
    series.getParentSeriesGroup().setOverlap(100);
    // كتابة العرض التقديمي إلى القرص
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**ما أنواع الرسوم البيانية التي تدعم وضع 3D في Aspose.Slides؟**

تدعم Aspose.Slides المتغيرات ثلاثية الأبعاد من الرسوم العمودية، بما في ذلك Column 3D و Clustered Column 3D و Stacked Column 3D و 100% Stacked Column 3D، إلى جانب الأنواع الثلاثية الأبعاد ذات الصلة التي يتم كشفها من خلال تعداد [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). للحصول على قائمة دقيقة ومحدثة، راجع أعضاء [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) في مرجع API للإصدار المثبت لديك.

**هل يمكن الحصول على صورة نقطية (raster) لرسمة بيانية ثلاثية الأبعاد لتضمينها في تقرير أو على الويب؟**

نعم. يمكنك تصدير الرسم البياني إلى صورة عبر [chart API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) أو [تحويل الشريحة بالكامل](/slides/ar/nodejs-java/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة دقيقة بالبيكسل أو تريد تضمين الرسم البياني في مستندات أو لوحات معلومات أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى كفاءة بناء وعرض الرسوم البيانية الثلاثية الكبيرة؟**

تعتمد الكفاءة على حجم البيانات وتعقيد العرض البصري. للحصول على أفضل النتائج، حافظ على الحد الأدنى من تأثيرات 3D، وتجنب القوام الثقيل على الجدران ومناطق الرسم، قلل عدد نقاط البيانات لكل سلسلة عندما يكون ذلك ممكناً، وقم بالعرض على حجم إخراج مناسب (الدقة والأبعاد) ليتطابق مع شاشة العرض أو متطلبات الطباعة.
---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية باستخدام Java
linktitle: مخطط ثلاثي الأبعاد
type: docs
url: /ar/java/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- دوران
- عمق
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعرّف على كيفية إنشاء وتخصيص المخططات ثلاثية الأبعاد في Aspose.Slides لـ Java، مع دعم ملفات PPT و PPTX—عزّز عروضك التقديمية اليوم."
---

## **ضبط خصائص RotationX و RotationY و DepthPercents للمخطط ثلاثي الأبعاد**
توفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة لضبط هذه الخصائص. سيساعدك المقال التالي على كيفية ضبط خصائص مختلفة مثل **X,Y Rotation, DepthPercents** وغيرها. يطبق نموذج الشيفرة ضبط الخصائص المذكورة أعلاه.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. ضبط خصائص Rotation3D.
5. كتابة العرض التقديمي المعدل إلى ملف PPTX.
```java
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة مخطط ببيانات افتراضية
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // تعيين فهرس ورقة بيانات المخطط
    int defaultWorksheetIndex = 0;
    
    // الحصول على ورقة عمل بيانات المخطط
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // إضافة سلسلة
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // إضافة الفئات
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // ضبط خصائص Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // أخذ سلسلة المخطط الثانية
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // الآن يتم تعبئة بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // تعيين قيمة OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // حفظ العرض التقديمي إلى القرص
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**ما أنواع المخططات التي تدعم وضع ثلاثي الأبعاد في Aspose.Slides؟**

يدعم Aspose.Slides المتغيرات ثلاثية الأبعاد للمخططات العمودية، بما في ذلك Column 3D و Clustered Column 3D و Stacked Column 3D و 100% Stacked Column 3D، إلى جانب الأنواع الثلاثية الأبعاد ذات الصلة التي تُعرض عبر فئة [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). للحصول على قائمة دقيقة ومحدثة، تحقق من أعضاء فئة [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) في مرجع API للإصدار المثبت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقارير أو الويب؟**

نعم. يمكنك تصدير المخطط إلى صورة عبر [chart API](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) أو [render the entire slide](/slides/ar/java/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة دقيقة بكسل أو تريد تضمين المخطط في مستندات أو لوحات معلومات أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى أداء بناء وعرض المخططات ثلاثية الأبعاد الكبيرة؟**

يعتمد الأداء على حجم البيانات وتعقيد الصورة البصرية. للحصول على أفضل النتائج، حافظ على الحد الأدنى من التأثيرات ثلاثية الأبعاد، وتجنب القوام الثقيلة على الجدران ومناطق الرسم، وقلل عدد نقاط البيانات لكل سلسلة عندما يكون ذلك ممكنًا، وقم بالتصيير إلى حجم إخراج مناسب (الدقة والأبعاد) ليتطابق مع عرض الشاشة المستهدف أو احتياجات الطباعة.
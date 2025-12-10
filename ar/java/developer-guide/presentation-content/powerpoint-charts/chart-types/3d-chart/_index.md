---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية باستخدام Java
linktitle: مخطط ثلاثي الأبعاد
type: docs
url: /ar/java/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- تدوير
- عمق
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إنشاء وتخصيص المخططات ثلاثية الأبعاد في Aspose.Slides for Java، مع دعم ملفات PPT و PPTX—حسّن عروضك التقديمية اليوم."
---

## **تعيين خصائص RotationX و RotationY و DepthPercents لمخطط ثلاثي الأبعاد**
توفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة لتعيين هذه الخصائص. ستساعدك المقالة التالية على كيفية ضبط خصائص مختلفة مثل **X,Y Rotation, DepthPercents** وغيرها. يطبق الكود النموذجي ضبط الخصائص المذكورة أعلاه.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط بالبيانات الافتراضية.
1. تعيين خصائص Rotation3D.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.
```java
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة مخطط بالبيانات الافتراضية
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // تحديد فهرس ورقة بيانات المخطط
    int defaultWorksheetIndex = 0;
    
    // جلب ورقة عمل بيانات المخطط
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // إضافة سلسلة
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // إضافة فئات
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // تعيين خصائص Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // أخذ السلسلة الثانية للمخطط
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // الآن يتم ملء بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // تعيين قيمة OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // كتابة العرض التقديمي إلى القرص
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**ما أنواع المخططات التي تدعم وضع 3D في Aspose.Slides؟**

يدعم Aspose.Slides إصدارات ثلاثية الأبعاد من مخططات الأعمدة، بما في ذلك Column 3D وClustered Column 3D وStacked Column 3D و100% Stacked Column 3D، إلى جانب الأنواع الثلاثية الأبعاد المرتبطة التي يتم الكشف عنها عبر فئة [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). للحصول على قائمة دقيقة ومحدثة، تحقق من أعضاء [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) في وثائق واجهة برمجة التطبيقات للإصدار المثبت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة عبر [chart API](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage-int-float-float-) أو [render the entire slide](/slides/ar/java/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة دقيقة بالبكسل أو تريد تضمين المخطط في مستندات أو لوحات معلومات أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى أداء بناء وعرض المخططات ثلاثية الأبعاد الكبيرة؟**

يعتمد الأداء على حجم البيانات وتعقيد المظهر البصري. للحصول على أفضل النتائج، حافظ على تقليل تأثيرات 3D قدر الإمكان، وتجنب القوام الثقيلة على الجدران ومناطق الرسم، وقم بتقليل عدد نقاط البيانات لكل سلسلة عندما يكون ذلك ممكنًا، وقم بالتصيير إلى مخرج بالحجم المناسب (الدقة والأبعاد) ليتوافق مع العرض المستهدف أو احتياجات الطباعة.
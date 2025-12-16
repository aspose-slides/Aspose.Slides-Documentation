---
title: تخصيص مخططات الفطيرة في العروض التقديمية على Android
linktitle: مخطط الفطيرة
type: docs
url: /ar/androidjava/pie-chart/
keywords:
- مخطط فطيرة
- إدارة المخطط
- تخصيص المخطط
- خيارات المخطط
- إعدادات المخطط
- خيارات الرسم
- لون الشريحة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيف تنشئ وتخصص مخططات الفطيرة في Java باستخدام Aspose.Slides for Android، قابلة للتصدير إلى PowerPoint، مما يعزز سرد بياناتك في ثوانٍ."
---

## **خيارات المخطط الثانوي لمخططات فطيرة داخل فطيرة وشريط داخل فطيرة**
Aspose.Slides for Android عبر Java الآن يدعم خيارات المخطط الثانوي لمخطط فطيرة داخل فطيرة أو شريط داخل فطيرة. في هذا الموضوع، سنوضح لك كيفية تحديد تلك الخيارات باستخدام Aspose.Slides. لتحديد الخصائص، قم بما يلي:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. إضافة مخطط إلى الشريحة.
1. تحديد خيارات المخطط الثانوي للمخطط.
1. كتابة العرض التقديمي إلى القرص.

في المثال أدناه، قمنا بتعيين خصائص مختلفة لمخطط فطيرة داخل فطيرة.
```java
// إنشاء نسخة من الفئة Presentation
Presentation pres = new Presentation();
try {
    // إضافة مخطط إلى الشريحة
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // تعيين خصائص مختلفة
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // كتابة العرض التقديمي إلى القرص
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين ألوان شرائح مخطط الفطيرة تلقائيًا**
Aspose.Slides for Android عبر Java يوفر واجهة برمجة تطبيقات بسيطة لتعيين ألوان شرائح مخطط الفطيرة تلقائيًا. يطبق كود العينة تعيين الخصائص المذكورة أعلاه.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط مع البيانات الافتراضية.
1. تعيين عنوان المخطط.
1. تعيين أول سلسلة لعرض القيم.
1. تعيين فهرس ورقة بيانات المخطط.
1. الحصول على ورقة عمل بيانات المخطط.
1. حذف السلاسل والفئات التي تم إنشاؤها تلقائيًا.
1. إضافة فئات جديدة.
1. إضافة سلاسل جديدة.

اكتب العرض التقديمي المعدل إلى ملف PPTX.
```java
// إنشاء نسخة من فئة Presentation class
Presentation pres = new Presentation();
try {
    // إضافة مخطط مع البيانات الافتراضية
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // تعيين عنوان المخطط
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // تعيين السلسلة الأولى لعرض القيم
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // تعيين فهرس ورقة بيانات المخطط
    int defaultWorksheetIndex = 0;

    // الحصول على ورقة عمل بيانات المخطط
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // إضافة فئات جديدة
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // إضافة سلسلة جديدة
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // الآن يتم ملء بيانات السلسلة
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**هل يتم دعم المتغيرات 'فطيرة داخل فطيرة' و'شريط داخل فطيرة'؟**

نعم، المكتبة [تدعم](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) مخططًا ثانويًا لمخططات الفطيرة، بما في ذلك النوعين 'فطيرة داخل فطيرة' و'شريط داخل فطيرة'.

**هل يمكنني تصدير المخطط فقط كصورة (مثلاً PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) (مثل PNG) دون العرض التقديمي بالكامل.
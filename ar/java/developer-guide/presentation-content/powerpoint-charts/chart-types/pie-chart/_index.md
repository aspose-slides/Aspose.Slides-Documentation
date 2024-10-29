---
title: مخطط الدائرة
type: docs
url: /ar/java/pie-chart/
---

## **خيارات المخطط الثاني لمخطط الدائرة أو مخطط العمود للدائرة**
يدعم Aspose.Slides لـ Java الآن خيارات المخطط الثاني لمخطط الدائرة أو مخطط العمود للدائرة. في هذا الموضوع، سنظهر لك كيفية تحديد تلك الخيارات باستخدام Aspose.Slides. لتحديد الخصائص، افعل ما يلي:

1. قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. أضف المخطط على الشريحة.
1. حدد خيارات المخطط الثاني من المخطط.
1. قم بكتابة العرض التقديمي على القرص.

في المثال المقدم أدناه، قمنا بتعيين خصائص مختلفة لمخطط الدائرة.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // إضافة مخطط على الشريحة
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // تعيين خصائص مختلفة
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // كتابة العرض التقديمي على القرص
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين ألوان شرائح مخطط الدائرة التلقائية**
يوفر Aspose.Slides لـ Java واجهة برمجة تطبيقات بسيطة لتعيين ألوان شرائح مخطط الدائرة التلقائية. الكود النموذجي ينطبق على تعيين الخصائص المذكورة أعلاه.

1. قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. تعيين عنوان المخطط.
1. تعيين السلسلة الأولى لتظهر القيم.
1. تعيين فهرس ورقة بيانات المخطط.
1. الحصول على ورقة بيانات المخطط.
1. حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا.
1. إضافة فئات جديدة.
1. إضافة سلاسل جديدة.

قم بكتابة العرض التقديمي المعدل إلى ملف PPTX.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // إضافة مخطط ببيانات افتراضية
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // تعيين عنوان المخطط
    chart.getChartTitle().addTextFrameForOverriding("عنوان عينة");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // تعيين السلسلة الأولى لتظهر القيم
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // تعيين فهرس ورقة بيانات المخطط
    int defaultWorksheetIndex = 0;

    // الحصول على ورقة بيانات المخطط
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // إضافة فئات جديدة
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "الربع الأول"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "الربع الثاني"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "الربع الثالث"));

    // إضافة سلاسل جديدة
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "السلسلة 1"), chart.getType());

    // الآن تعبئة بيانات السلسلة
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
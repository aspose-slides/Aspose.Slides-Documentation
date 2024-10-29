---
title: مخطط دائري
type: docs
url: /ar/androidjava/pie-chart/
---

## **خيارات المخطط الثاني لمخطط الدائري أو المخطط العمودي الدائري**
Aspose.Slides لـ Android عبر Java تدعم الآن خيارات المخطط الثاني لمخطط الدائري أو المخطط العمودي الدائري. في هذا الموضوع، سنوضح لك كيفية تحديد تلك الخيارات باستخدام Aspose.Slides. لتحديد الخصائص، قم بما يلي:

1. قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. أضف المخطط إلى الشريحة.
1. حدد خيارات المخطط الثاني للمخطط.
1. احفظ العرض على القرص.

في المثال المقدم أدناه، لقد قمنا بتعيين خصائص مختلفة لمخطط الدائري.

```java
// إنشاء نموذج من فئة Presentation
Presentation pres = new Presentation();
try {
    // أضف المخطط إلى الشريحة
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // تعيين خصائص مختلفة
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // احفظ العرض على القرص
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين ألوان شرائح المخطط الدائري تلقائيًا**
Aspose.Slides لـ Android عبر Java توفر واجهة برمجة تطبيقات بسيطة لتعيين ألوان شرائح المخطط الدائري تلقائيًا. الكود النموذجي يطبق تعيين الخصائص المذكورة أعلاه.

1. قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. أضف المخطط ببيانات افتراضية.
1. تعيين عنوان المخطط.
1. تعيين السلسلة الأولى لعرض القيم.
1. تعيين مؤشر ورقة بيانات المخطط.
1. الحصول على ورقة عمل بيانات المخطط.
1. حذف السلاسل والكategories الناتجة افتراضيًا.
1. إضافة فئات جديدة.
1. إضافة سلاسل جديدة.

احفظ العرض المعدل في ملف PPTX.

```java
// إنشاء نموذج من فئة Presentation
Presentation pres = new Presentation();
try {
    // أضف المخطط ببيانات افتراضية
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // تعيين عنوان المخطط
    chart.getChartTitle().addTextFrameForOverriding("عنوان عينة");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // تعيين السلسلة الأولى لعرض القيم
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // تعيين مؤشر ورقة بيانات المخطط
    int defaultWorksheetIndex = 0;

    // الحصول على ورقة عمل بيانات المخطط
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // حذف السلاسل والفئات الناتجة افتراضيًا
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
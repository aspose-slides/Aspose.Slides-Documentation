---
title: مخطط دائري
type: docs
url: /ar/nodejs-java/pie-chart/
---

## **خيارات المخطط الثانوي لمخطط Pie of Pie و Bar of Pie**
أصبح Aspose.Slides for Node.js عبر Java يدعم الآن خيارات المخطط الثانوي لمخطط Pie of Pie أو Bar of Pie. في هذا الموضوع، سنوضح لك كيفية تحديد تلك الخيارات باستخدام Aspose.Slides. لتحديد الخصائص، قم بما يلي:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. إضافة مخطط إلى الشريحة.
3. تحديد خيارات المخطط الثانوي للمخطط.
4. حفظ العرض التقديمي إلى القرص.

```javascript
// إنشاء مثيل من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // إضافة مخطط إلى الشريحة
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // تعيين خصائص مختلفة
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // حفظ العرض التقديمي إلى القرص
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **ضبط ألوان شرائح المخطط الدائري تلقائيًا**
يوفر Aspose.Slides for Node.js عبر Java واجهة برمجة تطبيقات بسيطة لضبط ألوان شرائح المخطط الدائري تلقائيًا. يطبق رمز المثال ضبط الخصائص المذكورة أعلاه.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. تعيين عنوان المخطط.
5. ضبط السلسلة الأولى لعرض القيم.
6. ضبط الفهرس لورقة بيانات المخطط.
7. الحصول على ورقة عمل بيانات المخطط.
8. حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا.
9. إضافة فئات جديدة.
10. إضافة سلسلة جديدة.

حفظ العرض التقديمي المعدل إلى ملف PPTX.

```javascript
// إنشاء مثيل من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // إضافة مخطط ببيانات افتراضية
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // تعيين عنوان المخطط
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // تعيين السلسلة الأولى لعرض القيم
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // تعيين فهرس ورقة بيانات المخطط
    var defaultWorksheetIndex = 0;
    // الحصول على ورقة عمل بيانات المخطط
    var fact = chart.getChartData().getChartDataWorkbook();
    // حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // إضافة فئات جديدة
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // إضافة سلسلة جديدة
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // الآن تعبئة بيانات السلسلة
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**هل يتم دعم تنويعات 'Pie of Pie' و 'Bar of Pie'؟**

نعم، المكتبة [تدعم](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) مخططًا ثانويًا لمخططات الدائرة، بما في ذلك الأنواع 'Pie of Pie' و 'Bar of Pie'.

**هل يمكنني تصدير المخطط فقط كصورة (على سبيل المثال، PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (مثل PNG) دون الحاجة إلى العرض التقديمي بالكامل.
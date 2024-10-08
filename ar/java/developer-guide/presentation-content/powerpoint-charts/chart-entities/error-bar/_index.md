---
title: شريط الخطأ
type: docs
url: /ar/java/error-bar/
---

## **إضافة شريط خطأ**
توفر Aspose.Slides لـ Java API بسيطة لإدارة قيم شريط الخطأ. ينطبق رمز المثال عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة البيانات المحددة في مجموعة [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) للسلاسل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. إضافة مخطط فقاعي على الشريحة المطلوبة.
1. الوصول إلى السلسلة الأولى من المخطط وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى السلسلة الأولى من المخطط وتعيين تنسيق شريط الخطأ Y.
1. تعيين قيم القضبان والتنسيق.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // إنشاء مخطط فقاعي
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // إضافة شرائط الخطأ وتعيين تنسيقها
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // حفظ العرض التقديمي
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة قيمة شريط خطأ مخصصة**
توفر Aspose.Slides لـ Java API بسيطة لإدارة قيم شريط الخطأ المخصصة. ينطبق رمز المثال عندما تكون خاصية [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/java/com.aspose.slides/IErrorBarsFormat#getValue--) مساوية لـ **Custom**. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة البيانات المحددة في مجموعة [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) للسلاسل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. إضافة مخطط فقاعي على الشريحة المطلوبة.
1. الوصول إلى السلسلة الأولى من المخطط وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى السلسلة الأولى من المخطط وتعيين تنسيق شريط الخطأ Y.
1. الوصول إلى نقاط البيانات الفردية من السلسلة وتعيين قيم شريط الخطأ لنقطة البيانات الفردية للسلسلة.
1. تعيين قيم القضبان والتنسيق.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // إنشاء مخطط فقاعي
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // إضافة شرائط الخطأ المخصصة وتعيين تنسيقها
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // الوصول إلى نقطة بيانات السلسلة وتعيين قيم شرائط الخطأ لـ
    // نقطة فردية
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // تعيين شرائط الخطأ لنقاط سلسلة المخطط
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // حفظ العرض التقديمي
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
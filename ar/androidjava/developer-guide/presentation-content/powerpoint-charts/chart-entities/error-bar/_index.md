---
title: شريط الخطأ
type: docs
url: /ar/androidjava/error-bar/
---

## **إضافة شريط خطأ**
توفر Aspose.Slides لنظام Android عبر Java واجهة برمجة تطبيقات بسيطة لإدارة قيم شريط الخطأ. ينطبق كود العينة عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection):

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. إضافة مخطط فقاعي على الشريحة المرغوبة.
1. الوصول إلى سلسلة المخطط الأولى وضبط تنسيق الشريط الخطأ X.
1. الوصول إلى سلسلة المخطط الأولى وضبط تنسيق الشريط الخطأ Y.
1. ضبط قيم وأشكال الأشرطة.
1. كتابة العرض المعدل إلى ملف PPTX.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // إنشاء مخطط فقاعي
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // إضافة أشرطة الخطأ وضبط تنسيقها
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

    // حفظ العرض
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إضافة قيمة شريط خطأ مخصص**
توفر Aspose.Slides لنظام Android عبر Java واجهة برمجة تطبيقات بسيطة لإدارة قيم شريط الخطأ المخصص. ينطبق كود العينة عندما تكون خاصية [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) مساوية لـ **Custom**. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة [**DataPoints**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartSeriesCollection):

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. إضافة مخطط فقاعي على الشريحة المرغوبة.
1. الوصول إلى سلسلة المخطط الأولى وضبط تنسيق الشريط الخطأ X.
1. الوصول إلى سلسلة المخطط الأولى وضبط تنسيق الشريط الخطأ Y.
1. الوصول إلى نقاط بيانات سلسلة المخطط الفردية وضبط قيم شريط الخطأ لنقطة بيانات السلسلة الفردية.
1. ضبط قيم وأشكال الأشرطة.
1. كتابة العرض المعدل إلى ملف PPTX.

```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // إنشاء مخطط فقاعي
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // إضافة أشرطة الخطأ المخصصة وضبط تنسيقها
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // الوصول إلى نقاط بيانات سلسلة المخطط وضبط قيم أشرطة الخطأ لـ
    // النقطة الفردية
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // ضبط أشرطة الخطأ لنقاط سلسلة المخطط
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // حفظ العرض
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
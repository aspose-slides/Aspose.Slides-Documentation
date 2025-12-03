---
title: تخصيص أشرطة الخطأ في مخططات العروض باستخدام Java
linktitle: شريط الخطأ
type: docs
url: /ar/java/error-bar/
keywords:
- شريط الخطأ
- قيمة مخصصة
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إضافة وتخصيص أشرطة الخطأ في المخططات باستخدام Aspose.Slides for Java—حسّن التصورات البصرية للبيانات في عروض PowerPoint."
---

## **إضافة شريط الخطأ**
Aspose.Slides for Java توفر واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ. يُطبق الكود النموذجي عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم الخاصية **ErrorBarCustomValues** لنقطة بيانات معينة في مجموعة [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) الخاصة بالسلسلة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. إضافة مخطط فقاعات إلى الشريحة المطلوبة.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ Y.
1. تعيين قيم الأشرطة والتنسيق.
1. حفظ العرض التقديمي المعدل في ملف PPTX.
```java
// إنشاء مثيل من الفئة Presentation
Presentation pres = new Presentation();
try {
    // إنشاء مخطط فقاعي
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // إضافة أشرطة الخطأ وتعيين تنسيقها
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


## **إضافة قيمة مخصصة لشريط الخطأ**
Aspose.Slides for Java توفر واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ المخصصة. يُطبق الكود النموذجي عندما تكون خاصية [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/java/com.aspose.slides/IErrorBarsFormat#getValue--) مساوية لـ **Custom**. لتحديد قيمة، استخدم الخاصية **ErrorBarCustomValues** لنقطة بيانات معينة في مجموعة [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) الخاصة بالسلسلة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. إضافة مخطط فقاعات إلى الشريحة المطلوبة.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ Y.
1. الوصول إلى نقاط البيانات الفردية لسلسلة المخطط وتعيين قيم شريط الخطأ لكل نقطة بيانات.
1. تعيين قيم الأشرطة والتنسيق.
1. حفظ العرض التقديمي المعدل في ملف PPTX.
```java
// إنشاء مثيل من فئة Presentation
Presentation pres = new Presentation();
try {
    // إنشاء مخطط فقاعي
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // إضافة أشرطة خطأ مخصصة وتعيين تنسيقها
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // الوصول إلى نقطة بيانات سلسلة المخطط وتعيين قيم أشرطة الخطأ لـ
    // نقطة فردية
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // تعيين أشرطة الخطأ لنقاط سلسلة المخطط
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


## **الأسئلة الشائعة**

**ما الذي يحدث لأشرطة الخطأ عند تصدير عرض تقديمي إلى PDF أو صور؟**

يتم عرضها كجزء من المخطط وتُحافظ عليها أثناء التحويل مع بقية تنسيقات المخطط، بافتراض وجود نسخة أو محرك عرض متوافق.

**هل يمكن دمج أشرطة الخطأ مع العلامات والتسميات البيانية؟**

نعم. أشرطة الخطأ عنصر منفصل ومتوافق مع العلامات والتسميات البيانية؛ إذا تداخلت العناصر قد تحتاج إلى تعديل التنسيق.

**أين يمكن العثور على قائمة الخصائص والفئات الخاصة بالعمل مع أشرطة الخطأ في API؟**

في مرجع API: الفئة [ErrorBarsFormat](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarsformat/) والفئات ذات الصلة [ErrorBarType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbartype/) و[ErrorBarValueType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarvaluetype/).
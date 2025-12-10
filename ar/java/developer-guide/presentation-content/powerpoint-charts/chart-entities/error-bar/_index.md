---
title: تخصيص أشرطة الخطأ في مخططات العروض التقديمية باستخدام Java
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
description: "تعلم كيفية إضافة وتخصيص أشرطة الخطأ في المخططات باستخدام Aspose.Slides for Java—حسّن التصوير البياني للبيانات في عروض PowerPoint التقديمية."
---

## **إضافة أشرطة الخطأ**
توفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ. ينطبق رمز العينة عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة البيانات المحددة في مجموعة [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) الخاصة بالسلسلة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. إضافة مخطط فقاعي إلى الشريحة المطلوبة.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ Y.
1. تعيين قيم الأشرطة وتنسيقها.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.
```java
// إنشاء مثال من فئة Presentation
Presentation pres = new Presentation();
try {
    // إنشاء مخطط فقاعي
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // إضافة أشرطة الخطأ وتحديد تنسيقها
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


## **إضافة قيم مخصصة لأشرطة الخطأ**
توفر Aspose.Slides for Java واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ المخصصة. ينطبق رمز العينة عندما تكون الخاصية [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/java/com.aspose.slides/IErrorBarsFormat#getValue--) مساوية لـ **Custom**. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة البيانات المحددة في مجموعة [**DataPoints**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartSeriesCollection) الخاصة بالسلسلة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. إضافة مخطط فقاعي إلى الشريحة المطلوبة.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ Y.
1. الوصول إلى نقاط البيانات الفردية لسلسلة المخطط وتعيين قيم شريط الخطأ لكل نقطة بيانات.
1. تعيين قيم الأشرطة وتنسيقها.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.
```java
// إنشاء مثال من فئة Presentation
Presentation pres = new Presentation();
try {
    // إنشاء مخطط فقاعي
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // إضافة أشرطة خطأ مخصصة وتحديد تنسيقها
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // الوصول إلى نقطة بيانات سلسلة المخطط وتعيين قيم أشرطة الخطأ لل
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


## **الأسئلة المتداولة**

**ماذا يحدث لأشرطة الخطأ عند تصدير عرض تقديمي إلى PDF أو صور؟**

يتم رسمها كجزء من المخطط وتُحافظ عليها أثناء التحويل مع باقي تنسيقات المخطط، بشرط استخدام نسخة أو محول متوافق.

**هل يمكن دمج أشرطة الخطأ مع العلامات وملصقات البيانات؟**

نعم. أشرطة الخطأ عنصر منفصل ومتوافق مع العلامات وملصقات البيانات؛ إذا تداخلت العناصر قد تحتاج إلى تعديل التنسيق.

**أين يمكن العثور على قائمة الخصائص والفئات الخاصة بالعمل مع أشرطة الخطأ في واجهة البرمجة؟**

في مرجع واجهة البرمجة: الفئة [ErrorBarsFormat](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarsformat/) والفئات المتعلقة [ErrorBarType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbartype/) و[ErrorBarValueType](https://reference.aspose.com/slides/java/com.aspose.slides/errorbarvaluetype/).
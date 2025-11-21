---
title: شريط الخطأ
type: docs
url: /ar/nodejs-java/error-bar/
---

## **إضافة شريط الخطأ**

توفر Aspose.Slides for Node.js عبر Java واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ. يُطبق الكود النموذجي عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) للسلسلة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. إضافة مخطط فقاعة إلى الشريحة المطلوبة.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ Y.
1. تعيين قيم الأشرطة والتنسيق.
1. كتابة العرض المُعدَّل إلى ملف PPTX.
```javascript
// إنشاء مثيل من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // إنشاء مخطط فقاعة
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // إضافة أشرطة الأخطاء وتعيين تنسيقها
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // حفظ العرض التقديمي
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إضافة قيمة مخصصة لشريط الخطأ**

توفر Aspose.Slides for Node.js عبر Java واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ المخصصة. يُطبق الكود النموذجي عندما تكون خاصية [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) مساوية لـ **Custom**. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة [**DataPoints**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartSeriesCollection) للسلسلة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. إضافة مخطط فقاعة إلى الشريحة المطلوبة.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ Y.
1. الوصول إلى نقاط البيانات الفردية في سلسلة المخطط وتعيين قيم شريط الخطأ لكل نقطة بيانات.
1. تعيين قيم الأشرطة والتنسيق.
1. كتابة العرض المُعدَّل إلى ملف PPTX.
```javascript
// إنشاء مثيل من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // إنشاء مخطط فقاعة
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // إضافة أشرطة الأخطاء المخصصة وتعيين تنسيقها
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // الوصول إلى نقطة بيانات سلسلة المخطط وتعيين قيم أشرطة الأخطاء لـ
    // النقطة الفردية
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // تعيين أشرطة الأخطاء لنقاط سلسلة المخطط
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // حفظ العرض التقديمي
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**ماذا يحدث لشريط الأخطاء عند تصدير عرض تقديمي إلى PDF أو صور؟**

يتم تنزيله كجزء من المخطط ويُحافظ عليه أثناء التحويل مع بقية تنسيقات المخطط، بشرط وجود نسخة أو محوِّل متوافق.

**هل يمكن دمج أشرطة الأخطاء مع العلامات وتسميات البيانات؟**

نعم. أشرطة الأخطاء عنصر منفصل ومتوافق مع العلامات وتسميات البيانات؛ إذا تداخلت العناصر قد تحتاج إلى تعديل التنسيق.

**أين يمكنني العثور على قائمة الخصائص والعدادات (enums) للعمل مع أشرطة الأخطاء في واجهة البرمجة؟**

في مرجع API: الفئة [ErrorBarsFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbarsformat/) والعدادات المرتبطة [ErrorBarType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbartype/) و[ErrorBarValueType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/errorbarvaluetype/).
---
title: تخصيص أشرطة الأخطاء في مخططات العروض التقديمية في .NET
linktitle: شريط الخطأ
type: docs
url: /ar/net/error-bar/
keywords:
- شريط الأخطاء
- قيمة مخصصة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة وتخصيص أشرطة الأخطاء في المخططات باستخدام Aspose.Slides for .NET—تحسين العرض البصري للبيانات في عروض PowerPoint التقديمية."
---

## **إضافة أشرطة الأخطاء**
توفر Aspose.Slides للـ .NET واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الأخطاء. يُطبق رمز العينة عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم الخاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة **DataPoints** الخاصة بالسلسلة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. إضافة مخطط فقاعة إلى الشريحة المطلوبة.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ Y.
1. تعيين قيم الأشرطة والتنسيق.
1. كتابة العرض المعدل إلى ملف PPTX.
```c#
 // إنشاء عرض تقديمي فارغ
using (Presentation presentation = new Presentation())
{
    // إنشاء مخطط فقاعة
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // إضافة أشرطة الأخطاء وتعيين تنسيقها
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // حفظ العرض التقديمي
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```




## **إضافة قيم مخصصة لأشرطة الأخطاء**
توفر Aspose.Slides للـ .NET واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الأخطاء المخصصة. يُطبق رمز العينة عندما تكون خاصية **IErrorBarsFormat.ValueType** مساوية لـ **Custom**. لتحديد قيمة، استخدم الخاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة **DataPoints** الخاصة بالسلسلة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. إضافة مخطط فقاعة إلى الشريحة المطلوبة.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى سلسلة المخطط الأولى وتعيين تنسيق شريط الخطأ Y.
1. الوصول إلى نقاط البيانات الفردية لسلسلة المخطط وتعيين قيم شريط الخطأ لنقطة البيانات الفردية للسلسلة.
1. تعيين قيم الأشرطة والتنسيق.
1. كتابة العرض المعدل إلى ملف PPTX.
```c#
 // إنشاء عرض تقديمي فارغ
using (Presentation presentation = new Presentation())
{
    // إنشاء مخطط فقاعة
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // إضافة أشرطة أخطاء مخصصة وتعيين تنسيقها
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // الوصول إلى نقطة بيانات سلسلة المخطط وتعيين قيم أشرطة الأخطاء لنقطة فردية
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // تعيين أشرطة الأخطاء لنقاط سلسلة المخطط
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // حفظ العرض التقديمي
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتكررة**

**ماذا يحدث لأشرطة الأخطاء عند تصدير العرض إلى PDF أو صور؟**

يتم عرضها كجزء من المخطط وتُحفظ أثناء التحويل مع بقية تنسيق المخطط، بافتراض نسخة أو أداة عرض متوافقة.

**هل يمكن دمج أشرطة الأخطاء مع العلامات وملصقات البيانات؟**

نعم. أشرطة الأخطاء عنصر منفصل وتتناسب مع العلامات وملصقات البيانات؛ إذا تداخلت العناصر، قد تحتاج إلى تعديل التنسيق.

**أين يمكنني العثور على قائمة الخصائص والعدادات للعمل مع أشرطة الأخطاء في API؟**

في مرجع API: الفئة [ErrorBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarsformat/) والعدادات المرتبطة [ErrorBarType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbartype/) و[ErrorBarValueType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarvaluetype/).
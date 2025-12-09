---
title: تخصيص أشرطة الخطأ في مخططات العروض التقديمية في .NET
linktitle: شريط الخطأ
type: docs
url: /ar/net/error-bar/
keywords:
- شريط الخطأ
- قيمة مخصصة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرف على كيفية إضافة وتخصيص أشرطة الخطأ في المخططات باستخدام Aspose.Slides for .NET - تحسين تصور البيانات في عروض PowerPoint التقديمية."
---

## **إضافة شريط الخطأ**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ. يطبق كود العينة عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات معينة في مجموعة **DataPoints** الخاصة بالسلسلة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. إضافة مخطط فقاعة إلى الشريحة المطلوبة.
1. الوصول إلى السلسلة الأولى للمخطط وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى السلسلة الأولى للمخطط وتعيين تنسيق شريط الخطأ Y.
1. تعيين قيم الأشرطة وتنسيقها.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.
```c#
// إنشاء عرض تقديمي فارغ
using (Presentation presentation = new Presentation())
{
    // إنشاء مخطط فقاعة
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // إضافة أشرطة الخطأ وتعيين تنسيقها
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


## **إضافة قيمة مخصصة لشريط الخطأ**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ المخصصة. يطبق كود العينة عندما تكون خاصية **IErrorBarsFormat.ValueType** مساوية لـ **Custom**. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات معينة في مجموعة **DataPoints** الخاصة بالسلسلة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. إضافة مخطط فقاعة إلى الشريحة المطلوبة.
1. الوصول إلى السلسلة الأولى للمخطط وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى السلسلة الأولى للمخطط وتعيين تنسيق شريط الخطأ Y.
1. الوصول إلى نقاط البيانات الفردية لسلسلة المخطط وتعيين قيم شريط الخطأ لنقطة البيانات الفردية في السلسلة.
1. تعيين قيم الأشرطة وتنسيقها.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.
```c#
// إنشاء عرض تقديمي فارغ
using (Presentation presentation = new Presentation())
{
    // إنشاء مخطط فقاعة
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // إضافة أشرطة خطأ مخصصة وتعيين تنسيقها
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // الوصول إلى نقطة بيانات سلسلة المخطط وتعيين قيم أشرطة الخطأ لنقطة مفردة
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // تعيين أشرطة الخطأ لنقاط سلسلة المخطط
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

**ماذا يحدث لأشرطة الخطأ عند تصدير عرض تقديمي إلى PDF أو صور؟**
يتم رسمها كجزء من المخطط وتُحافظ عليها أثناء التحويل مع باقي تنسيق المخطط، بشرط وجود نسخة أو محرك عرض متوافق.

**هل يمكن دمج أشرطة الخطأ مع العلامات ووسوم البيانات؟**
نعم. أشرطة الخطأ عنصر منفصل ومتوافق مع العلامات ووسوم البيانات؛ إذا تداخلت العناصر قد تحتاج إلى تعديل التنسيق.

**أين يمكنني العثور على قائمة الخصائص والعدادات (enums) للعمل مع أشرطة الخطأ في الواجهة البرمجية؟**
في مرجع الواجهة البرمجية: الفئة [ErrorBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarsformat/) والعدادات المرتبطة [ErrorBarType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbartype/) و[ErrorBarValueType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarvaluetype/).
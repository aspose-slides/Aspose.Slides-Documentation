---
title: شريط الخطأ
type: docs
url: /ar/net/error-bar/
keywords: "شريط الخطأ، قيم شريط الخطأ، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "إضافة شريط خطأ إلى عروض PowerPoint في C# أو .NET"
---

## **إضافة شريط خطأ**
توفر Aspose.Slides لـ .NET واجهة برمجة تطبيقات بسيطة لإدارة قيم شريط الخطأ. ينطبق كود العينة عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات معينة في مجموعة **DataPoints** لسلسلة البيانات:

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. أضف مخطط فقاعي على الشريحة المرغوبة.
1. الوصول إلى السلسلة الأولى من المخطط وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى السلسلة الأولى من المخطط وتعيين تنسيق شريط الخطأ Y.
1. تعيين قيم وأشكال الأشرطة.
1. كتابة العرض المعدل إلى ملف PPTX.

```c#
// إنشاء عرض تقديمي فارغ
using (Presentation presentation = new Presentation())
{
    // إنشاء مخطط فقاعي
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



## **إضافة قيمة شريط خطأ مخصصة**
توفر Aspose.Slides لـ .NET واجهة برمجة تطبيقات بسيطة لإدارة قيم شريط الخطأ المخصصة. ينطبق كود العينة عندما تكون خاصية **IErrorBarsFormat.ValueType** مساوية لـ **Custom**. لتحديد قيمة، استخدم خاصية **ErrorBarCustomValues** لنقطة بيانات معينة في مجموعة **DataPoints** لسلسلة البيانات:

1. قم بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. أضف مخطط فقاعي على الشريحة المرغوبة.
1. الوصول إلى السلسلة الأولى من المخطط وتعيين تنسيق شريط الخطأ X.
1. الوصول إلى السلسلة الأولى من المخطط وتعيين تنسيق شريط الخطأ Y.
1. الوصول إلى نقاط بيانات السلسلة الفردية وتعيين قيم شريط الخطأ لنقطة بيانات السلسلة الفردية.
1. تعيين قيم وأشكال الأشرطة.
1. كتابة العرض المعدل إلى ملف PPTX.

```c#
// إنشاء عرض تقديمي فارغ
using (Presentation presentation = new Presentation())
{
    // إنشاء مخطط فقاعي
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // إضافة أشرطة خطأ مخصصة وتعيين تنسيقها
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // الوصول إلى نقاط بيانات السلسلة وتعيين قيم أشرطة الخطأ للنقاط الفردية
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
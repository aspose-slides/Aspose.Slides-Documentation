---
title: شريط الخطأ
type: docs
url: /ar/net/error-bar/
keywords: "شريط الخطأ، قيم شريط الخطأ عرض تقديمي PowerPoint، C#، Csharp، Aspose.Slides for .NET"
description: "إضافة شريط خطأ إلى عروض PowerPoint التقديمية في C# أو .NET"
---

## **إضافة شريط الخطأ**
Aspose.Slides for .NET يوفر واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ. يُطبق الكود النموذجي عند استخدام نوع قيمة مخصص. لتحديد قيمة، استخدم الخاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة **DataPoints** الخاصة بالسلسلة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. إضافة مخطط فقاعة إلى الشريحة المطلوبة.
3. الوصول إلى السلسلة الأولى للمخطط وتعيين تنسيق شريط الخطأ X.
4. الوصول إلى السلسلة الأولى للمخطط وتعيين تنسيق شريط الخطأ Y.
5. تعيين قيم الأشرطة والتنسيق.
6. كتابة العرض التقديمي المعدل إلى ملف PPTX .
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
Aspose.Slides for .NET يوفر واجهة برمجة تطبيقات بسيطة لإدارة قيم أشرطة الخطأ المخصصة. يُطبق الكود النموذجي عندما تكون الخاصية **IErrorBarsFormat.ValueType** مساوية لـ **Custom**. لتحديد قيمة، استخدم الخاصية **ErrorBarCustomValues** لنقطة بيانات محددة في مجموعة **DataPoints** الخاصة بالسلسلة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. إضافة مخطط فقاعة إلى الشريحة المطلوبة.
3. الوصول إلى السلسلة الأولى للمخطط وتعيين تنسيق شريط الخطأ X.
4. الوصول إلى السلسلة الأولى للمخطط وتعيين تنسيق شريط الخطأ Y.
5. الوصول إلى نقاط البيانات الفردية لسلسلة المخططات وتعيين قيم شريط الخطأ لنقطة البيانات الفردية في السلسلة.
6. تعيين قيم الأشرطة والتنسيق.
7. كتابة العرض التقديمي المعدل إلى ملف PPTX .
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

    // الوصول إلى نقطة بيانات سلسلة المخطط وتعيين قيم أشرطة الخطأ للنقطة الفردية
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


## **الأسئلة الشائعة**

**ماذا يحدث لأشرطة الخطأ عند تصدير عرض تقديمي إلى PDF أو صور؟**  
يتم عرضها كجزء من المخطط ويتم الحفاظ عليها أثناء التحويل مع باقي تنسيق المخطط، بافتراض وجود نسخة أو مُعالج متوافق.

**هل يمكن دمج أشرطة الخطأ مع العلامات وملصقات البيانات؟**  
نعم. أشرطة الخطأ عنصر منفصل ومتوافق مع العلامات وملصقات البيانات؛ إذا تداخلت العناصر، قد تحتاج إلى تعديل التنسيق.

**أين يمكنني العثور على قائمة الخصائص والـ enums للعمل مع أشرطة الخطأ في الـ API؟**  
في مرجع الـ API: الفئة [ErrorBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarsformat/) والـ enums ذات الصلة [ErrorBarType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbartype/) و [ErrorBarValueType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarvaluetype/).
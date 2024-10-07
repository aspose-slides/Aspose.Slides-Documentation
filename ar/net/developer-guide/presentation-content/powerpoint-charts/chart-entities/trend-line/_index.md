---
title: خط الاتجاه
type: docs
url: /net/trend-line/
keywords: "خط الاتجاه, خط مخصص عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إضافة خط اتجاه وخط مخصص إلى عروض PowerPoint في C# أو .NET"
---

## **إضافة خط الاتجاه**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لإدارة خطوط الاتجاه المختلفة في الرسم البياني:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
1. إضافة رسم بياني ببيانات افتراضية مع أي نوع مرغوب (هذا المثال يستخدم ChartType.ClusteredColumn).
1. إضافة خط اتجاه أسي للسلسلة البيانية 1.
1. إضافة خط اتجاه خطي للسلسلة البيانية 1.
1. إضافة خط اتجاه لوغاريتمي للسلسلة البيانية 2.
1. إضافة خط اتجاه متوسط متحرك للسلسلة البيانية 2.
1. إضافة خط اتجاه حدودي للسلسلة البيانية 3.
1. إضافة خط اتجاه طاقة للسلسلة البيانية 3.
1. كتابة العرض المعدل إلى ملف PPTX.

يستخدم الكود التالي لإنشاء رسم بياني مع خطوط الاتجاه.

```c#
// إنشاء عرض تقديمي فارغ
Presentation pres = new Presentation();

// إنشاء رسم بياني عمودي مكدس
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// إضافة خط اتجاه أسي للسلسلة البيانية 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// إضافة خط اتجاه خطي للسلسلة البيانية 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

// إضافة خط اتجاه لوغاريتمي للسلسلة البيانية 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("خط الاتجاه اللوغاريتمي الجديد");

// إضافة خط اتجاه متوسط متحرك للسلسلة البيانية 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "اسم خط الاتجاه الجديد";

// إضافة خط اتجاه حدودي للسلسلة البيانية 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// إضافة خط اتجاه طاقة للسلسلة البيانية 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// حفظ العرض التقديمي
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **إضافة خط مخصص**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لإضافة خطوط مخصصة في الرسم البياني. لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة Presentation
- الحصول على مرجع لشريحة باستخدام فهرسها
- إنشاء رسم بياني جديد باستخدام طريقة AddChart التي تعرضها كائنات Shapes
- إضافة شكل تلقائي من نوع خط باستخدام طريقة AddAutoShape التي تعرضها كائنات Shapes
- تعيين لون خطوط الشكل.
- كتابة العرض المعدل كملف PPTX

يستخدم الكود التالي لإنشاء رسم بياني مع خطوط مخصصة.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```
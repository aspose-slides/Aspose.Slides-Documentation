---
title: خط الاتجاه
type: docs
url: /ar/net/trend-line/
keywords: "خط الاتجاه، خط مخصص عرض تقديمي PowerPoint، C#، Csharp، Aspose.Slides for .NET"
description: "إضافة خط اتجاه وخط مخصص إلى عروض PowerPoint التقديمية في C# أو .NET"
---

## **إضافة خط اتجاه**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لإدارة خطوط الاتجاه المختلفة في المخططات:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة باستخدام فهرسها.
3. إضافة مخطط ببيانات افتراضية مع أي نوع مرغوب (هذا المثال يستخدم ChartType.ClusteredColumn).
4. إضافة خط اتجاه أسي للسلسلة 1 في المخطط.
5. إضافة خط اتجاه خطي للسلسلة 1 في المخطط.
6. إضافة خط اتجاه لوغاريتمي للسلسلة 2 في المخطط.
7. إضافة خط اتجاه متوسط متحرك للسلسلة 2 في المخطط.
8. إضافة خط اتجاه متعدد الحدود للسلسلة 3 في المخطط.
9. إضافة خط اتجاه أساسي للسلسلة 3 في المخطط.
10. كتابة العرض التقديمي المعدل إلى ملف PPTX.

يتم استخدام الشيفرة التالية لإنشاء مخطط مع خطوط الاتجاه.
```c#
// إنشاء عرض تقديمي فارغ
Presentation pres = new Presentation();

// إنشاء مخطط عمودي متجمع
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// إضافة خط اتجاه أسي للسلسلة 1 في المخطط
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// إضافة خط اتجاه خطي للسلسلة 1 في المخطط
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// إضافة خط اتجاه لوغاريتمي للسلسلة 2 في المخطط
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// إضافة خط اتجاه متوسط متحرك للسلسلة 2 في المخطط
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// إضافة خط اتجاه متعدد الحدود للسلسلة 3 في المخطط
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// إضافة خط اتجاه أسّي للسلسلة 3 في المخطط
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// حفظ العرض التقديمي
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```


## **إضافة خط مخصص**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لإضافة خطوط مخصصة في المخطط. لإضافة خط بسيط عادي إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء كائن من الفئة Presentation.
- الحصول على مرجع شريحة باستخدام فهرستها.
- إنشاء مخطط جديد باستخدام طريقة AddChart المتاحة عبر كائن Shapes.
- إضافة AutoShape من نوع Line باستخدام طريقة AddAutoShape المتاحة عبر كائن Shapes.
- تعيين لون خطوط الشكل.
- كتابة العرض التقديمي المعدل كملف PPTX.

يتم استخدام الشيفرة التالية لإنشاء مخطط مع خطوط مخصصة.
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


## **FAQ**

**ماذا تعني 'forward' و 'backward' في خط الاتجاه؟**

إنها أطوال خط الاتجاه الممتد إلى الأمام/الخلف: في المخططات النقطية (XY) — بوحدات المحور؛ في المخططات غير النقطية — بعدد الفئات. لا يُسمح إلا بالقيم غير السالبة.

**هل سيُحافظ على خط الاتجاه عند تصدير العرض التقديمي إلى PDF أو SVG، أو عند تحويل شريحة إلى صورة؟**

نعم. تقوم Aspose.Slides بتحويل العروض التقديمية إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)/[SVG](/slides/ar/net/render-a-slide-as-an-svg-image/) وتُعيد رسم المخططات كصور؛ تُحفظ خطوط الاتجاه كجزء من المخطط أثناء هذه العمليات. تتوفر أيضًا طريقة لـ [تصدير صورة للمخطط](/slides/ar/net/create-shape-thumbnails/).
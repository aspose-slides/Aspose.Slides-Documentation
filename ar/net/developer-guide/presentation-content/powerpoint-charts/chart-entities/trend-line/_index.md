---
title: إضافة خطوط الاتجاه إلى مخططات العرض في .NET
linktitle: خط الاتجاه
type: docs
url: /ar/net/trend-line/
keywords:
- مخطط
- خط الاتجاه
- خط اتجاه أسي
- خط اتجاه خطي
- خط اتجاه لوغاريتمي
- خط اتجاه متوسط متحرك
- خط اتجاه متعدد الحدود
- خط اتجاه قوة
- خط اتجاه مخصص
- PowerPoint
- عرض
- .NET
- C#
- Aspose.Slides
description: "أضف خطوط الاتجاه وتخصيصها بسرعة في مخططات PowerPoint باستخدام Aspose.Slides for .NET — دليل عملي لجذب جمهورك."
---

## **إضافة خط الاتجاه**
Aspose.Slides for .NET يوفر API بسيط لإدارة خطوط الاتجاه المختلفة في المخططات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة بواسطة فهرسها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مطلوب (يستخدم هذا المثال ChartType.ClusteredColumn).
1. إضافة خط اتجاه أسي للسلسلة 1 في المخطط.
1. إضافة خط اتجاه خطي للسلسلة 1 في المخطط.
1. إضافة خط اتجاه لوغاريتمي للسلسلة 2 في المخطط.
1. إضافة خط اتجاه متوسط متحرك للسلسلة 2 في المخطط.
1. إضافة خط اتجاه متعدد الحدود للسلسلة 3 في المخطط.
1. إضافة خط اتجاه قوّي للسلسلة 3 في المخطط.
1. كتابة العرض المعدل إلى ملف PPTX.

الكود التالي يُستخدم لإنشاء مخطط بخطوط الاتجاه.
```c#
// إنشاء عرض فارغ
Presentation pres = new Presentation();

// إنشاء مخطط عمودي مجمع
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// إضافة خط اتجاه أسي لسلسلة المخطط 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// إضافة خط اتجاه خطي لسلسلة المخطط 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// إضافة خط اتجاه لوغاريتمي لسلسلة المخطط 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// إضافة خط اتجاه متوسط متحرك لسلسلة المخطط 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// إضافة خط اتجاه متعدد الحدود لسلسلة المخطط 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// إضافة خط اتجاه قوة لسلسلة المخطط 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// حفظ العرض
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```




## **إضافة خط مخصص**
Aspose.Slides for .NET يوفر API بسيط لإضافة خطوط مخصصة في مخطط. لإضافة خط بسيط إلى شريحة مختارة من العرض، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة Presentation
- الحصول على مرجع الشريحة باستخدام فهرستها
- إنشاء مخطط جديد باستخدام طريقة AddChart المتوفرة في كائن Shapes
- إضافة AutoShape من النوع Line باستخدام طريقة AddAutoShape المتوفرة في كائن Shapes
- ضبط لون خطوط الشكل
- كتابة العرض المعدل كملف PPTX

الكود التالي يُستخدم لإنشاء مخطط بخطوط مخصصة.
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


## **الأسئلة الشائعة**

**ماذا يعني “forward” و “backward” بالنسبة لخط الاتجاه؟**

هما أطوال خط الاتجاه الممتدة إلى الأمام/الخلف: للمخططات النقطية (XY) — بوحدات المحور؛ للمخططات غير النقطية — بعدد الفئات. يُسمح فقط بالقيم غير السالبة.

**هل يتم الحفاظ على خط الاتجاه عند تصدير العرض إلى PDF أو SVG، أو عند تحويل شريحة إلى صورة؟**

نعم. Aspose.Slides يحول العروض إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)/[SVG](/slides/ar/net/render-a-slide-as-an-svg-image/) ويحول المخططات إلى صور؛ خطوط الاتجاه، كجزء من المخطط، تُحفظ خلال هذه العمليات. توجد طريقة أيضاً لتصدير صورة للمخطط نفسه عبر [export an image of the chart](/slides/ar/net/create-shape-thumbnails/).
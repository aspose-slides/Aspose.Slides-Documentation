---
title: إضافة خطوط اتجاه إلى مخططات العرض التقديمي في .NET
linktitle: خط الاتجاه
type: docs
url: /ar/net/trend-line/
keywords:
- مخطط
- خط اتجاه
- خط اتجاه أسي
- خط اتجاه خطي
- خط اتجاه لوغاريتمي
- خط اتجاه متوسط متحرك
- خط اتجاه متعدد الحدود
- خط اتجاه أسّي
- خط اتجاه مخصص
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "أضف وعدّل خطوط الاتجاه بسرعة في مخططات PowerPoint باستخدام Aspose.Slides for .NET — دليل عملي لجذب جمهورك."
---

## **إضافة خط اتجاه**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لإدارة خطوط الاتجاه المختلفة في المخططات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة عبر الفهرس الخاص بها.
1. إضافة مخطط ببيانات افتراضية مع أي نوع مرغوب (هذا المثال يستخدم ChartType.ClusteredColumn).
1. إضافة خط اتجاه أسي للسلسلة 1 في المخطط.
1. إضافة خط اتجاه خطي للسلسلة 1 في المخطط.
1. إضافة خط اتجاه لوغاريتمي للسلسلة 2 في المخطط.
1. إضافة خط اتجاه متوسط متحرك للسلسلة 2 في المخطط.
1. إضافة خط اتجاه متعدد الحدود للسلسلة 3 في المخطط.
1. إضافة خط اتجاه أسّي للسلسلة 3 في المخطط.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

الكود التالي يُستخدم لإنشاء مخطط مع خطوط الاتجاه.
```c#
// إنشاء عرض تقديمي فارغ
Presentation pres = new Presentation();

// إنشاء مخطط عمودي مجمع
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
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لإضافة خطوط مخصصة في المخطط. لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة Presentation.
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها.
- إنشاء مخطط جديد باستخدام طريقة AddChart الموجودة في كائن Shapes.
- إضافة AutoShape من النوع Line باستخدام طريقة AddAutoShape الموجودة في كائن Shapes.
- ضبط لون خطوط الشكل.
- كتابة العرض التقديمي المعدل كملف PPTX.

الكود التالي يُستخدم لإنشاء مخطط مع خطوط مخصصة.
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

**ماذا يعني "forward" و "backward" بالنسبة لخط الاتجاه؟**

هما طولا خط الاتجاه الممتد إلى الأمام أو الخلف: للمخططات النقطية (XY) — بوحدات المحور؛ للمخططات غير النقطية — بعدد الفئات. يُسمح فقط بالقيم غير السالبة.

**هل سيُحفظ خط الاتجاه عند تصدير العرض التقديمي إلى PDF أو SVG، أو عند تحويل شريحة إلى صورة؟**

نعم. تقوم Aspose.Slides بتحويل العروض التقديمية إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)/[SVG](/slides/ar/net/render-a-slide-as-an-svg-image/) وتُصوّر المخططات إلى صور؛ تُحفظ خطوط الاتجاه كجزء من المخطط خلال هذه العمليات. وهناك طريقة متاحة أيضاً لتصدير صورة للمخطط نفسه عبر [export an image of the chart](/slides/ar/net/create-shape-thumbnails/).
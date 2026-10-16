---
title: إضافة خطوط الاتجاه إلى مخططات العروض التقديمية في .NET
linktitle: خط الاتجاه
type: docs
url: /ar/net/trend-line/
keywords:
- مخطط
- خط الاتجاه
- خط الاتجاه الأسي
- خط الاتجاه الخطي
- خط الاتجاه اللوغاريتمي
- خط الاتجاه المتوسط المتحرك
- خط الاتجاه متعدد الحدود
- خط الاتجاه القوي
- خط الاتجاه المخصص
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "أضف خطوط الاتجاه بسرعة وقم بتخصيصها في مخططات PowerPoint باستخدام Aspose.Slides لـ .NET — دليل عملي لجذب جمهورك."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية إضافة خطوط الاتجاه إلى مخططات العروض التقديمية باستخدام Aspose.Slides. توضح كيفية إنشاء مخطط، إضافة خطوط اتجاه إلى سلاسل المخطط، والعمل مع عدة أنواع من خطوط الاتجاه، بما في ذلك الأسية، الخطية، اللوغاريتمية، المتوسط المتحرك، المتعددة الحدود، والقوة.

كما تصف كيفية إضافة خط مخصص إلى مخطط عن طريق إدراج شكل خط، وتضم أسئلة شائعة قصيرة حول قيم إظهار الخط الأمامي والخلفي للاتجاه وما إذا كانت خطوط الاتجاه محفوظة أثناء التصدير إلى PDF أو SVG وعند تصيير المخططات كصور.

## **إضافة خط اتجاه**

استخدم [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) لإضافة خط اتجاه إلى سلسلة مخطط، مع تحديد نوعه باستخدام [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/). يُنشئ المثال مخطط أعمدة مجمع مع بيانات افتراضية ويضيف خطي اتجاه إلى كل من سلاسله الثلاث.

يخفي خط الاتجاه الأسّي معادلته وقيمة R‑squared عبر [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) و[DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/)، بينما يكون خط الاتجاه الخطي أحمر. يستخدم خط الاتجاه اللوغاريتمي [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) لتسمية مخصصة. يستخدم المتوسط المتحرك [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) لثلاث نقاط بيانات و[TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/) مخصص.

يملك خط الاتجاه المتعدد الحدود [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) بقيمة ثلاثة ويمتد فئة واحدة إلى الأمام عبر [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). يمتد خط الاتجاه القوي فئة واحدة إلى الخلف عبر [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **ضبط تقاطع خط الاتجاه**

استخدم [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) لتثبيت قيمة Y لخط الاتجاه عند X = 0. يدعم هذا الإعداد الخطوط الخطية، الأسية، والمتعددة الحدود.

على سبيل المثال، قد يحتاج نموذج تكلفة الإنتاج إلى البدء بتكاليف ثابتة معروفة قيمتها 100، حتى عندما تشير القياسات عند أحجام إنتاج غير صفرية إلى خط أساس مختلف. بالنسبة لخط الاتجاه الخطي، يقيّد تثبيت التقاطع المعادلة `y = ax + b` إلى `b = 100`؛ يتم ملاءمة الانحدار للبيانات تحت هذا القيد. هذا لا يحرك خطًا ملائمًا بالفعل ببساطة. تتحكم إعدادات تقاطع المحاور في مكان التقاء محاور المخطط، وليس في معاملات خط الاتجاه الملائم.

ينشئ المثال التالي مخطط تبعثر (XY) بأحجام إنتاج من 1 إلى 4 وتكاليف 170، 200، 230، و260. يحفظ المخطط بالتقاطع التلقائي الافتراضي، ثم يضبط التقاطع إلى 100، ويحفظ ملف PPTX ثاني. يختلف الملفان فقط في إعداد التقاطع. يعرض خط الاتجاه معادلته ويمتد إلى X = 0.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

مع الحساب التلقائي، تُنتج هذه البيانات `y = 30x + 140`. ضبط التقاطع إلى 100 ينتج تقريبًا `y = 43.33x + 100`: القيمة الملائمة عند الصفر تتطابق مع الخط الأساسي المعروف، بينما لا يمر الخط بعد الآن عبر كل نقطة بيانات.

| التقاطع التلقائي | تقاطع ثابت 100 |
| --- | --- |
| ![خط الاتجاه الخطي بتقاطع محسوب تلقائيًا 140](intercept-automatic.png) | ![خط الاتجاه الخطي بتقاطع ثابت 100](intercept-fixed.png) |

تستخدم الصورتان نفس البيانات ومقاييس المحاور. يتم تمديد خطوط الاتجاه إلى X = 0 لإظهار تقاطعاتها.

بشكل افتراضي، يحتوي الخاصية على `double.NaN`، الذي يمثل تقاطعًا غير محدد بدلاً من الصفر. ثم يُحسب التقاطع تلقائيًا من البيانات.

## **إضافة خط مخصص**

الخط المخصص هو شكل مرسوم فوق المخطط بدلاً من أن يكون خط اتجاه محسوبًا من بيانات السلاسل. يستخدم هذا المثال [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) لإضافة خط أفقي إلى الشريحة فوق المخطط. يتم تحديد موقع الخط بإحداثيات الشريحة، مقاسة بالنقاط، لذا يبدأ عند الحافة اليسرى للمخطط ويقع في منتصف ارتفاع المخطط. عرضه يطابق عرض المخطط. تُعطي [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) الخط لونًا أحمرًا صلبًا.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **الأسئلة المتكررة**

**ماذا يعني 'forward' و 'backward' بالنسبة إلى خط الاتجاه؟**

إنهما طولان لخط الاتجاه الممدود إلى الأمام أو الخلف: بالنسبة لمخططات التبعثر (XY) — بوحدات المحور؛ بالنسبة للمخططات غير التبعثّر — بعدد الفئات. يُسمح فقط بالقيم غير السالبة.

**هل سيتم حفظ خط الاتجاه عند تصدير العرض إلى PDF أو SVG، أو عند تصيير شريحة إلى صورة؟**

نعم. تقوم Aspose.Slides بتحويل العروض إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/) أو [SVG](/slides/ar/net/render-a-slide-as-an-svg-image/) وتصدّر المخططات إلى صور؛ تُحفظ خطوط الاتجاه كجزء من المخطط خلال هذه العمليات. تتوفر أيضًا طريقة لـ[تصدير صورة للمخطط](/slides/ar/net/create-shape-thumbnails/).
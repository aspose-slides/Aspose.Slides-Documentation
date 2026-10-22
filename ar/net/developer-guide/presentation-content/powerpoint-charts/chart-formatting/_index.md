---
title: تنسيق مخططات العرض في .NET
linktitle: تنسيق المخطط
type: docs
weight: 60
url: /ar/net/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخططات
- كيان المخطط
- خصائص المخطط
- إعدادات المخطط
- خيارات المخطط
- خصائص الخط
- حد مستدير
- PowerPoint
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرّف على تنسيق المخططات في Aspose.Slides لـ .NET وارتقِ بعرض PowerPoint الخاص بك باستخدام محاور مخصصة، خطوط، تنسيقات رقمية، وحدود مخطط مستديرة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق المخططات في عروض PowerPoint باستخدام Aspose.Slides. تُظهر كيفية تخصيص عناصر المخطط الأساسية مثل المحاور، خطوط الشبكة، العناوين، وسادة الألوان، منطقة الرسم، وتعبئة الجدران لتحسين مظهر وقراءة بيانات المخطط.

كما تُظهر كيفية ضبط خصائص الخط لنص المخطط، تطبيق تنسيقات عددية مُعرفة مسبقًا على بيانات المخطط، وتمكين الزوايا المستديرة لمنطقة المخطط. معًا، تُظهر هذه الأمثلة كيفية التحكم في النمط البصري وعرض البيانات للمخططات في العرض التقديمي.

## **تنسيق كيانات المخطط**

استخدم [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) لتنسيق عناوين المخطط، المحاور، خطوط الشبكة، وسادة الألوان، ومنطقة الرسم. يخلق هذا المثال مخططًا خطيًا مع علامات وبيانات افتراضية، ثم يطبق أنماط نصية وخطية منفصلة على محوري القيم والفئات. تُحدد أحجام الخطوط وعرض الخطوط بالنقاط؛ تُدوَّر تسميات الفئات بزاوية 45 درجة.

يستخدم محور القيم [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) بشكل مستقل عن الخلايا المصدر. يمتد مقياسه من -2 إلى 15، مع فواصل رئيسية قدرها 2 وفواصل فرعية قدرها 0.5. يجمع المثال أيضًا بين تنسيق النسبة المئوية و[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) المُضبط على الآلاف، لذا قم بتكييف هذه الإعدادات وفقًا لمعنى وحجم بياناتك. تبقى وسادة الألوان خارج منطقة الرسم لأن [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) معطَّلة. تُضبط تعبئة الجدار الخلفي والأرضية عبر [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) و[Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/)، لكن هذه الأسطح تظهر فقط في المخططات ثلاثية الأبعاد.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **ضبط خصائص الخط لمخطط**

اضبط حجم الخط الافتراضي لنص المخطط عبر [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/). ينشئ المثال مخطط أعمدة متجمع مع خط بحجم 20 نقطة ويفعّل تسميات القيم للسلسلة الأولى عبر [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). يمكن لعناصر النص التي لها إعدادات خط صريحة خاصة أن تتجاوز الإعداد الافتراضي للمخطط.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **تعيين التنسيق الرقمي**

استخدم [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) لتطبيق تنسيق عدد مدمج على خلايا دفتر عمل المخطط. يخلق هذا المثال مخطط أعمدة متجمع ببيانات افتراضية مدعومة بالخلايا ويطبق فهرس التنسيق 10 (`0.00%`) على كل خلية قيمة سلسلة. يغيّر هذا طريقة عرض القيم في دفتر العمل دون تغيير الأعداد الأساسية؛ على سبيل المثال، تُعرض 0.25 كـ 25.00%. يمكن تكوين تنسيقات المحور وتنسيقات تسميات البياناتSeparately.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

القائمة التالية تُظهر فهارس تنسيقات الأعداد المدمجة مع صيغ Excel النموذجية للغة الإنجليزية (الولايات المتحدة). قد تختلف سلاسل التنسيق وعرضها حسب التطبيق واللغة، خصوصًا للعملات والتواريخ. بعض صيغ Excel تختلف أيضًا عن الافتراضيات في معيار OOXML، كما هو موضح في [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| الفهرس | الصيغة |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **تعيين حدود مستديرة لمنطقة المخطط**

فعّل [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) لتقريب زوايا منطقة المخطط. ينشئ المثال مخطط أعمدة متجمع ويستخدم [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) لمنح حدودها لونًا رماديًا صلبًا ونمط خط وحيد قبل حفظ العرض التقديمي.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **تحرير تعليقات المخطط الموجودة**

يمكن للمخطط أن يحتوي على أشكال مخصصة، مثل تعليق نصي يوضح حالة تقرير. يمكن الوصول إلى هذه الأشكال عبر [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/)، المذكورة أيضًا تحت [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) في مرجع API الخاص بالمخطط. يحتوي مجموعة [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) على الأشكال المملوكة للمخطط.

مربع نص عادي موضع فوق المخطط ينتمي إلى الشريحة، حتى لو ظهر كجزء من المخطط. يكتشف التكرار عبر [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) المخطط والأشكال العادية للشريحة، لكنه لا يُدرج الأشكال الفردية داخل المخطط. عناوين المخطط وتسميات البيانات هي عناصر مخطط منفصلة، ليست تعليقات مخصصة في هذه المجموعة.

حمّل [chart-annotations.pptx](chart-annotations.pptx) وضعه في دليل العمل الخاص بالتطبيق. تحتوي شريحته الأولى على مخطط مع تعليق غير مُجَمَّع يقرأ "Preliminary results"، وخط مملوك للمخطط، ومربع نص عادي على الشريحة يقرأ "Slide overlay". يجد المثال المخطط الأول في تلك الشريحة ويغيّر التعليق إلى "Final results" عندما يصبح التقرير جاهزًا للنشر. يتحقق من وجود مجموعة فارغة ولا يُعدِّل سوى [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) التي تحتوي على [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) غير فارغ والنص المتوقع.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

يبقى الخط ومربع النص على الشريحة دون تغيير. تُظهر الصور التالية المدخل والنتيجة المحفوظة المفتوحة مجددًا:

| قبل التحرير | بعد التحرير |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
يفحص المثال فقط الأشكال ذات المستوى الأعلى المملوكة للمخطط. إذا كان التعليق داخل [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/)، فافحص مجموعة [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) الخاصة بذلك أيضًا. كرِّر ذلك بصورة متداخلة للمجموعات المتداخلة، مطبقًا نفس فحوصات النص على الأشكال الفرعية. المجموعة نفسها حاوية؛ لا تُعاملها كصندوق نص.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني ضبط تعبئات نصف شفافة للأعمدة/المناطق مع الحفاظ على الحدود غير شفافة؟**

نعم. يتم تكوين شفافية التعبئة والحدود بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني معالجة تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، عطل المكونات غير الضرورية للتسميات (مثل الفئات)، اضبط موضع التسمية، أظهر التسميات فقط للنقاط المحددة إذا لزم الأمر، أو غير الصيغة إلى "القيمة + وسادة الألوان".

**هل يمكنني تطبيق تعبئات متدرجة أو نمطية للسلاسل؟**

نعم. تدعم السلاسل تعبئات صلبة، متدرجة، ونمطية. في الممارسة العملية، استخدم التدرجات باعتدال وتجنب الجمع الذي يقلل من التباين مع الشبكة والنص.
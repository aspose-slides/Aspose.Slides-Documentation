---
title: تنسيق مخططات العرض التقديمي في .NET
linktitle: تنسيق المخطط
type: docs
weight: 60
url: /ar/net/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخطط
- كيان المخطط
- خصائص المخطط
- إعدادات المخطط
- خيارات المخطط
- خصائص الخط
- حدود مستديرة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides لـ .NET وارتقِ بعرض PowerPoint الخاص بك باستخدام محاور مخصصة، خطوط، تنسيقات رقمية، وحدود مخطط مستديرة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق المخططات في عروض PowerPoint باستخدام Aspose.Slides. تُظهر كيفية تخصيص عناصر المخطط الأساسية مثل المحاور، خطوط الشبكة، العناوين، الأساطير، منطقة الرسم، وتعبئات الجدران لتحسين مظهر البيانات وقابليتها للقراءة.

كما توضح كيفية ضبط خصائص الخط لنص المخطط، وتطبيق تنسيقات رقمية مُسبقة على بيانات المخطط، وتمكين الزوايا المستديرة لمنطقة المخطط. معًا، تُظهر هذه الأمثلة كيفية التحكم في كل من الأسلوب البصري وعرض البيانات للمخططات في العرض التقديمي.

للحصول على تعبئات وتحديدات منفصلة على الفواصل الصاعدة والهابطة، راجع [مثال مخطط الأسهم](/slides/ar/net/create-chart/#create-stock-charts).

## **تنسيق كيانات المخطط**

استخدم [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) لتنسيق عناوين المخطط، والمحاور، وخطوط الشبكة، والأساطير، ومنطقة الرسم. ينشئ هذا المثال مخططًا خطيًا مع علامات وبيانات افتراضية، ثم يطبق أنماط نصية وخطية منفصلة على محوري القيم والفئات. يتم تحديد حجم الخطوط وعرض الخطوط بالنقاط؛ تُدوَّر تسميات الفئات بزاوية 45 درجة.

يستخدم محور القيم [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) بشكل مستقل عن خلايا المصدر. يتراوح مقياسه من -2 إلى 15، مع فواصل رئيسية بمقدار 2 وفواصل فرعية بمقدار 0.5. يجمع المثال أيضًا تنسيق النسبة المئوية مع [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) المضبوطة على الآلاف، لذا عدل هذه الإعدادات لتتناسب مع معنى وحجم بياناتك. يبقى الأسطورة خارج منطقة الرسم لأن [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) غير مفعّل. يتم تكوين تعبئات الجدار الخلفي والأرضية عبر [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) و[Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/)، لكن هذه الأسطح تظهر فقط في المخططات ثلاثية الأبعاد.

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

## **ضبط خصائص الخط للمخطط**

حدد حجم الخط الافتراضي لنص المخطط من خلال [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/). ينشئ المثال مخطط أعمدة متجمع بخط 20 نقطة ويُفعّل تسميات القيم للسلسلة الأولى عبر [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). يمكن لعناصر النص التي لها إعدادات خط صريحة خاصة أن تتجاوز الإعداد الافتراضي للمخطط.

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

## **إعادة استخدام تنسيق إطار النص لوسيلة إيضاح المخطط**

لمطابقة وسيلة الإيضاح مع عنوان الشريحة، اضبط الخط في [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) للفقرة الأولى. استدعِ [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) على [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/) لوسيلة الإيضاح. يقرأ هذا إعدادات إطار النص، وتنسيق الفقرة الأولى، وخصائص الخط الافتراضية لتلك الفقرة. يبقى التنسيق المطبق مباشرة على أجزاء فردية أو على فقرات لاحقة محليًا إلى المصدر.

يستخدم المثال عنوانًا بخط Calibri سميك بحجم 26 نقطة باللون النيلي كنموذج. بعد تنسيق وسيلة الإيضاح، يستخدم [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/) لتطبيق نفس التنسيق على تسمية توضيحية منفصلة.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var heading = shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
var sourceTextFrame = heading.AddTextFrame("Quarterly sales");
var font = sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
font.LatinFont = new FontData("Calibri");
font.FontHeight = 26;
font.FontBold = NullableBool.True;
font.FillFormat.FillType = FillType.Solid;
font.FillFormat.SolidFillColor.Color = Color.FromArgb(32, 64, 96);

var chart = shapes.AddChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
chart.Style = StyleType.Style3;
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.GetCell(0, 0, 1).Value = "Retail";
workbook.GetCell(0, 0, 2).Value = "Online";
workbook.GetCell(0, 0, 3).Value = "Wholesale";
for (var quarter = 1; quarter <= 4; quarter++)
    workbook.GetCell(0, quarter, 0).Value = $"Q{quarter}";

chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.TextFormat.CopyFrom(sourceTextFrame);

var caption = shapes.AddAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
var captionTextFrame = caption.AddTextFrame("Sales in millions of dollars");
chart.Legend.TextFormat.CopyTo(captionTextFrame);

presentation.Save("legend-formatting.pptx", SaveFormat.Pptx);
```

في العرض المحفوظ، تتطابق وسيلة الإيضاح والتسمية التوضيحية مع العنوان من حيث الحجم والسمك واللون. لا تزال وسيلة الإيضاح تعرض أسماء السلاسل، وتحتفظ التسمية التوضيحية بنصها الخاص. إذا كان جزء من التسمية التوضيحية يحتوي بالفعل على حجم خط صريح، فإن ذلك الحجم يعتلي على حجم الفقرة المنسوخ.

| Before copying | After copying |
| --- | --- |
| ![Quarterly sales chart with regular black legend labels and a black caption](legend-formatting-before.png) | ![The same chart with larger, bold navy legend labels and a matching caption](legend-formatting.png) |

## **ضبط التنسيق الرقمي**

استخدم [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) لتطبيق تنسيق رقمي مدمج على خلايا دفتر عمل المخطط. ينشئ هذا المثال مخطط أعمدة متجمع ببيانات افتراضية مدعومة بالخلايا ويطبق فهرس التنسيق 10 (`0.00%`) على كل خلية قيمة سلسلة. يغيّر ذلك طريقة عرض القيم في دفتر العمل دون تغيير الأرقام الأساسية؛ على سبيل المثال، يتم عرض 0.25 كـ 25.00%. يمكن تكوين تنسيقات المحاور وتسميات البيانات بشكل منفصل.

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

القائمة التالية توضح فهارس تنسيقات الأرقام المدمجة مع صيغ Excel تمثيلية للغة الإنجليزية (الولايات المتحدة). قد تختلف سلاسل التنسيق الدقيقة وعرضها حسب التطبيق واللغة، خاصةً للعملات والتواريخ. بعض صيغ Excel تختلف أيضًا عن القيم الافتراضية في معيار OOXML، كما هو موضح في [ملاحظات تنفيذ تنسيق الأرقام من مايكروسفت](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| الفهرس | التنسيق |
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

## **ضبط حدود منطقة المخطط المستديرة**

فعّل [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) لتقوّيم زوايا منطقة المخطط. ينشئ المثال مخطط أعمدة متجمع ويستخدم [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) لإعطاء حدوده لونًا رماديًا صلبًا ونمط خط واحد قبل حفظ العرض.

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

## **تحرير تعليقات المخطط الحالية**

يمكن للمخطط أن يحتوي على أشكال مخصصة، مثل تعليقات نصية توضح حالة تقرير. يمكن الوصول إلى هذه الأشكال عبر [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/)، المذكورة أيضًا تحت [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) في مرجع واجهة برمجة تطبيقات المخطط. تحتوي مجموعة [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) الخاصة به على الأشكال المملوكة للمخطط.

يُعتبر مربع النص العادي الموضوع فوق المخطط جزءًا من الشريحة، حتى وإن بدا كجزء من المخطط. يكتشف التكرار عبر [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) المخطط والأشكال العادية في الشريحة، لكنه لا يسرد الأشكال الفردية داخل المخطط. عناوين المخططات وتسميات البيانات هي عناصر مخطط منفصلة، ليست تعليقات مخصصة في هذه المجموعة.

حمّل [chart-annotations.pptx](chart-annotations.pptx) وضعه في دليل عمل التطبيق. تحتوي الشريحة الأولى على مخطط مع تعليق غير مجمع مكتوب "Preliminary results"، وخط مملوك للمخطط، ومربع نص عادي على الشريحة مكتوب "Slide overlay". يجد المثال المخطط الأول في تلك الشريحة ويغيّر التعليق إلى "Final results" عندما يكون التقرير جاهزًا للنشر. يتحقق من وجود مجموعة فارغة ويعدل فقط [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) يحتوي على [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) غير فارغ والنص المتوقع.

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

يبقى الخط ومربع النص على الشريحة دون تغيير. تُظهر الصور التالية المدخل والنتيجة المحفوظة التي تم فتحها مرة أخرى:

| Before editing | After editing |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="ملاحظة" %}}
يفحص المثال فقط الأشكال المملوكة للمخطط على المستوى الأعلى. إذا كان التعليق داخل [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/)، فافحص مجموعة [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) الخاصة بذلك المجموعة أيضًا. كرّر ذلك بشكل متكرر للمجموعات المتداخلة، مطبقًا نفس فحوصات النص على الأشكال التابعة لها. المجموعة نفسها هي حاوية؛ لا تعاملها كمربع نص.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تعيين تعبئات شبه شفافة للأعمدة/المناطق مع الحفاظ على الحدود غير شفافة؟**

نعم. يتم تكوين شفافية التعبئة والحدود بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، عطل مكونات التسمية غير الضرورية (مثل الفئات)، اضبط موضع التسمية، اعرض التسميات فقط للنقاط المختارة إذا لزم الأمر، أو غيّر التنسيق إلى "القيمة + الأسطورة".

**هل يمكنني تطبيق تعبئات تدرجية أو نمطية على السلاسل؟**

نعم. تدعم السلاسل التعبئات الصلبة، والتدرجية، والنمطية. في الممارسة العملية، استخدم التدرجات بشكل محدود وتجنب التركيبات التي تقلل من التباين مع الشبكة والنص.
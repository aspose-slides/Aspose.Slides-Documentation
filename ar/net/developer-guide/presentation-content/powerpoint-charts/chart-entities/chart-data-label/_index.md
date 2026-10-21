---
title: إدارة تسميات بيانات المخطط في العروض التقديمية باستخدام .NET
linktitle: تسمية البيانات
type: docs
url: /ar/net/chart-data-label/
keywords:
- مخطط
- تسمية البيانات
- دقة البيانات
- النسبة المئوية
- مسافة التسمية
- موقع التسمية
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق تسميات بيانات المخطط في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ .NET للحصول على شرائح أكثر جاذبية."
---
## **المقدمة**

تُظهر تسميات البيانات معلومات حول سلاسل المخطط والنقاط البيانات الفردية، مما يساعد القارئ على تحديد القيم وفهم المخطط. يشرح هذا المقال كيفية تنسيق القيم، عرض النسب المئوية، قراءة نص التسمية، التحكم في التسميات خارج الحد الأقصى للمحور، تعديل تباعد تسميات محور الفئة، وتحديد موضع تسميات مخطط الفطيرة.

## **تعيين دقة البيانات في تسميات مخطط البيانات**

استخدام [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) لتنسيق قيم السلسلة. يخلق هذا المثال مخططًا خطيًا ببيانات افتراضية، يعرض جدول البيانات الخاص به، ويفعل تسميات القيم للسلسلة الأولى. التنسيق `#,##0.00` يُظهر فاصل الآلاف ومكانين عشريين دون تغيير القيم الأساسية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

لتنسيق الخلايا الرقمية في دفتر عمل مدمج بالمخطط، راجع [تحديد تنسيقات الأرقام المخصصة لخلايا المصنف](/slides/ar/net/chart-workbook/#set-custom-number-formats-for-workbook-cells). يوضح ذلك المثال أيضًا تسميات القيم التي تتبع تنسيقات خلايا المصدر مع الحفاظ على القيم الرقمية المخزنة.

## **عرض النسبة المئوية كتسميات**

لإنشاء مخطط عمودي متراكم، احسب كل قيمة كنسبة مئوية من مجموع الفئة الخاصة بها وعيّن النص إلى [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). يستخدم هذا المثال بيانات المخطط الافتراضية ويعرض النسب المئوية بمكانين عشريين بخط بحجم 8 نقاط. يتم تخطي الفئات التي مجموعها صفر لتجنب القسمة على الصفر. أعد حساب نص التسمية المخصص إذا تغيرت بيانات المخطط.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **تعيين علامة النسبة المئوية مع تسميات بيانات المخطط**

عند تخزين القيم ككسرات، استخدم [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) لعرض النسب المئوية. اضبط [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) على `false` لتطبيق تنسيق التسمية بشكل مستقل عن خلايا المصدر.

يُنشئ هذا المثال مخططًا عموديًا متراكمًا بنسبة 100٪ يحتوي على سلسلتين (أحمر وأزرق) عبر أربع فئات. كل زوج من القيم يساوي 1. يظهر تنسيق التسمية `0.0%` القيمة 0.30 كـ 30.0٪، بينما يستخدم المحور العمودي مكانين عشريين. تستخدم السلسلتان نصًا أبيضًا بحجم 10 نقاط للتسمية.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **قراءة النص الفعلي لتسميات البيانات**

استخدم [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) لاسترجاع النص الناتج عن إعدادات تسمية البيانات. يكون هذا مفيدًا عند استخراج التسميات للتقارير، البحث في محتوى العرض، أو التحقق من صحة المخططات المُنشأة. في المثال أدناه، يجمع تنسيق [تنسيق تسمية البيانات الافتراضي](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) كلًا من اسم الفئة، اسم السلسلة، والقيمة. تقوم نقطة واحدة بتنسيق قيمتها كنسبة مئوية، وتستخدم أخرى نصًا مخصصًا من [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

القيمة المخزنة في نقطة البيانات تظل `0.75`، حتى عندما تظهر تسميتها `75%` مع أسماء الفئة والسلسلة. النص المخصص يحل محل النص المُنشأ للتسمية. تُعيد [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) سلسلة التسمية الناتجة في الحالتين. تحقق من [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) بشكل منفصل، كما هو موضح أعلاه، عندما ترغب في استخراج التسميات المرئية فقط.

## **التحكم في تسميات البيانات خارج الحد الأقصى للمحور**

عند تحديد نطاق المحور يدويًا، قد تتجاوز بعض نقاط البيانات حدّه الأقصى. استخدم [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) للتحكم فيما إذا كانت تسميات بياناتها معروضة. هذا الإعداد يغيّر رؤية التسميات؛ لا يغيّر نطاق المحور أو القيم الأساسية للبيانات.

ينشئ المثال أدناه مخططًا عموديًا مجموعةً ثنائية الأبعاد بقيم 60 و120. يضبط [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) إلى `false` و[MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) إلى 100 على المحور العمودي. الشريحة الأولى تسمح بالتسميات التي تتجاوز الحد الأقصى؛ نسخة تلك الشريحة تعطلها. تُحفظ كلتا الشريحتين في `DataLabelsOverMaximum.pptx`.

فعّل تسميات القيم باستخدام [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). لا يقوم إعداد المستوى المخطط بتمكين عرض القيم بمفرده ولا يتجاوز إلغاء عرض القيمة لتسمية فردية. يُفعّل هذا المثال القيم لجميع السلسلة ويستخدم [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) لوضع التسميات في الطرف الخارجي لكل عمود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var firstCategory = workbook.GetCell(0, 1, 0, "Within range");
var secondCategory = workbook.GetCell(0, 2, 0, "Above maximum");

chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);

var seriesName = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);

var firstValue = workbook.GetCell(0, 1, 1, 60);
var secondValue = workbook.GetCell(0, 2, 1, 120);

series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 100;
chart.ShowDataLabelsOverMaximum = true;

var secondSlide = presentation.Slides.AddClone(slide);
var secondChart = (IChart)secondSlide.Shapes[0];
secondChart.ShowDataLabelsOverMaximum = false;

presentation.Save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
```

تُظهر الصور التالية الشرائح المحفوظة التي تم عرضها بواسطة Microsoft PowerPoint. عند `true`، تكون التسمية **120** مرئية عند الحد العلوي؛ عند `false`، تكون مخفية. تظل التسمية **60** مرئية، يبقى الحد الأقصى للمحور **100**، وتبقى نقطة البيانات الثانية **120** في الحالتين.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![مخطط PowerPoint يُظهر تسمية القيمة 120 مع حد أقصى للمحور يساوي 100](data-labels-over-maximum-true.png) | ![مخطط PowerPoint يُخفي تسمية القيمة 120 مع حد أقصى للمحور يساوي 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
يستخدم هذا المثال مخططًا عموديًا ثلاثي الأبعاد مع محور قيم. المخططات التي لا تحتوي على محور قيم، مثل مخططات الفطيرة والدونات، لا تملك حدًا أقصى للمحور يمكن تقييده بهذه الطريقة.
{{% /alert %}}

## **تعيين مسافة التسمية من المحور**

استخدم [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) للتحكم في المسافة بين تسميات محور الفئة والمحور. القيمة هي نسبة مئوية من الحد الأقصى لحجم خط تسميات المحور. يُنشئ هذا المثال مخططًا عموديًا مجموعةً ويضبط إزاحة تسمية محور الأفقي إلى 500. يؤثر هذا الإعداد على تسميات محور الفئة بدلاً من التسميات المرتبطة بنقاط البيانات الفردية.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **ضبط موقع التسمية**

في مخطط الفطيرة، اضبط مواضع تسميات البيانات لتحسين التباعد وإتاحة مساحة لخطوط الدليل.

يعرض هذا المثال قيمة نقطة البيانات الأولى، يضع تسميتها خارج الشريحة، ويضبط إزاحتيها [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) و[Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/). هذه الإزاحات نسبية لعرض المخطط وارتفاعه، على التوالي.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![مخطط فطيرة مع موضع تسمية بيانات مُعدَّل](pie-chart-adjusted-label.png)

## **تنسيق خطوط الدليل**

عندما تكون تسميات مخطط الفطيرة خارج القطع، تساعد خطوط الدليل القارئ على ربط كل قيمة بالقطعة الصحيحة. يمكن أن يجعل اللون المتباين والخط السميك قليلاً هذه الروابط أسهل للمتابعة، بينما تُبقي الشفافية والنمط المتقطع الخطوط غير مرئية بصريًا.

استخدم [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) لتنسيق خطوط الدليل على مستوى مجموعة تسميات بيانات السلسلة. تُطبق الإعدادات في `series.Labels.LeaderLinesFormat.Line` على المجموعة ككل، وليس على تسمية فردية.

يُنشئ هذا المثال مخطط فطيرة ببيانات افتراضية، يعرض القيم خارج القطع، ويفعل [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/). ينقل تسميتين أبعد عن قطعهما باستخدام إزاحتي [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) و[Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/)، معبرًا عنها ككسر من عرض وارتفاع المخطط. لا يلزم عرض تقديمي كمدخل.

تحدد [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) للخط لونًا أزرق صلبًا بقيمة ألفا 191 من أصل 255، ما يمنح شفافية تقريبية بنسبة 25٪. يضبط [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) سمك الخط إلى نقطتين، وتُحوِّل [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) الخط إلى نمط متقطع.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 80, 50, 560, 400);
chart.HasLegend = false;

var series = chart.ChartData.Series[0];

var labelFormat = series.Labels.DefaultDataLabelFormat;
labelFormat.ShowValue = true;
labelFormat.Position = LegendDataLabelPosition.OutsideEnd;
labelFormat.ShowLeaderLines = true;

// تحريك تسميتين بعيدًا عن قطعهما.
series.Labels[0].X = 0.10f;
series.Labels[0].Y = -0.05f;
series.Labels[1].X = -0.10f;
series.Labels[1].Y = 0.05f;

var line = series.Labels.LeaderLinesFormat.Line;
line.FillFormat.FillType = FillType.Solid;
line.FillFormat.SolidFillColor.Color = Color.FromArgb(191, 30, 90, 160);
line.Width = 2;
line.DashStyle = LineDashStyle.Dash;

presentation.Save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
```

تفعيل خطوط الدليل لا يضمن ظهور خط لكل تسمية. تعتمد الرؤية على موضع التسمية وسلوك تخطيط المخطط. في هذا المثال، تحتوي التسامتان المنقّلتان على خطوط دليل مرئية؛ أما التسميات القريبة من قطعها فلا تحتاج إليها.

الصورة التالية تُظهر ملف `FormattedLeaderLines.pptx` المحفوظ والمُعروض باستخدام Aspose.Slides:
![مخطط فطيرة بخطوط دليل زرقاء، شبه شفافة ومتقطعة، تربط تسميتين خارجيتين بقطعهما](formatted-leader-lines.png)

## **إضافة عدة صفوف من تسميات البيانات فوق مخطط عمودي**

ينشئ هذا المثال مخططًا عموديًا مع صفين من تسميات البيانات فوق منطقة الرسم. تعرض السلسلة A الأعمدة المرئية، بينما توفر السلسلة B والسلسلة C التسميات الإضافية. تُخفى أعمدتها بإزالة التعبئة والحد. تُطبق الخاصية [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) محاذاة جميع السلاسل الثلاثة إلى مراكز الفئة نفسها.

تُخصص إعدادات [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) مساحة لصفوف التسميات. بعد أن تُحسب المواضع الافتراضية بواسطة [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/)، تُحافظ إزاحتا [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) و[Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) على المحاذاة الأفقية وتُطبق إزاحات رأسية لترتيب التسميات في صفين. تظل الأرقام تسميات بيانات مرتبطة بقيم السلسلة؛ فقط رؤوس الصفوف هي أشكال نصية منفصلة.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
chart.HasTitle = false;
chart.HasLegend = false;
chart.TextFormat.PortionFormat.FontHeight = 12;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

string[] categories = { "North", "South", "East", "West" };
string[] seriesNames = { "Series A", "Series B", "Series C" };
double[,] seriesValues = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
{
    var categoryCell = workbook.GetCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
    chart.ChartData.Categories.Add(categoryCell);
}

for (int seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var seriesCell = workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
    var series = chart.ChartData.Series.Add(seriesCell, ChartType.ClusteredColumn);

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var valueCell = workbook.GetCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // إخفاء أعمدة B و C، مع الحفاظ على تسميات البيانات.
        series.Format.Fill.FillType = FillType.NoFill;
        series.Format.Line.FillFormat.FillType = FillType.NoFill;
        var labelFormat = series.Labels.DefaultDataLabelFormat;
        labelFormat.ShowValue = true;
        labelFormat.TextFormat.PortionFormat.FontHeight = 12;
        var labelFill = labelFormat.TextFormat.PortionFormat.FillFormat;
        labelFill.FillType = FillType.Solid;
        labelFill.SolidFillColor.Color = Color.Black;
        labelFormat.Position = LegendDataLabelPosition.InsideBase;
    }
}

// محاذاة السلاسل الثلاثة مع مراكز الفئات نفسها.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// استخدام خطوط شبكة أقل لهذا المثال المدمج.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// حجز مساحة فوق المنطقة الرسومية لصفين من تسميات البيانات.
chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
chart.PlotArea.X = 0.15f;
chart.PlotArea.Y = 0.32f;
chart.PlotArea.Width = 0.80f;
chart.PlotArea.Height = 0.48f;
chart.ValidateChartLayout();

for (int seriesIndex = 1; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var dataLabel = series.DataPoints[categoryIndex].Label;
        // احتفظ بالموقع الأفقي الافتراضي. Y هو إزاحة من
        // الموقع الافتراضي للتسمية، معبرًا عنه ككسر من ارتفاع المخطط.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // فقط عنوان الصف هو شكل نص منفصل.
    var rowHeading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, chart.X, chart.Y + rowTop * chart.Height, 85, 18);
    rowHeading.FillFormat.FillType = FillType.NoFill;
    rowHeading.LineFormat.FillFormat.FillType = FillType.NoFill;
    rowHeading.AddTextFrame(seriesNames[seriesIndex]);
    rowHeading.TextFrame.TextFrameFormat.MarginTop = 0;
    rowHeading.TextFrame.TextFrameFormat.MarginBottom = 0;
    var headingFormat = rowHeading.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    headingFormat.FontHeight = 12;
    headingFormat.FillFormat.FillType = FillType.Solid;
    headingFormat.FillFormat.SolidFillColor.Color = Color.Black;
}

presentation.Save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
```

![مخطط عمودي مع صفين من تسميات البيانات فوق منطقة الرسم](multiple-rows-of-labels.png)

## **الأسئلة الشائعة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات الكثيفة؟**

استخدم وضع التسمية التلقائي، خطوط الدليل، وتقليل حجم الخط؛ إذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للقيم المتطرفة أو النقاط الرئيسية.

**كيف يمكنني تعطيل التسميات للقيات الصفرية أو السلبية أو الفارغة فقط؟**

قم بترشيح نقاط البيانات قبل تفعيل التسميات وأوقف العرض للقيم التي تساوي 0 أو القيم السلبية أو القيم المفقودة وفق قاعدة محددة.

**كيف يمكنني ضمان تناسق نمط التسمية عند التصدير إلى PDF/صور؟**

حدد عائلة الخط وحجمه صراحةً وتأكد من توفر الخط في بيئة العرض لتجنب الاستخدام البديل.
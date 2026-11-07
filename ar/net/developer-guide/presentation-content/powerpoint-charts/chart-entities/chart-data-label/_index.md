---
title: "إدارة علامات بيانات المخطط في العروض التقديمية في .NET"
linktitle: "علامة البيانات"
type: docs
url: /ar/net/chart-data-label/
keywords:
- مخطط
- علامة البيانات
- دقة البيانات
- نسبة مئوية
- مسافة العلامة
- موضع العلامة
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق علامات بيانات المخطط في عروض PowerPoint باستخدام Aspose.Slides لـ .NET للحصول على شرائح أكثر جاذبية."
---
## **مقدمة**

تقوم علامات البيانات بعرض معلومات حول سلاسل المخطط والنقاط الفردية، مما يساعد القُرّاء على تحديد القيم وفهم المخطط. يوضح هذا المقال كيفيّة تنسيق القيم، وعرض النسب المئوية، وقراءة نص العلامة، والتحكم في العلامات خارج الحد الأقصى للمحور، وضبط المسافة بين علامات محور الفئات، وتحديد موقع علامات مخطط الفطيرة.

## **CountVisibleDataLabels**

استخدم [CountOfVisibleDataLabels](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/countofvisibledatalabels/) للتحقق من عدد علامات البيانات المفعّلة للعرض قبل نشر العرض التقديمي. على عكس [Count](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/count/)، الذي يُعيد إجمالي عدد العلامات في المجموعة، فإنّه يأخذ في الاعتبار الإعدادات الافتراضية للسلاسل وإعدادات العلامة الفردية.

هذا المثال ينشئ مخطط أعمدة بسلسلة واحدة وثلاث نقاط بيانات. يصل إلى مجموعة [Labels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/labels/) الخاصة بالسلسلة ويطبع العدد المرئي مع تغيّر الإعدادات: **0, 3, 2, 3**. يبقى العدد الكلي **3**.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesCell = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

for (int i = 0; i < 3; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var labels = series.Labels;
Console.WriteLine($"Total: {labels.Count}; visible: {labels.CountOfVisibleDataLabels}"); // الإجمالي: 3; مرئي: 0

labels.DefaultDataLabelFormat.ShowValue = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // مرئي: 3

labels[1].DataLabelFormat.ShowValue = false;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // مرئي: 2

labels[1].DataLabelFormat.ShowLegendKey = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // مرئي: 3
```

توفر خاصية [DefaultDataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultdatalabelformat/) الإعدادات الافتراضية. تمكين [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) هناك يعرض القيم لجميع العلامات الثلاث. تعيينها إلى `false` عبر خاصية [DataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/datalabelformat/) لعلامة واحدة يتخطى هذا الإعداد لتلك العلامة. تمكين [ShowLegendKey](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showlegendkey/) يجعل تلك العلامة تُحسب مرئية مرة أخرى، رغم أن قيمتها لا تزال مخفية.

يعكس العدد المرئي إعدادات الرؤية. لا يقيس ما إذا كانت العلامات متداخلة أو مقطوعة أو مقروءة في المخطط المصدّر.

## **SetDataPrecisionInChartDataLabels**

استخدم [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) لتنسيق قيم السلسلة. ينشئ هذا المثال مخطط خط مع بيانات افتراضية، يعرض جدول البيانات الخاص به، ويفعل علامات القيم للسلسلة الأولى. التنسيق `#,##0.00` يعرض فاصل الآلاف ومكانين عشريين دون تغيير القيم الأساسية.

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

لتنسيق الخلايا الرقمية في مصنف مدمج بالمخطط، راجع [Set Custom Number Formats for Workbook Cells](/slides/ar/net/chart-workbook/#set-custom-number-formats-for-workbook-cells). يُظهر ذلك المثال أيضًا علامات القيم وفقًا لتنسيقات خلايا المصدر مع الحفاظ على القيم الرقمية المخزّنة.

## **DisplayPercentageAsLabels**

لإنشاء مخطط أعمدة مكدّس، احسب كل قيمة كنسبة مئوية من إجمالي فئتها وعيّن النص إلى [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). يستخدم هذا المثال بيانات المخطط الافتراضية ويظهر النسب المئوية بمكانين عشريين بخط 8 نقاط. تُتخطى الفئات التي مجموعها صفر لتجنّب القسمة على الصفر. أعد حساب نص العلامة المخصّص إذا تغيّرت بيانات المخطط.

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

## **SetPercentageSignWithChartDataLabels**

عند تخزين القيم ككسور، استخدم [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) لعرض النسب المئوية. عيّن [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) إلى `false` لتطبيق تنسيق العلامة بصورة مستقلة عن خلايا المصدر.

هذا المثال ينشئ مخطط أعمدة مكدس 100% بسلسلتين (أحمر وأزرق) عبر أربع فئات. كل زوج من القيم يساوي 1. تنسيق العلامة `0.0%` يعرض 0.30 كـ30.0%، بينما يستخدم المحور العمودي مكانين عشريين. كلا السلسلتين تستخدم نصًا أبيض بحجم 10 نقاط.

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

## **ReadTheActualTextOfDataLabels**

استخدم [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) لاسترداد النص الناتج عن إعدادات علامة البيانات. يكون ذلك مفيدًا عند استخراج العلامات للتقارير، أو البحث في محتوى العرض التقديمي، أو التحقق من صحة المخططات المولدة. في المثال أدناه، يجمع تنسيق [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) الافتراضي اسم الفئة، اسم السلسلة، والقيمة. تنسّق إحدى النقاط قيمتها كنسبة مئوية، وتستخدم أخرى نصًا مخصّصًا من [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

العدد المخزّن في نقطة البيانات يظل `0.75`، حتى عندما تُظهر علامتها `75%` إلى جانب أسماء الفئة والسلسلة. النص المخصّص يحلّ محل النص المولّد للعلامة. تُعيد [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) سلسلة العلامة الناتجة في كلتا الحالتين. تحقق من [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) بشكل منفصل، كما هو موضح أعلاه، عندما تريد استخراج العلامات المرئية فقط.

## **ControlDataLabelsBeyondTheAxisMaximum**

عند تحديد نطاق محور يدويًا، قد تتجاوز بعض نقاط البيانات الحد الأقصى. استخدم [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) للتحكم فيما إذا كانت علامات بياناتها تُظهر. يغيّر هذا الإعداد رؤية العلامة؛ لا يغيّر نطاق المحور ولا القيم الأساسية.

ينشئ المثال أدناه مخطط أعمدة متكتّف ثنائي الأبعاد بقيم 60 و120. يعيّن [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) إلى `false` و[MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) إلى 100 على المحور العمودي. الشريحة الأولى تسمح بالعلامات خارج الحد الأقصى؛ نسخة تلك الشريحة تُعطّلها. تُحفظ كلتا الشريحتين في `DataLabelsOverMaximum.pptx`.

فعّل علامات القيم باستخدام [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). لا يفعّل الإعداد على مستوى المخطط عرض القيم بنفسه ولا يتجاوز إلغاء تمكين قيمة علامة فردية. يمكّن هذا المثال القيم لكامل السلسلة ويستخدم [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) لوضع العلامات عند الطرف الخارجي لكل عمود.

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

تُظهر الصور التالية الشرائح المحفوظة كما يُظهرها Microsoft PowerPoint. مع `true`، تكون العلامة **120** مرئية عند الحد العلوي؛ مع `false` تُخفى. تظل العلامة **60** مرئية، يبقى الحد الأقصى للمحور **100**، وتظل النقطة الثانية **120** في الحالتين.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![مخطط PowerPoint يُظهر علامة القيمة 120 مع حد محور 100](data-labels-over-maximum-true.png) | ![مخطط PowerPoint يُخفي علامة القيمة 120 مع حد محور 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}

يستخدم هذا المثال مخطط أعمدة ثنائي الأبعاد مع محور قيم. المخططات التي لا تحتوي على محور قيم، مثل مخططات الفطيرة والدونات، لا تمتلك حدًا أقصى للمحور يمكن تقييده بهذه الطريقة.

{{% /alert %}}

## **SetLabelDistanceFromAnAxis**

استخدم [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) للتحكم في المسافة بين علامات محور الفئات والمحور. القيمة هي نسبة من الحد الأقصى لحجم خط علامات المحور. ينشئ هذا المثال مخطط أعمدة متكتّف ويعيّن إزاحة علامة المحور الأفقي إلى 500. يؤثر هذا الإعداد على علامات محور الفئات وليس على العلامات المرتبطة بنقاط البيانات الفردية.

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

## **AdjustLabelLocation**

في مخطط الفطيرة، اضبط مواضع علامات البيانات لتحسين التباعد وإتاحة مساحة لخطوط الربط.

يعرض هذا المثال قيمة أول نقطة بيانات، يضع علامتها خارج الشريحة، ويضبط إزاحتي [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) و[Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) لها. تُقاس هذه الإزاحات بالنسبة إلى عرض وارتفاع المخطط على التوالي.

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

![مخطط فطيرة مع موضع علامة بيانات معدل](pie-chart-adjusted-label.png)

## **FormatLeaderLines**

عند وضع علامات مخطط الفطيرة خارج الشرائح، تساعد خطوط الربط القُرّاء على مطابقة كل قيمة مع الشريحة الصحيحة. يمكن أن تجعل اللون المتباين والخط السميك قليلاً هذه الاتصالات أسهل للمتابعة، بينما تحافظ الشفافية والنمط المتقطّع على عدم بروز الخطوط بصريًا.

استخدم [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) لتنسيق خطوط الربط على مستوى مجموعة علامات بيانات السلسلة. تُطبق الإعدادات في `series.Labels.LeaderLinesFormat.Line` على المجموعة، وليس على علامة فردية.

ينشئ هذا المثال مخطط فطيرة ببيانات افتراضية، يُظهر القيم خارج الشرائح، ويُفعّل [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/). ينقل علامتين أبعد عن الشرائح باستخدام إزاحات [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) و[Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) معبرًا عنها ككسور من عرض وارتفاع المخطط. لا يتطلّب تقديم عرض تقديمي كمدخل.

تُعيّن خاصية الخطّ [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) لونًا أزرقًا صلبًا بقيمة ألفا 191 من 255، ما يُقرّب إلى 25% شفافية. يحدد [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) السماكة بـ2 نقطة، ويجعل [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) الخط متقطّعًا.

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

// تحريك علامتين بعيدًا عن شرائحهما.
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

تمكين خطوط الربط لا يضمن ظهور خط لكل علامة. تعتمد الرؤية على موضع العلامة وسلوك تخطيط المخطط. في هذا المثال، للعلامتين المنقَلتين خطوط ربط مرئية؛ العلامات التي تبقى قريبة من الشرائح لا تحتاجها.

تُظهر الصورة التالية ملف `FormattedLeaderLines.pptx` المُحفظ كما يُظهره Aspose.Slides:

![مخطط فطيرة بخطوط ربط زرقاء، شبه شفافة، متقطّعة تربط علامتين خارجيتين بشرائحهما](formatted-leader-lines.png)

## **AddMultipleRowsOfDataLabelsAboveAColumnChart**

ينشئ هذا المثال مخطط أعمدة مع صفين من علامات البيانات فوق منطقة الرسم. تُظهر السلسلة A الأعمدة المرئية، بينما توفر السلسلة B والسلسلة C العلامات الإضافية. تُخفى أعمدتها بإزالة التعبئة والخط الخارجي. تُحاذى خاصية [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) جميع السلاسل الثلاث إلى مراكز الفئة نفسها.

تُخصص إعدادات [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) مساحة لصفوف العلامات. بعد أن يحسّب [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) المواضع الافتراضية، تحافظ [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) و[Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) على المحاذاة الأفقية وتطبّق إزاحات رأسية لترتيب العلامات في صفين. تظل الأرقام علامات بيانات مرتبطة بقيم السلسلة؛ العناوين الصفية هي أشكال نصية منفصلة.

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
        // إخفاء أعمدة B و C، مع الاحتفاظ بعلامات البيانات الخاصة بهما.
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

// Align all three series with the same category centers.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// Use fewer gridlines for this compact example.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// Reserve space above the plot for two rows of data labels.
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
        // الاحتفاظ بالموقع الأفقي الافتراضي. Y هو إزاحة من
        // موضع العلامة الافتراضي، معبرًا عنه ككسر من ارتفاع المخطط.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // فقط عنوان الصف هو شكل نصي منفصل.
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

![مخطط أعمدة مع صفين من علامات البيانات فوق منطقة الرسم](multiple-rows-of-labels.png)

## **ChangeDataLabelShapes**

تضيف Aspose.Slides for .NET 26.11 الخاصية [IDataLabel.LabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/labelshapetype/) لعلامة واحدة و[IDataLabelCollection.DefaultLabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultlabelshapetype/) لجميع العلامات الحالية في سلسلة. تُغيّر هذه الخاصية شكل العلامة، وليس مؤشر النقطة. للإعداد المنفصل للخطاب، راجع [Data Label Callouts](/slides/ar/net/callout/).

يُحدّث تخصيص المجموعة العلامات الموجودة، لذا طبّق التجاوزات الفردية **بعد** إعداد المجموعة. يتطلّب هذا المثال الكامل [Aspose.Slides for .NET](/slides/ar/net/installation/) 26.11 أو أحدث. ينشئ علامات قيمة مرئية، يختار إهليلجيًا للسلسلة الأولى ثم يجعل علامتها الأولى مستطيلة.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var labels = chart.ChartData.Series[0].Labels;
labels.DefaultDataLabelFormat.ShowValue = true;
labels.DefaultLabelShapeType = ShapeType.Ellipse;
labels[0].LabelShapeType = ShapeType.Rectangle;

foreach (var label in labels)
{
    var format = label.DataLabelFormat.Format;
    format.Fill.FillType = FillType.Solid;
    format.Fill.SolidFillColor.Color = Color.LightYellow;
    format.Line.FillFormat.FillType = FillType.Solid;
    format.Line.FillFormat.SolidFillColor.Color = Color.DarkBlue;
}

presentation.Save("label-shapes.pptx", SaveFormat.Pptx);

// إعادة تعيين اختيار الشكل الصريح لجميع العلامات الحالية.
labels.DefaultLabelShapeType = ShapeType.NotDefined;
presentation.Save("label-shapes-reset.pptx", SaveFormat.Pptx);
```

إعادة تعيين شكل المجموعة مرة أخرى تستبدل خيارات الشكل الفردي السابقة. يُزيل [NotDefined](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) التحديد الصريح للشكل؛ لا يخفي العلامات ولا يمسّ تنسيقها الآخر. عيّن الأشكال المطلوبة بعد تعبئة السلسلة بدلاً من افتراض أن النقاط المضافة لاحقًا ترث التعيين السابق. يُستخدم المستطيل والإهليلج هنا؛ افحص النتيجة المصدّرة عند اختيار أنواع أشكال أخرى.

## **FAQ**

**كيف يمكنني منع تداخل علامات البيانات في المخططات المكتظة؟**

اجمع بين وضع العلامات التلقائي، وخطوط الربط، وتصغير حجم الخط؛ إذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض العلامات فقط للقيم المتطرفة أو النقاط الرئيسية.

**كيف يمكنني تعطيل العلامات للقيم الصفرية أو السلبية أو الفارغة فقط؟**

صنّف نقاط البيانات قبل تفعيل العلامات وأوقف العرض للقيم 0 أو القيم السلبية أو القيم المفقودة وفق قاعدة محددة.

**كيف يمكنني ضمان تنسيق علامة موحد عند التصدير إلى PDF/صور؟**

عيّن صراحة عائلة الخط وحجمه وتأكد من توفر الخط في بيئة التصيير لتجنّب الاعتماد على خط بديل.
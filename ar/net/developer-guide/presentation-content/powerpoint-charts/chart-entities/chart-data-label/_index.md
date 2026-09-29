---
title: إدارة ملصقات بيانات المخطط في العروض التقديمية في .NET
linktitle: ملصق البيانات
type: docs
url: /ar/net/chart-data-label/
keywords:
- مخطط
- ملصق البيانات
- دقة البيانات
- نسبة مئوية
- مسافة الملصق
- موقع الملصق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق ملصقات بيانات المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ .NET للحصول على شرائح أكثر جذبًا."
---
## **المقدمة**

تُظهر ملصقات البيانات معلومات حول سلاسل المخطط ونقاط البيانات الفردية، مما يساعد القارئين على تحديد القيم وفهم المخطط. يشرح هذا المقال كيفية تنسيق القيم، وعرض النسب المئوية، وقراءة نص الملصق، والتحكم في الملصقات التي تتجاوز الحد الأقصى للمحور، وضبط تباعد ملصقات محور الفئات، وتحديد موضع ملصقات مخطط الفطيرة.

## **ضبط دقة البيانات في ملصقات بيانات المخطط**

استخدم [NumberFormatOfValues](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/numberformatofvalues/) لتنسيق قيم السلسلة. يُنشئ هذا المثال مخططًا خطيًا ببيانات افتراضية، يعرض جدول البيانات الخاص به، ويفعل ملصقات القيم للسلسلة الأولى. التنسيق `#,##0.00` يعرض فاصل آلاف ومكانين عشريين دون تغيير القيم الأساسية.

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

## **عرض النسبة المئوية كملصقات**

في مخطط أعمدة مكدس، احسب كل قيمة كنسبة مئوية من إجمالي الفئة الخاصة بها وعيّن النص إلى [TextFrameForOverriding](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). يستخدم هذا المثال بيانات المخطط الافتراضية ويعرض النسب المئوية بمكانين عشريين بخط حجم 8 نقاط. تُتَجاهل الفئات التي إجمالها صفر لتجنب القسمة على صفر. أعد حساب نص الملصق المخصص إذا تغيرت بيانات المخطط.

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

## **ضبط علامة النسبة المئوية مع ملصقات بيانات المخطط**

عند تخزين القيم ككسور، استخدم [NumberFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabelformat/numberformat/) لعرض النسب المئوية. اضبط [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) على `false` لتطبيق تنسيق الملصق بشكل مستقل عن خلايا المصدر.  
يُنشئ هذا المثال مخطط أعمدة مكدس 100% مع سلسلتين أحمر وأزرق عبر أربع فئات. كل زوج من القيم يضيف إلى 1. تنسيق الملصق `0.0%` يعرض 0.30 كـ 30.0%، بينما يستخدم المحور الرأسي مكانين عشريين. تستخدم السلسلتان نص ملصق أبيض بحجم 10 نقاط.

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

## **قراءة النص الفعلي لملصقات البيانات**

استخدم [GetActualLabelText](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabel/getactuallabeltext/) لاسترجاع النص الذي ينتجه إعدادات ملصق البيانات. هذا مفيد عند استخراج الملصقات للتقارير، أو البحث في محتوى العرض التقديمي، أو التحقق من صحة المخططات المُنشأة. في المثال أدناه، يجمع تنسيق [ملصق البيانات الافتراضي](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabelformat/) كل من اسم الفئة، اسم السلسلة، والقيمة. ينسق نقطة واحدة قيمتها كنسبة مئوية، وتستخدم أخرى نصًا مخصصًا من [TextFrameForOverriding](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

العدد المخزن في نقطة البيانات يظل `0.75`، حتى عندما يظهر ملصقه `75%` مع أسماء الفئة والسلسلة. النص المخصص يستبدل النص المُولَّد للملصق. تُعيد [GetActualLabelText](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabel/getactuallabeltext/) سلسلة الملصق الناتجة في الحالتين. تحقق من [IsVisible](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabel/isvisible/) بشكل منفصل، كما هو موضح أعلاه، عندما تريد استخراج الملصقات الظاهرة فقط.

## **التحكم في ملصقات البيانات خارج الحد الأقصى للمحور**

عند قصر نطاق المحور يدويًا، قد تتجاوز بعض نقاط البيانات الحد الأقصى له. استخدم [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) للتحكم فيما إذا كانت ملصقات البيانات الخاصة بها تُظهر أم لا. يغيّر هذا الإعداد ظهور الملصق؛ ولا يغيّر نطاق المحور أو القيم الأساسية للبيانات.  
ينشئ المثال أدناه مخطط أعمدة مجمع ثنائي الأبعاد بقيم 60 و120. يضبط [IsAutomaticMaxValue](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) على `false` و[MaxValue](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/iaxis/maxvalue/) إلى 100 على المحور الرأسي. الشريحة الأولى تسمح بوجود ملصقات تتجاوز الحد الأقصى؛ نسخة من تلك الشريحة تُعطّلها. تُحفظ كلتا الشريحتين في `DataLabelsOverMaximum.pptx`.  
قم بتمكين ملصقات القيم باستخدام [ShowValue](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabelformat/showvalue/). لا يقوم إعداد مستوى المخطط بتمكين عرض القيم بمفرده ولا يتجاوز إيقاف عرض القيمة لملصق فردي. يُمكِّن هذا المثال القيم للسلسلة بأكملها ويستخدم [Position](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabelformat/position/) لوضع الملصقات في الطرف الخارجي لكل عمود.

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

تظهر الصور التالية الشرائح المحفوظة التي تم عرضها بواسطة Microsoft PowerPoint. عندما تكون القيمة `true`، يكون الملصق **120** مرئيًا عند الحد العلوي؛ وعندما تكون `false`، يكون مخفيًا. يظل الملصق **60** مرئيًا، يبقى الحد الأقصى للمحور عند **100**، وتظل نقطة البيانات الثانية **120** في الحالتين.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![مخطط PowerPoint يظهر ملصق القيمة 120 مع حد أقصى للمحور 100](data-labels-over-maximum-true.png) | ![مخطط PowerPoint يخفي ملصق القيمة 120 مع حد أقصى للمحور 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
يستخدم هذا المثال مخطط أعمدة ثنائي الأبعاد مع محور قيم. المخططات التي لا تحتوي على محور قيم، مثل مخططات الفطيرة والدونات، لا تمتلك حدًا أقصى للمحور لتقييده بهذه الطريقة.
{{% /alert %}}

## **ضبط مسافة الملصق عن المحور**

استخدم [LabelOffset](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/iaxis/labeloffset/) للتحكم في المسافة بين ملصقات محور الفئات والمحور. القيمة هي نسبة مئوية من الحد الأقصى لحجم خط ملصقات المحور. يُنشئ هذا المثال مخطط أعمدة مجمع ويضبط إزاحة ملصق المحور الأفقي إلى 500. يؤثر هذا الإعداد على ملصقات محور الفئات بدلاً من الملصقات المرتبطة بنقاط البيانات الفردية.

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

## **ضبط موقع الملصق**

في مخطط الفطيرة، قم بضبط مواضع ملصقات البيانات لتحسين التباعد وإتاحة مساحة لخطوط القائد.  
يعرض هذا المثال قيمة نقطة البيانات الأولى، يضع ملصقها خارج القطعة، ويضبط إزاحات [X](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ilayoutable/x/) و[Y](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ilayoutable/y/). هذه الإزاحات نسبية إلى عرض المخطط وارتفاعه على التوالي.

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

![مخطط فطيرة مع موضع ملصق بيانات معدل](pie-chart-adjusted-label.png)

## **الأسئلة الشائعة**

**كيف يمكنني منع تداخل ملصقات البيانات في المخططات المكتظة؟**  
اجمع بين وضع الملصقات التلقائي، خطوط القائد، وتقليل حجم الخط؛ إذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض الملصقات فقط للقيم المتطرفة أو النقاط الرئيسية.

**كيف يمكنني تعطيل الملصقات للقيم الصفرية أو السلبية أو الفارغة فقط؟**  
قُم بترشيح نقاط البيانات قبل تمكين الملصقات وأوقف العرض للقيم التي تساوي 0، أو القيم السلبية، أو القيم المفقودة وفقًا لقاعدة محددة.

**كيف أضمن نمط ملصق موحد عند التصدير إلى PDF/صور؟**  
حدد عائلة الخط وحجمه صراحةً وتحقق من توفر الخط في بيئة العرض لتجنب الاستبدال.
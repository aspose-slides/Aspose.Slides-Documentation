---
title: إدارة تسميات بيانات المخطط في العروض التقديمية في .NET
linktitle: تسمية البيانات
type: docs
url: /ar/net/chart-data-label/
keywords:
- مخطط
- تسمية البيانات
- دقة البيانات
- نسبة مئوية
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

تُظهر تسميات البيانات معلومات حول سلاسل المخطط والنقاط الفردية، مما يساعد القارئ على تحديد القيم وفهم المخطط. يوضح هذا المقال كيفية تنسيق القيم، وعرض النسب المئوية، وقراءة نص التسمية، وضبط تباعد تسميات محور الفئات، وتحديد موضع تسميات المخطط الدائري.

## **تعيين دقة البيانات في تسميات بيانات المخطط**

استخدم [NumberFormatOfValues](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ichartseries/numberformatofvalues/) لتنسيق قيم السلسلة. يخلق هذا المثال مخطط خط مع بيانات افتراضية، يعرض جدول البيانات الخاص به، ويمكن تسميات القيم للسلسلة الأولى. التنسيق `#,##0.00` يعرض فاصل الآلاف ومكانين عشريين دون تغيير القيم الأساسية.

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

## **عرض النسبة المئوية كعناوين**

في مخطط الأعمدة المتراصة، احسب كل قيمة كنسبة مئوية من إجمالي الفئة الخاصة بها وعيّن النص إلى [TextFrameForOverriding](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). يستخدم هذا المثال بيانات المخطط الافتراضية ويعرض النسب المئوية بمكانين عشريين بخط بحجم 8 نقاط. يتم تخطي الفئات التي يكون مجموعها صفرًا لتجنب القسمة على صفر. أعد حساب نص التسمية المخصص إذا تغيرت بيانات المخطط.

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

عند تخزين القيم ككسرات، استخدم [NumberFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabelformat/numberformat/) لعرض النسب المئوية. عيّن [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) إلى `false` لتطبيق تنسيق التسمية بشكل مستقل عن خلايا المصدر.

ينشئ هذا المثال مخطط أعمدة متراص بنسبة 100٪ مع سلاسل حمراء وزرقاء عبر أربعة فئات. كل زوج من القيم يجموع إلى 1. تنسيق التسمية `0.0%` يعرض 0.30 كـ 30.0٪، بينما يستخدم المحور العمودي مكانين عشريين. كلا السلسلتين تستخدم نص تسمية أبيض بحجم 10 نقاط.

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

استخدم [GetActualLabelText](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabel/getactuallabeltext/) لاسترجاع النص الذي تنتجه إعدادات تسمية البيانات. هذا مفيد عند استخراج التسميات للتقارير، أو البحث في محتوى العرض التقديمي، أو التحقق من صحة المخططات المُنشأة. في المثال أدناه، يجمع تنسيق [تنسيق تسمية البيانات](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabelformat/) الافتراضي كل اسم فئة واسم سلسلة وقيمة. ينسق أحد النقاط قيمته كنسبة مئوية، وآخر يستخدم نصًا مخصصًا من [TextFrameForOverriding](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/).

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

الرقم المخزن في نقطة البيانات يبقى `0.75`، حتى عندما تُظهر تسميته `75%` مع أسماء الفئة والسلسلة. النص المخصص يستبدل نص التسمية المُولَّد. [GetActualLabelText](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabel/getactuallabeltext/) يُعيد سلسلة التسمية الناتجة في كلتا الحالتين. تحقق من [IsVisible](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/idatalabel/isvisible/) بشكل منفصل، كما هو موضح أعلاه، عندما تريد استخراج التسميات الظاهرة فقط.

## **تعيين مسافة التسمية من المحور**

استخدم [LabelOffset](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/iaxis/labeloffset/) للتحكم في المسافة بين تسميات محور الفئات والمحور. القيمة هي نسبة مئوية من الحد الأقصى لحجم الخط لتسميات المحور. ينشئ هذا المثال مخطط أعمدة مجمع ويضبط إزاحة تسمية المحور الأفقي إلى 500. يؤثر هذا الإعداد على تسميات محور الفئات بدلاً من التسميات المرتبطة بالنقاط الفردية.

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

## **ضبط موضع التسمية**

في مخطط دائري، اضبط مواضع تسميات البيانات لتحسين التباعد وإتاحة مساحة لخطوط الربط.

يعرض هذا المثال قيمة أول نقطة بيانات، يضع تسميتها خارج الشريحة، ويضبط إزاحات [X](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ilayoutable/x/) و[Y](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/ilayoutable/y/) الخاصة بها. هذه الإزاحات نسبية إلى عرض المخطط وارتفاعه على التوالي.

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

![مخطط دائري مع موضع تسمية بيانات معدَّل](pie-chart-adjusted-label.png)

## **الأسئلة المتكررة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات المكتظة؟**

استخدم دمج وضعية التسمية التلقائية، وخطوط الربط، وتقليل حجم الخط؛ إذا لزم الأمر، أخفِ بعض الحقول (مثلاً الفئة) أو اعرض التسميات فقط للقيم المتطرفة أو النقاط الرئيسية.

**كيف يمكنني إلغاء تمكين التسميات للقيم الصفرية أو السلبية أو الفارغة فقط؟**

قُم بفلترة نقاط البيانات قبل تمكين التسميات وأوقف العرض للقيم 0 أو القيم السلبية أو القيم المفقودة وفق قاعدة محددة.

**كيف يمكنني ضمان نمط تسمية ثابت عند التصدير إلى PDF/الصور؟**

حدِّد صراحةً عائلة الخط وحجمه وتأكد من توفر الخط في بيئة العرض لتجنب الاستبدال.
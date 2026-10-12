---
title: "مدیریت برچسب‌های داده نمودار در ارائه‌ها در .NET"
linktitle: "برچسب داده"
type: docs
url: /fa/net/chart-data-label/
keywords:
  - "نمودار"
  - "برچسب داده"
  - "دقت داده"
  - "درصد"
  - "فاصله برچسب"
  - "موقعیت برچسب"
  - "PowerPoint"
  - "ارائه"
  - ".NET"
  - "C#"
  - "Aspose.Slides"
description: "یاد بگیرید چگونه برچسب‌های داده نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای .NET اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده اطلاعاتی دربارهٔ سری‌های نمودار و نقاط دادهٔ منفرد نمایش می‌دهند و به خوانندگان کمک می‌کنند مقادیر را شناسایی کرده و نمودار را درک کنند. این مقاله توضیح می‌دهد چگونه مقادیر را قالب‌بندی کنیم، درصدها را نمایش دهیم، متن برچسب را بخوانیم، برچسب‌ها را فراتر از حداکثر محور کنترل کنیم، فاصلهٔ برچسب‌های محور دسته‌بندی را تنظیم کنیم و موقعیت برچسب‌های نمودار دایره‌ای را تعیین کنیم.

## **تنظیم دقت داده در برچسب‌های دادهٔ نمودار**

از [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) برای قالب‌بندی مقادیر سری استفاده کنید. این مثال یک نمودار خطی با دادهٔ پیش‌فرض ایجاد می‌کند، جدول دادهٔ آن را نمایش می‌دهد و برچسب‌های مقدار را برای اولین سری فعال می‌سازد. قالب `#,##0.00` جداکنندهٔ هزارگان و دو رقم اعشار را نشان می‌دهد بدون اینکه مقادیر اصلی تغییر کنند.

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

## **نمایش درصد به عنوان برچسب‌ها**

برای یک نمودار ستونی انباشته، هر مقدار را به عنوان درصدی از مجموع دستهٔ خود محاسبه کنید و متن را به [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) اختصاص دهید. این مثال از دادهٔ پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در فونت 8 پوینت نمایش می‌دهد. دسته‌های با مجموع صفر صرف‌نظر می‌شوند تا از تقسیم بر صفر جلوگیری شود. اگر داده‌های نمودار تغییر کنند، متن برچسب سفارشی را دوباره محاسبه کنید.

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

## **تنظیم نماد درصد با برچسب‌های دادهٔ نمودار**

وقتی مقادیر به صورت کسر ذخیره می‌شوند، از [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) برای نمایش درصدها استفاده کنید. برای اعمال قالب برچسب به‌صورت مستقل از سلول‌های منبع، [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) را روی `false` تنظیم کنید.

این مثال یک نمودار ستونی 100% انباشته با سری‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار مجموعاً برابر 1 است. قالب برچسب `0.0%` مقدار 0.30 را به‌صورت 30.0% نمایش می‌دهد، در حالی که محور عمودی از دو رقم اعشار استفاده می‌کند. هر دو سری از متن برچسب سفید با اندازهٔ 10 پوینت استفاده می‌کنند.

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

## **خواندن متن واقعی برچسب‌های داده**

از [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) برای بازیابی متنی که توسط تنظیمات برچسب داده تولید می‌شود استفاده کنید. این هنگام استخراج برچسب‌ها برای گزارش‌ها، جستجو در محتوای ارائه یا اعتبارسنجی نمودارهای تولیدشده مفید است. در مثال زیر، [قالب پیش‌فرض برچسب داده](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) نام هر دسته، نام سری و مقدار را ترکیب می‌کند. یک نقطه مقدارش را به‌صورت درصد قالب‌بندی می‌کند و دیگری از متن سفارشی از [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) استفاده می‌کند.

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

عدد ذخیره‌شده در یک نقطه داده همچنان `0.75` باقی می‌ماند، حتی اگر برچسب آن `75%` همراه با نام دسته و نام سری را نشان دهد. متن سفارشی متن برچسب تولیدشده را جایگزین می‌کند. [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) رشتهٔ برچسب نهایی را در هر دو حالت برمی‌گرداند. برای استخراج فقط برچسب‌های قابل مشاهده، همان‌طور که در بالا نشان داده شد، [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) را جداگانه بررسی کنید.

## **کنترل برچسب‌های داده فراتر از حداکثر محور**

زمانی که بازهٔ محور را به‌صورت دستی محدود می‌کنید، ممکن است برخی نقاط داده از حداکثر آن عبور کنند. از [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) برای کنترل نمایش برچسب‌های دادهٔ آن‌ها استفاده کنید. این تنظیم قابلیت دیدن برچسب‌ها را تغییر می‌دهد؛ بازهٔ محور یا مقادیر دادهٔ اصلی را تغییر نمی‌دهد.

مثال زیر یک نمودار ستونی خوشه‌ای دو بُعدی با مقادیر 60 و 120 ایجاد می‌کند. بر روی محور عمودی، [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) را روی `false` و [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) را روی 100 تنظیم می‌کند. اسلاید اول اجازه می‌دهد برچسب‌ها فراتر از حداکثر باشند؛ نسخه‌ای از آن اسلاید این قابلیت را غیرفعال می‌کند. هر دو اسلاید در `DataLabelsOverMaximum.pptx` ذخیره می‌شوند.

برچسب‌های مقدار را با [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) فعال کنید. تنظیم سطح نمودار به‌تنهایی نمایش مقدار را فعال نمی‌کند و نمایش مقدار غیرفعال شدهٔ یک برچسب را نادیده نمی‌گیرد. این مثال مقادیر را برای تمام سری فعال می‌کند و از [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) برای قرار دادن برچسب‌ها در انتهای بیرونی هر ستون استفاده می‌کند.

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

تصاویر زیر اسلایدهای ذخیره‌شده را که توسط Microsoft PowerPoint رندر شده‌اند نشان می‌دهند. با مقدار `true`، برچسب **120** در حدود بالایی قابل مشاهده است؛ با مقدار `false`، مخفی می‌شود. برچسب **60** همچنان قابل مشاهده است، حداکثر محور در **100** باقی می‌ماند و نقطه دادهٔ دوم در هر دو حالت **120** می‌ماند.

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 نشان می‌دهد](data-labels-over-maximum-true.png) | ![نمودار PowerPoint که برچسب مقدار 120 را با حداکثر محور 100 مخفی می‌کند](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
این مثال از یک نمودار ستونی دو بُعدی با محور مقدار استفاده می‌کند. نمودارهایی که محور مقدار ندارند، مانند نمودارهای دایره‌ای و دونات، حداکثر محوری برای محدود کردن به این شکل ندارند.
{{% /alert %}}

## **تنظیم فاصله برچسب از محور**

از [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) برای کنترل فاصلهٔ بین برچسب‌های محور دسته‌بندی و محور استفاده کنید. مقدار این گزینه درصدی از حداکثر اندازهٔ قلم برچسب‌های محور است. این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند و فاصلهٔ برچسب محور افقی را روی 500 تنظیم می نماید. این تنظیم بر برچسب‌های محور دسته‌بندی اثر می‌گذارد نه بر برچسب‌های مربوط به نقاط دادهٔ منفرد.

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

## **تنظیم موقعیت برچسب**

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده را تنظیم کنید تا فضای بیشتری برای خطوط راهنما ایجاد شود.

این مثال مقدار اولین نقطه داده را نمایش می‌دهد، برچسب آن را خارج از قطعه قرار می‌دهد و انحرافات [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) و [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) آن را تنظیم می‌کند. این انحرافات به ترتیب نسبت به عرض و ارتفاع نمودار می‌باشند.

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

![نمودار دایره‌ای با موقعیت تنظیم‌شده برچسب داده](pie-chart-adjusted-label.png)

## **افزودن ردیف‌های متعدد برچسب داده بالای یک نمودار ستونی**

این مثال یک نمودار ستونی با دو ردیف برچسب داده در بالای ناحیهٔ رسم ایجاد می‌کند. سری A ستون‌های قابل مشاهده را نشان می‌دهد، در حالی که سری‌های B و C برچسب‌های اضافی را فراهم می‌کنند. ستون‌های آن‌ها با حذف پرش و خط مرزی مخفی می‌شوند. ویژگی [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) تمام سه سری را با مراکز دستهٔ یکسان هم‌تراز می‌کند.

تنظیمات [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) فضا را برای ردیف‌های برچسب رزرو می‌کند. پس از محاسبهٔ موقعیت‌های پیش‌فرض توسط [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/)، [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) و [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) هم‌راستاگی افقی را حفظ کرده و انحرافات عمودی را برای ترتیب برچسب‌ها در دو ردیف اعمال می‌کنند. اعداد همچنان برچسب‌های دادهٔ مرتبط با مقادیر سری‌ها باقی می‌مانند؛ فقط سرستون‌های ردیف به عنوان شکل‌های متن جداگانه هستند.

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
        // ستون‌های B و C را مخفی کنید، اما برچسب‌های داده‌ی آن‌ها را نگه دارید.
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

// هم‌ترازی تمام سه سری با مراکز دسته‌ی یکسان.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// استفاده از خطوط شبیه‌ساز کمتر برای این مثال فشرده.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// رزرو فضا بالای ناحیه‌ی رسم برای دو ردیف برچسب داده.
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
        // حفظ موقعیت افقی پیش‌فرض.
        // Y به عنوان فاصله‌ای از موقعیت پیش‌فرض برچسب، به صورت کسر ارتفاع نمودار بیان می‌شود.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // فقط عنوان ردیف به عنوان یک شکل متن جداگانه است.
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

![نمودار ستونی با دو ردیف برچسب داده بالای ناحیهٔ رسم](multiple-rows-of-labels.png)

## **سوالات متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده در نمودارهای پر تراکم جلوگیری کنم؟**  
از ترکیب قرارگیری خودکار برچسب، خطوط راهنما و کاهش اندازه قلم استفاده کنید؛ در صورت نیاز برخی فیلدها (مثلاً دسته) را مخفی کنید یا فقط برچسب‌ها را برای مقادیر انتهایی یا نقاط کلیدی نمایش دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**  
قبل از فعال‌سازی برچسب‌ها نقاط داده را فیلتر کنید و نمایش مقادیر 0، مقادیر منفی یا مقادیر خالی را طبق یک قانون تعریف‌شده غیرفعال کنید.

**چگونه می‌توانم سبک برچسب ثابت را هنگام خروجی گرفتن به PDF/تصاویر تضمین کنم؟**  
قلم خانواده و اندازه را به‌صورت صریح تنظیم کنید و اطمینان حاصل کنید که قلم در محیط رندر موجود است تا از استفاده از قلم پیش‌فرض جلوگیری شود.
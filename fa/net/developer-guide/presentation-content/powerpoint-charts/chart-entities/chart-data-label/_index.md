---
title: مدیریت برچسب‌های داده‌ای نمودار در ارائه‌ها در .NET
linktitle: برچسب داده‌ای
type: docs
url: /fa/net/chart-data-label/
keywords:
- نمودار
- برچسب داده‌ای
- دقت داده
- درصد
- فاصله برچسب
- موقعیت برچسب
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌های داده‌ای نمودار را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای .NET اضافه و قالب‌بندی کنید تا اسلایدهای جذاب‌تری داشته باشید."
---
## **مقدمه**

برچسب‌های داده‌ای اطلاعاتی دربارهٔ سری‌های نمودار و نقاط داده‌ای مجزا نمایش می‌دهند و به خوانندگان کمک می‌کنند تا مقادیر را شناسایی کرده و نمودار را درک کنند. این مقاله توضیح می‌دهد که چگونه مقادیر را قالب‌بندی کنید، درصدها را به‌صورت برچسب نمایش دهید، متن برچسب را بخوانید، فاصله برچسب‌های محور دسته‌بندی را تنظیم کنید و برچسب‌های نمودار دایره‌ای را موقعیت‌دهی کنید.

## **تنظیم دقت داده‌ها در برچسب‌های داده‌ای نمودار**

از [NumberFormatOfValues](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/numberformatofvalues/) برای قالب‌بندی مقادیر سری استفاده کنید. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند، جدول داده‌های آن را نمایش می‌دهد و برچسب‌های مقدار را برای اولین سری فعال می‌سازد. قالب `#,##0.00` جداکنندهٔ هزارگان و دو رقم اعشار را بدون تغییر مقادیر پایه نمایش می‌دهد.

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

## **نمایش درصد به‌عنوان برچسب‌ها**

برای یک نمودار ستون‌پشته‌ای، هر مقدار را به‌عنوان درصدی از مجموع دستهٔ خود محاسبه کنید و متن را به [TextFrameForOverriding](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) اختصاص دهید. این مثال از داده‌های پیش‌فرض نمودار استفاده می‌کند و درصدها را با دو رقم اعشار در قلم ۸ نقطه‌ای نمایش می‌دهد. دسته‌هایی که مجموعشان صفر است برای جلوگیری از تقسیم بر صفر نادیده گرفته می‌شوند. اگر داده‌های نمودار تغییر کنند، متن برچسب سفارشی را دوباره محاسبه کنید.

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

## **تنظیم علامت درصد در برچسب‌های داده‌ای نمودار**

زمانی که مقادیر به‌صورت کسر ذخیره می‌شوند، از [NumberFormat](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/idatalabelformat/numberformat/) برای نمایش درصدها استفاده کنید. با تنظیم [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) روی `false` قالب برچسب به‌صورت مستقل از سلول‌های منبع اعمال می‌شود.

این مثال یک نمودار ستون‌پشته ۱۰۰٪ با سری‌های قرمز و آبی در چهار دسته ایجاد می‌کند. هر جفت مقدار مجموعاً برابر ۱ است. قالب برچسب `0.0%` مقدار ۰.۳۰ را به‌صورت ۳۰.۰٪ نمایش می‌دهد، در حالی که محور عمودی از دو رقم اعشار استفاده می‌کند. هر دو سری از متن برچسب سفید با اندازهٔ ۱۰ نقطه استفاده می‌کنند.

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

## **خواندن متن واقعی برچسب‌های داده‌ای**

از [GetActualLabelText](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/idatalabel/getactuallabeltext/) برای بازیابی متنی که توسط تنظیمات برچسب داده‌ای تولید می‌شود استفاده کنید. این عملکرد هنگام استخراج برچسب‌ها برای گزارش‌ها، جستجو در محتوای ارائه یا اعتبارسنجی نمودارهای تولیدی مفید است. در مثال زیر، قالب پیش‌فرض [data label format](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/idatalabelformat/) نام هر دسته، نام سری و مقدار را ترکیب می‌کند. یک نقطه مقدار خود را به‌صورت درصد قالب‌بندی می‌کند و دیگری از متن سفارشی [TextFrameForOverriding](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) استفاده می‌کند.

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

عدد ذخیره‌شده در یک نقطهٔ داده‌ای همچنان `0.75` باقی می‌ماند، حتی وقتی برچسب آن `75%` به‌همراه نام‌های دسته و سری را نشان می‌دهد. متن سفارشی متن تولید شدهٔ برچسب را جایگزین می‌کند. [GetActualLabelText](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/idatalabel/getactuallabeltext/) در هر دو حالت رشتهٔ برچسب نهایی را برمی‌گرداند. همان‌طور که در بالا نشان داده شد، برای استخراج فقط برچسب‌های قابل مشاهده، به‌صورت جداگانه [IsVisible](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/idatalabel/isvisible/) را بررسی کنید.

## **تنظیم فاصله برچسب از محور**

از [LabelOffset](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/iaxis/labeloffset/) برای کنترل فاصله بین برچسب‌های محور دسته‌بندی و خود محور استفاده کنید. مقدار این ویژگی درصد حداکثر اندازهٔ قلم برچسب‌های محور است. این مثال یک نمودار ستون خوشه‌ای ایجاد می‌کند و فاصلهٔ برچسب محور افقی را روی ۵۰۰ تنظیم می‌نماید. این تنظیم برچسب‌های محور دسته‌بندی را تحت تأثیر قرار می‌دهد نه برچسب‌های متصل به نقاط داده‌ای منفرد.

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

در یک نمودار دایره‌ای، موقعیت برچسب‌های داده‌ای را تنظیم کنید تا فضا بهبود یابد و جای خطوط رهبری (leader lines) باقی بماند.

این مثال مقدار اولین نقطهٔ داده‌ای را نمایش می‌دهد، برچسب آن را خارج از برش قرار می‌دهد و جابه‌جایی‌های [X](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ilayoutable/x/) و [Y](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ilayoutable/y/) را تنظیم می‌کند. این جابه‌جایی‌ها به ترتیب نسبت به عرض و ارتفاع نمودار محسوب می‌شوند.

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

![نقشهٔ دایره‌ای با موقعیت برچسب داده‌ای تنظیم‌شده](pie-chart-adjusted-label.png)

## **سؤال‌های متداول**

**چگونه می‌توانم از هم‌پوشانی برچسب‌های داده‌ای در نمودارهای پرتراکم جلوگیری کنم؟**

از ترکیب قراردهی خودکار برچسب، خطوط رهبری و کاهش اندازهٔ قلم استفاده کنید؛ در صورت نیاز برخی فیلدها (مثلاً دسته) را مخفی کنید یا فقط برای مقادیر افراطی یا نقاط کلیدی برچسب نمایش دهید.

**چگونه می‌توانم برچسب‌ها را فقط برای مقادیر صفر، منفی یا خالی غیرفعال کنم؟**

نقاط داده‌ای را قبل از فعال‌سازی برچسب‌ها فیلتر کنید و نمایش را برای مقادیر ۰، مقادیر منفی یا مقادیر گمشده بر اساس قاعده‌ای تعریف‌شده خاموش کنید.

**چگونه می‌توانم سبک برچسب یکسانی هنگام خروجی به PDF/تصاویر تضمین کنم؟**

خانواده و اندازهٔ قلم را به‌طور صریح تنظیم کنید و اطمینان حاصل کنید که قلم در محیط رندرینگ در دسترس است تا از استفادهٔ قلم پیش‌فرض جلوگیری شود.
---
title: مدیریت سری‌های داده نمودار در ارائه‌ها در .NET
linktitle: سری‌های داده
type: docs
url: /fa/net/chart-series/
keywords:
- سری نمودار
- هم‌پوشانی سری
- رنگ سری
- رنگ دسته
- نام سری
- نقطه داده
- فاصله سری
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "با C# یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، هم‌پوشانی، عرض شکاف و مقادیر منفی را در ارائه‌ها مدیریت کنید."
---
## **نمای کلی**

یک نمودار می‌تواند مقادیر رسم‌شده خود را در سلول‌های کتاب‌کار یا به‌صورت مستقیم به‌عنوان مقادیر عددی ثابت ذخیره کند. یک [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) نمایانگر یک مجموعه از مقادیر مرتبط است و هر [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) نمایانگر یک نقطه در آن مجموعه است. اشیاء [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین مجموعه‌ها را فراهم می‌کنند. در نمودارهایی که با داده‌های پیش‌فرض ایجاد می‌شوند، نام‌های مجموعه، دسته‌ها و مقادیر نقاط از اشیاء [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) کتاب‌کار نمودار استفاده می‌کنند.

برای یک نمودار دسته‌ای معمول، کتاب‌کار پیش‌فرض از ردیف 0 برای نام‌های مجموعه، ستون 0 برای نام‌های دسته و بقیه سلول‌ها برای مقادیر مجموعه استفاده می‌کند. ایندکس‌های برگه کاری، ردیف و ستون که به [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) پاس می‌شوند، صفر‑مبتنی هستند. این چیدمان زمانی مفید است که نموداری با داده‌های پیش‌فرض بسازید، اما فرض نکنید که تمام نمودارهای موجود از آن استفاده می‌کنند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب‌کار سلول‌های ارجاع دهده شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار در سه دامنه متفاوت قرار دارند:

- تنظیمات در سطح مجموعه، مانند [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)، ظاهر پیش‌فرض همه نقاط یک مجموعه را تعیین می‌کند.
- تنظیمات نقطه داده، مانند [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی برای مجموعه‌های سازگاری که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) تعلق دارند، اعمال می‌شود. برای تنظیم گزینه‌هایی مانند هم‌پوشانی یا عرض شکاف، از [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) استفاده کنید.

زمانی که پر کردن صریحی برای نقطه یا مجموعه تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات مجموعه و هم تنظیمات نقطه وجود داشته باشد، تنظیمات نقطه برای آن نقطه اولویت دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

برای یک نمودار استوانه‌ای خوشه‌ای، نگاه کنید که چگونه [تغییر نوع سری ۳D یا شکل میله](/slides/fa/net/3d-chart/#change-the-3d-series-type-and-bar-shape) بر اولین سری تأثیر می‌گذارد.

## **تنظیم مقادیر سری با مقادیر عددی ثابت**

وقتی مقادیر سری از داده‌های برنامه یا محاسبات می‌آیند و نیازی به ارجاع به سلول‌های برگه کاری ندارند، از مقادیر عددی ثابت استفاده کنید. قبل از اختصاص [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) هر نقطه، [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) را به [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) تنظیم کنید و از [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/) استفاده کنید.

تنظیم مجموعه، نوع منبع تمام مقادیر نقاط در همان سری را کنترل می‌کند. [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) هر نقطه نوع انتخاب‌شده را گزارش می‌دهد؛ آن را از طریق تنظیم مجموعه تغییر دهید. با `Worksheet`، برای دسترسی به سلول ارجاع‌شده از [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) استفاده کنید. با `DoubleLiterals`، از `AsLiteralDouble` برای خواندن یا نوشتن مستقیم عدد استفاده کنید.

مثال زیر یک نمودار ستونی با مجموعه‌ها و دسته‌های پیش‌فرض ایجاد می‌کند، سپس مقادیر محاسبه‌شده 10، 20 و غیره را به نقاط موجود اولین سری اختصاص می‌دهد. پس از ذخیره ارائه، آن را دوباره باز می‌کند و مقادیر ذخیره‌شده را چاپ می‌کند.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

نوع منبع مقدار نقطه جدا از [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/) است که پیکربندی کتاب‌کار داخلی یا خارجی نمودار را شناسایی می‌کند. استفاده از مقادیر عددی ثابت به‌تنهایی کتاب‌کار توکار را حذف نمی‌کند. در این مثال، کتاب‌کار برای برچسب‌های دسته، نام‌های مجموعه و سایر مجموعه‌ها در دسترس می‌ماند. برای مدیریت کتاب‌کار به [Workbook نمودار](/slides/fa/net/chart-workbook/) مراجعه کنید.

برای نمودارهای پراکندگی و حباب، [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) و [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) را تنظیم کنید تا منابع برای [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) و [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) انتخاب شوند. نمودارهای حباب همچنین از [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) برای [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/) استفاده می‌کنند. هر منبع مربوطه را قبل از اختصاص اعداد به ویژگی `AsLiteralDouble` مربوطه، به `DoubleLiterals` تنظیم کنید.

## **تنظیم هم‌پوشانی سری نمودار**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) نشان می‌دهد که میله‌ها یا ستون‌ها در یک نمودار ۲D تا چه اندازه با هم هم‌پوشانی دارند؛ مقدار از ‑۱۰۰ تا ۱۰۰ درصد است. این یک تصویر فقط‑خواندنی از تنظیمات گروه سری والد است. برای به‌روز کردن تمام مجموعه‌های سازگار در همان گروه، [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) را تنظیم کنید. این گزینه فقط برای انواع نموداری که میله‌ها یا ستون‌های گروهی را نمایش می‌دهند، اعمال می‌شود؛ در نمودار ترکیبی بر گروه‌های سری نامرتبط تأثیری ندارد.

مثال زیر هم‌پوشانی گروهی که شامل اولین سری است را تنظیم می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// نمودار جدید شامل سری‌های نمونه، دسته‌ها و مقادیر است.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

نتیجه:

![The series overlap](series_overlap.png)

## **تغییر رنگ پر کردن سری**

از [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) برای تنظیم پر کردن پیش‌فرض تمام سری استفاده کنید. اگر برای یک نقطه پر کردن صریحی تنظیم شده باشد، تنظیمات [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) رنگ پر کردن آن نقطه را بازنویسی می‌کند.

مثال زیر پر کردن آبی سالی‌دار را به اولین سری اعمال می‌کند:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

نتیجه:

![The color of the series](series_color.png)

## **تغییر نام سری**

نام یک سری در کتاب‌کار داده‌های نمودار ذخیره می‌شود و معمولاً در افسانه نمایش داده می‌شود. در کتاب‌کار پیش‌فرض که برای یک نمودار ستونی خوشه‌ای ایجاد می‌شود، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین سری را دارد. ثابت‌های نامگذاری در مثال زیر این ساختار را صریح می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

همچنین می‌توانید سلولی را که توسط [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) ارجاع شده است، به‌روزرسانی کنید. این رویکرد از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

نتیجه:

![The series name](series_name.png)

### **ایجاد سری با نامی ترکیبی از چند سلول**

یک نام سری ترکیبی وقتی مفید است که نام محصول و دوره گزارش در سلول‌های جداگانه کتاب‌کار ذخیره شوند. به‌عنوان مثال، می‌توانید `Product A` در B1 و `2026` در C1 را در یک نام سری ترکیب کنید در حالی که هر دو بخش به سلول‌های منبع خود پیوند دارند.

از [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) برای دریافت بازه نام استفاده کنید، سپس آن مجموعه را به [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/) پاس دهید. پارامتر `skipHiddenCells` تعیین می‌کند آیا سلول‌های مخفی شامل شوند یا نه: `true` آن‌ها را حذف می‌کند، `false` شامل می‌شود. این مثال از `false` برای شامل کردن همه سلول‌های بازه نام استفاده می‌کند.

مثال زیر یک ارائه با یک سری و دو نقطه داده ایجاد می‌کند. سلول‌های B1:C1 فقط نام سری را فراهم می‌کنند؛ A2:A3 برچسب‌های دسته را فراهم می‌کنند و B2:B3 مقادیر عددی را فراهم می‌کنند.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// این دو سلول نام سری را ارائه می‌دهند.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// Separate cells supply the categories and numeric data points.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

نام سری حاصل `Product A 2026` است که بین دو مقدار سلولی یک فاصله دارد. افسانه این را به‌عنوان یک ورودی برای هر دو ستون نمایش می‌دهد. تصویر زیر از ارائه ذخیره‌شده رندر شده است:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **دریافت رنگ پر کردن خودکار سری**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) رنگی را که بر اساس اندیس سری و سبک نمودار محاسبه می‌شود، برمی‌گرداند. این همان رنگی است که وقتی پر کردن سری به‌طور صریح تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ رنگ جدیدی را اعمال نمی‌کند.

مثال زیر رنگ خودکار هر سری پیش‌فرض را چاپ می‌کند:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

خروجی نمونه برای سبک پیش‌فرض نمودار:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

رنگ‌های دقیق بسته به سبک و تم نمودار متفاوت هستند.

## **تنظیم رنگ پر کردن معکوس برای یک سری نمودار**

برای سری‌های میله، ستون و حباب، می‌توانید [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) را فعال کنید تا مقادیر منفی با رنگ پر کردن متفاوتی نمایش داده شوند. پر کردن عادی سری را به‌صورت سالی‌دار تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ منفی را از طریق [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) اختصاص دهید. اعداد منفی در کتاب‌کار بدون تغییر می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 برگه کاری نام سری را دارد، ستون 0 نام‌های دسته و ستون 1 مقادیر را دارد:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

نتیجه:

![The inverted solid fill color](inverted_solid_fill_color.png)

می‌توانید معکوس‌سازی را برای یک نقطه از طریق [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) فعال کنید. در مثال زیر معکوس‌سازی برای سری غیرفعال و فقط برای نقطه انتخاب‌شده فعال می‌شود. همچنین به نقطه مقدار منفی اختصاص داده می‌شود تا اثر قابل مشاهده باشد:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **پاک‌سازی مقدار یک نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول کتاب‌کار پشت آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار رسم‌شده از طریق [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات مقدار خالی نمودار به‌عنوان خالی در نظر می‌گیرد.

مثال زیر فقط نقطه دوم اولین سری را پاک می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

نمودارهای پراکندگی از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حباب نیز از یک سلول اندازه استفاده می‌کنند. فقط سلولی را که نمایانگر مقداری است که می‌خواهید حذف کنید، پاک کنید. وقتی می‌خواهید نقاط دیگر را نگه دارید، از [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) استفاده نکنید، زیرا این متد تمام نقاط را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که مقدار دارند، موردی متفاوت از سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی برگه کاری، به [شمول داده‌ها از ردیف‌ها و ستون‌های مخفی](/slides/fa/net/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول خالی کتاب‌کار نمایانگر فقدان داده است؛ سلولی که مقدار `0` دارد، نمایانگر مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) را به `null` تنظیم کنید. صفر عددی همچنان صفر می‌ماند، صرف‌نظر از تنظیم خالی‑سلول.

از [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) برای انتخاب نحوه نمایش سلول‌های خالی استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. آن نحوه رسم خالی‌ها را تغییر می‌دهد بدون اینکه سلول خالی کتاب‌کار با صفر یا مقدار میانی پر شود.

مثال زیر یک نمودار خطی با یک سری ایجاد می‌کند، مقدار Day 3 را خالی می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. هیچ فایل ورودی‌ای لازم نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) از برگه 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام سری را دارد. داده نهایی `10, 20, empty, 30, 40` است.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// روز سوم را به‌طور واقعی خالی بگذارید، در حالی که دسته‌بندی و نقطه دادهٔ آن را نگه می‌دارید.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

هر فایل خروجی حالت انتخاب‌شده قبل از ذخیره را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیره فقط یک نسخه، حالت موردنظر را تنظیم کنید و یک بار ارائه را ذخیره کنید به‌جای اینکه بر تمام حالت‌ها تکرار کنید.

مقایسه زیر همان داده را در هر سه فایل نشان می‌دهد. Day 3 در هر سه مورد در کتاب‌کار خالی است:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

اثر قابل مشاهده بسته به نوع نمودار متفاوت است. یک نمودار خطی همه سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای میله و ستون خطی برای اتصال بین دسته‌های گمشده ندارند، بنابراین `Span` نمی‌تواند بخش اتصال نشان داده‌شده در بالا را تولید کند؛ یک ستون گمشده و یک ستون صفر طول می‌تواند مشابه به هم به‌نظر برسند. به‌طور مشابه، یک نمودار پراکندگی فقط با نشانگرها خط متصل‌کننده‌ای ندارد. انتظار نتایج سه‌گانه متفاوت برای هر نوع نمودار نباشید؛ خروجی را برای نوع نموداری که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض شکاف سری**

عرض شکاف فضای بین خوشه‌های میله یا ستون مجاور است که به‌صورت درصدی از عرض میله یا ستون بیان می‌شود. مشابه هم‌پوشانی، این تنظیم به گروه سری والد تعلق دارد نه به یک سری. برای کل گروه یک بار [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) را تنظیم کنید. مقدار بزرگتر فضای بین خوشه‌ها را بیشتر می‌کند؛ مقدار کوچک‌تر آنها را متراکم‌تر می‌سازد.

مثال زیر عرض شکاف را تغییر می‌دهد و فقط ارائه نهایی را ذخیره می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

نتیجه:

![The gap width](gap_width.png)

## **نمایش یا پنهان‌سازی خطوط سری**

خطوط سری به‌صورت بصری قسمت‌های مرتبط یک نمودار را به هم وصل می‌کنند. از [IChartSeriesGroup.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hasserieslines/) برای نمایش یا پنهان‌سازی این خطوط در نمودارهای میلهٔ پشته‌ای و OfPie پشتیبانی‌شده استفاده کنید. در نمودارهای میله و ستون پشته‌ای دو‑بعدی، این خطوط مرزهای پشته‌های متناظر را بین دسته‌ها وصل می‌کنند. در نمودارهای Pie of Pie و Bar of Pie، این خطوط نمودار اصلی را به نمودار ثانویه متصل می‌کنند. این تنظیم برای سایر انواع نمودارهای عمومی کاربرد ندارد.

از گروه از طریق [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) دسترسی پیدا کنید. این تنظیم برای هر سری در آن گروه اعمال می‌شود. [IChartSeries.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/hasserieslines/) فقط‑خواندنی است و تنظیمات گروه والد را منعکس می‌کند؛ برای به‌روزرسانی آن، ویژگی گروه را تغییر دهید.

مثال زیر یک نمودار [PieOfPie](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) با داده‌های پیش‌فرض ایجاد می‌کند. سپس همان نمودار را ابتدا با خطوط سری فعال و سپس غیرفعال ذخیره می‌کند تا دو ارائه برای مقایسه داشته باشید.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 400);
var series = chart.ChartData.Series[0];
var seriesGroup = series.ParentSeriesGroup;

seriesGroup.HasSeriesLines = true;
presentation.Save("series_lines_enabled.pptx", SaveFormat.Pptx);

seriesGroup.HasSeriesLines = false;
presentation.Save("series_lines_disabled.pptx", SaveFormat.Pptx);
```

| خطوط سری فعال | خطوط سری غیرفعال |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| دو خط، پای اصلی را به پای ثانویه متصل می‌کنند. | هر دو پای قابل رؤیت هستند، اما خطوط اتصال مخفی شده‌اند. |

خطوط سری با خطوط رهبری برچسب‌ داده، خطوط شبکه، و خطوط در یک نمودار خط که نمایانگر مقادیر داده هستند، متفاوت هستند. این تنظیم این عناصر را کنترل نمی‌کند.

## **سؤالات متداول**

**کدام انواع نمودار از سری داده پشتیبانی می‌کنند؟**

همه انواع نمودارهای معرفی‌شده توسط شمارش [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) از داده‌های نمودار استفاده می‌کنند، اما ساختار یا تنظیمات مقدار سری برای همه یکسان نیست. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حباب از اندازهٔ حباب‌ها بهره می‌برند. روش ایجاد نقطه داده‌ای را که با نوع سری مطابقت دارد، استفاده کنید. گزینه‌هایی مانند هم‌پوشانی و عرض شکاف فقط برای گروه‌های میله یا ستون سازگار اعمال می‌شوند.

**گروه سری نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات رسم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروه دسترسی‑یافته از طریق یک سری لزوماً همه سری‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‑ساخته شامل داده‌های پیش‌فرض است؟**

بله. به‌صورت پیش‌فرض، [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) سری‌ها، دسته‌ها و مقادیر نمونه‌ای ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه سری و دسته را پاک کنید. یک overload نیز می‌تواند نمودار را بدون داده‌های پیش‌فرض ایجاد کند.

**چگونه اشیای نمودار به سلول‌های کتاب‌کار متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده المان مربوط به نمودار را به‌روزرسانی می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقدار سری را هم‌تراز نگهدارید تا هر نقطه زیر دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را به‌جای تمام سری پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی باقی بماند. فقط وقتی می‌خواهید تمام نقاط یک سری را حذف کنید، از [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) استفاده کنید؛ این روش تمام نقاط مجموعه را حذف می‌کند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه بسته به نوع نمودار و [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) متفاوت است. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت شکاف، مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که با معنای داده‌های گمشده در ارائهٔ شما همخوانی داشته باشد. برای مثال کامل و مقایسهٔ بصری، به [کنترل نمایش سلول‌های خالی](#control-the-display-of-empty-cells) مراجعه کنید.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های میله، ستون و حباب پشتیبانی‌شده، [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) را فعال کنید و [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ جداگانه با [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) بازنویسی کنید. این ویژگی‌ها فقط قالب‌بندی را تحت‌تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**کدام قالب‌بندی برنده است وقتی هم سری و هم نقطه قالب‌بندی شده باشند؟**

قالب‌بندی صریح نقطه داده برای همان نقطه اولویت دارد. نقاط دیگر همچنان از قالب‌بندی صریح سری یا، وقتی قالب‌بندی سری تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. ویژگی‌های گروهی مانند هم‌پوشانی و عرض شکاف طرح‌بندی را کنترل می‌کنند و بازنویسی قالب‌بندی در سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد معقول هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد نزدیک یا دور از یک‌دیگر هستند؟**

[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) را در گروه والد مناسب تنظیم کنید. برای افزایش فاصله بین خوشه‌ها مقدار را بزرگ کنید و برای نزدیک‌تر کردن خوشه‌ها مقدار را کوچک کنید.
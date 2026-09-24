---
title: مدیریت مجموعه داده‌های نمودار در ارائه‌ها با .NET
linktitle: سری داده‌ها
type: docs
url: /fa/net/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
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
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های دفتر کاری، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با C# مدیریت کنید."
---
## **بررسی کلی**

یک نمودار داده‌های ترسیم شده خود را در یک دفتر کاری داده‌های نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/) یک مجموعه از مقادیر مرتبط را نشان می‌دهد و هر [IChartDataPoint](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/) در این سری به یک یا چند سلول دفتر کاری اشاره می‌کند. اشیاء [IChartCategory](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین سری‌ها را فراهم می‌کنند. به همین دلیل نام سری، دسته‌ها و مقادیر نقاط به اشیاء [IChartDataCell](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/) متصل هستند نه اینکه فقط به‌عنوان متن نمایش ذخیره شوند.

برای یک نمودار دسته‌ای معمولی، دفتر کاری پیش‌فرض از ردیف 0 برای نام‌های سری، ستون 0 برای نام‌های دسته و سلول‌های باقی‌مانده برای مقادیر سری استفاده می‌کند. اندیس‌های شیت، ردیف و ستون که به [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/getcell/) پاس داده می‌شوند، صفر‑مبنا هستند. این چیدمان هنگام ساختن نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر دفتر کاری، سلول‌های مرجع توسط سری‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه حوزه مختلف هستند:

- تنظیمات سطح سری، مانند [IChartSeries.Format](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/format/)، ظاهر پیش‌فرض برای همه نقاط در یک سری را فراهم می‌کنند.
- تنظیمات نقطه داده، مانند [IChartDataPoint.Format](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/format/)، ظاهر سری را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی به سری‌های سازگاری که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/) تعلق دارند، اعمال می‌شود. برای تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله، از [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/parentseriesgroup/) استفاده کنید.

زمانی که پر کردن صریح برای نقطه یا سری تعیین نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کنند. وقتی هر دو قالب‌بندی سری و نقطه موجود باشد، قالب‌بندی نقطه برای آن نقطه اولویت دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری نمودار**

[IChartSeries.Overlap](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/overlap/) مقدار همپوشانی نوارها یا ستون‌ها را در یک نمودار دو‑بعدی، از ‎-100 تا 100 درصد، گزارش می‌دهد. این یک تصویر فقط‑خواندنی از تنظیمات گروه سری والد است. برای به‌روزرسانی همه سری‌های سازگار در آن گروه، [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/overlap/) را تنظیم کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروهی را نمایش می‌دهند اعمال می‌شود؛ در یک نمودار ترکیبی بر گروه‌های سری نامرتبط تأثیری ندارد.

مثال زیر همپوشانی برای گروهی که شامل اولین سری است تنظیم می‌کند:

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

![همپوشانی سری](series_overlap.png)

## **تغییر رنگ پر کردن سری**

از [IChartSeries.Format](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/format/) برای تنظیم پر کردن پیش‌فرض یک سری کامل استفاده کنید. اگر یک نقطه قبلاً پر کردن صریح داشته باشد، تنظیمات [IChartDataPoint.Format](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/format/) آن، پر کردن سری را برای همان نقطه بازنویسی می‌کند.

مثال زیر پر کردن آبی ثابت را به اولین سری اعمال می‌کند:

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

![رنگ سری](series_color.png)

## **تغییر نام سری**

نام یک سری در دفتر کاری داده‌های نمودار ذخیره می‌شود و به‌طور معمول در افسانه نمایش داده می‌شود. در دفتر کاری پیش‌فرض ایجاد‌شده برای یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین سری را شامل می‌شود. ثابت‌های نام‌گذاری در مثال زیر این ساختار را به‌صورت صریح نشان می‌دهند:

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

همچنین می‌توانید سلولی که توسط [IChartSeries.Name](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/name/) مرجع شده است، به‌روزرسانی کنید. این رویکرد از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

![نام سری](series_name.png)

## **دریافت رنگ پر کردن خودکار سری**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) رنگ محاسبه‌شده بر پایه اندیس سری و سبک نمودار را برمی‌گرداند. این همان رنگی است که وقتی پر کردن سری به‌صورت صریح تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد تنها رنگ محاسبه‌شده را می‌خواند؛ پر کردن جدیدی اختصاص نمی‌دهد.

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

رنگ‌های دقیق بستگی به سبک و تم نمودار دارند.

## **تنظیم رنگ معکوس پر کردن برای یک سری نمودار**

برای سری‌های میله، ستون و حباب، [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/invertifnegative/) می‌تواند مقادیر منفی را با پر کردن متفاوت نمایش دهد. پر کردن معمولی سری را به حالت ثابت تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) اختصاص دهید. اعداد منفی در دفتر کاری بدون تغییر می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 شیت شامل نام سری، ستون 0 شامل نام‌های دسته و ستون 1 شامل مقادیر است:

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

![رنگ پر ثابت معکوس](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه خاص معکوس‌سازی را از طریق [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) فعال کنید. در مثال زیر، معکوس‌سازی برای سری غیرفعال و فقط برای نقطه‌ی انتخاب‌شده فعال شده است. همچنین برای مشاهده اثر، به نقطه یک مقدار منفی اختصاص داده شده است:

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

## **پاک کردن مقدار یک نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول دفتر کاری پشت آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [IChartDataPoint.YValue](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/yvalue/) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات خالی‑مقدار نمودار به‌صورت خالی در نظر می‌گیرد.

مثال زیر فقط نقطه دوم در اولین سری را پاک می‌کند:

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

نمودارهای پراکندگی از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حباب نیز سلول اندازه دارند. فقط سلولی را که نمایانگر مقداری است که می‌خواهید حذف کنید پاک کنید. هنگام نیاز به نگه داشتن نقاط دیگر، از فراخوانی [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapointcollection/clear/) خودداری کنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

یک سلول خالی در دفتر کاری نمایانگر دادهٔ گمشده است؛ سلول حاوی `0` نمایانگر مقدار عددی شناخته‌شده‌ای است. برای خالی کردن یک سلول، [IChartDataCell.Value](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/value/) را به `null` تنظیم کنید. مقدار عددی صفر صرف‌نظر از تنظیم خالی‑سلول، به‌صورت صفر باقی می‌ماند.

از [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/displayblanksas/) برای انتخاب نحوهٔ نمایش سلول‌های خالی توسط نمودار استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. با این کار نحوهٔ ترسیم خالی‌ها تغییر می‌کند، بدون اینکه سلول خالی دفتر کاری با صفر یا مقدار درونی‌سازی پر شود.

مثال خودکافی زیر یک نمودار خطی با یک سری ایجاد می‌کند، مقدار روز ۳ را خالی می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/) از شیت 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام سری را نگه می‌دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است:

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

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

هر فایل خروجی حالت اختصاص‌یافته پیش از ذخیره را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت دلخواه را اختصاص دهید و یک بار ارائه را ذخیره کنید به جای تکرار بر روی حالت‌ها.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز ۳ در دفتر کاری همیشه خالی است:

![نمودارهای خطی با دادهٔ یکسان: Gap خط را در روز ۳ قطع می‌کند، Zero خط را به صفر می‌برد و Span روز ۲ را به روز ۴ متصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده بستگی به نوع نمودار دارد. یک نمودار خطی هر سه حالت را به سادگی مقایسه می‌کند. نمودارهای میله و ستون خطی برای اتصال نقطهٔ گمشده ندارند، بنابراین `Span` نمی‌تواند قسمت متصل‌شدهٔ نشان‑داده‌شده در بالا را تولید کند؛ یک ستون گمشده و یک ستون صفر‌ارتفاع نیز می‌توانند مشابه به نظر برسند. به همان ترتیب، یک نمودار پراکندگی فقط با نشانگرها خط اتصال ندارد. انتظار داشتن سه نتیجهٔ متمایز برای هر نوع نمودار نیست؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصله سری**

عرض فاصله فضای بین خوشه‌های میله یا ستون مجاور است که به‌صورت درصدی از عرض میله یا ستون بیان می‌شود. مشابه همپوشانی، این تنظیم به گروه سری والد تعلق دارد نه به یک سری. برای گروه یکبار [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) را تنظیم کنید. مقدار بزرگ‌تر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچک‌تر آن‌ها را متراکم‌تر می‌سازد.

مثال زیر عرض فاصله را تغییر می‌دهد و تنها ارائهٔ نهایی را ذخیره می‌کند:

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

![عرض فاصله](gap_width.png)

## **پرسش‌های متداول**

**کدام انواع نمودار از داده‌های سری پشتیبانی می‌کنند؟**

تمام انواع نمودارهایی که توسط enumeration [ChartType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/charttype/) نمایان می‌شوند، از داده‌های نمودار استفاده می‌کنند، اما ساختار مقادیر یا تنظیمات سری‌های آن‌ها همسان نیست. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حباب علاوه بر آن اندازه حباب را دارند. روش ایجاد نقطه داده‌ای را به‌کار ببرید که با نوع سری مطابقت دارد. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های میله یا ستون سازگار اعمال می‌شوند.

**گروه سری نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات ترسیم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری دسترسی پیدا می‌کنید لزوماً تمام سری‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه ایجاد‌شده داده‌های پیش‌فرض دارد؟**

بله. به‌طور پیش‌فرض، [IShapeCollection.AddChart](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addchart/) سری‌ها، دسته‌ها و مقادیر نمونه ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا هم‌زمان مجموعهٔ سری و دسته‌ها را پاک کنید تا یک مجموعه دادهٔ کاملاً سفارشی اضافه کنید. یک overload نیز می‌تواند نمودار را بدون دادهٔ پیش‌فرض ایجاد کند.

**اشیاء نمودار چگونه به سلول‌های دفتر کاری متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول مرجع، عنصر مربوطه در نمودار را به‌روزرسانی می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر سری را طوری هم‌راستا نگه دارید که هر نقطه زیر دستهٔ موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای کل سری پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. از [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapointcollection/clear/) فقط زمانی استفاده کنید که قصد حذف تمام نقاط آن سری را دارید. اگر دسته‌ها را نیز حذف می‌کنید، هر سری را به‌روز کنید تا مقادیرشان با مجموعهٔ دسته‌ها هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه بسته به نوع نمودار و [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/displayblanksas/) متفاوت است. نمودارهای پشتیبان می‌توانند خالی‌ها را به‌صورت فاصله، مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی که با معنای دادهٔ مفقود در ارائهٔ شما مطابقت دارد انتخاب کنید. برای مثال کامل و مقایسهٔ تصویری به بخش «کنترل نمایش سلول‌های خالی» مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های میله، ستون و حباب پشتیبان، [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/invertifnegative/) را فعال کنید و [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ خاص با [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) بازنویسی کنید. این ویژگی‌ها بر قالب‌بندی تأثیر می‌گذارند، نه بر مقادیر عددی ذخیره‌شده.

**کدام قالب‌بندی برنده است وقتی هم سری و هم نقطه قالب‌بندی شده باشند؟**

قالب‌بندی صریح نقطه داده برای آن نقطه اولویت دارد. سایر نقاط به قالب‌بندی صریح سری یا، وقتی قالب‌بندی سری تعریف نشده باشد، به سبک و تم خودکار نمودار ادامه می‌دهند. ویژگی‌های گروهی مانند همپوشانی و عرض فاصله بر چیدمان تأثیر می‌گذارند و بازنویسی قالب‌بندی در سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیتی ثابت برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندر و قابلیت خوانایی نمودار تعیین‌کنندهٔ حد عملي هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها خیلی نزدیک یا خیلی دور هستند؟**

[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) را بر روی گروه سری والد مناسب تنظیم کنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها گسترده‌تر شود یا کاهش دهید تا خوشه‌ها نزدیک‌تر به هم بیایند.
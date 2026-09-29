---
title: مدیریت سری‌های داده‌های نمودار در ارائه‌ها در .NET
linktitle: سری داده
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
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با C# مدیریت کنید."
---
## **نمای کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب‌کار داده‌های نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/) نمایانگر یک مجموعه مقادیر مرتبط است و هر [IChartDataPoint](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/) در این مجموعه به یک یا چند سلول کتاب‌کار اشاره می‌کند. اشیاء [IChartCategory](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین مجموعه‌ها را فراهم می‌کنند. بنابراین نام مجموعه، دسته‌ها و مقادیر نقاط به اشیاء [IChartDataCell](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/) متصل هستند نه فقط به‌عنوان متن نمایش.

برای یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض سطر 0 را برای نام‌ مجموعه‌ها، ستون 0 را برای نام دسته‌ها و بقیه سلول‌ها را برای مقادیر مجموعه‌ها استفاده می‌کند. ایندکس‌های برگه، سطر و ستون که به [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/getcell/) ارسال می‌شوند، صفر‑محور هستند. این چیدمان هنگام ایجاد یک نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب‌کار، سلول‌های ارجاع‌شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه دامنه متفاوت هستند:

- تنظیمات سطح‑مجموعه، مانند [IChartSeries.Format](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/format/)، ظاهر پیش‌فرض تمام نقاط در یک مجموعه را فراهم می‌کند.
- تنظیمات نقطه‑داده، مانند [IChartDataPoint.Format](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/format/)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی بر مجموعه‌های سازگاری اعمال می‌شود که به یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/) تعلق دارند. برای تنظیم گزینه‌هایی همچون همپوشانی یا عرض فاصله، از [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/parentseriesgroup/) استفاده کنید.

وقتی پر کردن صریح نقطه یا مجموعه‌ای تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات مجموعه و هم تنظیمات نقطه موجود باشد، تنظیمات نقطه برای آن نقطه اولویت دارد.

![نمودار‑سری‑پاورپوینت](chart-series-powerpoint.png)

## **تنظیم همپوشانی مجموعه نمودار**

[IChartSeries.Overlap](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/overlap/) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار دو‑بعدی تا چه حد همپوشانی دارند، از ‑۱۰۰ تا ۱۰۰ درصد. این مقدار یک تصویر فقط‑خواندنی از تنظیم در گروه سری والد است. برای به‌روزرسانی تمام مجموعه‌های سازگار در آن گروه، [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/overlap/) را تنظیم کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود؛ در نمودار ترکیبی بر گروه‌های سری نامرتبط تأثیری ندارد.

مثال زیر همپوشانی گروه حاوی اولین مجموعه را تنظیم می‌کند:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// نمودار جدید شامل مجموعه‌های نمونه، دسته‌ها و مقادیر است.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

نتیجه:

![همپوشانی مجموعه‌ها](series_overlap.png)

## **تغییر رنگ پر کردن مجموعه**

از [IChartSeries.Format](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/format/) برای تنظیم پر کردن پیش‌فرض یک مجموعه کامل استفاده کنید. اگر برای یک نقطه پر کردن صریحی تعریف شده باشد، تنظیم [IChartDataPoint.Format](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/format/) آن، پر کردن مجموعه را برای آن نقطه بازنویسی می‌کند.

مثال زیر پر شدن آبی ثابت را برای اولین مجموعه اعمال می‌کند:

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

![رنگ مجموعه](series_color.png)

## **تغییر نام مجموعه**

نام یک مجموعه در کتاب‌کار داده‌های نمودار ذخیره می‌شود و معمولاً در فهرست ظاهر می‌شود. در کتاب‌کار پیش‌فرض ایجادشده برای یک نمودار ستونی خوشه‌ای، سلول B1 در سطر 0، ستون 1 قرار دارد و نام اولین مجموعه را شامل می‌شود. ثابت‌های نامگذاری در مثال زیر این ساختار را به وضوح نشان می‌دهند:

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

همچنین می‌توانید سلول ارجاع‌شده توسط [IChartSeries.Name](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/name/) را به‌روزرسانی کنید. این روش از فرض سطر و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

![نام مجموعه](series_name.png)

## **دست‌یابی به رنگ پر کردن خودکار مجموعه**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) رنگی را برمی‌گرداند که بر اساس شاخص مجموعه و سبک نمودار محاسبه می‌شود. این همان رنگی است که وقتی پر کردن مجموعه صریحاً تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر شدن جدیدی تخصیص نمی‌دهد.

مثال زیر رنگ خودکار هر مجموعه پیش‌فرض را چاپ می‌کند:

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

نمونه خروجی برای سبک پیش‌فرض نمودار:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

رنگ‌های دقیق به سبک و تم نمودار بستگی دارند.

## **تنظیم رنگ پر کردن معکوس برای یک مجموعه نمودار**

برای مجموعه‌های نوار، ستون و حباب، [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/invertifnegative/) می‌تواند مقادیر منفی را با پر شدن متفاوتی نمایش دهد. پر کردن معمولی مجموعه را به حالت ثابت تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) اختصاص دهید. اعداد منفی در کتاب‌کار تغییر نمی‌کنند؛ فقط رنگ نمایش آن‌ها تغییر می‌یابد.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. سطر 0 برگه حاوی نام مجموعه، ستون 0 حاوی نام دسته‌ها و ستون 1 حاوی مقادیر است:

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

![رنگ پر کردن ثابت معکوس](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه معکوس‌سازی را از طریق [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) فعال کنید. در مثال زیر معکوس‌سازی برای مجموعه غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال می‌شود. همچنین به نقطه یک مقدار منفی اختصاص داده می‌شود تا اثر قابل مشاهده باشد:

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

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول کتاب‌کار پشت آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [IChartDataPoint.YValue](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/yvalue/) در دسترس است. نقطه داده همچنان در همان موقعیت دسته می‌ماند، اما نمودار مقدار آن را به‌عنوان خالی بر اساس تنظیمات خالی‑مقدار نمودار در نظر می‌گیرد.

مثال زیر فقط نقطه دوم در اولین مجموعه را پاک‌سازی می‌کند:

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

نمودارهای پراکندگی از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حباب نیز یک سلول اندازه دارند. فقط سلولی را که نمایانگر مقداری است که می‌خواهید حذف کنید، پاک کنید. هنگام تمایل به نگه داشتن سایر نقاط، از فراخوانی [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapointcollection/clear/) خودداری کنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی حاوی مقدار، موردی متفاوت نسبت به سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از سطرها و ستون‌های مخفی برگه، به <https://reference.aspose.com/slides/fa/net/chart-workbook/#include-data-from-hidden-rows-and-columns> مراجعه کنید.

یک سلول خالی در کتاب‌کار نشان‌دهنده داده‌های گمشده است؛ سلول حاوی `0` نمایانگر مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، [IChartDataCell.Value](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/value/) را به `null` تنظیم کنید. عدد صفر عدد صفر می‌ماند صرف‌نظر از تنظیم خالی‑سلول.

از [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/displayblanksas/) برای انتخاب نحوه نمایش سلول‌های خالی استفاده کنید. این تنظیم به کل نمودار اعمال می‌شود و نحوه ترسیم خالی‌ها را بدون پر کردن سلول خالی با صفر یا مقدار درونی‌شده تغییر می‌دهد.

مثال خود‑مختار زیر یک نمودار خطی با یک مجموعه می‌سازد، مقدار روز ۳ را خالی می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/) از برگه 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ سطر 0 نام مجموعه را نگه می‌دارد. داده نهایی `10, 20, empty, 30, 40` است.

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

// روز ۳ را واقعا خالی بگذارید، در حالی که دسته و نقطه دادهٔ آن را حفظ می‌کنید.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

هر فایل خروجی حالت اختصاص داده‌شده پیش از ذخیره را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت مطلوب را تنظیم کنید و یک‌بار ارائه را ذخیره کنید به‌جای تکرار بر حالت‌ها.

مقایسهٔ زیر همان داده‌ها را در هر سه فایل نشان می‌دهد. روز ۳ در کتاب‌کار در هر صورت خالی است:

![نمودارهای خطی با داده‌های یکسان: Gap خط را در روز ۳ قطع می‌کند، Zero خط را به صفر می‌کشاند، و Span روز ۲ را به روز ۴ وصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای نوار و ستونی خطی برای اتصال بین دسته‌های گمشده ندارند، بنابراین `Span` نمی‌تواند بخش متصل نشان داده‌شده در بالا را تولید کند؛ یک ستون گمشده و یک ستون صفر‑ارتفاع نیز می‌توانند مشابه دیده شوند. به‌طور مشابه، یک نمودار پراکندگی فقط با نشانگرها خط اتصال ندارد. انتظار نتایج متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصله مجموعه**

عرض فاصله فاصله بین خوشه‌های نوار یا ستون مجاور است که به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. مشابه همپوشانی، این تنظیم به گروه سری والد تعلق دارد نه به یک مجموعهٔ خاص. یک بار برای کل گروه [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) را تنظیم کنید. مقدار بزرگ‌تر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را فشرده‌تر می‌کند.

مثال زیر عرض فاصله را تغییر می‌دهد و فقط ارائهٔ نهایی را ذخیره می‌کند:

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

## **سؤالات رایج**

**کدام انواع نمودار از مجموعه داده پشتیبانی می‌کنند؟**

همهٔ انواع نمودارهای نشان‌داده‌شده توسط شمارش [ChartType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/charttype/) از داده‌های نمودار استفاده می‌کنند، اما ساختار یا تنظیمات مقادیر مجموعه‌های آن‌ها یکسان نیست. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حباب از اندازهٔ حباب نیز بهره می‌برند. از روش ایجاد نقطه‑داده‌ای که با نوع مجموعه همخوانی دارد استفاده کنید. گزینه‌هایی مانند همپوشانی و عرض فاصله تنها برای گروه‌های نوار یا ستونی سازگار اعمال می‌شوند.

**گروه مجموعه نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/) شامل مجموعه‌های سازگاری است که تنظیمات ترسیم سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه به دست می‌آید لزوماً همهٔ مجموعه‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار جدید داده‌های پیش‌فرض دارد؟**

 بله. به‌صورت پیش‌فرض، [IShapeCollection.AddChart](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addchart/) یک سری نمونه، دسته‌ها و مقادیر ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه و دسته‌ها را پاک‌سازی کنید. یک overload نیز می‌تواند نمودار را بدون دادهٔ پیش‌فرض ایجاد کند.

**چگونه اشیاء نمودار به سلول‌های کتاب‌کار متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطه‑داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‑شده، عنصر مربوط به نمودار را به‌روزرسانی می‌کند. هنگام ساخت داده‌های سفارشی، سطرهای دسته و سطرهای مقدار‑مجموعه را طوری هم‌راستا کنید که هر نقطه تحت دستهٔ موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای کل مجموعه پاک‌سازی کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی باقی بماند. فقط زمانی که می‌خواهید تمام نقاط یک مجموعه را حذف کنید، از [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapointcollection/clear/) استفاده کنید. اگر هم دسته‌ها را حذف می‌کنید، برای حفظ هم‌راستایی مقادیر، همهٔ مجموعه‌ها را به‌روزرسانی کنید.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه بستگی به نوع نمودار و [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/displayblanksas/) دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، مقدار صفر یا با وصل کردن نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که با معنای داده‌های گمشده در ارائهٔ شما مطابقت داشته باشد. برای مثال کامل و مقایسهٔ تصویری به بخش <#control-the-display-of-empty-cells> مراجعه کنید.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های نوار، ستون و حباب پشتیبانی‌شده، [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/invertifnegative/) را فعال کنید و [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) بازنویسی کنید. این ویژگی‌ها فقط ظاهر را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**زمانی که هم مجموعه و هم نقطه قالب‌بندی شوند، کدام یک برتری دارد؟**

قالب‌بندی صریح نقطه‑داده برای آن نقطه اولویت دارد. نقاط دیگر همچنان از قالب‌بندی صریح مجموعه یا، اگر قالب‌بندی مجموعه تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. ویژگی‌های گروهی مانند همپوشانی و عرض فاصله بر چیدمان تأثیر می‌گذارند و بازنویسی قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌های قابل‌داشتن در یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و قابلیت خواندن نمودار تعیین‌کنندهٔ حد مفید هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد نزدیک یا دور هستند؟**

[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) را در گروه سری والد مناسب تنظیم کنید. مقدار را برای گسترش فضای بین خوشه‌ها افزایش دهید یا برای نزدیک‌تر کردن خوشه‌ها کاهش دهید.
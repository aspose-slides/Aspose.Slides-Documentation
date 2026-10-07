---
title: مدیریت مجموعه داده‌های نمودار در ارائه‌ها با .NET
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
description: "یاد بگیرید چگونه سری‌های نمودار، نقطه‌های داده، سلول‌های دفتر کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با C# مدیریت کنید."
---
## **بررسی کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک دفتر کار دادهٔ نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) نمایانگر یک مجموعه مقادیر مرتبط است و هر [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) در این مجموعه به یک یا چند سلول دفتر کار اشاره می‌کند. اشیای [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین مجموعه‌ها را فراهم می‌آورند. بنابراین نام مجموعه، دسته‌ها و مقادیر نقاط به اشیای [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) متصل هستند نه فقط به صورت متن نمایش داده شده ذخیره می‌شوند.

برای یک نمودار دسته‌ای معمولی، دفتر کار پیش‌فرض از ردیف ۰ برای نام مجموعه‌ها، ستون ۰ برای نام دسته‌ها و سلول‌های باقی‌مانده برای مقادیر مجموعه استفاده می‌کند. ایندکس‌های شیت، ردیف و ستون که به [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) پاس داده می‌شوند، از صفر شروع می شوند. این طرح‌بندی برای ایجاد نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائهٔ بارگذاری‌شده، قبل از تغییر مقادیر دفتر کار، سلول‌های مرجع توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه حوزهٔ متفاوت هستند:

- تنظیمات در سطح مجموعه، مانند [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)، ظاهر پیش‌فرض تمام نقاط یک مجموعه را فراهم می‌کند.
- تنظیمات نقطه داده، مانند [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)، ظاهر مجموعه را برای یک نقطه خاص بازنویسی می‌کند.
- تنظیمات گروهی بر مجموعه‌های سازگاری که به یک [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) تعلق دارند، اعمال می‌شوند. برای تنظیم گزینه‌هایی مانند هم‌پوشانی یا عرض فاصله، از [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) استفاده کنید.

زمانی که پر کردن صریح برای نقطه یا مجموعه‌ای تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هر دو قالب‌بندی مجموعه و نقطه وجود داشته باشد، قالب‌بندی نقطه برای آن نقطه اولویت دارد.

![سری‌های نمودار در پاورپوینت](chart-series-powerpoint.png)

## **تنظیم هم‌پوشانی مجموعهٔ نمودار**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) گزارش می‌دهد که ستون‌ها یا میله‌ها در یک نمودار دو‑بعدی تا چه اندازه هم‌پوشانی دارند، از ‎‑100 تا 100 درصد. این مقدار یک تصویر فقط‑خواندنی از تنظیمات در گروه مجموعهٔ والد است. برای به‌روزرسانی تمام مجموعه‌های سازگار در آن گروه، [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) را تنظیم کنید. این گزینه برای انواع نموداری که میله‌های گروهی یا ستون‌های گروهی را نشان می‌دهند اعمال می‌شود؛ در یک نمودار ترکیبی بر گروه‌های مجموعهٔ نامرتبط تأثیری ندارد.

مثال زیر هم‌پوشانی گروهی که شامل اولین مجموعه است تنظیم می‌کند:

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

![هم‌پوشانی مجموعه‌ها](series_overlap.png)

## **تغییر رنگ پر کردن مجموعه**

از [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) برای تنظیم پر کردن پیش‌فرض یک مجموعه کامل استفاده کنید. اگر یک نقطه قبلاً پر کردن صریح داشته باشد، تنظیم [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) آن، پر کردن مجموعه را برای آن نقطه نادیده می‌گیرد.

مثال زیر پر کردن ثابت آبی را برای اولین مجموعه اعمال می‌کند:

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

نام مجموعه در دفتر کار دادهٔ نمودار ذخیره می‌شود و معمولاً در راهنمای توضیحی (legend) نشان داده می‌شود. در دفتر کار پیش‌فرض که برای یک نمودار ستونی خوشه‌ای ساخته می‌شود، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را حاوی می‌شود. ثابت‌های نامگذاری در مثال زیر این ساختار را به وضوح نشان می‌دهند:

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

همچنین می‌توانید سلولی را که توسط [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) ارجاع شده است، مستقیم به‌روزرسانی کنید. این روش از فرض کردن ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

### **ایجاد یک مجموعه با نام از چندین سلول**

یک نام ترکیبی برای مجموعه زمانی مفید است که نام محصول و دورهٔ گزارش در سلول‌های جداگانه‌ای ذخیره شده باشند. به عنوان مثال می‌توانید `Product A` در B1 و `2026` در C1 را به یک نام مجموعه ترکیب کنید و هر دو بخش به سلول‌های منبع خود متصل بمانند.

از [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) برای دریافت محدودهٔ نام استفاده کنید، سپس آن مجموعه را به [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/) پاس دهید. آرگومان `skipHiddenCells` کنترل می‌کند که آیا سلول‌های مخفی شامل شوند یا نه: `true` آنها را خارج می‌کند، در حالی که `false` شامل می‌شود. این مثال از `false` برای شامل کردن تمام سلول‌های محدودهٔ نام استفاده می‌کند.

مثال زیر یک ارائه با یک مجموعه و دو نقطه داده ایجاد می‌کند. سلول‌های B1:C1 فقط نام مجموعه را فراهم می‌کنند؛ A2:A3 برچسب‌های دسته را، و B2:B3 مقادیر عددی را فراهم می‌کنند.

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

// این دو سلول نام مجموعه را فراهم می‌کنند.
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

نام مجموعهٔ حاصل `Product A 2026` است، با یک فاصله بین دو مقدار سلولی. راهنما (legend) این را به‌عنوان یک ورودی برای هر دو ستون نشان می‌دهد. تصویر زیر از ارائهٔ ذخیره‌شده رندر شده است:

![نمودار ستونی با مقادیر شمال و جنوب و نام ترکیبی مجموعه Product A 2026 در راهنما](composite_series_name.png)

## **دریافت رنگ خودکار پر کردن مجموعه**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) رنگی را برمی‌گرداند که از اندیس مجموعه و سبک نمودار محاسبه می‌شود. این رنگ زمانی استفاده می‌شود که پر کردن مجموعه صراحتاً تعریف نشده باشد. فراخوانی این متد تنها رنگ محاسبه‌شده را می‌خواند؛ رنگ جدیدی تخصیص نمی‌دهد.

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

خروجی نمونه برای سبک پیش‌فرض نمودار:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

رنگ‌های دقیق به سبک و تم نمودار وابسته‌اند.

## **تنظیم رنگ پر کردن معکوس برای مجموعهٔ نمودار**

برای مجموعه‌های میله، ستون و حباب، [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) می‌تواند مقادیر منفی را با رنگ پر کردن متفاوتی نمایش دهد. پر کردن عادی مجموعه را به حالت ثابت (solid) تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) تعیین کنید. اعداد منفی در دفتر کار بدون تغییر می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف ۰ شیت نام مجموعه را دارد، ستون ۰ نام دسته‌ها و ستون ۱ مقادیر را دارد:

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

می‌توانید معکوس‌سازی را برای یک نقطه از طریق [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) فعال کنید. در مثال زیر، معکوس‌سازی برای کل مجموعه غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال است. همچنین مقدار نقطه منفی تنظیم می‌شود تا اثر قابل مشاهده باشد:

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

## **پاک‌سازی مقدار یک نقطه دادهٔ خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتوانهٔ آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر مبنای تنظیمات خالی‑مقدار (blank‑value) نمودار به‌صورت خالی در نظر می‌گیرد.

مثال زیر فقط نقطه دوم در اولین مجموعه را پاک می‌کند:

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

نمودارهای پراکنده از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حبابی همچنین از سلول اندازه استفاده می‌کنند. فقط سلولی را که نمایانگر مقدار هدف شماست پاک کنید. هنگام تمایل به نگه داشتن سایر نقاط، از فراخوانی [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) خودداری کنید، زیرا این متد تمام نقاط دادهٔ مجموعه را حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که شامل مقادیر هستند مورد متفاوتی نسبت به سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی شیت، به [Include Data from Hidden Rows and Columns](/slides/fa/net/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول خالی در دفتر کار نشان‌دهندهٔ دادهٔ از دست رفته است؛ یک سلول حاوی `0` نشان‌دهندهٔ مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) را به `null` تنظیم کنید. صفر عددی همچنان صفر می‌ماند صرف‌نظر از تنظیم خالی‑سلول.

از [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) برای انتخاب نحوهٔ نمایش سلول‌های خالی استفاده کنید. این تنظیم برای تمام نمودار اعمال می‌شود. این تنظیم نحوهٔ رسم خالی‌ها را تغییر می‌دهد، بدون اینکه سلول خالی دفتر کار با صفر یا مقدار درون‌یابی پر شود.

مثال زیر یک نمودار خطی با یک مجموعه می‌سازد، مقدار روز ۳ را پاک می‌کند و هر حالت را ذخیره می‌کند. نیازی به فایل ورودی نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) از شیت ۰، ستون ۰ برای برچسب‌های دسته و ستون ۱ برای مقادیر استفاده می‌کند؛ ردیف ۰ نام مجموعه را نگه می‌دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

// روز ۳ را واقعاً خالی بگذارید، در حالی که دسته‌بندی و نقطه داده آن را نگه می‌دارید.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

هر فایل خروجی حالت اختصاص داده‌شده قبل از ذخیره‌سازی را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت مورد نظر را تنظیم کنید و یک بار ارائه را ذخیره کنید به جای تکرار بر حالت‌ها.

مقایسه زیر همان داده را در هر سه فایل نشان می‌دهد. روز ۳ در هر حالت در دفتر کار خالی است:

![نمودارهای خطی با داده‌های یکسان: Gap خط را در روز ۳ قطع می‌کند، Zero خط را به صفر می‌کشاند، و Span روز ۲ را به روز ۴ متصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی تمام سه حالت را به‌راحتی مقایسه می‌کند. نمودارهای میله و ستونی خطی برای اتصال بین دسته‌های گمشده ندارند، بنابراین `Span` نمی‌تواند بخش متصل‌شده نشان داده شده را تولید کند؛ یک ستون گمشده و یک ستون با ارتفاع صفر نیز می‌توانند مشابه به نظر برسند. به‌طور مشابه، یک نمودار پراکنده فقط دارای مارکر است و خط متصلی ندارد. انتظار نتایج سه‌گانهٔ متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصلهٔ مجموعه**

عرض فاصله (Gap width) فضای بین خوشه‌های میله یا ستون مجاور است که به‌عنوان درصدی از عرض میله یا ستون بیان می‌شود. مشابه هم‌پوشانی، این تنظیم به گروه مجموعهٔ والد تعلق دارد نه به یک مجموعهٔ خاص. برای گروه یک‌بار [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) را تنظیم کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را متراکم می‌کند.

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

## **سوالات متداول**

**کدام انواع نمودارها از مجموعه داده پشتیبانی می‌کنند؟**

تمامی انواع نمودارهای تعریف‌شده توسط شمارش [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) از داده‌های نمودار استفاده می‌کنند، اما ساختار مقدار یا تنظیمات مجموعه برای همهٔ آن‌ها یکسان نیست. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حبابی اندازه حباب‌ها را نیز اضافه می‌کنند. از روش ایجاد نقطه داده‌ای استفاده کنید که با نوع مجموعه مطابقت داشته باشد. گزینه‌هایی مانند هم‌پوشانی و عرض فاصله فقط برای گروه‌های میله یا ستون سازگار اعمال می‌شوند.

**یک گروه مجموعهٔ نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) مجموعه‌ای از مجموعه‌های سازگار است که تنظیمات رسم در سطح گروه را به اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دسترسی پیدا می‌شود، لزوماً تمام مجموعه‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه ایجاد‌شده شامل داده‌های پیش‌فرض است؟**

بله. به‌صورت پیش‌فرض، [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) مجموعه‌ها، دسته‌ها و مقادیر نمونه‌ای ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن یک مجموعهٔ کاملاً سفارشی، هر دو مجموعه و دسته‌ها را پاک کنید. یک overload نیز می‌تواند نموداری بدون دادهٔ پیش‌فرض ایجاد کند.

**چگونه اشیای نمودار به سلول‌های دفتر کار متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده، عنصر مربوط به نمودار را به‌روزرسانی می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را هم‌تراز نگه دارید تا هر نقطه زیر دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را به‌جای کل مجموعه پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان یک نقطهٔ خالی حفظ شود. از [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) تنها زمانی استفاده کنید که قصد حذف تمام نقاط از آن مجموعه را داشته باشید. اگر دسته‌ها را نیز حذف می‌کنید، باید هر مجموعه را طوری به‌روزرسانی کنید که مقادیرشان با مجموعهٔ دسته هم‌تراز بمانند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه بستگی به نوع نمودار و [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌عنوان گپ‌ها، به‌عنوان مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که با معنای داده‌های گمشده در ارائهٔ شما منطبق باشد. برای یک مثال کامل و مقایسهٔ تصویری، به [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های میله، ستون و حباب پشتیبانی‌شده، [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) را فعال کنید و [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) بازنویسی کنید. این ویژگی‌ها فقط نمایش را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**وقتی هم مجموعه و هم نقطه قالب‌بندی شده باشند، کدام فرمت برتری دارد؟**

قالب‌بندی صریح نقطه داده برای آن نقطه اولویت دارد. نقاط دیگر به قالب‌بندی صریح مجموعه یا، در صورت عدم تعریف قالب‌بندی مجموعه، به سبک و تم خودکار نمودار ادامه می‌دهند. ویژگی‌های گروهی مانند هم‌پوشانی و عرض فاصله تنظیمات چیدمان هستند و بر روی قالب‌بندی نقطه‌ای تأثیری ندارند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و قابلیت خواندن نمودار، تعیین‌کنندهٔ حد مفید هستند.

**در صورتی که ستون‌ها بیش از حد نزدیک یا دور باشند، چه کاری باید انجام دهم؟**

[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) را در گروه مجموعهٔ والد مناسب تنظیم کنید. برای گسترده‌تر کردن فضا بین خوشه‌ها مقدار را افزایش دهید یا برای نزدیک کردن خوشه‌ها مقدار را کاهش دهید.
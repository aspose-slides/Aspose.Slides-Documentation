---
title: مدیریت سری‌های داده نمودار در ارائه‌ها با .NET
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
description: "یاد بگیرید چگونه سری‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، هم‌پوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با C# مدیریت کنید."
---
## **مرور کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب‌کار داده نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/) یک مجموعه مقادیر مرتبط را نشان می‌دهد و هر [IChartDataPoint](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/) در این مجموعه به یک یا چند سلول کتاب‌کار ارجاع می‌دهد. اشیاء [IChartCategory](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی‌شده‌ای را که بین مجموعه‌ها به اشتراک گذاشته می‌شود، ارائه می‌دهند. بنابراین نام مجموعه، دسته‌بندی‌ها و مقادیر نقاط به اشیاء [IChartDataCell](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/) متصل هستند نه این که تنها به صورت متن نمایش ذخیره شوند.

برای یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض از ردیف 0 برای نام‌های مجموعه، ستون 0 برای نام‌های دسته و سلول‌های باقی‌مانده برای مقادیر مجموعه استفاده می‌کند. اندیس‌های کاربرگ، ردیف و ستون که به [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/getcell/) پاس می‌شوند، صفر‑مبنا هستند. این طرح‌بندی وقتی که نمودار را با داده‌های پیش‌فرض ایجاد می‌کنید مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب‌کار، سلول‌های ارجاع‌شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار در سه حوزه متفاوت قرار می‌گیرد:

- تنظیمات در سطح مجموعه، مانند [IChartSeries.Format](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/format/)، ظاهر پیش‌فرض برای تمام نقاط یک مجموعه را فراهم می‌کند.
- تنظیمات نقطه‑داده، مانند [IChartDataPoint.Format](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/format/)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی بر روی مجموعه‌های سازگاری که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/) تعلق دارند، اعمال می‌شود. برای تنظیم گزینه‌هایی مانند هم‌پوشانی یا عرض فاصله، از [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/parentseriesgroup/) دسترسی پیدا کنید.

زمانی که پر‑کردن نقطه یا مجموعه به‌صراحت تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هر دو قالب‌بندی مجموعه و نقطه موجود باشد، قالب‌بندی نقطه برای آن نقطه برتر است.

![نمودار‑سری‑پاورپوینت](chart-series-powerpoint.png)

## **تنظیم هم‌پوشانی سری‌های نمودار**

[IChartSeries.Overlap](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/overlap/) میزان هم‌پوشانی میله‌ها یا ستون‌ها را در یک نمودار دو‑بعدی، از ‑100 تا 100 درصد، گزارش می‌دهد. این مقدار یک پیش‌بینی فقط‑خواندنی از تنظیمات در گروه سری اصلی است. برای به‌روزرسانی همه مجموعه‌های سازگار در آن گروه، [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/overlap/) را تنظیم کنید. این گزینه برای انواع نموداری که میله‌ها یا ستون‌های گروهی را نمایش می‌دهند اعمال می‌شود؛ برای گروه‌های سری نامرتبط در یک نمودار ترکیبی تغییری ایجاد نمی‌کند.

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

// نمودار جدید شامل مجموعه نمونه، دسته‌ها و مقادیر است.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

نتیجه:

![هم‌پوشانی سری‌ها](series_overlap.png)

## **تغییر رنگ پر‑کردن سری**

از [IChartSeries.Format](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/format/) برای تنظیم پر‑کردن پیش‌فرض یک سری کامل استفاده کنید. اگر نقطه‌ای پر‑کردن صریح داشته باشد، تنظیمات [IChartDataPoint.Format](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/format/) آن، پر‑کردن سری را برای آن نقطه بازنویسی می‌کند.

مثال زیر پر‑کردن آبی صلب برای اولین سری اعمال می‌کند:

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

نام یک سری در کتاب‌کار داده نمودار ذخیره می‌شود و معمولاً در افسانه (legend) نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ایجاد شده برای یک نمودار ستون خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین سری را دارد. ثابت‌های نام‌گذاری شده در مثال زیر این ساختار را واضح می‌کنند:

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

همچنین می‌توانید سلولی که توسط [IChartSeries.Name](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/name/) ارجاع داده شده است، به‌روزرسانی کنید. این رویکرد از فرض ردیف و ستون خاص در یک نمودار موجود جلوگیری می‌کند:

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

## **دریافت رنگ پر‑کردن خودکار سری**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) رنگی را برمی‌گرداند که بر اساس اندیس سری و سبک نمودار محاسبه شده است. این همان رنگی است که زمانی که پر‑کردن سری به‌صورت صریح تعریف نشده باشد، استفاده می‌شود. فراخوانی متد رنگ محاسبه‌شده را می‌خواند؛ مقدار جدیدی برای پر‑کردن اختصاص نمی‌دهد.

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

خروجی مثال برای سبک پیش‌فرض نمودار:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

رنگ‌های دقیق بسته به سبک و تم نمودار متفاوت است.

## **تنظیم رنگ پر‑کردن معکوس برای یک سری نمودار**

برای سری‌های میله، ستون و حباب، می‌توانید با استفاده از [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/invertifnegative/) مقادیر منفی را با پر‑کردن متفاوتی نشان دهید. پر‑کردن منظم سری را به صلب تنظیم کنید، معکوس شدن را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) اختصاص دهید. اعداد منفی در کتاب‌کار تغییر نمی‌کنند؛ فقط رنگ نمایش آن‌ها تغییر می‌یابد.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 کاربرگ شامل نام سری، ستون 0 شامل نام دسته‌ها و ستون 1 شامل مقادیر است:

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

![رنگ پر‑کردن صلب معکوس](inverted_solid_fill_color.png)

می‌توانید معکوس شدن را برای یک نقطه با استفاده از [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) فعال کنید. در مثال زیر، معکوس شدن برای سری غیرفعال و فقط برای نقطه انتخاب‌شده فعال شده است. همچنین به نقطه یک مقدار منفی اختصاص می‌دهیم تا اثر مشاهده شود:

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

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشت‌صحنهٔ کتاب‌کار آن را به `null` تنظیم کنید. برای یک نمودار ستون، مقدار ترسیم‌شده از طریق [IChartDataPoint.YValue](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/yvalue/) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را برحسب تنظیمات مقادیر خالی نمودار به‌عنوان خالی در نظر می‌گیرد.

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

نمودارهای پراکنده از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حباب نیز از یک سلول اندازه بهره می‌برند. فقط سلولی که نمایانگر مقداری است که می‌خواهید حذف کنید را پاک کنید. هنگام تمایل به نگه‌داشتن سایر نقاط، از فراخوانی [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapointcollection/clear/) خودداری کنید، چون این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **تنظیم عرض فاصله سری**

عرض فاصله فاصله بین خوشه‌های میله یا ستون مجاور است که به‌صورت درصدی از عرض میله یا ستون بیان می‌شود. مشابه هم‌پوشانی، این مقدار متعلق به گروه سری پدر است نه به یک سری. برای گروه یک بار [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) را تنظیم کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را فشرده‌تر می‌سازد.

مثال زیر عرض فاصله را تغییر می‌دهد و فقط ارائه نهایی را ذخیره می‌کند:

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

**کدام انواع نمودار از سری‌های داده پشتیبانی می‌کنند؟**

همهٔ انواع نمودار که توسط شمارش‌گر [ChartType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/charttype/) نمایندگی می‌شوند از داده‌های نمودار استفاده می‌کنند، اما ساختار یا تنظیمات ارزش آن‌ها یکسان نیست. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حباب اندازه حباب‌ها را اضافه می‌کنند. از روش ایجاد نقطه‑داده‌ای که با نوع سری مطابقت دارد استفاده کنید. گزینه‌هایی مانند هم‌پوشانی و عرض فاصله تنها برای گروه‌های میله یا ستون سازگار اعمال می‌شوند.

**گروه سری نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات نموداری سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری دسترسی پیدا می‌کنید لزوماً تمام سری‌های نمودار را تحت تأثیر قرار نمی‌دهد.

**آیا یک نمودار تازه‌ساخته داده‌های پیش‌فرض دارد؟**

بله. به‌طور پیش‌فرض، [IShapeCollection.AddChart](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addchart/) نمونه‌ای از سری‌ها، دسته‌ها و مقادیر را ایجاد می‌کند. می‌توانید آن سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه سری و دسته را پاک کنید. یک بارگذاری دیگر نیز می‌تواند نموداری بدون داده پیش‌فرض ایجاد کند.

**نمودارها چگونه به سلول‌های کتاب‌کار متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقطه‑داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده، عنصر مربوطهٔ نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقدار سری را هم‌راستا نگه دارید تا هر نقطه زیر دستهٔ منظورش ترسیم شود.

**چگونه یک نقطه را به‌جای کل سری پاک کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. از [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapointcollection/clear/) فقط زمانی استفاده کنید که قصد حذف تمام نقاط آن سری را دارید. اگر دسته‌ها را نیز حذف می‌کنید، باید هر سری را به‌روزرسانی کنید تا مقادیرشان با مجموعهٔ دسته‌ها هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/displayblanksas/) بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، به‌عنوان مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای داده‌های از دست رفته در ارائهٔ شما را بازتاب دهد.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های میله، ستون و حباب پشتیبانی‌شده، [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/invertifnegative/) را فعال کنید و [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) را تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ خاص با [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) بازنویسی کنید. این ویژگی‌ها بر قالب‌بندی اثر می‌گذارند، نه بر مقادیر عددی ذخیره‌شده.

**زمانی که هم سری و هم نقطه قالب‌بندی شده باشند، کدام یک برتری دارد؟**

قالب‌بندی صریح نقطه‑داده برای آن نقطه برتر است. سایر نقاط به قالب صریح سری ادامه می‌دهند یا، اگر قالب سری تعریف نشده باشد، به سبک و تم خودکار نمودار متکی می‌شوند. ویژگی‌های گروهی مانند هم‌پوشانی و عرض فاصله بر چیدمان کنترل می‌شوند و بازنویسی قالب‌بندی سطح‑نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و قابلیت خواندن نمودار تعیین‌کنندهٔ حد مفید هستند.

**وقتی ستون‌ها خیلی نزدیک یا خیلی دور از هم هستند، چه کاری باید انجام دهم؟**

[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) را در گروه سری پدر مربوطه تنظیم کنید. مقدار را برای افزایش فضای بین خوشه‌ها بزرگ‌تر کنید یا برای نزدیک‌تر کردن خوشه‌ها کوچک‌تر.
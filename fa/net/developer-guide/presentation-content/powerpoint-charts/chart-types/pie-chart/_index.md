---
title: "سفارشی‌سازی نمودارهای دایره‌ای در ارائه‌ها در .NET"
linktitle: "نمودار دایره‌ای"
type: docs
url: /fa/net/pie-chart/
keywords:
- "نمودار دایره‌ای"
- "مدیریت نمودار"
- "سفارشی‌سازی نمودار"
- "گزینه‌های نمودار"
- "تنظیمات نمودار"
- "گزینه‌های ترسیم"
- "رنگ برش"
- "PowerPoint"
- "ارائه"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "ایجاد و سفارشی‌سازی نمودارهای دایره‌ای در .NET با Aspose.Slides. پیکربندی نمودارهای ثانویه، نمایش برچسب‌های داده و اعمال رنگ‌های خودکار برش در PowerPoint."
---
## **بررسی کلی**

این مقاله نحوه کار با نمودارهای دایره‌ای در Aspose.Slides را توضیح می‌دهد. این مقاله نحوه پیکربندی گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie را نشان می‌دهد و چگونگی فعال‌سازی رنگ‌آمیزی خودکار برش‌ها برای یک نمودار دایره‌ای استاندارد را شرح می‌دهد.

مثال‌ها بر روی وظایف سفارشی‌سازی نمودار مانند افزودن یک نمودار به اسلاید، تنظیم سری‌ها و برچسب‌ها، جایگزینی داده‌های پیش‌فرض نمودار با دسته‌ها و مقادیر سفارشی، و ذخیره‌سازی ارائه به‌روز شده تمرکز دارند.

## **گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie**

Aspose.Slides for .NET گزینه‌های نمودار ثانویه را برای نمودارهای Pie of Pie و Bar of Pie پشتیبانی می‌کند. این گزینه‌ها اندازه نمودار ثانویه و نحوه تقسیم نقاط داده بین دو نمودار را کنترل می‌کنند.

مثال زیر یک نمودار Pie of Pie در یک ارائهٔ جدید ایجاد می‌کند و مقادیر نقاط داده را به عنوان برچسب نمایش می‌دهد. ویژگی [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) اندازهٔ نمودار ثانویه را روی 149٪ نمودار اصلی تنظیم می‌کند. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) تقسیم‌بندی مبتنی بر درصد را انتخاب می‌کند و [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) آستانه را روی 53٪ تنظیم می‌کند.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// مقادیر را نمایش دهید و نمودار ثانویه را پیکربندی کنید.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **انتخاب دسته‌ها برای نمودار ثانویه**

از تقسیم‌بندی سفارشی استفاده کنید وقتی می‌خواهید دسته‌های خاصی را در نمودار ثانویه گروه‌بندی کنید بدون در نظر گرفتن مقدار درصدی آنها. به عنوان مثال، یک گزارش فروش ممکن است Online و Events را همراه هم نشان دهد تا خوانندگان بتوانند این دو کانال را مقایسه کنند، حتی اگر این دو به ترتیب 35٪ و 10٪ از مجموع فروش را تشکیل دهند.

ویژگی [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) را روی [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) تنظیم کنید و نقاط را از طریق [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/) انتخاب کنید. متد [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) این مجموعه می‌تواند یک ایندکس صفر مبنا در سری یا یک شیء نقطه داده را بپذیرد. در این مثال، ایندکس 1 Online را انتخاب می‌کند و نقطهٔ ایندکس 3 Events را انتخاب می‌کند. Partners نیز به‌صورت موقت اضافه می‌شود و سپس با استفاده از [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/) حذف می‌شود.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// داده‌های پیش‌فرض را با فروش بر حسب کانال جایگزین کنید.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Online را با ایندکس صفر مبنا و Events را با شیء نقطه داده‌ای انتخاب کنید.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Partners را از انتخاب حذف کنید بدون اینکه داده منبع آن را حذف کنید.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) و Events (10) به عنوان برش‌های جداگانه در نمودار ثانویه ظاهر می‌شوند. در نمودار اصلی، آنها توسط یک برش ترکیبی با مقدار 45 همراه با Retail (40) و Partners (15) نشان داده می‌شوند. حذف Partners از انتخاب سفارشی آن را در نمودار اصلی نگه می‌دارد؛ این کار دسته یا مقدار آن را از داده منبع نمودار حذف نمی‌کند.

تصویر زیر ارائهٔ ذخیره‌شده در PowerPoint را نشان می‌دهد:
![نمودار Pie of Pie با Online و Events در نمودار ثانویه و مقدار ترکیبی 45 آن در نمودار اصلی](pie_of_pie_custom.png)

## **تنظیم رنگ‌گذاری خودکار برش‌های نمودار دایره‌ای**

Aspose.Slides for .NET می‌تواند به‌صورت خودکار رنگ‌های متفاوتی به برش‌های نمودار دایره‌ای اختصاص دهد. مثال زیر یک نمودار دایره‌ای با عنوان مرکزی ایجاد می‌کند و داده‌های پیش‌فرض را با سه دستهٔ فصلی و مقادیرشان جایگزین می‌نماید. ویژگی [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) مقادیر 20، 50 و 30 را به عنوان برچسب نمایش می‌دهد، در حالی که [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) رنگ متمایزی برای هر برش فعال می‌کند.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// یک عنوان نمودار را به صورت مرکزچین اضافه کنید.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// داده‌های پیش‌فرض را با استفاده از اولین برگه کاری جایگزین کنید.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// مقادیر را نمایش دهید و رنگ‌های متفاوتی به برش‌ها اختصاص دهید.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **سوالات متداول**

**آیا انواع Pie of Pie و Bar of Pie پشتیبانی می‌شوند؟**

بله، کتابخانه یک نمودار ثانویه برای نمودارهای دایره‌ای، شامل انواع Pie of Pie و Bar of Pie، [پشتیبانی می‌کند](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

**آیا می‌توانم فقط نمودار را به عنوان تصویر (مثلاً PNG) صادر کنم؟**

بله، می‌توانید [نمودار را به عنوان تصویر صادر کنید](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (مانند PNG) بدون اینکه کل ارائه را صادر کنید.
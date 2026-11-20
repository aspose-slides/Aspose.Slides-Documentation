---
title: سفارشی‌سازی محورها در نمودارها در ارائه‌های .NET
linktitle: محور نمودار
type: docs
url: /fa/net/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دست‌کاری محور
- مدیریت محور
- ویژگی‌های محور
- حداکثر مقدار
- حداقل مقدار
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کشف کنید چگونه از Aspose.Slides برای .NET استفاده کنید تا محورها را در نمودارها در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها سفارشی‌سازی کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه محورها را در نمودارها با Aspose.Slides برای .NET سفارشی کنید. این مقاله به مقادیر محاسبه‌شده محور، جابجایی ردیف‌ها و ستون‌های نمودار، قابلیت مشاهده محور، فواصل برچسب‌های دسته و نشانگرهای تیک، دسته‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت‌گذاری محور، واحدهای نمایش، و مقیاس لگاریتمی پرداخته است.

## **دریافت بیشینه مقادیر در محور عمودی نمودارها**

یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید و یک نمودار مساحتی با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) را فراخوانی کنید تا طرح‌بندی نمودار به‌روز باشد.

[ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) و [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) را برای حدهای محور بخوانید، و [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) و [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) را برای فواصل تیک. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) و [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) مقیاس‌های زمان‑واحد را فراهم می‌کنند که برای محورهای تاریخ مرتبط هستند. مثال این مقادیر را در متغیرهای محلی ذخیره می‌کند و نمودار را ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **جابه‌جایی داده‌ها بین محورها**

از [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته قبلی تبدیل به سری می‌شود و هر سری قبلی تبدیل به دسته. این تغییر نحوه گروه‌بندی داده‌ها را ایجاد می‌کند؛ محورهای افقی و عمودی را تبدیل نمی‌کند. مثال از [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) برای بایند کردن داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل ردیف سرصفحه و ستون دسته، قبل از جابه‌جایی ردیف‌ها و ستون‌ها استفاده می‌کند. یک نمودار با چهار سری و سه دسته ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **معکوس کردن ترتیب رسم محور**

از [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) برای معکوس کردن یک محور دسته یا مقدار استفاده کنید. برای مثال، یک نمودار نوار افقی می‌تواند مراحل پروژه را از بالا به پایین همان ترتیب worksheet نشان دهد: برنامه‌ریزی، توسعه، تست. معکوس کردن محور جهت رسم را تغییر می‌دهد؛ ترتیب یا بازچینی داده‌های workbook را تغییر نمی‌دهد. برای مقایسه، [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) نقش سری‌ها و دسته‌ها را تعویض می‌کند.

مثال زیر یک نمودار نوار افقی با سه مرحله و یک سری ایجاد می‌کند. یک ارائه با سه اسلاید ذخیره می‌کند: ترتیب عادی، دسته‌های معکوس، مقادیر معکوس. هر کپی از همان مجموعه داده استفاده می‌کند و فقط یک محور در هر کپی معکوس می‌شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Slide 2: نمایش اولین دسته در بالای صفحه.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Keep the horizontal value axis at the bottom.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Slide 3: فقط مقیاس عددی افقی را معکوس کنید.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

معکوس کردن یک محور می‌تواند محور عمودی را به سمت مخالف صفحه حرکت دهد. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) تعیین می‌کند محور دیگر در کجا محور پیکربندی‌شده را قطع می‌کند. در اسلاید ۲، تنظیم آن به `Maximum` روی محور دسته معکوس محور مقدار افقی را در پایین نگه می‌دارد. برای نقطه تقاطع خاص، از [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) استفاده کنید. هنگام تغییر جهت، تنظیمات تقاطع را بررسی کنید، به‌ویژه اگر نمودار قبلاً نقطه تقاطع سفارشی داشته باشد. `IsPlotOrderReversed` را به `false` برگردانید تا جهت رسم عادی بازیابی شود؛ تنظیمات تقاطع جداگانه هستند.

| ترتیب عادی (اسلاید 1) | دسته‌های معکوس (اسلاید 2) | مقادیر معکوس (اسلاید 3) |
| --- | --- | --- |
| ![نمودار نوار افقی با ترتیب عادی محور دسته و مقدار](axis-order-normal.png) | ![نمودار نوار افقی با نمایش دسته‌ها از بالا به پایین](axis-order-categories-reversed.png) | ![نمودار نوار افقی با محور مقدار معکوس و صفر در سمت راست](axis-order-values-reversed.png) |
| دسته‌ها از پایین به بالا پیش می‌روند؛ مقادیر از چپ به راست افزایش می‌یابند. | برنامه‌ریزی، توسعه و تست از بالا به پایین پیش می‌روند. مقادیر و ترتیب ردیف‌های کاربرگ بدون تغییر باقی می‌مانند. | دسته‌ها ترتیب عادی خود را حفظ می‌کنند؛ مقادیر از راست به چپ افزایش می‌یابند. محور دسته در صفر سمت راست تقاطع می‌کند. |

## **غیرفعال کردن محور عمودی برای نمودارهای خطی**

[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) را روی `false` تنظیم کنید تا محور عمودی مخفی شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور عمودی مخفی ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **غیرفعال کردن محور افقی برای نمودارهای خطی**

[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) را روی `false` تنظیم کنید تا محور افقی مخفی شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور افقی مخفی ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **نمایش یا مخفی‌سازی خطوط شبکه نمودار**

[ShowMajorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showmajorgridlines/) و [ShowMinorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showminorgridlines/) را بخوانید تا بفهمید کدام خطوط شبکه محور را نمایش می‌دهند. هر دو ویژگی فقط‑خواندنی هستند. از پر کردن خط [MinorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/minorgridlinesformat/) برای نشان یا مخفی کردن خطوط شبکه جزئی استفاده کنید. یک پرکردن ثابت با رنگ مرئی برای نمایش تنظیم کنید یا از `FillType.NoFill` برای مخفی‌کردن استفاده کنید. تنظیم متناظر برای خطوط شبکه اصلی [MajorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorgridlinesformat/)`.Line.FillFormat`. تغییر پر کردن یک خط شبکه، قابلیت مشاهده محور و نشانگرهای تیک را حفظ می‌کند.

محور عمودی این نمودار ستونی خوشه‌ای با خطوط شبکه اصلی قابل مشاهده و خطوط شبکه جزئی مخفی شروع می‌شود. مثال خطوط شبکه جزئی را به رنگ نارنجی نشان می‌دهد، سپس دوباره مخفی می‌کند و ارائه را ذخیره می‌کند.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
var axis = chart.Axes.VerticalAxis;
Console.WriteLine($"Initial: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

var minorFill = axis.MinorGridLinesFormat.Line.FillFormat;
minorFill.FillType = FillType.Solid;
minorFill.SolidFillColor.Color = Color.DarkOrange;
Console.WriteLine($"Enabled: minor={axis.ShowMinorGridLines}");

minorFill.FillType = FillType.NoFill;
Console.WriteLine($"Hidden: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

presentation.Save("ChartGridlines.pptx", SaveFormat.Pptx);
```

| خطوط شبکه جزئی فعال | خطوط شبکه جزئی مخفی |
| --- | --- |
| ![خطوط شبکه جزئی نارنجی بین خطوط شبکه اصلی در محور عمودی](minor-gridlines-enabled.png) | ![نمودار ستونی مشابه که فقط خطوط شبکه اصلی قابل مشاهده‌اند](minor-gridlines-hidden.png) |

## **تغییر محور دسته**

[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) را تنظیم کنید تا یک محور دسته تاریخ یا متن انتخاب شود. این مثال نیاز به `ExistingChart.pptx` دارد که در اسلاید اول اولین شکل آن یک نمودار است و سلول‌های دسته شامل مقادیر عددی تاریخ Excel هستند. محور افقی را به محور تاریخ تغییر می‌دهد. تنظیم [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) به `false`، [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) به `1` و [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) به ماه‌ها، نشانگرهای اصلی را در فواصل یک ماه قرار می‌دهد.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

### **تعیین نوع محور دسته بر اساس داده**

پس از پر کردن دسته‌ها، [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) را فراخوانی کنید، سپس [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) را بخوانید تا انتخاب را بررسی کنید. این کار زمانی که نمودار همانند متن یا مقادیر عددی تاریخ دریافت می‌کند مفید است. متد هنگام فراخوانی نوع را تعیین می‌کند؛ حالت پایدار برای ارزیابی تغییرات داده‌های بعدی ایجاد نمی‌کند. پس از جایگزینی دسته‌ها، دوباره آن را فراخوانی کنید.

مثال زیر یک نمودار با دسته‌های متنی ایجاد می‌کند و `Text` چاپ می‌کند. سپس مقادیر سلول‌های دسته را با تاریخ‌ها جایگزین می‌کند و دوباره متد را فراخوانی می‌کند که `Date` چاپ می‌شود. تاریخ‌ها به‌عنوان مقادیر عددی OLE Automation برگردانده‌شده توسط [DateTime.ToOADate](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tooadate) ذخیره می‌شوند، نه به‌صورت رشته تاریخ. [CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/customnumberformat/) نحوه نمایش این مقادیر را کنترل می‌کند؛ متن را به تاریخ عددی تبدیل نمی‌کند. برای اطلاعات بیشتر درباره سلول‌های دسته، به [Chart Workbook](/slides/fa/net/chart-workbook/) مراجعه کنید.

از تعیین خودکار زمانی که ورودی به وضوح شامل دسته‌های متنی یا تاریخ‌های عددی است استفاده کنید، همان‌طور که در این مثال نشان داده شد. برای برچسب‌های عددی عادی، دسته‌های ترکیبی یا داده‌های خالی، به‌طور صریح [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) را متناسب با معنای موردنظر تنظیم کنید. مقادیر عددی به‌تنهایی نشان نمی‌دهند که دسته‌ها تاریخ هستند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var seriesName = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);
var labels = new[] { "First", "Second", "Third" };

for (var i = 0; i < labels.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, labels[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // متن

var dates = new[] { new DateTime(2026, 1, 1), new DateTime(2026, 1, 2), new DateTime(2026, 2, 1) };

for (var i = 0; i < dates.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0);
    categoryCell.Value = dates[i].ToOADate();
    categoryCell.CustomNumberFormat = "yyyy-mm-dd";
}

axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // تاریخ

presentation.Save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
```

## **کنترل فواصل برچسب‌های محور دسته**

وقتی یک نمودار دارای تعداد زیادی دسته است، می‌توانید تعداد برچسب‌های قابل مشاهده محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) را به `false` تنظیم کنید، سپس [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) را به فاصله دلخواه دسته تنظیم کنید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته آغاز می‌شود:

| فاصله | برچسب‌های نمایش داده شده در مثال |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

یک فاصله `3` هر برچسب سوم را نشان می‌دهد و دو برچسب بین برچسب‌های نمایش داده‌شده پنهان می‌مانند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصلهٔ خودکار بر اساس فضای موجود انتخاب می‌شود؛ لزوماً تمام برچسب‌ها را نمایش نمی‌دهد.

نشانگرهای تیک کنترل‌های جداگانه‌ای دارند. [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) را به `false` تنظیم کنید و از [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) برای تنظیم فاصلهٔ آن‌ها استفاده کنید. برای مثال، `1` یک نشانگر تیک در هر فاصلهٔ دسته نگه می‌دارد در حالی که برچسب‌ها فقط هر سومین دسته ظاهر می‌شوند. [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) را به یک سبک قابل مشاهده تنظیم کنید تا نتیجه را ببینید. تنظیم هر یک از ویژگی‌های فاصلهٔ خودکار به `true` اجازه می‌دهد نمودار دوباره آن فاصله را انتخاب کند.

مثال زیر یک مثال تمام‌وقفه‌ای است که ۲۴ دسته و یک سری ایجاد می‌کند، سپس سه اسلاید را در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصلهٔ خودکار، فاصلهٔ دستی برچسب با نشانگرهای تیک مستقل، و بازگرداندن فاصلهٔ خودکار. دو کپی داده‌های اصلی نمودار را حفظ می‌کنند. ارائه ورودی نیاز نیست. متن برچسب افقی تفاوت چگالی را به‌راحتی نشان می‌دهد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// اسلاید 2: نمایش هر برچسب سوم، اما نگه داشتن نشانگر تیک برای هر دسته.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// اسلاید 3: بگذارید نمودار دوباره هر دو بازه را انتخاب کند.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**فاصلهٔ خودکار (اسلاید ۱):** در این رندر، هر برچسب دوم دسته نمایش داده می‌شود و روی دو خط می‌گردد. نتیجهٔ خودکار ممکن است با اندازهٔ نمودار، قلم‌ها و رندر متفاوت باشد.

![فاصلهٔ خودکار برچسب‌های دسته با تمام ۲۴ ستون قابل مشاهده](category-axis-automatic.png)

**فاصلهٔ دستی (اسلاید ۲):** هر برچسب سوم بر روی یک خط نمایش داده می‌شود، در حالی که نشانگرهای تیک در هر فاصلهٔ دسته باقی می‌مانند. تمام ۲۴ ستون، از جمله آن‌هایی که بدون برچسب هستند، با همان مقادیر قابل مشاهده‌اند. اسلاید ۳ ظاهر خودکار نشان داده‌شده در بالا را بازمی‌گرداند.

![فاصلهٔ دستی برچسب‌های دسته به مقدار سه با تمام ۲۴ ستون قابل مشاهده](category-axis-manual.png)

### **انتخاب محور و فاصله صحیح**

از این فاصلهٔ شمارش دسته برای محور دسته متنی استفاده کنید، مانند محور دسته در نمودار ستونی، خطی، مساحتی یا نوار. در یک نمودار ستونی، این محور افقی است. در نمودار نوار افقی، محور دسته عمودی است، بنابراین این تنظیمات را بر روی [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) اعمال کنید. فاصلهٔ نشانگر تیک همچنین برای محور سری در نمودارهایی که دارای آن هستند اعمال می‌شود.

از فاصلهٔ برچسب دسته برای تنظیم مقیاس عددی محور مقدار استفاده نکنید. در محور مقدار، [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) تفاوتی در مقادیر را مشخص می‌کند: برای مثال، واحد اصلی `10` تیک‌ها را در ۰، ۱۰، ۲۰ و … وقتی محور از صفر شروع شود، تولید می‌کند. فاصلهٔ برچسب دسته `3` به جای مقادیر، موقعیت‌های دسته را می‌شمارد، صرف‌نظر از مقدار داده‌ای آن‌ها. نمودارهای پراکندگی و حباب از محورها‌ی مقدار استفاده می‌کنند نه محور دسته متنی. برای محور تاریخ، از واحدهای اصلی مبتنی بر زمان و مقیاس‌ها همان‌طور که در ‎[Change a Category Axis](#change-a-category-axis)‎ توضیح شد، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌عنوان شماره سریال OLE Automation در اولین کاربرگ (شاخص `0`) ذخیره می‌شوند. [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) را به محور تاریخ تنظیم کنید، [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) را غیرفعال کنید و `yyyy` را به [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) اختصاص دهید تا برچسب‌های دسته به‌صورت سال چهاررقمی نمایش داده شوند، مستقل از قالب‌بندی سلول.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **تنظیم زاویه چرخش برای عنوان محور نمودار**

[HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) را در محور عمودی فعال کنید، متن عنوان را فراهم کنید و [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) را برای چرخاندن عنوان تنظیم کنید. زاویه بر حسب درجه است؛ این مثال یک نمودار ستونی را با عنوان محور مقدار خود را به‌صورت ۹۰ درجه می‌چرخاند و ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **تنظیم موقعیت محور در محور دسته یا مقدار**

از [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) برای کنترل این که آیا محور مقدار در بین دسته‌ها یا در علامت‌های تیک دسته‌ها تقاطع می‌کند استفاده کنید. این ویژگی برای محورهای دسته اعمال می‌شود. مثال این ویژگی را روی محور دسته افقی یک نمودار ستونی به `true` تنظیم می‌کند و نتیجه را ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **تنظیم واحد نمایش در محور مقدار نمودار**

[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) را تنظیم کنید تا برچسب‌های محور مقدار را بدون تغییر داده‌های زیرین مقیاس کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) به `Millions`، مقدار 60 000 000 به‌صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر روی محور عمودی آن اعمال می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **پیکربندی محور مقدار لگاریتمی**

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت چندین مرتبه بزرگ‌نمایی متفاوت داشته باشند. برای مثال، سرویسی ممکن است در پنج دوره درخواست‌های 10، 100، 1 000، 10 000 و 100 000 دریافت کند. در مقیاس خطی، مقادیر کوچکتر نزدیک به صفر به‌هم می‌چسبند. مقیاس لگاریتمی رشد نسبی آن‌ها را راحت‌تر مقایسه می‌کند: فواصل برابر نسبت‌های برابر را نشان می‌دهند نه اختلافات مساوی.

[IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) را بر روی `true` در محور مقدار تنظیم کنید و از [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) برای انتخاب پایه استفاده کنید. این کار نحوه نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. خط روند نمایانگر یک رابطهٔ برازش‌شده در داده‌هاست و ویژگی جداگانه‌ای است.

### **انتخاب محور مقدار و پایه**

برای نمودار خطی یا ستونی، محور مقدار [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) است. برای نمودار نوار افقی، این محور [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/) است. نمودارهای پراکندگی و حباب دو محور مقدار دارند، بنابراین برای مقادیر X محور افقی، برای مقادیر Y محور عمودی یا هر دو انتخاب کنید. مقیاس لگاریتمی را روی محور دسته اعمال نکنید.

پایهٔ پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX، می‌توانید پایه‌ای از `2` تا `1000` استفاده کنید؛ پایه‌های کسری مانند `2.5` هم پشتیبانی می‌شوند. با پایهٔ `10`، توان‌های متوالی مانند 10، 100، 1 000 و 10 000 به‌صورت مساوی فاصله دارند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال زیر یک نمودار خطی ایجاد می‌کند که پنج شمارش درخواست را در اسلاید اول نشان می‌دهد، سپس آن اسلاید را کپی می‌کند و محور مقدار لگاریتمی با پایهٔ 10 را در اسلاید دوم فعال می‌کند. هر دو اسلاید همان داده‌ها را حفظ می‌کنند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// اسلاید اول را به‌صورت خطی نگه دارید و فقط مقیاس محور مقدار نسخهٔ کپی را تغییر دهید.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**مقیاس خطی (اسلاید ۱):** فواصل عمودی برابر نشانگرهای برابر در تعداد درخواست‌ها هستند. مقدار بزرگ‌ترین داده نمودار را مسلط می‌کند و مقادیر کوچکتر را تشخیص سخت می‌شود.

![نمودار خطی در PowerPoint که پنج شمارش درخواست را روی محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید ۲):** فواصل عمودی برابر نسبت‌های برابر را نشان می‌دهند. هر دوره ده برابر دوره قبلی درخواست دارد، بنابراین نقاط در مقیاس پایهٔ 10 یک خط صعودی مستقیم تشکیل می‌دهند. برچسب‌های محور همچنان شمارش‌های اصلی درخواست را نشان می‌دهند.

![همان پنج شمارش درخواست در PowerPoint روی محور مقدار لگاریتمی پایهٔ 10](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

مقیاس لگاریتمی فقط می‌تواند مقادیر مثبت صریح را نمایش دهد. قبل از فعال‌سازی آن داده‌ها را بررسی کنید. اگر صفر یا مقادیر منفی معنایی داشته باشند، مقیاس خطی را استفاده کنید یا آن‌ها را جداگانه نمایش دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل حذف را توضیح دهید. به‌صورت خاموش آنها را با اعداد مثبت کوچک جایگزین نکنید، زیرا معنای داده را تغییر می‌دهد. هر حداقل یا حداکثر به‌دست‌آمده برای محور لگاریتمی نیز باید مثبت باشد.

## **سوالات متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر را تنظیم کنم؟**

از [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) برای انتخاب رفتار تقاطع استفاده کنید. برای تعیین مقدار تقاطع عددی، [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) را تنظیم کنید. این تنظیمات به شما امکان می‌دهند تقاطع محور را به خط پایهٔ مناسب منتقل کنید.

**چگونه می‌توان برچسب‌های تیک را نسبت به محور موقعیت‌دهی کرد؟**

[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) را با استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) تنظیم کنید: `Low`, `High`, `NextTo` یا `None`. برای کنترل خود نشانگرهای تیک، از [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) یا [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) استفاده کنید؛ این‌ها جدا از موقعیت برچسب‌ها هستند.
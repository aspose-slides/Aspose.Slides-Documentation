---
title: سفارشی‌سازی محورها در نمودارهای ارائه در .NET
linktitle: محور نمودار
type: docs
url: /fa/net/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دستکاری محور
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
description: "کشف کنید چگونه از Aspose.Slides برای .NET استفاده کنید تا محورها را در نمودارهای ارائه PowerPoint برای گزارش‌ها و تجسم‌ها سفارشی کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه محورها را در نمودارها با Aspose.Slides برای .NET سفارشی کنید. این مقاله شامل مقادیر محاسبه‌شده محور، تعویض سطرها و ستون‌های نمودار، نمایش محور، فواصل برچسب‌های دسته و علامت‌های تیک، دسته‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت‌دهی محور و واحدهای نمایش می‌شود.

## **دریافت مقادیر حداکثری در محور عمودی نمودارها**

یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) را فراخوانی کنید تا طرح‌بندی نمودار به‌روز باشد.

مقادیر [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) و [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) را برای حدود محور بخوانید و برای فواصل تیک‌ها از [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) و [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) استفاده کنید. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) و [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) مقیاس‌های واحد زمانی را فراهم می‌کنند که برای محورهای تاریخ مرتبط هستند. این مثال این مقادیر را در متغیرهای محلی ذخیره کرده و نمودار را ذخیره می‌کند.

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

از [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) برای تعویض نقش‌های سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته قبلی به یک سری تبدیل می‌شود و هر سری قبلی به یک دسته. این تغییر نحوه گروه‌بندی داده‌ها را تغییر می‌دهد؛ محورهای افقی و عمودی را جابه‌جا نمی‌کند. این مثال از [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) برای اتصال داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل سطر سرصفحه و ستون دسته، قبل از جابه‌جایی سطرها و ستون‌ها استفاده می‌کند. یک نمودار با چهار سری و سه دسته ذخیره می‌شود.

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

## **غیر فعال کردن محور عمودی برای نمودارهای خطی**

[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) را روی `false` در محور عمودی تنظیم کنید تا مخفی شود. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با مخفی بودن محور عمودی ذخیره می‌کند.

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

## **غیر فعال کردن محور افقی برای نمودارهای خطی**

[IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) را روی `false` در محور افقی تنظیم کنید تا مخفی شود. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با مخفی بودن محور افقی ذخیره می‌کند.

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

## **تغییر محور دسته**

[CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) را تنظیم کنید تا یک محور دسته تاریخ یا متنی انتخاب شود. این مثال به `ExistingChart.pptx` نیاز دارد که شامل نموداری به‌عنوان اولین شکل در اولین اسلاید باشد و سلول‌های دسته حاوی مقدارهای عددی تاریخ Excel باشند. محور افقی را به یک محور تاریخ تغییر می‌دهد. تنظیم [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) روی `false`، [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) روی `1` و [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) روی ماه‌ها، تیک‌های اصلی را در فواصل یک‌ماهه قرار می‌دهد.

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

## **کنترل فواصل برچسب‌های محور دسته**

هنگامی که یک نمودار دارای تعداد زیادی دسته است، تعداد برچسب‌های قابل مشاهده محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) را روی `false` تنظیم کنید، سپس [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) را به فاصله دلخواه تنظیم کنید. برای دسته‌های متنی به ترتیب عادی، شمارش از اولین دسته آغاز می‌شود:

| فاصله | برچسب‌های نمایش داده شده در مثال |
| --- | --- |
| `1` | دسته 1، دسته 2، دسته 3، … دسته 24 |
| `2` | دسته 1، دسته 3، دسته 5، … دسته 23 |
| `3` | دسته 1، دسته 4، دسته 7، … دسته 22 |

فاصله `3` هر برچسب سوم را نمایش می‌دهد و دو برچسب بین برچسب‌های نمایش داده شده مخفی می‌مانند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصله خودکار بر اساس فضای موجود یک مقدار را انتخاب می‌کند؛ لزوماً همه برچسب‌ها را نمایش نمی‌دهد.

علامت‌های تیک دارای کنترل‌های جداگانه‌ای هستند. [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) را روی `false` تنظیم کنید و با استفاده از [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) فاصله آن‌ها را تنظیم کنید. برای مثال، `1` یک علامت تیک در هر فاصله دسته حفظ می‌کند در حالی که برچسب‌ها فقط هر سومین دسته ظاهر می‌شوند. [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) را به یک سبک قابل مشاهده تنظیم کنید تا نتیجه را ببینید. تنظیم هر یک از ویژگی‌های فاصله خودکار به `true` اجازه می‌دهد تا نمودار دوباره همان فاصله را انتخاب کند.

مثال خودمستقلی زیر ۲۴ دسته و یک سری ایجاد می‌کند، سپس سه اسلاید را در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصله خودکار، فاصله برچسب دستی با علامت‌های تیک مستقل، و بازگرداندن فاصله خودکار. دو نسخه کپی داده‌های اصلی نمودار را حفظ می‌کنند. ارائه ورودی موردنیاز نیست. متن برچسب افقی تفاوت چگالی را به‌راحتی نشان می‌دهد.

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

// اسلاید ۲: نمایش هر سومین برچسب، ولی نگه داشتن یک علامت تیک برای هر دسته.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// اسلاید ۳: اجازه بدهید نمودار دوباره هر دو بازه را انتخاب کند.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**فاصله خودکار (اسلاید 1):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و به دو خط می‌پیچد. نتیجه خودکار می‌تواند بسته به اندازه نمودار، قلم‌ها و رندر کننده متفاوت باشد.

![فاصله خودکار برچسب‌های دسته با نمایش همه ۲۴ ستون](category-axis-automatic.png)

**فاصله دستی (اسلاید 2):** هر سومین برچسب در یک خط نمایش داده می‌شود، در حالی که علامت‌های تیک در هر فاصله دسته باقی می‌مانند. همه ۲۴ ستون، از جمله آن‌هایی که برچسب ندارند، با همان مقادیر قابل مشاهده هستند. اسلاید 3 ظاهر خودکار نشان‌داده‌شده در بالا را بازمی‌گرداند.

![فاصله دستی برچسب‌های دسته به اندازه سه با نمایش همه ۲۴ ستون](category-axis-manual.png)

### **انتخاب محور و فاصله صحیح**

از این فاصله شمارش دسته برای یک محور دسته متنی استفاده کنید، مانند محور دسته یک نمودار ستونی، خطی، ناحیه‌ای یا میله‌ای. در یک نمودار ستونی، این محور افقی است. در یک نمودار میله‌ای افقی، محور دسته عمودی است، بنابراین این تنظیمات را برای [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) اعمال کنید. فاصله علامت‌های تیک همچنین برای محور سری در نمودارهایی که یک محور دارند صدق می‌کند.

از فاصله برچسب دسته برای تنظیم مقیاس عددی یک محور مقدار استفاده نکنید. در یک محور مقدار، [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) اختلافی در مقادیر را مشخص می‌کند: به عنوان مثال، یک واحد اصلی `10` تیک‌ها را در 0، 10، 20 و غیره تولید می‌کند هنگامی که محور از صفر شروع می‌شود. یک فاصله برچسب دسته `3` به‌جای آن موقعیت‌های دسته را می‌شمارد، صرف‌نظر از مقادیر داده‌ای آن‌ها. نمودارهای پراکندگی و حباب از محورها مقدار استفاده می‌کنند نه از محور دسته متنی. برای یک محور تاریخ، از واحدهای اصلی مبتنی بر زمان و مقیاس‌ها همان‌طور که در [Change a Category Axis](#change-a-category-axis) توصیف شده است، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته**

این مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌عنوان شماره‌های سریال OLE Automation در اولین برگه کاری (اندیس `0`) ذخیره می‌شوند. [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) را به یک محور تاریخ تنظیم کنید، [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) را غیرفعال کنید و `yyyy` را به [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) اختصاص دهید تا برچسب‌های دسته سال‌های چهاررقمی را مستقل از قالب‌بندی سلول نمایش دهند.

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

[HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) را در محور عمودی فعال کنید، متن عنوان را فراهم کنید و [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) را برای چرخش عنوان تنظیم کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی را با عنوان محور مقدار چرخانده به 90 درجه ذخیره می‌کند.

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

از [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) برای کنترل این‌که آیا محور مقدار بین دسته‌ها یا در علامت‌های تیک دسته عبور می‌کند استفاده کنید. این ویژگی برای محورها دسته اعمال می‌شود. مثال آن را روی محور دسته افقی یک نمودار ستونی به `true` تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

## **تنظیم واحد نمایش بر روی محور مقدار نمودار**

[DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) را تنظیم کنید تا برچسب‌های محور مقدار بدون تغییر داده‌های پایه مقیاس‌بندی شوند. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) به `Millions`، مقدار 60,000,000 به صورت 60 نشان داده می‌شود. این مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر روی محور عمودی آن اعمال می‌کند.

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

## **سوالات متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر را تنظیم کنم؟**

از [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) برای انتخاب رفتار تقاطع استفاده کنید. برای مشخص کردن مقدار عددی تقاطع، [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) را تنظیم کنید. این تنظیمات به شما امکان می‌دهد تقاطع محور را به یک خط پایه مناسب منتقل کنید.

**چگونه می‌توانم برچسب‌های تیک را نسبت به محور موقعیت‌گذاری کنم؟**

[TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) را با استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) تنظیم کنید: `Low`, `High`, `NextTo` یا `None`. برای کنترل خود علامت‌های تیک، از [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) یا [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) استفاده کنید؛ این‌ها جدا از موقعیت‌گذاری برچسب‌ها هستند.
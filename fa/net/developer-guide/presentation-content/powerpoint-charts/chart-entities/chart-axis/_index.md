---
title: سفارشی‌سازی محورهای نمودار در ارائه‌ها در .NET
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
- خصوصیات محور
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
description: "کشف کنید چگونه می‌توانید از Aspose.Slides برای .NET برای سفارشی‌سازی محورهای نمودار در ارائه‌های PowerPoint جهت گزارش‌ها و تجسم‌ها استفاده کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه محورهای نمودار را با Aspose.Slides برای .NET سفارشی کنید. این مقاله به مقادیر محاسبه‌شده محور، جابجایی ردیف‌ها و ستون‌های نمودار، قابلیت مشاهده محور، بازه‌های برچسب دسته و علامت‌گذاری تیک‌ها، دسته‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت‌یابی محور، واحدهای نمایش و مقیاس لگاریتمی می‌پردازد.

## **دریافت مقادیر بیشینه در محور عمودی نمودارها**

یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد کنید و یک نمودار مساحتی با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) را فراخوانی کنید تا چیدمان نمودار به‌روز باشد.

مقادیر [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) و [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) را برای محدوده‌های محور بخوانید و [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) و [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) را برای بازه‌های تیک‌ها دریافت کنید. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) و [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) مقیاس‌های زمان‑واحد را ارائه می‌دهند که برای محورهای تاریخ مرتبط هستند. این مثال این مقادیر را در متغیرهای محلی ذخیره می‌کند و نمودار را ذخیره می‌نماید.

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

از [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته قبلی تبدیل به یک سری می‌شود و هر سری قبلی تبدیل به یک دسته می‌شود. این تغییر نحوه گروه‌بندی داده‌ها را تغییر می‌دهد؛ محورهای افقی و عمودی را جابه‌جا نمی‌کند. این مثال از [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) برای بستن داده‌های پیش‌فرض به `Sheet1!A1:D5` استفاده می‌کند، شامل ردیف سرعنوان و ستون دسته، قبل از جابجایی ردیف‌ها و ستون‌ها. سپس نموداری با چهار سری و سه دسته ذخیره می‌کند.

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

## **غیرفعال‌سازی محور عمودی برای نمودارهای خطی**

مقدار [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) را روی `false` برای محور عمودی تنظیم کنید تا مخفی شود. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور عمودی مخفی ذخیره می‌کند.

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

## **غیرفعال‌سازی محور افقی برای نمودارهای خطی**

مقدار [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) را روی `false` برای محور افقی تنظیم کنید تا مخفی شود. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور افقی مخفی ذخیره می‌کند.

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

## **تغییر محور دسته‌ای**

مقدار [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) را تنظیم کنید تا یک محور دسته تاریخی یا متنی انتخاب شود. این مثال به `ExistingChart.pptx` نیاز دارد، که شامل یک نمودار به عنوان اولین شکل در اولین اسلاید است و سلول‌های دسته شامل مقادیر عددی تاریخ Excel می‌باشند. این مثال محور افقی را به یک محور تاریخ تبدیل می‌کند. تنظیم [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) روی `false`، [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) روی `1` و [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) روی ماه‌ها، علامت‌های بزرگ را در فواصل یک ماهی تنظیم می‌کند.

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

## **کنترل بازه برچسب‌های محور دسته‌ای**

هنگامی که یک نمودار دارای دسته‌های زیادی باشد، می‌توانید تعداد برچسب‌های قابل مشاهده محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. مقدار [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) را روی `false` تنظیم کنید، سپس [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) را به بازه موردنظر دسته تنظیم کنید. برای دسته‌های متنی به ترتیب عادی، شمارش از اولین دسته شروع می‌شود:

| بازه | برچسب‌های نمایش داده شده در مثال |
| --- | --- |
| `1` | دسته 1, دسته 2, دسته 3, … دسته 24 |
| `2` | دسته 1, دسته 3, دسته 5, … دسته 23 |
| `3` | دسته 1, دسته 4, دسته 7, … دسته 22 |

بازه `3` هر برچسب سوم را نمایش می‌دهد و دو برچسب بین برچسب‌های نمایش داده شده مخفی می‌ماند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصله خودکار بر مبنای فضای موجود یک بازه انتخاب می‌کند؛ لزوماً تمام برچسب‌ها را نمایش نمی‌دهد.

علامت‌های تیک کنترل‌های جداگانه‌ای دارند. مقدار [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) را روی `false` تنظیم کنید و از [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) برای تنظیم بازهٔ آن‌ها استفاده کنید. به عنوان مثال، `1` علامت تیک را در هر بازهٔ دسته نگه می‌دارد در حالی که برچسب‌ها فقط هر سومین دسته ظاهر می‌شوند. مقدار [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) را به سبکی قابل مشاهده تنظیم کنید تا نتیجه را ببینید. تنظیم هر یک از خصوصیات فاصله خودکار به `true` باعث می‌شود نمودار دوباره آن بازه را انتخاب کند.

مثال خودمحافظ زیر ۲۴ دسته و یک سری ایجاد می‌کند، سپس سه اسلاید را در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصله خودکار، فاصله برچسب دستی با علامت‌های تیک مستقل، و بازگرداندن فاصله خودکار. دو نسخه داده‌های اصلی نمودار را حفظ می‌کنند. نیازی به ارائه ورودی نیست. متن برچسب افقی تفاوت چگالی را به‌صورت واضح نشان می‌دهد.

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

// اسلاید ۲: هر برچسب سوم را نشان دهید، اما برای هر دسته یک علامت تیک نگه دارید.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// اسلاید ۳: اجازه دهید نمودار دوباره هر دو بازه را انتخاب کند.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**فاصله خودکار (اسلاید ۱):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و به دو خط می‌پیچد. نتیجهٔ خودکار می‌تواند با اندازه نمودار، قلم‌ها و رندرر متفاوت باشد.

![فاصله خودکار برچسب دسته با نمایش تمام ۲۴ ستون](category-axis-automatic.png)

**فاصله دستی (اسلاید ۲):** هر سومین برچسب بر روی یک خط نمایش داده می‌شود، در حالی که علامت‌های تیک در هر بازهٔ دسته باقی می‌مانند. تمام ۲۴ ستون، از جمله ستون‌های بدون برچسب، با همان مقادیر قابل مشاهده هستند. اسلاید ۳ ظاهر خودکار نشان داده‌شده در بالا را بازمی‌گرداند.

![فاصله برچسب دسته دستی به مقدار سه با نمایش همهٔ ۲۴ ستون](category-axis-manual.png)

### **انتخاب محور و بازهٔ صحیح**

از این بازهٔ شمارش دسته برای یک محور دسته‌ای متنی استفاده کنید، مانند محور دسته‌ای یک نمودار ستون، خط، مساحت یا میله. در یک نمودار ستون، این محور افقی است. در یک نمودار میله‌ای افقی، محور دسته عمودی است، بنابراین این تنظیمات را بر روی [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) اعمال کنید. فاصله علامت‌های تیک نیز برای محور سری در نمودارهایی که دارای آن هستند اعمال می‌شود.

از فاصله برچسب دسته برای تنظیم مقیاس عددی یک محور مقدار استفاده نکنید. در یک محور مقدار، [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) اختلافی در مقادیر را مشخص می‌کند: به عنوان مثال، یک واحد اصلی `10` تیک‌ها را در ۰، ۱۰، ۲۰ و غیره تولید می‌کند زمانی که محور از صفر شروع می‌شود. بازهٔ برچسب دسته‌ای `3` به‌جای مقادیر داده‌ای، موقعیت‌های دسته‌ای را می‌شمارد. نمودارهای پراکنده و حبابی از محورهای مقدار استفاده می‌کنند نه یک محور دسته‌ای متنی. برای یک محور تاریخ، از واحدهای اصلی مبتنی بر زمان و مقیاس‌ها همان‌طور که در [Change a Category Axis](#change-a-category-axis) توضیح داده شده است، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌ای**

این مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به عنوان شماره‌های سریال OLE Automation در اولین کاربرگ (اندیس `0`) ذخیره می‌شوند. مقدار [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) را به یک محور تاریخ تنظیم کنید، [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) را غیرفعال کنید و `yyyy` را به [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) اختصاص دهید تا برچسب‌های دسته سال‌های چهاررقمی را صرف‌نظر از قالب‌بندی سلول‌ها نمایش دهند.

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

## **تنظیم زاویهٔ چرخش برای عنوان محور نمودار**

در محور عمودی، ویژگی [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) را فعال کنید، متن عنوان را فراهم کنید و مقدار [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) را برای چرخش عنوان تنظیم کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستون را با عنوان محور مقدار که ۹۰ درجه چرخیده است، ذخیره می‌کند.

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

## **تنظیم موقعیت محور بر روی محور دسته‌ای یا مقدار**

از [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) برای کنترل این‌که آیا محور مقدار، محور دسته را بین دسته‌ها یا در علامت‌گذاری‌های دسته عبور می‌دهد، استفاده کنید. این ویژگی بر محورهای دسته‌ای اعمال می‌شود. مثال این مقدار را روی `true` برای محور دسته افقی یک نمودار ستون تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

مقدار [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) را تنظیم کنید تا برچسب‌های یک محور مقدار را بدون تغییر داده‌های پایه مقیاس‌بندی کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) روی `Millions`، مقدار ۶۰,۰۰۰,۰۰۰ به صورت ۶۰ نمایش داده می‌شود. این مثال یک نمودار ستون ایجاد می‌کند و واحد نمایش میلیون‌ها را بر محور عمودی آن اعمال می‌کند.

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

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت در چندین مرتبه بزرگنمایی متفاوت باشند. برای مثال، یک سرویس ممکن است در پنج دوره درخواست‌های ۱۰، ۱۰۰، ۱٬۰۰۰، ۱۰٬۰۰۰ و ۱۰۰٬۰۰۰ دریافت کند. در مقیاس خطی، مقادیر کوچکتر نزدیک به صفر به‌هم چسبیده ظاهر می‌شوند. مقیاس لگاریتمی رشد نسبی آن‌ها را آسان‌تر مقایسه می‌کند: فواصل برابر نشان‌دهنده نسبت‌های برابر هستند نه اختلاف‌های عددی برابر.

مقدار [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) را روی `true` برای محور مقدار تنظیم کنید و از [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) برای انتخاب پایه استفاده کنید. این کار نحوهٔ نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. یک خط روند رابطهٔ برازش‌شده‌ای در داده‌ها را نشان می‌دهد و ویژگی جداگانه‌ای است.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خطی یا ستونی، محور مقدار [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) است. برای یک نمودار میله‌ای افقی، محور مقدار [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/) است. نمودارهای پراکنده و حبابی دو محور مقدار دارند، بنابراین محور افقی را برای مقادیر X، محور عمودی را برای مقادیر Y یا هر دو انتخاب کنید. مقیاس لگاریتمی را روی یک محور دسته اعمال نکنید.

پایهٔ پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX، می‌توانید پایه‌ای بین `2` تا `1000` (شامل) استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایه `10`، توان‌های متوالی مانند 10، 100، 1,000 و 10,000 به‌طور مساوی فاصله دارند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال خودمحافظ زیر یک نمودار خطی با پنج شمارش درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کلون می‌کند و در اسلاید دوم یک محور مقدار لگاریتمی پایه‑۱۰ فعال می‌کند. هر دو اسلاید داده‌های یکسانی را حفظ می‌کنند.

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

// اولین اسلاید را خطی نگه دارید و فقط مقیاس محور مقدار کپی را تغییر دهید.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**مقیاس خطی (اسلاید ۱):** فواصل عمودی برابر نشان‌دهندهٔ اختلافات برابر در شمارش درخواست‌ها هستند. بزرگ‌ترین مقدار بر نمودار تسلط دارد و مقادیر کوچکتر را تشخیص دادن دشوار می‌کند.

![نمودار خطی در پاورپوینت نشان‌دهنده پنج شمارش درخواست در یک محور مقدار خطی](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید ۲):** فواصل عمودی برابر نشان‌دهنده نسبت‌های برابر هستند. هر دوره درخواست‌هایش ده برابر دورهٔ قبلی است، بنابراین نقاط یک خط صعودی مستقیم روی مقیاس پایه‑۱۰ تشکیل می‌دهند. برچسب‌های محور هنوز شمارش درخواست‌های اصلی را نمایش می‌دهند.

![پنج شمارش درخواست مشابه در پاورپوینت بر روی محور مقدار لگاریتمی پایه‑۱۰](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

یک مقیاس لگاریتمی فقط می‌تواند مقادیر کاملاً مثبت را نمایش دهد. قبل از فعال‌سازی آن، داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنایی داشته باشند، مقیاس خطی را نگه دارید یا آن‌ها را جداگانه نمایش دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل حذف را توضیح دهید. به‌طور خاموش مقادیر را با اعداد مثبت کوچک جایگزین نکنید، زیرا این کار معنای داده‌ها را تغییر می‌دهد. هر مقدار حداقل یا حداکثر به‌صورت دستی تنظیم‌شده برای یک محور لگاریتمی نیز باید مثبت باشد.

## **سؤالات متداول**

**چگونه مقدار تقاطع محور با دیگری را تنظیم کنم (تقاطع محور)؟**

از [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) برای انتخاب رفتار تقاطع استفاده کنید. برای تعیین یک مقدار عددی تقاطع، [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) را تنظیم کنید. این تنظیمات به شما امکان می‌دهند تقاطع محور را به یک خط پایه مناسب منتقل کنید.

**چگونه می‌توانم برچسب‌های تیک را نسبت به محور موقعیت‌دهی کنم؟**

مقدار [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) را با استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`، `High`، `NextTo` یا `None` تنظیم کنید. برای کنترل خود علامت‌های تیک، از [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) یا [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) استفاده کنید؛ این‌ها جدا از موقعیت برچسب‌ها هستند.
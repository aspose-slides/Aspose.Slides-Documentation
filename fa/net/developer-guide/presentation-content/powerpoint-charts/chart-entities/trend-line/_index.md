---
title: افزودن خطوط روند به نمودارهای ارائه در .NET
linktitle: خط روند
type: docs
url: /fa/net/trend-line/
keywords:
- نمودار
- خط روند
- خط روند نمایی
- خط روند خطی
- خط روند لگاریتمی
- خط روند متوسط متحرک
- خط روند چندجمله‌ای
- خط روند توان
- خط روند سفارشی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌سرعت خطوط روند را در نمودارهای PowerPoint با Aspose.Slides برای .NET اضافه و سفارشی کنید — راهنمای عملی برای جذب مخاطبان شما."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه خطوط روند را با استفاده از Aspose.Slides به نمودارهای ارائه اضافه کنیم. این مقاله نشان می‌دهد چگونه یک نمودار ساخته شود، خطوط روند به سری‌های نمودار اضافه شوند و با انواع مختلف خطوط روند کار شود، از جمله نمایی، خطی، لگاریتمی، متوسط متحرک، چندجمله‌ای و توان.

همچنین شرح می‌دهد چگونه یک خط سفارشی به نمودار اضافه شود با درج یک شکل خط، و شامل سؤالات متداول کوتاهی درباره مقادیر پیش‌روی و پس‌روی خط روند و این که آیا خطوط روند در هنگام صادرات به PDF یا SVG و هنگام رندر نمودارها به تصویر حفظ می‌شوند یا خیر.

## **افزودن خط روند**

از [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) برای افزودن خط روند به یک سری نمودار استفاده کنید و نوع آن را با [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/) انتخاب کنید. مثال یک نمودار ستون خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند و دو خط روند به هر یک از سه سری آن اضافه می‌نماید.

خط روند نمایی معادله و مقدار R‑squared خود را از طریق [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) و [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/) مخفی می‌کند، در حالی که خط روند خطی قرمز است. خط روند لگاریتمی از [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) برای برچسب سفارشی استفاده می‌کند. متوسط متحرک از یک [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) سه نقطه داده و یک [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/) سفارشی بهره می‌برد.

خط روند چندجمله‌ای دارای یک [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) سه است و یک دسته به سمت جلو از طریق [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/) گسترش می‌یابد. خط روند توان یک دسته به سمت عقب از طریق [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/) گسترش می‌دهد.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **تنظیم مقطع خط روند**

از [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) برای ثابت نگه داشتن مقدار Y خط روند در X = 0 استفاده کنید. این تنظیم برای خطوط روند خطی، نمایی و چندجمله‌ای پشتیبانی می‌شود.

به‌عنوان مثال، یک مدل هزینه تولید ممکن است نیاز داشته باشد از هزینه‌های ثابت شناخته‌شده ۱۰۰ شروع شود، حتی زمانی که اندازه‌گیری‌ها در مقادیر تولید غیر صفر نشان‌دهنده مبنای متفاوتی باشند. برای یک خط روند خطی، ثابت‌کردن مقطع معادله `y = ax + b` را به `b = 100` محدود می‌کند؛ شیب تحت آن محدودیت به داده‌ها تنظیم می‌شود. این کار به سادگی خطی که پیش از این برازش شده را جابه‌جا نمی‌کند. تنظیمات عبور محور، محل تقاطع محورها را کنترل می‌کند، نه ضرایب خط روند برازش‌شده.

مثال زیر یک نمودار نقطه‌ای (XY) با حجم‌های تولید از ۱ تا ۴ و هزینه‌های ۱۷۰، ۲۰۰، ۲۳۰ و ۲۶۰ ایجاد می‌کند. این نمودار را با مقطع خودکار پیش‌فرض ذخیره می‌کند، مقطع را به ۱۰۰ تنظیم می‌کند و یک فایل PPTX دوم ذخیره می‌کند. دو فایل تنها در تنظیم مقطع متفاوت هستند. خط روند معادله خود را نمایش می‌دهد و به X = 0 باز می‌گردد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

با محاسبه خودکار، این داده‌ها `y = 30x + 140` را تولید می‌کنند. تنظیم مقطع به ۱۰۰ به‌جای آن تقریباً `y = 43.33x + 100` می‌دهد: مقدار برازش‌شده در صفر با مبنای شناخته‌شده مطابقت دارد، در حالی که خط دیگر از تمام نقاط داده عبور نمی‌کند.

| مقطع خودکار | مقطع ثابت ۱۰۰ |
| --- | --- |
| ![خط روند خطی با مقطع محاسبه‌شده خودکار 140](intercept-automatic.png) | ![خط روند خطی با مقطع ثابت 100](intercept-fixed.png) |

هر دو تصویر از داده‌ها و مقیاس‌های محور یکسان استفاده می‌کنند. خطوط روند به سمت X = 0 گسترش یافته‌اند تا مقاطعشان نمایش داده شود.

به‌طور پیش‌فرض، این ویژگی مقدار `double.NaN` را دارد که نشان‌دهنده مقطع نامشخص است نه صفر. سپس مقطع به‌صورت خودکار از داده‌ها محاسبه می‌شود.

## **افزودن خط سفارشی**

خط سفارشی یک شکل است که بر روی نمودار کشیده می‌شود نه خط روندی که از داده‌های سری محاسبه می‌شود. این مثال از [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) برای افزودن یک خط افقی به اسلاید روی نمودار استفاده می‌کند. موقعیت خط در مختصات اسلاید، بر حسب نقطه، مشخص می‌شود، به طوری که از لبه چپ نمودار شروع شده و در میان ارتفاع نمودار قرار می‌گیرد. عرض آن برابر با عرض نمودار است. [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) به خط رنگ قرمز یکدست می‌دهد.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **پرسش‌های متداول**

**معنی 'forward' و 'backward' برای خط روند چیست؟**

آنها طول‌های خط روند هستند که به جلو/به عقب پیش‌بینی می‌شوند: برای نمودارهای نقطه‌ای (XY) — بر حسب واحدهای محور؛ برای نمودارهای غیر نقطه‌ای — بر حسب تعداد دسته‌ها. تنها مقادیر غیرمنفی مجاز هستند.

**آیا خط روند هنگام صادرات ارائه به PDF یا SVG، یا هنگام رندر اسلاید به تصویر حفظ می‌شود؟**

بله. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/net/convert-powerpoint-to-pdf/) یا [SVG](/slides/fa/net/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصاویر رندر می‌کند؛ خطوط روند به عنوان بخشی از نمودار در طول این عملیات‌ها حفظ می‌شوند. همچنین روشی برای [export an image of the chart](/slides/fa/net/create-shape-thumbnails/) موجود است.
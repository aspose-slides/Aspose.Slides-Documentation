---
title: سفارشی‌سازی نمودارهای 3D در ارائه‌ها در .NET
linktitle: نمودار 3D
type: docs
url: /fa/net/3d-chart/
keywords:
- نمودار 3D
- چرخش
- عمق
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نمودارهای سه‌بعدی را در ارائه‌های PowerPoint با Aspose.Slides برای .NET ایجاد کنید. چرخش، نسبت‌های ارتفاع، عمق نمودار و فاصله بین سری‌ها را با مثال‌های C# تنظیم کنید."
---
## **نمای کلی**

Aspose.Slides for .NET به شما امکان می‌دهد نمای یک نمودار سه‌بعدی را از طریق ویژگی [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) سفارشی کنید. این مقاله نشان می‌دهد چگونه چرخش، نسبت‌های ارتفاع، عمق، محورهای زاویه راست، و فاصله بین سری‌ها را تنظیم کنید و سپس ارائه را با فرمت PPTX ذخیره نمایید.

## **تنظیم چرخش و عمق یک نمودار سه‌بعدی**

مثال زیر یک [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ایجاد می‌کند و از [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) برای افزودن یک نمودار ستونی سه‌بعدی پشته‌ای به اسلاید اول آن استفاده می‌کند. این مثال سری‌ها و دسته‌بندی‌های پیش‌فرض را با دو سری که هر کدام سه مقدار دارند، جایگزین می‌کند. شاخص ورک‌شیت `0` شیت داده اولین نمودار را شناسایی می‌کند؛ ردیف `0` نام‌های سری‌ها را دارد و ستون `0` برچسب‌های دسته را دارد.

ویژگی‌های [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) و [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) به ترتیب چرخش نمودار را به ۴۰ و ۲۷۰ درجه تنظیم می‌کنند. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) عمق آن را به ۱۵۰٪ از عرضش تنظیم می‌کند، در حالی که [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) محورهای زاویه راست را به جای پرسپکتیو فعال می‌سازد. ارائهٔ حاصل شامل نمودار پر شده با این تنظیمات نمای سه‌بعدی است.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **اعمال پر کردن تصویر به سطح نمودار سه‌بعدی**

یک نمودار سه‌بعدی دارای سه سطح است که می‌توانید به صورت مستقل پر کنید: [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/)، [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) و [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). نوع پر کردن سطح انتخاب شده را با [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) به `Picture` تنظیم کنید و یک تصویر اختصاص دهید. هم [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) و هم [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) سطح را به `Stretch` تنظیم کنید تا یک نسخه از تصویر در سرتاسر سطح کشیده شود.

[arrow.png](arrow.png) را در پوشه کاری ذخیره کنید. مثال نمودار را می‌چرخاند و مقدار حداکثری محور عمودی را افزایش می‌دهد تا کف بین ستون‌ها قابل مشاهده باشد. سپس اسلاید را دو بار کپی می‌کند و قبل از اعمال پیکان، هر بار سطح متفاوتی را انتخاب می‌کند. هر سه نمودار داده‌ها، زاویه نمایش و پس‌زمینه یکسانی دارند.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 20, 30, 680, 480);
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 30;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 24;

var backSlide = presentation.Slides.AddClone(slide);
var floorSlide = presentation.Slides.AddClone(slide);
var backChart = (IChart)backSlide.Shapes[0];
var floorChart = (IChart)floorSlide.Shapes[0];

var imageBytes = File.ReadAllBytes("arrow.png");
var arrow = presentation.Images.AddImage(imageBytes);

foreach (var surface in new[] { chart.SideWall, backChart.BackWall, floorChart.Floor })
{
    var fill = surface.Format.Fill;
    fill.FillType = FillType.Picture;
    fill.PictureFillFormat.Picture.Image = arrow;
    fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    surface.PictureType = PictureType.Stretch;
}

presentation.Save("chart-surfaces.pptx", SaveFormat.Pptx);
```

Microsoft PowerPoint سه اسلاید را به صورت زیر نمایش می‌دهد.

| دیوار جانبی | دیوار خلفی | کف |
| --- | --- | --- |
| ![پیکان نشان‌گر به داخل نمودار در طول دیوار جانبی](side-wall.png) | ![پیکان نشان‌گر به سمت راست در طول دیوار خلفی](back-wall.png) | ![پیکان نشان‌گر به سمت راست در طول کف بین ستون‌ها](floor.png) |

## **تنظیم نسبت‌های ارتفاع یک نمودار سه‌بعدی**

از [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) برای تنظیم ارتفاع یک نمودار سه‌بعدی به عنوان درصدی از عرض آن استفاده کنید. این کار نسبت‌های صحنهٔ سه‌بعدی را بدون تغییر اندازهٔ شیء نمودار در اسلاید تغییر می‌دهد.

مثال زیر یک نمودار [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) با داده‌های پیش‌فرض ایجاد می‌کند: سه سری و چهار دسته. این مثال سه ارائه را با نسبت‌های ارتفاع ۵۰٪، ۱۰۰٪ و ۲۰۰٪ ذخیره می‌کند. موقعیت، عرض و ارتفاع نمودار ثابت می‌مانند. داده‌ها، چرخش، عمق، فاصله سری‌ها و قالب‌بندی در هر سه فایل یکسان است؛ تنها درصد ارتفاع تغییر می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

تصاویر زیر از ارائه‌های تولید شده با استفاده از Microsoft PowerPoint استخراج شده‌اند. درصد کوچکتر صحنه‌ای صاف‌تر ایجاد می‌کند، در حالی که درصد بزرگتر صحنه‌ای بلندتر در همان شیء نمودار می‌سازد. PowerPoint ممکن است فواصل تیک‌های محور و موقعیت برچسب‌ها را برای متناسب شدن با صحنه تنظیم کند.

| ارتفاع: ۵۰٪ | ارتفاع: ۱۰۰٪ | ارتفاع: ۲۰۰٪ |
| --- | --- | --- |
| ![نمودار ستونی سه‌بعدی با ارتفاع تنظیم‌شده به ۵۰ درصد از عرض آن](height_percent_50.png) | ![نمودار ستونی سه‌بعدی با ارتفاع تنظیم‌شده به ۱۰۰ درصد از عرض آن](height_percent_100.png) | ![نمودار ستونی سه‌بعدی با ارتفاع تنظیم‌شده به ۲۰۰ درصد از عرض آن](height_percent_200.png) |

این ویژگی‌ها جنبه‌های مختلفی از نمودار را کنترل می‌کنند:

| ویژگی | اثر |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | ارتفاع صحنهٔ سه‌بعدی به‌عنوان درصدی از عرض آن. |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | ارتفاع شیء نمودار در اسلاید، به نقطه. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | عمق صحنهٔ سه‌بعدی به‌عنوان درصدی از عرض آن. |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | فاصله بین سری‌ها در امتداد محور عمق، به‌عنوان درصدی از عرض مارکر. |

تنظیم ارتفاع بر نمودارهای ستونی و میله‌ای سه‌بعدی، شامل انواع استوانه‌ای، مخروطی و هرمی، و همچنین نمودارهای خط، مساحت، دایره‌ای و سطحی سه‌بعدی تأثیر می‌گذارد. مقایسهٔ بالا از نوع تأییدشدهٔ `Column3D` استفاده می‌کند. این تنظیم ظاهر یک نمودار دو‌بعدی `ClusteredColumn` یا `BubbleWith3D` را تغییر نمی‌دهد؛ این نام‌ها اعضای [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) هستند. برای سایر تنظیمات ظاهر نمودار، به [Chart Formatting](/slides/fa/net/chart-formatting/) مراجعه کنید.

## **تنظیم فاصله بین سری‌ها**

از [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) برای کنترل فاصله بین سری‌های داده در امتداد محور عمق یک نمودار سه‌بعدی، به‌عنوان درصدی از عرض مارکر، استفاده کنید. از مقادیر **0 تا 500** استفاده کنید: `0` فاصله را حذف می‌کند، در حالی که مقادیر بزرگتر فاصله را افزایش می‌دهند. با عمق ثابت نمودار، افزایش فاصله باعث باریک‌تر شدن مارکرها در محور عمق می‌شود.

به گروه از طریق [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) دسترسی پیدا کنید. این تنظیم برای هر سری در آن گروه اعمال می‌شود، نه فقط سری‌ای که برای دسترسی استفاده شده است. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) فقط‑خواندنی است و تنظیمات گروه والد را بازتاب می‌دهد.

این تنظیم بر نمودارهای ستونی و میله‌ای سه‌بعدی، شامل انواع استوانه، مخروط و هرمی، و همچنین نمودارهای خط و مساحت سه‌بعدی تأثیر می‌گذارد. ظاهر بسته به این‌که سری‌ها در عمق، خوشه‌ای یا پشته‌ای مرتب شده باشند متفاوت است. برای مقایسهٔ واضح فاصله‌ها بین سری‌های جداگانه، از `ChartType.Column3D` در [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) استفاده کنید.

| ویژگی | اثر |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | فاصله بین سری‌ها در امتداد محور عمق، به‌عنوان درصدی از عرض مارکر. |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | فاصله بین خوشه‌های میله یا ستون مجاور، به‌عنوان درصدی از عرض میله یا ستون. |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | عمق کلی نمودار، به‌عنوان درصدی از عرض نمودار. |

مثال کامل زیر از داده‌های پیش‌فرض نمودار استفاده می‌کند که شامل سه سری و چهار دسته است. این مثال دو ارائه را با داده، چرخش، عرض فاصله و عمق نمودار یکسان ذخیره می‌کند؛ فقط عمق فاصله تغییر می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

تصاویر زیر از ارائه‌های تولید شده با استفاده از Microsoft PowerPoint استخراج شده‌اند.

| عمق فاصله: ۰٪ | عمق فاصله: ۵۰۰٪ |
| --- | --- |
| ![نمودار ستونی سه‌بعدی بدون فاصله بین سری‌ها در امتداد محور عمق](gap_depth_0.png) | ![نمودار ستونی سه‌بعدی با فاصله ۵۰۰ درصدی بین سری‌ها در امتداد محور عمق](gap_depth_500.png) |

## **تغییر نوع سری سه‌بعدی و شکل میله**

در یک نمودار استوانه‌ای خوشه‌ای، سری اول با شکل میله استوانه‌ای شروع می‌شود. مثال [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) و [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) را قبل و بعد از هر تغییر می‌خواند.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| تغییر به سری اول | `Type` | `Bar3DShape` |
| --- | --- | --- |
| ایجاد نمودار | `ClusteredCylinder` | `Cylinder` |
| تنظیم `Type` به `ClusteredCone` | `ClusteredCone` | `Cone` |
| تنظیم `Bar3DShape` به `Box` | `ClusteredColumn3D` | `Box` |

تنظیم شکل به `Box` همچنین نوع سری را به `ClusteredColumn3D` تغییر می‌دهد. اگر کد شما بر اساس نوع سری شاخه می‌گیرد، پس از تغییر شکل، `series.Type` را بخوانید. مقداری که قبل از انتساب کش شده باشد همچنان شاخهٔ `ClusteredCone` را انتخاب می‌کند.

![مقایسهٔ PowerPoint که سری اول را به‌صورت استوانه، مخروط و ستون‌های مستطیلی از چپ به راست نشان می‌دهد](series-shapes.png)

## **پرسش‌های متداول**

**کدام انواع نمودار حالت 3D را در Aspose.Slides پشتیبانی می‌کنند؟**

Aspose.Slides انواع سه‌بعدی نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D، و 100% Stacked Column 3D، به‌همراه انواع سه‌بعدی مرتبط که از طریق شمارشگر [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) در دسترس هستند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) را در مستندات API نسخهٔ نصب‌شده‌تان بررسی کنید.

**آیا می‌توانم تصویر رستر از یک نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید یک نمودار را با استفاده از [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) به تصویر خروجی دهید یا [render the entire slide](/slides/fa/net/convert-powerpoint-to-png/) را به فرمت‌هایی مانند PNG یا JPEG تبدیل کنید. این کار زمانی مفید است که به پیش‌نمایش رستر نیاز دارید یا می‌خواهید نمودار را در اسناد، داشبوردها یا صفحات وب بدون نیاز به PowerPoint جای‌گذاری کنید.

**عملکرد ساخت و رندر نمودارهای بزرگ سه‌بعدی چقدر است؟**

عملکرد به حجم داده‌ها و پیچیدگی بصری بستگی دارد. برای بهترین نتایج، اثرات سه‌بعدی را حداقل نگه دارید، از بافت‌های سنگین بر روی دیوارها و نواحی نمودار پرهیز کنید، در صورت امکان تعداد نقاط داده در هر سری را محدود کنید و به خروجی با اندازه (وضوح و ابعاد) مناسب برای نمایش یا چاپ هدف رندر کنید.
---
title: مدیریت دفترچه‌های کار نمودار در ارائه‌ها در .NET
linktitle: دفترچه کار نمودار
type: docs
weight: 70
url: /fa/net/chart-workbook/
keywords:
- دفترچه کار نمودار
- داده‌های نمودار
- سلول دفترچه کار
- برچسب داده
- برگه کاری
- منبع داده
- دفترچه کار خارجی
- داده خارجی
- کش نمودار
- بازیابی دفترچه کار
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides برای .NET را کشف کنید: به‌صورت آسان دفترچه‌های کار نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با دفترچه‌های کار چارت در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های چارت را از طریق جریان‌های دفترچه کار خوانده و نوشته، از سلول‌های دفترچه کار به عنوان برچسب‌های داده چارت استفاده کرده، به مجموعه‌های برگه‌ها دسترسی پیدا کنید و نوع منبع داده برای مقادیر چارت را مشخص کنید.

همچنین کار با دفترچه‌های کار خارجی به عنوان منابع داده چارت را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک دفترچه کار خارجی ایجاد و اختصاص داده، مسیر دفترچه کار خارجی مرتبط با یک چارت را دریافت کرده و داده‌های چارت را وقتی دفترچه کار در دسترس است ویرایش کنید.

برای سلول‌های دفترچه کاری که نشانگر داده‌های گمشده هستند، به [کنترل نمایش سلول‌های خالی](/slides/fa/net/chart-series/) مراجعه کنید تا تفاوت بین سلول خالی و صفر، و مقایسهٔ نمودار خطی از حالت‌های نمایش موجود را ببینید.

## **شامل کردن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) برای کنترل اینکه آیا چارت داده‌ها را از ردیف‌ها و ستون‌های مخفی برگه کاری رسم می‌کند یا نه استفاده کنید. آن را به `true` تنظیم کنید تا فقط سلول‌های قابل مشاهده رسم شوند، یا به `false` تا هم سلول‌های قابل مشاهده و هم مخفی شامل شوند. این تنظیم فقط رسم چارت را کنترل می‌کند؛ ردیف‌ها یا ستون‌های برگه کاری را مخفی یا آشکار نمی‌کند.

[نمونه ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی به عنوان اولین شکل در اسلاید اول است. برگه کاری توکار، `Sheet1`، محدودهٔ منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها هنوز مقدار دارند.

| ردیف برگه کاری | A: ماه | B: خرده‌فروش | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) دسترسی پیدا کنید و [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) را برای بررسی وضعیت مخفی بودن آن‌ها بخوانید. این ویژگی فقط-خواندنی است. در این فایل، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی است و C2 متعلق به ستون مخفی؛ مثال به ترتیب `False`، `True` و `True` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم رسم، داده‌های چارت را تازه کنید: دفترچه کار توکار را با [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) نگه دارید و با [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) دوباره بارگذاری کنید. هنگام شامل کردن تمام سلول‌ها، از [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) نیز برای بازگرداندن محدوده کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. فقط تغییر پرچم برای تازه‌سازی داده‌های کش‌شدهٔ این مثال کافی نیست.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // داده‌های نمودار را از دفترچه کار توکار تازه کنید.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // محدودهٔ منبع کامل را بازگردانید، شامل دسته‌های مخفی.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

این مثال دو نسخهٔ ارائه ذخیره می‌کند: یکی فقط با مقادیر قابل مشاهدهٔ خرده‌فروش (10 و 20) و دیگری با تمام شش مقدار. تصاویر زیر پس از بازکردن مجدد ارائه‌های ذخیره‌شده رندر شده‌اند؛ هر دو فایل تنظیم رسم اختصاصی خود را حفظ می‌کنند. ردیف 3 و ستون C در هر دو دفترچه توکار مخفی باقی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | تمام سلول‌ها (`false`) |
| --- | --- |
| ![فقط سلول‌های قابل مشاهده: مقادیر خرده‌فروش ۱۰ و ۲۰ برای ژانویه و مارس.](hidden_cells_True.png) | ![تمام سلول‌ها: مقادیر خرده‌فروش و عمده‌فروشی برای ژانویه، فوریه و مارس.](hidden_cells_False.png) |

یک سلول مخفی که مقدار دارد، متفاوت از یک سلول خالی است. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم شامل یا حذف داده‌های منبع مخفی نمی‌شود. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/net/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **دریافت بازه داده‌های یک چارت**

قبل از به‌روزرسانی داده‌های دفترچه کار در یک ارائه موجود، بازه‌های منبع را بررسی کنید تا مشخص شود هر چارت از کدام سلول‌های برگه کاری استفاده می‌کند. متد [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) بازهٔ دادهٔ فعلی را به صورت یک فرمول با مشخصات برگه کاری برمی‌گرداند، مانند `Sheet1!$A$1:$D$5`. در اینجا، `Sheet1` نام برگه کاری است، `!` آن را از محدودهٔ سلول جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت دلار نشان‌دهندهٔ ارجاع مطلق به ردیف و ستون است.

این متد بازهٔ فعلی را بدون تغییر چارت یا دفترچهٔ کار می‌خواند. اگر چارت از دفترچه کار به عنوان منبع داده استفاده نکند، یک [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) پرتاب می‌شود. برای جزئیات بیشتر به [مرجع API ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/) مراجعه کنید.

این مثال یک ارائه باز می‌کند و شکل‌های هر اسلاید را مستقیم برای یافتن چارت‌ها بررسی می‌کند. نام هر چارت و بازهٔ منبع را چاپ می‌کند. اگر چارت از دفترچه کار استفاده نکند، پیام مربوطه را چاپ کرده و به چارت بعدی ادامه می‌دهد.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **خواندن و نوشتن داده‌های چارت از یک دفترچه کار**

Aspose.Slides for .NET متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که امکان خواندن و نوشتن دفترچه‌های کار چارت (حاوی داده‌های چارت ویرایش‌شده با Aspose.Cells) را می‌دهند. **توجه** داشته باشید که داده‌های چارت باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال از یک ارائه با یک چارت به عنوان اولین شکل در اسلاید اول استفاده می‌کند. دفترچه کار توکار را به یک جریان می‌خواند، سری‌ها و دسته‌ها را پاک می‌کند و همان دفترچه را باز می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **اعتبارسنجی چیدمان چارت پس از تغییر دفترچه کار**

هنگامی که دفترچه کار توکار را با یک نسخهٔ اصلاح‌شده جایگزین می‌کنید، چارت مجموعهٔ سری و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند منجر به شکست [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) با خطای out-of-range شود. پیش از نوشتن دفترچه کار به‌روز شده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک چارت استفاده می‌کند که اولین شکل در اسلاید اول است. نقطهٔ نظر کامنت نشان می‌دهد که ویرایش دفترچه در اینجا رخ می‌دهد؛ مثال اجرایی دفترچه اصلی را برمی‌گرداند و چیدمان را در حافظه اعتبارسنجی می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // جریان دفترچه کار را اینجا تغییر دهید، به عنوان مثال با استفاده از Aspose.Cells.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

پاک‌سازی مجموعه‌ها قبل از نوشتن دفترچه کار، مراجع دادهٔ کهنه را حذف می‌کند. قبل از استفاده از چارت، هر سری و نگاشت دسته‌ مورد نیاز برای دفترچه به‌روزرسانی‌شده بازسازی شود.

## **تنظیم قالب‌های عددی سفارشی برای سلول‌های دفترچه کار**

از [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) برای کنترل نحوهٔ نمایش مقدارهای عددی در دفترچه کار توکار چارت استفاده کنید. به عنوان مثال، یک گزارش ممکن است نیاز به نمایش نرخ تبدیل به درصد با چهار رقم اعشار و یک ضریب با پنج رقم اعشار داشته باشد. هر دو مقدار را به صورت عددی نگه دارید تا برای محاسبات و رسم چارت در دسترس باشند.

یک قالب عددی نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` عدد `0.125` را به صورت `12.5000%` نشان می‌دهد؛ عدد ذخیره‌شده همچنان `0.125` باقی می‌ماند. به همین ترتیب، `0.00000` عدد `0.1234567` را به `0.12346` نمایش می‌دهد بدون این‌که مقدار ذخیره‌شده را گرد کند. اگر قالب سفارشی یک رشتهٔ خالی (`""`) باشد، به جای آن از [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) استفاده می‌شود.

مثال زیر یک نمودار ستونی ایجاد می‌کند و سلول‌های آن را از طریق [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) دسترسی می‌یابد. در برگهٔ 0، B2 حاوی نرخ تبدیل و C2 حاوی ضریب است. هر دو سلول مقدارهای چارت را تأمین می‌کنند. مثال همچنین برچسب‌های مقدار را که به قالب‌های منبع پیوند دارند فعال می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

قالب‌های سلول دفترچه کار جدا از قالب‌های تنظیم‌شده مستقیم روی محورها یا برچسب‌های داده هستند. در این مثال هر برچسب مقدار سلول منبع خود را نشان می‌دهد چون [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) فعال است و به دلیل اینکه [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) برابر `true` است، قالب عددی منبع را دنبال می‌کند. پس از ذخیره و باز کردن مجدد ارائه، برچسب‌ها `12.5000%` و `0.12346` را نشان می‌دهند، همان‌طور که در زیر نشان داده شده است. محور عمودی قالب خود را با [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00` دارد و [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) به `false` تنظیم شده است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم پیوند به منبع آن را به `false` بگذارید و [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) موردنظر را اختصاص دهید. این کار قالب سلول دفترچه کار را تغییر نمی‌دهد. برای مثال، قالب مستقل برچسب `0.00` مقدار اول را به `0.13` نمایش می‌دهد، در حالی که B2 همچنان `12.5000%` را نشان می‌دهد. برای جزئیات بیشتر به [برچسب‌های دادهٔ چارت](/slides/fa/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

![نمودار ستونی با برچسب‌های پیوندی به منبع که `12.5000%` و `0.12346` را نشان می‌دهند و یک محور عددی با قالب مستقل.](custom-cell-formats.png)

## **تنظیم یک سلول دفترچه کار به عنوان برچسب داده چارت**

می‌توانید از متن موجود در سلول‌های دفترچه کار به‌عنوان برچسب‌های داده چارت استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اسلاید اول یک ارائه موجود اضافه می‌کند. از سلول‌های A10:A12 در برگهٔ 0 برای سه برچسب اول در سری اول استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌کند و ارائه به‌روزشده را ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **مدیریت برگه‌های کاری**

خاصیتی به نام [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) دسترسی به برگه‌های کاری موجود در دفترچه کار چارت را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر برگه را در کنسول چاپ می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **مشخص کردن نوع منبع داده**

مقدارهای نقاط سری می‌توانند به‌صورت مستقیم به عنوان مقدارهای عددی literal نیز ذخیره شوند. برای مثال کامل که آن‌ها را ذخیره و می‌خواند، به [تنظیم مقادیر سری با استفاده از عددهای literal](/slides/fa/net/chart-series/#set-series-values-using-numeric-literals) مراجعه کنید. نوع منبع مقادیر نقطه‌ای جدا از پیکربندی داخلی یا خارجی دفترچه کار چارت است؛ استفاده از عددهای literal به تنهایی دفترچه کار توکار را حذف نمی‌کند.

این مثال یک نمودار ستونی 3بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. نام اول از یک literal رشته‌ای استفاده می‌کند؛ نام دوم از سلول C1 در برگهٔ 0 بهره می‌برد. مقدار [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روزشده ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **تشخیص قالب‌های پشتیبانی نشده دفترچه کار توکار**

Aspose.Slides قالب دفترچه کار باینری اکسل (.xlsb) را که می‌تواند در برخی چارت‌ها توکار باشد، پشتیبانی نمی‌کند. می‌توانید از ویژگی [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) روی [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) به همراه شمارش [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) برای تشخیص قالب‌های پشتیبانی نشده و عبور از آن چارت‌ها استفاده کنید. این مثال شکل‌های اسلاید اول یک ارائه موجود را بررسی می‌کند، شکل‌های غیرچارت را عبور می‌دهد و برای هر چارت دارای دفترچه کار .xlsb پیغام تشخیصی چاپ می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // در اینجا داده‌های دفترچه کار پشتیبانی‌شدهٔ چارت را بخوانید یا تغییر دهید.
}
```

## **دفترچه کار خارجی**

Aspose.Slides از استفاده از دفترچه‌های کار خارجی به عنوان منبع داده برای چارت‌ها پشتیبانی می‌کند.

### **ایجاد یک دفترچه کار خارجی**

از [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) برای استخراج دفترچه کار توکار یک چارت به فایل و پیوند چارت به آن دفترچه کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و دفترچه کار آن را استخراج می‌کند. قبل از اختصاص دفترچه کار خارجی به عنوان منبع داده چارت، جریان خروجی را می‌بندد و سپس ارائه پیوندشده را ذخیره می‌کند.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **تنظیم یک دفترچه کار خارجی**

با استفاده از متد [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) می‌توانید یک دفترچه کار خارجی را به یک چارت به عنوان منبع دادهٔ آن اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر دفترچه کار خارجی (در صورت جابجا شدن) به کار رود.

اگرچه نمی‌توانید داده‌های دفترچه کارهای ذخیره‌شده در مکان‌های راه دور یا منابع را مستقیماً ویرایش کنید، می‌توانید همچنان از چنین دفترچه‌هایی به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای دفترچه کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک دفترچه کار خارجی استفاده می‌کند که برگهٔ آن با نام `Sheet1` شامل یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای ایجاد می‌کند، دفترچه را پیوند می‌دهد و از [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) برای نگاشت A1:B4 به یک سری و سه دسته استفاده می‌کند. ارائه با چارت پیوندشده ذخیره می‌شود.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

پارامتر `updateChartData` متد [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) کنترل می‌کند آیا دفترچه کار بارگذاری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر دفترچه کار به‌روزرسانی می‌شود. داده‌های چارت از دفترچه کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند، بنابراین می‌توان دفترچه کار را در دسترس نبودن نگه داشت.
* وقتی `updateChartData` برابر `true` باشد، داده‌های چارت از دفترچه کار هدف به‌روزرسانی می‌شوند.

مثال زیر یک URL مکان‌گیر با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شوند و ارائه بدون بارگذاری دفترچه کار غیرقابل دسترس ذخیره می‌شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **دریافت مسیر دفترچه کار منبع دادهٔ خارجی یک چارت**

برای شناسایی دفترچه کار پیوندشده به یک چارت، بررسی کنید آیا چارت از منبع دادهٔ خارجی استفاده می‌کند و مسیر دفترچه کار آن را بازیابی کنید.

این مثال اولین شکل در اولین اسلاید یک ارائه با دفترچه کار خارجی پیوندشده را بررسی می‌کند. اگر این شکل یک چارت پیوندشده به دفترچه کار خارجی باشد، [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را ذخیره می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **ویرایش داده‌های چارت**

می‌توانید داده‌های دفترچه‌های کار خارجی را همانند داده‌های داخلی ویرایش کنید. وقتی یک دفترچه کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این مثال از یک چارت که اولین شکل در اولین اسلاید است و به یک دفترچه کار خارجی قابل دسترس پیوند دارد استفاده می‌کند. مقدار پشتیبان‌دستهٔ اولین نقطه داده در اولین سری را به 100 تنظیم می‌کند و ارائه به‌روزشده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوندشده را به‌روز کند، بنابراین در صورت نیاز به حفظ دفترچه اصلی از یک کپی استفاده کنید.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **بازیابی دفترچه کار از حافظه نهان چارت**

اگر یک چارت از دفترچه کار خارجی که موجود نیست یا در دسترس نیست استفاده می‌کند، Aspose.Slides می‌تواند دفترچه کار چارت را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) ایجاد کنید، [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) آن را پیکربندی کنید و [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) را به `true` تنظیم کنید.

مثال C# زیر داده‌های دفترچه کار را برای یک چارت که اولین شکل در اولین اسلاید است و به یک دفترچه کار خارجی غیرقابل دسترس ارجاع می‌دهد، بازمی‌یابد. داده‌های بازگردانده‌شده از طریق [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) و [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) دسترسی می‌یابند:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // در اینجا داده‌های دفترچه کار بازیابی‌شده را بخوانید یا ویرایش کنید.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

اگر دفترچه کار خارجی در دسترس نباشد و بازسازی غیرفعال باشد، Aspose.Slides یک [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) پرتاب می‌کند. فقط زمانی بازسازی را فعال کنید که استفاده از داده‌های کش‌شدهٔ چارت یک گزینهٔ قابل قبول باشد، زیرا ممکن است کش شامل تغییرات انجام‌شده در دفترچه کار خارجی پس از آخرین به‌روزرسانی ارائه نشود.

## **سوالات متداول**

**آیا می‌توانم تشخیص دهم یک چارت خاص به یک دفترچه کار خارجی یا توکار پیوند دارد؟**

بله. یک چارت دارای [نوع منبع داده](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) و یک [مسیر به یک دفترچه کار خارجی](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) است؛ اگر منبع یک دفترچه کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به دفترچه‌های کار خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابجایی دفترچه ممکن است نیاز به به‌روزرسانی لینک داشته باشد.

**آیا می‌توانم از دفترچه‌های کاری که در منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، می‌توان از چنین دفترچه‌هایی به عنوان منبع دادهٔ خارجی استفاده کرد. با این حال، ویرایش مستقیم دفترچه‌های کاری از راه دور توسط Aspose.Slides پشتیبانی نمی‌شود—آن‌ها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [پیوند به فایل خارجی](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) را ذخیره می‌کند. ویرایش داده‌های چارت پشتیبان‌دسته می‌تواند فایل XLSX محلی پیوندشده را نیز به‌روز کند. اگر باید دفترچه اصلی دست نخورده بماند، از یک کپی استفاده کنید.

**در صورت داشتن فایل خارجی با رمز عبور چه کاری باید انجام دهم؟**

Aspose.Slides هنگام پیوندگیری رمز عبور را نمی‌پذیرد. یک روش رایج این است که پیش از استفاده، حفاظت را حذف کنید یا یک کپی رمزگشایی‌شده (به عنوان مثال با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/net/)) تهیه کنید و به آن پیوند دهید.

**آیا چندین چارت می‌توانند به همان دفترچه کار خارجی ارجاع دهند؟**

بله. هر چارت لینک خودش را ذخیره می‌کند. اگر همه به یک فایل ارجاع دهند، به‌روزرسانی آن فایل در آینده برای هر چارت بازتاب خواهد یافت.
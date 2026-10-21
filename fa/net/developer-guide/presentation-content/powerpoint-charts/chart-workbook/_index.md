---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها در .NET
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/net/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده‌های نمودار
- سلول کتاب‌کار
- برچسب داده
- برگه‌کار
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides برای .NET را کشف کنید: به‌سادگی کتاب‌کارهای نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **مروری کلی**

این مقاله توضیح می‌دهد چگونه با دفترچه‌های کار نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های دفترچه کاری بخوانید و بنویسید، از سلول‌های دفترچه کاری به‌عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های شیت‌ها دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با دفترچه‌های کاری خارجی به‌عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک دفترچه کاری خارجی ایجاد و اختصاص دهید، مسیر دفترچه کاری خارجی پیوست‌شده به یک نمودار را بازیابی کنید و داده‌های نمودار را زمانی که دفترچه در دسترس است ویرایش کنید.

برای سلول‌های دفترچه کاری که نمایانگر داده‌های گمشده هستند، به [Control the Display of Empty Cells](/slides/fa/net/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر، و مقایسه‌ی خطوط نمودار در حالت‌های نمایش موجود را ببینید.

## **درج داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) برای کنترل این‌که آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی شیت رسم کند یا نه استفاده کنید. آن را به `true` تنظیم کنید تا فقط سلول‌های قابل مشاهده رسم شوند، یا به `false` تا هر دو سلول قابل مشاهده و مخفی شامل شوند. این تنظیم فقط رسم نمودار را کنترل می‌کند؛ ردیف‌ها یا ستون‌های شیت را مخفی یا آشکار نمی‌کند.

[نمونه ارائه](hidden-source-data.pptx) شامل یک نمودار ستون به‌عنوان اولین شکل در اسلاید اول است. شیت جاسازی‌شده، `Sheet1`، محدوده منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آنها هنوز مقدار دارند.

| ردیف شیت | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) دسترسی پیدا کنید و برای بررسی وضعیت مخفی بودن آنها از [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) استفاده کنید. این خصوصیت فقط‑خواندنی است. در این مثال، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی و C2 متعلق به ستون مخفی است؛ مثال `False`، `True` و `True` را به ترتیب چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم رسم، داده‌های نمودار را تازه کنید: دفترچه جاسازی‌شده را با [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) حفظ کنید و آن را با [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) دوباره بارگذاری کنید. هنگام شامل‌کردن تمام سلول‌ها، از [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) برای بازگرداندن محدوده کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. فقط تغییر پرچم کافی نیست تا داده‌های کش‌شدهٔ نمونه و برچسب‌های دسته بروز شوند.

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

        // داده‌های نمودار را از کتاب‌کار جاسازی‌شده تازه کنید.
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

مثال دو نسخهٔ ارائه را ذخیره می‌کند: یک نسخه تنها با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) و دیگری با تمام شش مقدار. تصاویر زیر از ارائه‌های ذخیره‑شده پس از بازگشایی آنها رندر شده‌اند؛ هر دو فایل تنظیم رسم تخصیص‑داده‌شده خود را حفظ می‌کنند. ردیف 3 و ستون C در هر دو دفترچه کاری جاسازی‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | همه سلول‌ها (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی که دارای مقدار است با یک سلول خالی متفاوت است. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این ویژگی شامل یا مستثنی کردن داده‌های منبع مخفی را انجام نمی‌دهد. برای مثال به [Control the Display of Empty Cells](/slides/fa/net/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **بازیابی بازهٔ داده‌های یک نمودار**

قبل از به‌روزرسانی داده‌های دفترچه کاری در یک ارائه موجود، بازه‌های منبع را بررسی کنید تا متوجه شوید هر نمودار از کدام سلول‌های شیت استفاده می‌کند. متد [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) بازهٔ دادهٔ جاری را به‌صورت یک فرمول شیت‑مواجه برمی‌گرداند، برای مثال `Sheet1!$A$1:$D$5`. در اینجا `Sheet1` نام شیت، `!` آن را از بازه سلولی جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را (شامل) نشان می‌دهد. علامت دلار نشان‌دهندهٔ ارجاع مطلق ردیف و ستون است.

این متد بازهٔ جاری را بدون تغییر نمودار یا دفترچه‌اش می‌خواند. اگر نمودار از دفترچه‌ای به‌عنوان منبع داده استفاده نکند، یک [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) پرتاب می‌شود. برای اطلاعات بیشتر، به [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/) مراجعه کنید.

این مثال یک ارائه باز می‌کند و شکل‌های هر اسلاید را مستقیم برای یافتن نمودارها بررسی می‌کند. نام هر نمودار و بازهٔ منبع آن را چاپ می‌کند. اگر نمودار از دفترچه‌ای استفاده نکند، پیامی چاپ می‌شود و به نمودار بعدی ادامه می‌دهد.

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

## **خواندن و نوشتن داده‌های نمودار از دفترچه کاری**

Aspose.Slides for .NET متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که به شما اجازه می‌دهد دفترچه‌های کار دادهٔ نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال از یک ارائه با یک نمودار به‌عنوان اولین شکل در اسلاید اول استفاده می‌کند. دفترچهٔ جاسازی‌شده را به یک جریان می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان دفترچه را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی طرح‌بندی نمودار پس از تغییر دفترچه کاری**

زمانی که دفترچهٔ جاسازی‌شده را با یک دفترچهٔ اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) با خطای «index‑out‑of‑range» شکست بخورد. پیش از نوشتن دفترچهٔ به‌روزرسانی‌شده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اسلاید اول است استفاده می‌کند. نظرات نشان می‌دهند کجا ویرایش دفترچه انجام می‌شود؛ مثال قابل اجرا دفترچهٔ اصلی را باز می‌نویسد و طرح‌بندی را در حافظه اعتبارسنجی می‌کند.

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

    // جریان کتاب‌کار را در اینجا تغییر دهید، برای مثال با استفاده از Aspose.Cells.

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

پاک‌کردن مجموعه‌ها مراجع دادهٔ منقضی‌شده را پیش از نوشتن دفترچه حذف می‌کند. پیش از استفاده از نمودار، هر سری و نگاشت دستهٔ مورد نیاز را برای دفترچه به‌روزرسانی‌شده بازسازی کنید.

## **تنظیم قالب‌های عددی سفارشی برای سلول‌های دفترچه کاری**

از [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) برای کنترل نحوهٔ نمایش مقادیر عددی در دفترچهٔ جاسازی‌شدهٔ یک نمودار استفاده کنید. به‌عنوان مثال، ممکن است یک گزارش نیاز داشته باشد نرخ تبدیل را به‌صورت درصد با چهار رقم اعشار و یک ضریب را با پنج رقم اعشار نمایش دهد. هر دو مقدار را عددی نگه دارید تا برای محاسبات و رسم نمودار در دسترس باشند.

یک قالب عددی فقط نمایش را تغییر می‌دهد، مقدار ذخیره‌شده را تغییر نمی‌دهد. قالب `0.0000%` مقدار `0.125` را به‌صورت `12.5000%` نمایش می‌دهد؛ عدد ذخیره‌شده همچنان `0.125` است. به‌طور مشابه، `0.00000` مقدار `0.1234567` را به‌صورت `0.12346` نشان می‌دهد بدون اینکه مقدار ذخیره‌شده rond شود. اگر قالب سفارشی یک رشتهٔ خالی (`""`) باشد، به‌جای آن از [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) استفاده می‌شود.

مثال زیر یک نمودار ستون ایجاد می‌کند و سلول‌های آن را از طریق [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) دسترسی می‌یابد. در شیت 0، B2 حاوی نرخ تبدیل و C2 حاوی ضریب است. هر دو سلول مقدارهای نمودار را فراهم می‌کنند. مثال همچنین برچسب‌های مقدار را که به قالب‌های منبع پیوند دارند فعال می‌کند.

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

قالب‌های سلول دفترچه متفاوت از قالب‌های تنظیم‌شده مستقیم بر محورها یا برچسب‌های داده هستند. در این مثال، هر برچسب مقدار سلول منبع خود را نمایش می‌دهد زیرا [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) فعال است و به‌دلیل اینکه [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) برابر `true` است، قالب عددی منبع را دنبال می‌کند؛ پس از ذخیره و بازگشایی ارائه، برچسب‌ها `12.5000%` و `0.12346` را نشان می‌دهند همان‌طور که در زیر مشاهده می‌شود. محور عمودی قالب خود را با [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) برابر `0.00` دارد و [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) برابر `false` است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم پیوند به منبع را به `false` تنظیم کنید و برای آن [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) اختصاص دهید. این کار قالب سلول دفترچه را تغییر نمی‌دهد. برای مثال، قالب مستقل برچسب `0.00` مقدار اول را به‌صورت `0.13` نشان می‌دهد در حالی که B2 همچنان `12.5000%` را نشان می‌دهد. برای قالب‌بندی مستقیم برچسب‌ها به [Chart Data Labels](/slides/fa/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

تصویر زیر از ارائهٔ ذخیره‌شده پس از بازگشایی رندر شده است:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **استفاده از یک سلول دفترچه کاری به‌عنوان برچسب دادهٔ نمودار**

می‌توانید متن سلول‌های دفترچه کاری را به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اولین اسلاید یک ارائه موجود اضافه می‌کند. از سلول‌های A10:A12 در شیت 0 برای سه برچسب اول در اولین سری استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌کند و ارائه به‌روز‌شده را ذخیره می‌کند.

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

## **مدیریت شیت‌ها**

خاصیت [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) دسترسی به شیت‌های یک دفترچهٔ نمودار را فراهم می‌کند. این مثال یک نمودار پای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر شیت را در کنسول چاپ می‌کند.

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

این مثال یک نمودار ستون 3D با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با استفاده از منابع داده مختلف تنظیم می‌کند. نام اول از یک رشتهٔ متنی استفاده می‌کند؛ نام دوم از سلول C1 در شیت 0 می‌گیرد. شمارش [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روزشده ذخیره می‌کند.

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

## **تشخیص فرمت‌های دفترچهٔ کار جاسازی‌شدهٔ پشتیبانی‌نشده**

Aspose.Slides فرمت دفترچهٔ کار باینری اکسل (.xlsb) را که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از خاصیت [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) در [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) فرمت‌های پشتیبانی‌نشده را شناسایی کنید و آن نمودارها را رد کنید. این مثال شکل‌های اسلاید اول یک ارائه موجود را بررسی می‌کند، شکل‌های غیرنمودار را رد می‌کند و برای هر نمودار دارای دفترچهٔ .xlsb جاسازی‌شده یک پیام تشخیصی چاپ می‌کند.

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

    // خواندن یا تغییر داده‌های پشتیبانی‌شدهٔ کتاب‌کار نمودار در اینجا.
}
```

## **دفترچهٔ کار خارجی**

Aspose.Slides استفاده از دفترچه‌های کاری خارجی به‌عنوان منبع داده برای نمودارها را پشتیبانی می‌کند.

### **ایجاد یک دفترچهٔ کار خارجی**

از [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) برای استخراج یک دفترچهٔ کار نمودار جاسازی‌شده به یک فایل و پیوند نمودار به آن دفترچهٔ کار خارجی استفاده کنید.

این مثال یک نمودار پای با داده‌های پیش‌فرض ایجاد می‌کند و دفترچهٔ آن را استخراج می‌کند. قبل از اختصاص دفترچهٔ کار خارجی به عنوان منبع دادهٔ نمودار، جریان خروجی را می‌بندد، سپس ارائهٔ پیوست‌شده را ذخیره می‌کند.

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

### **تنظیم یک دفترچهٔ کار خارجی**

با استفاده از متد [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) می‌توانید یک دفترچهٔ کار خارجی را به یک نمودار به‌عنوان منبع دادهٔ آن اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر دفترچهٔ کار خارجی (در صورت جابجایی آن) به کار رود.

اگرچه نمی‌توانید داده‌های دفاتر کاری ذخیره‌شده در مکان‌های راه دور یا منابع را مستقیماً ویرایش کنید، همچنان می‌توانید از چنین دفاتری به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای یک دفترچهٔ کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک دفترچهٔ کار خارجی استفاده می‌کند که شیت آن با نام `Sheet1` شامل نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار پای ایجاد می‌کند، دفترچه را پیوند می‌دهد و با استفاده از [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) بازهٔ A1:B4 را به یک سری و سه دسته نگاشت می‌کند. سپس ارائهٔ حاوی نمودار پیوست‌شده را ذخیره می‌کند.

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

پارامتر `updateChartData` متد [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) کنترل می‌کند آیا دفترچهٔ کار بارگذاری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر دفترچه به‌روزرسانی می‌شود. دادهٔ نمودار از دفترچهٔ هدف بارگذاری یا به‌روزرسانی نمی‌شود، بنابراین دفترچه می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، دادهٔ نمودار از دفترچهٔ هدف به‌روزرسانی می‌شود.

مثال زیر یک URL جایگزین را با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار پای حفظ می‌شوند و ارائه بدون بارگذاری دفترچهٔ در دسترس نیست ذخیره می‌شود.

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

### **دریافت مسیر دفترچهٔ کار منبع دادهٔ خارجی یک نمودار**

برای شناسایی دفترچهٔ کار پیوست‌شده به یک نمودار، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر دفترچهٔ کار را بازیابی کنید.

این مثال اولین شکل در اسلاید اول یک ارائه با دفترچهٔ کار خارجی پیوست‌شده را بررسی می‌کند. اگر یک نمودار باشد که به دفترچهٔ کار خارجی پیوست شده است، مثال [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را ذخیره می‌کند.

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

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های دفاتر کاری خارجی را همانند داده‌های دفاتر داخلی ویرایش کنید. وقتی یک دفترچهٔ کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل در اسلاید اول است و به یک دفترچهٔ کار خارجی قابل دسترس پیوست شده استفاده می‌کند. مقدار نقطهٔ دادهٔ اول در سری اول را به 100 تنظیم می‌کند و ارائهٔ به‌روزشده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوست‌شده را به‌روزرسانی کند، بنابراین برای حفظ نسخهٔ اصلی از یک کپی استفاده کنید.

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

### **بازیابی یک دفترچهٔ کار از کش نمودار**

اگر یک نمودار از یک دفترچهٔ کار خارجی که مفقود یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند دفترچهٔ کار نمودار را از داده‌های کش‌شده در ارائه بازیابی کند. قبل از باز کردن ارائه، یک [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) ایجاد کنید، [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) آن را پیکربندی کنید و ویژگی [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) را به `true` تنظیم کنید.

مثال زیر به زبان C# داده‌های دفترچه را برای یک نمودار که اولین شکل در اسلاید اول است و به یک دفترچهٔ کار خارجی غیرقابل دسترس ارجاع می‌دهد، بازیابی می‌کند. داده‌های بازیابی‌شده از طریق [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) و [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) دسترسی پیدا می‌کند:

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

    // خواندن یا تغییر داده‌های دفترچه بازیابی‌شده در اینجا.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

اگر دفترچهٔ کار خارجی در دسترس نباشد و بازسازی غیرفعال باشد، Aspose.Slides یک [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) پرتاب می‌کند. بازسازی را فقط زمانی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار گزینهٔ قابل قبولی باشد، زیرا کش ممکن است شامل تغییرات انجام‌شده روی دفترچهٔ کار خارجی پس از آخرین بروز رسانی ارائه نباشد.

## **پرسش‌های متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به یک دفترچهٔ کار خارجی یا داخلی پیوست شده است؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) و [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) است؛ اگر منبع یک دفترچهٔ کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به دفترچه‌های کاری خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابجایی دفترچه ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از دفترچه‌های کاری که روی منابع شبکه/به‌اشتراک‌گذاری شده قرار دارند استفاده کنم؟**

بله، چنین دفترچه‌هایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم دفترچه‌های کاری از راه دور توسط Aspose.Slides پشتیبانی نمی‌شود—فقط می‌توان از آنها به‌عنوان منبع استفاده کرد.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبان‌شده توسط سلول می‌تواند فایل XLSX محلی پیوست‌شده را نیز به‌روز کند. اگر نسخهٔ اصلی باید دست‌نخورده بماند، یک کپی از دفترچه کار استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه کاری باید انجام دهم؟**

Aspose.Slides هنگام پیوند گرفتن رمز عبوری قبول نمی‌کند. یک روش معمول این است که پیش از آن محافظت را حذف کنید یا یک کپی رمزگشایی‌شده تهیه کنید (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/net/)) و به آن کپی پیوند دهید.

**آیا چندین نمودار می‌توانند به یک دفترچهٔ کار خارجی ارجاع دهند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها برای تمام نمودارها منعکس خواهد شد.
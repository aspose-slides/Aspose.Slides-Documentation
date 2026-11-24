---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها در .NET
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/net/chart-workbook/
keywords:
- کتاب‌کار نمودار
- دادهٔ نمودار
- سلول کتاب‌کار
- برچسب داده
- کاربرگ
- منبع داده
- کتاب‌کار خارجی
- دادهٔ خارجی
- کش نمودار
- بازیابی کتاب‌کار
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET را کشف کنید: به‌راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا دادهٔ ارائهٔ خود را به‌صورت بهینه‌تری سازماندهی کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های دادهٔ نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به‌عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داده شود، مسیر کتاب‌کار خارجی پیوست‌شده به یک نمودار بازیابی شود و دادهٔ نمودار هنگام در دسترس بودن کتاب‌کار ویرایش شود.

برای سلول‌های کتاب‌کار که نمایانگر دادهٔ مفقود هستند، به [کنترل نمایش سلول‌های خالی](/slides/fa/net/chart-series/) برای تفاوت بین یک سلول خالی و صفر، و مقایسهٔ نمودار خطی از حالت‌های نمایش موجود مراجعه کنید.

## **شامل کردن داده‌ها از ردیف‌ها و ستون‌های پنهان**

از [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) برای کنترل اینکه آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های کاربرگ پنهان ترسیم می‌کند یا خیر استفاده کنید. مقدار آن را به `true` تنظیم کنید تا تنها سلول‌های قابل مشاهده ترسیم شوند، یا به `false` تا هر دو سلول قابل مشاهده و پنهان شامل شود. این تنظیم فقط ترسیم نمودار را کنترل می‌کند؛ ردیف‌ها یا ستون‌های کاربرگ را پنهان یا نمایان نمی‌کند.

[نمایش نمونه](hidden-source-data.pptx) شامل یک نمودار ستونی به عنوان اولین شکل در اسلاید اول است. کاربرگ جاسازی شده، `Sheet1`، بازهٔ منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C پنهان هستند، اما سلول‌های آن‌ها همچنان مقدار دارند.

| ردیف کاربرگ | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون پنهان) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف پنهان) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) دسترسی یافته و [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) را برای بررسی وضعیت پنهان بودن آن‌ها بخوانید. این ویژگی فقط‑خواندنی است. در این فایل، B2 قابل مشاهده است، B3 به ردیف پنهان تعلق دارد و C2 به ستون پنهان؛ مثال به ترتیب `False`، `True` و `True` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم ترسیم، دادهٔ نمودار را تازه کنید: کتاب‌کار جاسازی‌شده را با [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) نگه‌دارید و با [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) مجدداً بارگذاری کنید. هنگام شامل کردن تمام سلول‌ها، همچنین از [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) برای بازگرداندن بازهٔ کامل، شامل دستهٔ فوریهٔ پنهان، استفاده کنید. فقط تغییر پرچم برای تازه‌سازی دادهٔ کش‌شدهٔ این نمونه کافی نیست و برچسب‌های دسته نیز تازه نمی‌شوند.

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

        // داده‌های نمودار را از کتاب‌کار جاسازی‌شده تازه‌سازی کنید.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // محدودهٔ منبع کامل را بازگردانید، از جمله دسته‌های مخفی.
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

مثال دو نسخه از ارائه را ذخیره می‌کند: یکی با فقط مقادیر خرده‌فروشی قابل مشاهده (10 و 20) و دیگری با تمام شش مقدار. تصاویر زیر از ارائه‌های ذخیره‌شده پس از بازگشایی آن‌ها رندر شده‌اند؛ هر دو فایل تنظیم ترسیم اختصاصی خود را حفظ می‌کنند. ردیف 3 و ستون C در هر دو کتاب‌کار جاسازی‌شده پنهان می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | تمام سلول‌ها (`false`) |
| --- | --- |
| ![فقط سلول‌های قابل مشاهده: مقادیر خرده‌فروشی 10 و 20 برای ژانویه و مارس.](hidden_cells_True.png) | ![تمام سلول‌ها: مقادیر خرده‌فروشی و عمده‌فروشی برای ژانویه، فوریه و مارس.](hidden_cells_False.png) |

یک سلول پنهان حاوی مقدار، متفاوت از یک سلول خالی است. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) کنترل می‌کند مقادیر مفقود چگونه نمایش داده شوند؛ این ویژگی شامل یا حذف دادهٔ منبع پنهان نمی‌شود. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/net/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **بازخوانی بازه داده‌های نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائهٔ موجود، بازه‌های منبع را بررسی کنید تا تعیین کنید هر نمودار از کدام سلول‌های کاربرگ استفاده می‌کند. متد [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) بازهٔ دادهٔ فعلی را به‌صورت فرمولی با مشخصات کاربرگ برمی‌گرداند، مانند `Sheet1!$A$1:$D$5`. در اینجا `Sheet1` نام کاربرگ است، `!` آن را از بازهٔ سلولی جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت‌های دلار نشان‌دهندهٔ ارجاع مطلق به ردیف و ستون هستند.

این متد بازهٔ فعلی را می‌خواند بدون اینکه نمودار یا کتاب‌کار آن را تغییر دهد. اگر نمودار از کتاب‌کاری به‌عنوان منبع داده استفاده نکند، یک [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) پرتاب می‌کند. برای اطلاعات بیشتر به [مرجع API ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌ها را مستقیماً روی هر اسلاید بررسی می‌کند تا نمودارها را پیدا کند. نام هر نمودار و بازهٔ منبع آن را چاپ می‌کند. اگر نموداری کتاب‌کاری استفاده نکند، پیغامی چاپ می‌کند و به نمودار بعدی ادامه می‌دهد.

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

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides for .NET روش‌های [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که دادهٔ نمودار باید به همان شکل سازماندهی شده باشد یا ساختاری مشابه منبع داشته باشد.

این مثال از یک ارائه با یک نمودار به‌عنوان اولین شکل در اسلاید اول استفاده می‌کند. کتاب‌کار جاسازی‌شده را به یک جریان می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را بازمی‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی طرح‌بندی نمودار پس از تغییر کتاب‌کار**

زمانی که یک کتاب‌کار جاسازی‌شده را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این ناسازگاری می‌تواند باعث شکست [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) با خطای «index‑out‑of‑range» شود. قبل از نوشتن کتاب‌کار به‌روز شده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اسلاید اول است استفاده می‌کند. نظر در جایی قرار دارد که ویرایش کتاب‌کار انجام می‌شود؛ مثال اجرایی کتاب‌کار اصلی را بازمی‌نویسد و طرح‌بندی را در حافظه اعتبارسنجی می‌کند.

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

    // در اینجا جریان کتاب‌کار را اصلاح کنید، برای مثال با استفاده از Aspose.Cells.

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

پاک‌سازی مجموعه‌ها پیش از نوشتن کتاب‌کار، مراجع دادهٔ منسوخ را حذف می‌کند. قبل از استفاده از نمودار، هر سری و نگاشت دستهٔ لازم برای کتاب‌کار به‌روزرسانی‌شده را بازسازی کنید.

## **انتخاب نحوهٔ ذخیره‌سازی برچسب‌های دسته**

بر روی مجموعهٔ دستهٔ خالی قبل از افزودن برچسب‌ها، [IChartCategoryCollection.UseCells](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorycollection/usecells/) را تنظیم کنید. از سلول‌های کاربرگ برای برچسب‌هایی که به دادهٔ کتاب‌کار ارجاع می‌دهند یا سلسله‌مراتبی مانند فصول سال تشکیل می‌شوند، استفاده کنید. برای برچسب‌های تک‌سطحی که نیازی به ارجاع به سلول ندارند، از رشتهٔ ثابت استفاده کنید. این تنظیم فقط برای دسته‌ها اعمال می‌شود. هر دو نمودار زیر از سلول‌های کاربرگ برای مقادیر عددی سری‌ها استفاده می‌کنند.

مثال دو نمودار ستونی ایجاد می‌کند و برای هر یک `Q1 Q2 Q3 Q4` را چاپ می‌کند همراه با حالت ذخیره‌سازی خود. برای برچسب‌های مبتنی بر کاربرگ، [IChartCategory.AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/ascell/) دسترسی به سلول زیرین را می‌دهد و [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) برچسب آن را برمی‌گرداند. برای برچسب‌های ثابت، رشته را مستقیماً از [IChartCategory.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/value/) بخوانید.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

foreach (var useCells in new[] { true, false })
{
    var x = useCells ? 20 : 360;
    var chart = shapes.AddChart(ChartType.ClusteredColumn, x, 20, 320, 250);
    var data = chart.ChartData;
    data.Series.Clear();
    data.Categories.Clear();
    data.Categories.UseCells = useCells;

    var workbook = data.ChartDataWorkbook;
    var seriesName = workbook.GetCell(0, 0, 1, "Sales");
    var series = data.Series.Add(seriesName, chart.Type);
    for (var row = 1; row <= 4; row++)
    {
        var label = $"Q{row}";
        if (useCells)
        {
            var labelCell = workbook.GetCell(0, row, 0, label);
            data.Categories.Add(labelCell);
        }
        else
        {
            data.Categories.Add(label);
        }

        var valueCell = workbook.GetCell(0, row, 1, row * 10);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    Console.Write($"UseCells = {data.Categories.UseCells}:");
    foreach (var category in data.Categories)
    {
        var label = data.Categories.UseCells ? category.AsCell.Value : category.Value;
        Console.Write($" {label}");
    }
    Console.WriteLine();
}

presentation.Save("category-labels.pptx", SaveFormat.Pptx);
```

## **تنظیم قالب‌های عددی سفارشی برای سلول‌های کتاب‌کار**

از [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) برای کنترل نحوهٔ نمایش مقادیر عددی در کتاب‌کار جاسازی‌شدهٔ یک نمودار استفاده کنید. برای مثال، ممکن است گزارشی نیاز داشته باشد نرخ تبدیل را به‌صورت درصد با چهار رقم اعشار و یک ضریب را با پنج رقم اعشار نمایش دهد. هر دو مقدار باید به‌صورت عددی باقی بمانند تا برای محاسبات و ترسیم نمودار در دسترس باشند.

یک قالب عددی نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` مقدار `0.125` را به‌صورت `12.5000%` نمایش می‌دهد؛ عدد ذخیره‌شده به `12.5` تبدیل نمی‌شود. به‌طور مشابه، `0.00000` مقدار `0.1234567` را به‌صورت `0.12346` نمایش می‌دهد بدون اینکه مقدار ذخیره‌شده گرد شود. اگر قالب سفارشی رشتهٔ خالی (`""`) باشد، به‌جای آن از [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) استفاده می‌شود.

مثال زیر یک نمودار ستونی ایجاد می‌کند و سلول‌های آن را از طریق [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) دسترسی می‌یابد. در کاربرگ 0، B2 شامل نرخ تبدیل و C2 شامل ضریب است. هر دو سلول مقدارهای نمودار را تأمین می‌کنند. مثال همچنین برچسب‌های مقداری را که به قالب‌های منبع پیوند دارند فعال می‌کند.

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

قالب‌های سلول کتاب‌کار جدا از قالب‌های مستقیم روی محورهای نمودار یا برچسب‌های داده هستند. در این مثال، هر برچسب مقدار سلول منبع خود را نشان می‌دهد چون [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) فعال است و چون [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) برابر `true` است، قالب عددی منبع را دنبال می‌کند. پس از ذخیره و بازگشایی ارائه، برچسب‌ها `12.5000%` و `0.12346` را نشان می‌دهند، همان‌طور که در زیر مشاهده می‌شود. محور عمودی قالب خودشان [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) به‌صورت `0.00` دارد و [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) برابر `false` تنظیم شده است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم پیوند به منبع آن را به `false` تنظیم کنید و [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) مخصوص آن را اختصاص دهید. این کار قالب سلول کتاب‌کار را تغییر نمی‌دهد. برای مثال، یک قالب برچسب مستقل `0.00` مقدار اول را به‌صورت `0.13` نشان می‌دهد، در حالی که B2 همچنان `12.5000%` را نمایش می‌دهد. برای قالب‌بندی مستقیم برچسب‌ها به [برچسب‌های دادهٔ نمودار](/slides/fa/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

تصویر زیر از ارائهٔ ذخیره‌شده پس از بازگشایی رندر شده است:

![نمودار ستونی با برچسب‌های پیوند‑خورده به منبع که 12.5000% و 0.12346 را نشان می‌دهند و یک محور عددی به صورت مستقل قالب‌بندی شده است.](custom-cell-formats.png)

## **استفاده از یک سلول کتاب‌کار به‌عنوان برچسب دادهٔ نمودار**

می‌توانید متن سلول‌های کتاب‌کار را به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اسلاید اول یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای سه برچسب اول در سری اول استفاده می‌کند، برچسب‌های سلولی را فعال می‌کند و ارائهٔ به‌روزرسانی‌شده را ذخیره می‌کند.

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

## **مدیریت کاربرگ‌ها**

ویژگی [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) دسترسی به کاربرگ‌های موجود در کتاب‌کار یک نمودار را فراهم می‌کند. این مثال یک نمودار پایی با داده‌های پیش‌فرض ایجاد می‌کند و نام هر کاربرگ را در کنسول چاپ می‌کند.

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

مقادیر نقاط سری می‌توانند به‌صورت مستقیم به‌عنوان مقادیر عددی ثابت ذخیره شوند. برای مثال کامل که آن‌ها را ذخیره و می‌خواند به [تنظیم مقادیر سری با استفاده از مقادیر عددی ثابت](/slides/fa/net/chart-series/#set-series-values-using-numeric-literals) مراجعه کنید. نوع منبع مقادیر نقطه‌ای جدا از پیکربندی کتاب‌کار داخلی یا خارجی نمودار است؛ استفاده از مقادیر عددی ثابت به‌تنهایی کتاب‌کار جاسازی‌شده را حذف نمی‌کند.

این مثال یک نمودار ستونی 3بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. نام اول از یک رشته ثابت استفاده می‌کند؛ نام دوم از سلول C1 در کاربرگ 0 می‌آید. مقدار [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) نوع منبع را برای هر نام انتخاب می‌کند. مثال ارائه را با نام‌های به‌روزرسانی‌شدهٔ سری‌ها ذخیره می‌کند.

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

## **تشخیص فرمت‌های پشتیبانی‌نشدهٔ کتاب‌کارهای جاسازی‌شده**

Aspose.Slides فرمت کتاب‌کار باینری اکسل (.xlsb) را که ممکن است در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از ویژگی [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) روی [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) فرمت‌های پشتیبانی‌نشده را شناسایی کنید و از آن نمودارها عبور کنید. این مثال شکل‌های اسلاید اول یک ارائهٔ موجود را بررسی می‌کند، شکل‌های غیرنموداری را عبور می‌دهد و برای هر نمودار دارای کتاب‌کار .xlsb جاسازی‌شده، پیام تشخیص می‌دهد.

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

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) برای صادرات یک کتاب‌کار نمودار جاسازی‌شده به یک فایل و پیوند دادن نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار پایی با داده‌های پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را صادر می‌کند. قبل از اختصاص کتاب‌کار خارجی به عنوان منبع دادهٔ نمودار، جریان خروجی را بسته و سپس ارائهٔ پیوندشده را ذخیره می‌کند.

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

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به‌عنوان منبع دادهٔ آن اختصاص دهید. این متد می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورت جابجا شدن آن) نیز استفاده شود.

در حالی که نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های ریموت یا منابع را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که کاربرگ آن با نام `Sheet1` شامل یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار پایی ایجاد می‌کند، کتاب‌کار را پیوند می‌دهد و از [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) برای نگاشت A1:B4 به یک سری و سه دسته استفاده می‌کند. ارائهٔ دارای نمودار پیوندشده ذخیره می‌شود.

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

پارامتر `updateChartData` متد [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) کنترل می‌کند که آیا کتاب‌کار بارگذاری شود یا خیر.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. دادهٔ نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شود، بنابراین کتاب‌کار ممکن است در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، دادهٔ نمودار از کتاب‌کار هدف به‌روزرسانی می‌شود.

مثال زیر یک URL جایگزین با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار پایی حفظ می‌شود و ارائه بدون بارگذاری کتاب‌کار در دسترس ذخیره می‌شود.

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

### **دریافت مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

برای شناسایی کتاب‌کاری که به یک نمودار پیوند داده شده است، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را دریافت کنید.

این مثال شکل اول اسلاید اول یک ارائه با کتاب‌کار خارجی پیوندشده را بررسی می‌کند. اگر یک نمودار باشد که به کتاب‌کار خارجی پیوند دارد، مثال [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه ذخیره می‌شود.

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

### **ویرایش دادهٔ نمودار**

می‌توانید داده‌های کتاب‌کارهای خارجی را به همان شیوه‌ای که داده‌های کتاب‌کار داخلی را ویرایش می‌کنید، ویرایش کنید. وقتی کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی در دسترس پیوند داده شده استفاده می‌کند. مقدار پشتیبانی‌شده توسط سلول اولین نقطه دادهٔ اولین سری را به 100 تنظیم می‌کند و ارائهٔ به‌روزرسانی‌شده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوندشده را به‌روزرسانی کند، بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی از یک کپی استفاده کنید.

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

## **تازه‌سازی داده‌های نمودار از کتاب‌کارهای منبع**

Aspose.Slides for .NET 26.11 متد [IChartData.RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) را برای یک نمودار و [IPresentation.RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) را برای ارائه اضافه می‌کند. پس از تغییر مقادیر کتاب‌کار منبع از این متدها استفاده کنید. کتاب‌کارهای خارجی باید قابل دسترسی و پشتیبانی شوند.

با داشتن [Aspose.Slides for .NET](/slides/fa/net/installation/) نسخهٔ 26.11 یا بالاتر، این مثال اولین نمودار در اسلاید اول `charts.pptx` را تازه می‌کند. کتاب‌کار منبع آن باید در دسترس باشد. نتیجه برای حفظ دادهٔ به‌روز شدهٔ نمودار ذخیره می‌شود.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
var chart = presentation.Slides[0].Shapes.OfType<IChart>().FirstOrDefault();
if (chart == null)
{
    Console.WriteLine("The first slide must contain a chart.");
    return;
}

chart.ChartData.RefreshData();
presentation.Save("refreshed-chart.pptx", SaveFormat.Pptx);
```

برای تازه‌سازی تمام نمودارها، یک نمونهٔ جداگانهٔ ارائه به‌صورت زیر استفاده کنید. پاس دادن `false` باعث می‌شود شکست تازه‌سازی به فراخواننده منتقل شود؛ نمودارهای قبلاً تازه‌سازی‑شده بازگردانده نمی‌شوند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
presentation.RefreshChartsData(skipFailedCharts: false);
presentation.Save("refreshed-charts.pptx", SaveFormat.Pptx);
```

پارامتر به‌صورت پیش‌فرض `true` است: [RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) یک نمودار شکست‌خورده را نادیده می‌گیرد و به سایرین ادامه می‌دهد. این متد هیچ‌نتیجهٔ per‑chart برنمی‌گرداند، بنابراین یک فراخوانی کامل تضمین نمی‌کند که هر نمودار تازه‌سازی شده باشد. اگر نیاز داشته باشید هر نمودار شکست‌خورده را شناسایی کنید، از فراخوانی‌های جداگانهٔ [RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) استفاده کنید.

تازه‌سازی داده‌های منبع را بارگذاری مجدد می‌کند. این کار جدا از محاسبهٔ فرمول، اعتبارسنجی طرح‌بندی نمودار و به‌روزرسانی پیش‌نمایش OLE است. برای بررسی تازه‌سازی در حافظه، مقادیر پشتیبانی‌شده توسط سلول‌های زنده را بررسی کنید. یک [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) هنوز می‌تواند نمودار قبلاً ذخیره‌شده را توصیف کند تا زمانی که ارائه را ذخیره و باز کنید.

### **خواندن مقادیر کش‌شدهٔ نمودار بدون کتاب‌کار**

در .NET 26.11، دسترسی‌های مقدار کش‌شده مقادیر ذخیره‌شدهٔ نمودار را بدون باز کردن کتاب‌کار آن می‌خوانند. این‌ها زمانی مفید هستند که فایل پیوندشده در دسترس نباشد و فقط به آخرین دادهٔ ذخیره‌شدهٔ نمودار نیاز داشته باشید. این متفاوت از بازسازی کتاب‌کار با گزینهٔ بازیابی زیر است.

| شیء | دسترسی کش‌شده |
| --- | --- |
| نقطه دادهٔ سری عادی | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) |
| نقطه دادهٔ پراکندگی یا حباب | [CachedXValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedxvalue/), [CachedYValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedyvalue/) |
| نقطه دادهٔ حباب | [CachedBubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedbubblesize/) |
| دستهٔ نمودار | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/cachedvalue/) |

هر دسترسی یک [ICachedChartValue](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/) را برمی‌گرداند. [Data](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/data/) شیء ذخیره‌شده را فراهم می‌کند؛ [ToString](https://reference.aspose.com/slides/net/aspose.slides.charts/cachedchartvalue/tostring/) متن را ارائه می‌دهد؛ [ToDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/todouble/) برای مقدار غیردیدنی یا غیر عددی `NaN` برمی‌گرداند. یک کش می‌تواند گم‌شده یا قدیمی باشد، از جمله در یک نمودار تازه ایجاد شده که ذخیره نشده است. فرض نکنید که هر فیلد وجود دارد یا عددی است.

این مثال تمام این فیلدها را از `cached-chart.pptx` می‌خواند، یک ارائهٔ ذخیره‌شده حاوی نمودارها. یک کتاب‌کار خارجی گم‌شده قابل‌قبول است زیرا کد به [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) یا سلول‌های زندهٔ کتاب‌کار دسترسی ندارد.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("cached-chart.pptx");
foreach (var slide in presentation.Slides)
foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
        continue;

    foreach (var category in chart.ChartData.Categories)
        PrintCache("Category", category.CachedValue);

    foreach (var series in chart.ChartData.Series)
    foreach (var point in series.DataPoints)
    {
        PrintCache("Value", point.CachedValue);
        PrintCache("X", point.CachedXValue);
        PrintCache("Y", point.CachedYValue);
        PrintCache("Bubble size", point.CachedBubbleSize);
    }
}

static void PrintCache(string name, ICachedChartValue value)
{
    var number = value.ToDouble();
    if (value.Data == null)
        Console.WriteLine($"{name}: no cached value");
    else if (double.IsNaN(number))
        Console.WriteLine($"{name}: {value} (not numeric)");
    else
        Console.WriteLine($"{name}: {number}");
}
```

از تازه‌سازی وقتی به دادهٔ منبع جاری نیاز دارید استفاده کنید؛ از خواندن کش‌شده وقتی تنها snapshot ذخیره‌شده کافی است استفاده کنید. کش یک نسخهٔ کامل از کتاب‌کار نیست و نمی‌تواند تغییراتی که پس از آخرین به‌روزرسانی انجام شده‌اند را فراهم کند.

### **بازیابی کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی استفاده می‌کند که گم‌شده یا در دسترس نیست، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) ایجاد کنید، [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) آن را پیکربندی کنید و قبل از باز کردن ارائه، [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) را به `true` تنظیم کنید.

مثال C# زیر داده‌های کتاب‌کار را برای یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی در دسترس نیست، بازیابی می‌کند. داده‌های بازیابی‌شده از طریق [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) و [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) دسترسی می‌یابد:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true;
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

    // داده‌های کتاب‌کار بازیابی‌شده را اینجا بخوانید یا اصلاح کنید.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

اگر کد در حالی که کتاب‌کار خارجی در دسترس نیست به آن دسترسی پیدا کند و بازیابی غیرفعال باشد، Aspose.Slides یک [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) پرتاب می‌کند. بازیابی را فقط زمانی فعال کنید که استفاده از دادهٔ کش‌شدهٔ نمودار یک گزینهٔ قابل‌قبول باشد، زیرا کش ممکن است شامل تغییراتی که پس از آخرین به‌روزرسانی ارائه در کتاب‌کار خارجی انجام شده، نباشد.

## **پرسش‌های متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به یک کتاب‌کار خارجی یا یک کتاب‌کار جاسازی‌شده پیوند دارد؟**

بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) و [مسیر به کتاب‌کار خارجی](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابجایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهای قرار گرفته در منابع شبکه/اشتراک‌ها استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای ریموت از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [پیوند به فایل خارجی](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) را ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبانی‌شده توسط سلول می‌تواند فایل XLSX محلی پیوندشده را نیز به‌روز کند. اگر باید کتاب‌کار اصلی بدون تغییر بماند، از یک کپی استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد، چه کاری باید انجام دهم؟**

Aspose.Slides رمز عبور را هنگام پیوندگیری نمی‌پذیرد. یک روش معمول حذف محافظت پیش از پیوند یا تهیه یک کپی رمزگشایی‌شده (به‌عنوان مثال با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/net/)) و پیوند به آن کپی است.

**آیا چندین نمودار می‌توانند به همان کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همگی به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار در بار بعدی بارگذاری داده‌ها منعکس می‌شود.
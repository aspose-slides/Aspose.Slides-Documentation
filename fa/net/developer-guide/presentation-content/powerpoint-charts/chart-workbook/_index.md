---
title: مدیریت کتاب‌کار نمودار در ارائه‌ها در .NET
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/net/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده‌های نمودار
- سلول کتاب‌کار
- برچسب داده
- کاربرگ
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
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد که چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند که چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را بازیابی کنید و داده‌های نمودار را زمانی که کتاب‌کار در دسترس باشد ویرایش کنید.

برای سلول‌های کتاب‌کار که نمایانگر داده‌های گمشده هستند، به [کنترل نمایش سلول‌های خالی](/slides/fa/net/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر و مقایسهٔ خطی نمودار در حالت‌های نمایش موجود را ببینید.

## **درج داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) برای کنترل این که آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های کاربرگ مخفی ترسیم می‌کند یا نه، استفاده کنید. آن را به `true` تنظیم کنید تا فقط سلول‌های قابل مشاهده ترسیم شوند، یا به `false` تا هم سلول‌های قابل مشاهده و هم مخفی گنجانده شوند. این تنظیم فقط ترسیم نمودار را کنترل می‌کند؛ ردیف‌ها یا ستون‌های کاربرگ را مخفی یا آشکار نمی‌کند.

[ارائه نمونه](hidden-source-data.pptx) شامل یک نمودار ستونی به عنوان اولین شکل در اولین اسلاید است. کاربرگ جاسازی‌شده، `Sheet1`، محدوده منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها هنوز مقدار دارند.

| ردیف کاربرگ | A: ماه | B: خرده‌فروش | C: عمده‌فروش (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

دسترسی به سلول‌های منبع از طریق [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) و خواندن [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) برای بررسی وضعیت مخفی بودن آن‌ها انجام می‌شود. این ویژگی فقط-خواندنی است. در این فایل، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی است و C2 متعلق به ستون مخفی است؛ مثال به ترتیب `False`، `True` و `True` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم ترسیم، داده‌های نمودار را تازه کنید: کتاب‌کار جاسازی‌شده را با [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) نگه دارید و با [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) دوباره بارگذاری کنید. هنگام گنجاندن تمام سلول‌ها، همچنین از [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) برای بازگرداندن محدودهٔ کامل شامل دستهٔ مخفی فوریه استفاده کنید. فقط تغییر پرچم برای تازه‌سازی داده‌های کش‌شدهٔ نمونه کافی نیست.

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
            // محدوده منبع کامل را بازگردانید، شامل دسته‌بندی‌های مخفی.
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

مثال دو نسخه از ارائه را ذخیره می‌کند: یک نسخه فقط با مقادیر خرده‌فروش قابل مشاهده (10 و 20) و نسخهٔ دیگر با تمام شش مقدار. تصویرهای زیر از ارائه‌های ذخیره‌شده پس از بازگشایی رندر شده‌اند؛ هر دو فایل تنظیم ترسیم اختصاصی خود را حفظ کرده‌اند. ردیف 3 و ستون C در هر دو کتاب‌کار جاسازی‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | تمام سلول‌ها (`false`) |
| --- | --- |
| ![فقط سلول‌های قابل مشاهده: مقادیر خرده‌فروش 10 و 20 برای ژانویه و مارس.](hidden_cells_True.png) | ![تمام سلول‌ها: مقادیر خرده‌فروش و عمده‌فروش برای ژانویه، فوریه و مارس.](hidden_cells_False.png) |

یک سلول مخفی که مقدار دارد با یک سلول خالی متفاوت است. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) کنترل می‌کند که مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم شامل یا مستثنی کردن داده‌های منبع مخفی نمی‌شود. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/net/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **بازیابی محدودهٔ دادهٔ یک نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائهٔ موجود، محدوده‌های منبع را بررسی کنید تا تعیین کنید هر نمودار از کدام سلول‌های کاربرگ استفاده می‌کند. متد [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) محدودهٔ دادهٔ فعلی را به صورت فرمولی با شناسایی کاربرگ باز می‌گرداند، مانند `Sheet1!$A$1:$D$5`. در اینجا، `Sheet1` نام کاربرگ است، `!` آن را از محدودهٔ سلول جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را به صورت شامل نشان می‌دهد. علامت دلار نشانگر ارجاع مطلق ردیف و ستون است.

این متد محدودهٔ فعلی را می‌خواند بدون اینکه نمودار یا کتاب‌کار آن را تغییر دهد. اگر نمودار از کتاب‌کاری به عنوان منبع داده استفاده نکند، یک [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) پرتاب می‌شود. برای اطلاعات بیشتر به [مرجع API ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌ها را مستقیماً در هر اسلاید برای نمودارها بررسی می‌کند. نام هر نمودار و محدودهٔ منبع را چاپ می‌کند. اگر یک نمودار از کتاب‌کاری استفاده نکند، پیامی چاپ می‌شود و به نمودار بعدی ادامه می‌دهد.

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

## **خواندن و نوشتن داده‌های نمودار از کتاب‌کار**

Aspose.Slides for .NET متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که امکان خواندن و نوشتن کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های نمودار ویرایش‌شده با Aspose.Cells) را می‌دهند. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل سازمان یافته باشند یا ساختاری مشابه منبع داشته باشند.

این مثال از یک ارائه با نموداری به عنوان اولین شکل در اولین اسلاید استفاده می‌کند. کتاب‌کار جاسازی‌شده را به یک استریم می‌خواند، سری‌ها و دسته‌بندی‌های موجود را پاک می‌کند و همان کتاب‌کار را دوباره می‌نویسد. تغییرات در حافظه می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی طرح نمودار پس از اصلاح کتاب‌کار**

هنگامی که کتاب‌کار جاسازی‌شده را با یکی اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌بندی‌های اصلی خود را حفظ می‌کند. این ناسازگاری می‌تواند باعث شکست [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) با خطای out‑of‑range شود. قبل از نوشتن کتاب‌کار به‌روز شده به نمودار، سری‌ها و دسته‌بندی‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اولین اسلاید است استفاده می‌کند. نظر نشان می‌دهد که ویرایش کتاب‌کار در کجا انجام می‌شود؛ مثال قابل اجرا کتاب‌کار اصلی را دوباره می‌نویسد و طرح را در حافظه اعتبارسنجی می‌کند.

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

    // در اینجا جریان کتاب‌کار را تغییر دهید، به عنوان مثال با استفاده از Aspose.Cells.

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

پاک‌سازی مجموعه‌ها مراجع دادهٔ منسوخ را پیش از نوشتن کتاب‌کار حذف می‌کند. پیش از استفاده از نمودار، هر سری و نگاشت دسته‌بندی لازم برای کتاب‌کار به‌روز شده را بازسازی کنید.

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اولین اسلاید یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای اولین سه برچسب در اولین سری استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌کند و ارائه به‌روز شده را ذخیره می‌کند.

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

ویژگی [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) دسترسی به کاربرگ‌های موجود در کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر کاربرگ را در کنسول چاپ می‌کند.

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

## **مشخص‌کردن نوع منبع داده**

این مثال یک نمودار ستونی 3بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع دادهٔ مختلف تنظیم می‌کند. نام اول از یک رشتهٔ متنی استفاده می‌کند؛ نام دوم از سلول C1 در کاربرگ 0 استفاده می‌کند. شمارش [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) منبع را برای هر نام انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روز شده ذخیره می‌کند.

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

## **تشخیص قالب‌های پشتیبانی‌نشدهٔ کتاب‌کار جاسازی‌شده**

Aspose.Slides قالب کتاب‌کار باینری اکسل (.xlsb) را که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید از ویژگی [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) در [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) برای تشخیص قالب‌های نامپشتیبانی‌شده و صرف‌نظر از آن نمودارها استفاده کنید. این مثال شکل‌ها را در اسلاید اول یک ارائهٔ موجود بررسی می‌کند، شکل‌های غیرنموداری را نادیده می‌گیرد و برای هر نمودار با کتاب‌کار .xlsb جاسازی‌شده یک پیام تشخیصی چاپ می‌کند.

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

    // اینجا داده‌های کتاب‌کار نمودار پشتیبانی‌شده را بخوانید یا تغییر دهید.
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفادهٔ کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) برای استخراج کتاب‌کار نمودار جاسازی‌شده به یک فایل و لینک نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را استخراج می‌کند. پیش از اختصاص کتاب‌کار خارجی به عنوان منبع دادهٔ نمودار، استریم خروجی را می‌بندد، سپس ارائهٔ لینک‌دار را ذخیره می‌کند.

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

با استفاده از متد [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به عنوان منبع دادهٔ آن اختصاص دهید. این متد می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورتی که جابجا شده باشد) نیز استفاده شود.

اگرچه نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع را ویرایش کنید، همچنان می‌توانید از این کتاب‌کارها به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی ارائه شود، به طور خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که کاربرگ آن به نام `Sheet1` شامل یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را لینک می‌کند و از [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) برای نگاشتن A1:B4 به یک سری و سه دسته استفاده می‌کند. ارائه با نمودار لینک‌شده ذخیره می‌شود.

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

پارامتر `updateChartData` متد [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) کنترل می‌کند که آیا کتاب‌کار بارگذاری شود یا نه.

* زمانی که `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روز می‌شود. دادهٔ نمودار از کتاب‌کار مقصد بارگذاری یا به‌روزرسانی نمی‌شود، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* زمانی که `updateChartData` برابر `true` باشد، دادهٔ نمودار از کتاب‌کار مقصد به‌روزرسانی می‌شود.

مثال زیر یک URL جایگزین را با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شوند و ارائه بدون بارگذاری کتاب‌کار ناموجود ذخیره می‌شود.

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

برای شناسایی کتاب‌کار مرتبط با یک نمودار، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را دریافت کنید.

این مثال اولین شکل در اولین اسلاید یک ارائهٔ دارای کتاب‌کار خارجی لینک‌شده را بررسی می‌کند. اگر یک نمودار لینک‌شده به کتاب‌کار خارجی باشد، مثال [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) را در کنسول چاپ می‌کند. سپس یک نسخهٔ کپی از ارائه را ذخیره می‌کند.

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

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را به همان روشی که داده‌های کتاب‌کارهای داخلی را ویرایش می‌کنید، تغییر دهید. هنگامی که کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی قابل دسترسی لینک شده استفاده می‌کند. مقدار پشتیبانی‌شده توسط سلول اولین نقطه دادهٔ اولین سری را به 100 تنظیم کرده و ارائه به‌روز شده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی لینک‌شده را به‌روز کند، بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی از یک کپی استفاده کنید.

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

### **بازگرداندن کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که گم شده یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شدهٔ موجود در ارائه بازسازی کند. قبل از باز کردن ارائه، یک [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) ایجاد کنید، [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) آن را پیکربندی کنید و [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) را به `true` تنظیم کنید.

کد C# زیر داده‌های کتاب‌کار را برای یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی ناموجود ارجاع می‌دهد، بازیابی می‌کند. داده‌های بازیابی‌شده از طریق [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) و [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) دسترسی پیدا می‌شود:

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

    // در اینجا داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا تغییر دهید.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) پرتاب می‌کند. بازگرداندن را تنها زمانی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ قابل قبول باشد، زیرا کش ممکن است تغییرات ایجادشده در کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه را شامل نشود.

## **پرسش‌های متداول**

**آیا می‌توانم تعیین کنم یک نمودار خاص به کتاب‌کار خارجی یا جاسازی‌شده لینک دارد؟**

بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) و [مسیر به کتاب‌کار خارجی](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌طور خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابجایی کتاب‌کار ممکن است نیاز به به‌روزرسانی لینک داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که در منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای دوردست از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبانی‌شده توسط سلول می‌تواند فایل XLSX محلی لینک‌شده را نیز به‌روزرسانی کند. اگر کتاب‌کار اصلی باید دست‌نخورده بماند، از یک کپی استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه باید کرد؟**

Aspose.Slides هنگام لینک‌گذاری رمز عبوری نمی‌گیرد. یک راه معمول این است که پیش از لینک‌گذاری حفاظت را حذف کنید یا یک کپی رمزگشایی‌شده تهیه کنید (برای مثال با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/net/)) و به آن لینک دهید.

**آیا چندین نمودار می‌توانند به همان کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار در بار بعدی بارگذاری داده‌ها منعکس خواهد شد.
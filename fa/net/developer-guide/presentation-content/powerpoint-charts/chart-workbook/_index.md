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
description: "Aspose.Slides برای .NET را کشف کنید: به راحتی کتاب‌کارهای نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی داشته باشید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چطور یک کتاب‌کار خارجی ایجاد و اختصاص داده شود، مسیر کتاب‌کار خارجی پیوست شده به یک نمودار بازیابی شود، و داده‌های نمودار هنگام در دسترس بودن کتاب‌کار ویرایش شود.

برای کتاب‌کارهایی که سلول‌هایشان نشان‌دهنده داده‌های گمشده است، به [کنترل نمایش سلول‌های خالی](/slides/fa/net/chart-series/) برای تفاوت بین یک سلول خالی و صفر، و مقایسه نمودار خطی حالت‌های نمایش موجود مراجعه کنید.

## **داده‌ها از ردیف‌ها و ستون‌های پنهان شامل شوند**

از [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) برای کنترل این استفاده کنید که آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های پنهان کاربرگ رسم کند یا نه. مقدار آن را به `true` تنظیم کنید تا فقط سلول‌های قابل مشاهده رسم شوند، یا به `false` تا هر دو سلول قابل مشاهده و پنهان شامل شوند. این تنظیم فقط رسم نمودار را کنترل می‌کند؛ ردیف‌ها یا ستون‌های کاربرگ را مخفی یا نمایان نمی‌کند.

فایل [hidden-source-data.pptx](hidden-source-data.pptx) را دانلود کنید و در پوشه کاری قرار دهید. اسلاید اول آن شامل یک نمودار ستونی به عنوان اولین شکل است. کاربرگ جاسازی‌شده، `Sheet1`، شامل بازه منبع زیر است: `A1:C4`. ردیف 3 و ستون C پنهان هستند، اما سلول‌هایشان همچنان مقدار دارند.

| ردیف کاربرگ | A: ماه | B: خرده‌فروش | C: عمده‌فروش (ستون پنهان) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (hidden row) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

دسترسی به سلول‌های منبع از طریق [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/chartdataworkbook/) و خواندن [IChartDataCell.IsHidden](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdatacell/ishidden/) برای بررسی وضعیت مخفی بودن آنها امکان‌پذیر است. این ویژگی فقط‑خواندنی است. در این فایل، B2 قابل مشاهده است، B3 متعلق به ردیف پنهان است و C2 متعلق به ستون پنهان است؛ مثال به ترتیب `False`، `True` و `True` چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم رسم، داده‌های نمودار را تازه کنید: کتاب‌کار جاسازی‌شده را با [ReadWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/readworkbookstream/) حفظ کنید و با [WriteWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/writeworkbookstream/) دوباره بارگذاری کنید. هنگام شامل کردن تمام سلول‌ها، همچنین از [SetRange](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/setrange/) برای بازگرداندن بازه کامل، از جمله دستهٔ پنهان فوریه استفاده کنید. فقط تغییر پرچم برای تازه‌سازی داده‌های کش‌شدهٔ این نمونه کافی نیست.

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
            // محدوده منبع کامل را بازگردانید، از جمله دسته‌های پنهان.
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

مثال `hidden_cells_True.pptx` را تنها با مقادیر خرده‌فروش قابل مشاهده (10 و 20) ذخیره می‌کند و `hidden_cells_False.pptx` را با تمام شش مقدار. تصاویر زیر پس از باز کردن دوبارهٔ ارائه‌ها رندر شده‌اند؛ هر دو فایل تنظیم رسم اختصاص یافته خود را حفظ می‌کنند. ردیف 3 و ستون C در هر دو کتاب‌کار جاسازی‌شده پنهان می‌مانند.

| تنها سلول‌های قابل مشاهده (`true`) | تمام سلول‌ها (`false`) |
| --- | --- |
| ![فقط سلول‌های قابل مشاهده: مقادیر خرده‌فروش 10 و 20 برای ژانویه و مارس.](hidden_cells_True.png) | ![تمام سلول‌ها: مقادیر خرده‌فروش و عمده‌فروش برای ژانویه، فوریه و مارس.](hidden_cells_False.png) |

یک سلول پنهان که شامل مقدار است، با یک سلول خالی متفاوت است. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/displayblanksas/) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این ویژگی منبع دادهٔ مخفی را شامل یا حذف نمی‌کند. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/net/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **خواندن و نوشتن داده‌های نمودار از کتاب‌کار**

Aspose.Slides for .NET متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که امکان خواندن و نوشتن کتاب‌کارهای دادهٔ نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را می‌دهند. **توجه** این است که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال `chart.pptx` را باز می‌کند که باید یک نمودار به عنوان اولین شکل در اولین اسلاید داشته باشد. کتاب‌کار جاسازی‌شده را به یک جریان می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را باز می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی طرح نمودار پس از تغییر کتاب‌کار**

هنگامی که کتاب‌کار جاسازی‌شده را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شکست [IChart.ValidateChartLayout](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/validatechartlayout/) با خطای «شاخص خارج از بازه» شود. پیش از نوشتن کتاب‌کار به‌روزرسانی‌شده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال به `chart.pptx` با یک نمودار به عنوان اولین شکل در اولین اسلاید نیاز دارد. نظرات نشان می‌دهند که ویرایش کتاب‌کار کجا انجام می‌شود؛ مثال قابل اجرا کتاب‌کار اصلی را باز می‌نویسد و طرح را در حافظه اعتبارسنجی می‌کند.

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

    // در اینجا جریان کتاب‌کار را تغییر دهید، برای مثال با استفاده از Aspose.Cells.

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

پاک‌سازی مجموعه‌ها قبل از نوشتن کتاب‌کار، مراجع دادهٔ کهنه را حذف می‌کند. قبل از استفاده از نمودار، هر نگاشت سری یا دستهٔ مورد نیاز برای کتاب‌کار به‌روزرسانی‌شده بازسازی شود.

## **تنظیم سلول کتاب‌کار به عنوان برچسب داده نمودار**

می‌توانید متن سلول‌های کتاب‌کار را به عنوان برچسب‌های دادهٔ نمودار استفاده کنید. مراحل زیر نشان می‌دهند چگونه برچسب‌های یک نمودار حبابی را به سلول‌های کاربرگ دادهٔ آن لینک کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.  
2. اسلاید اول را با ایندکس صفر مبنا دسترسی پیدا کنید.  
3. یک نمودار حبابی با داده‌های پیش‌فرض اضافه کنید.  
4. سری‌های نمودار را دسترسی پیدا کنید.  
5. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.  
6. ارائه را ذخیره کنید.

این مثال `chart2.pptx` را باز می‌کند که باید حداقل یک اسلاید داشته باشد و یک نمودار حبابی با داده‌های پیش‌فرض اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای اولین سه برچسب در اولین سری استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌سازد و نتیجه را در `resultchart.pptx` ذخیره می‌کند.

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

ویژگی [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/worksheets/) دسترسی به کاربرگ‌های موجود در یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار پای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر کاربرگ را در کنسول چاپ می‌کند.

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

این مثال یک نمودار ستونی 3‑بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با استفاده از منابع داده متفاوت تنظیم می‌کند. نام اول از یک رشتهٔ ثابت استفاده می‌کند؛ دومین نام از سلول C1 در کاربرگ 0 استفاده می‌کند. شمارندهٔ [DataSourceType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/datasourcetype/) منبع هر نام را انتخاب می‌کند. نتیجه در `pres.pptx` ذخیره می‌شود.

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

## **تشخیص فرمت‌های نامشخص کتاب‌کار جاسازی‌شده**

Aspose.Slides از فرمت کتاب‌کار دودویی اکسل (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید از ویژگی [EmbeddedWorkbookType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) در [IChartData](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/) همراه با شمارندهٔ [WorkbookType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/workbooktype/) برای شناسایی فرمت‌های پشتیبانی‌نشده و عبور از آن نمودارها استفاده کنید. این مثال اشکال اولین اسلاید `sample.pptx` را بررسی می‌کند، اشکالی که نمودار نیستند را عبور می‌دهد و برای هر نمودار دارای کتاب‌کار .xlsb پیام تشخیص می‌دهد.

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

    // داده‌های کتاب‌کار پشتیبانی‌شدهٔ نمودار را اینجا بخوانید یا تغییر دهید.
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [ReadWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [SetExternalWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/setexternalworkbook/) برای استخراج کتاب‌کار نمودار جاسازی‌شده به یک فایل و لینک کردن نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار پای با داده‌های پیش‌فرض ایجاد می‌کند، کتاب‌کار آن را در `externalWorkbook1.xlsx` می‌نویسد و قبل از انتساب فایل به عنوان منبع دادهٔ نمودار، جریان خروجی را می‌بندد. ارائهٔ لینک‌شده در `externalWorkbook.pptx` ذخیره می‌شود.

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

با استفاده از متد [SetExternalWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/setexternalworkbook/) می‌توانید یک کتاب‌کار خارجی را به عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورت جابه‌جایی آن) استفاده شود.

اگرچه نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع را ویرایش کنید، می‌توانید همچنان از چنین کتاب‌کارهایی به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی فراهم شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال به `externalWorkbook.xlsx` در پوشه کاری نیاز دارد. کاربرگ آن که نامش `Sheet1` است باید یک نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 داشته باشد. مثال یک نمودار پای ایجاد می‌کند، کتاب‌کار را لینک می‌کند و از [SetRange](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/setrange/) برای نگاشت A1:B4 به یک سری و سه دسته استفاده می‌کند. نتیجه در `Presentation_with_externalWorkbook.pptx` ذخیره می‌شود.

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

پارامتر `updateChartData` متد [SetExternalWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/setexternalworkbook/) کنترل می‌کند که آیا کتاب‌کار بارگذاری شود یا نه.

* زمانی که `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.  
* زمانی که `updateChartData` برابر `true` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

مثال زیر یک URL برای جای‌گیرنده اختصاص می‌دهد در حالی که `updateChartData` برابر `false` تنظیم شده است. داده‌های پیش‌فرض نمودار پای حفظ می‌شود و ارائه بدون بارگذاری کتاب‌کار غیرفعال ذخیره می‌شود.

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

### **دریافت مسیر کتاب‌کار منبع داده خارجی یک نمودار**

برای شناسایی کتاب‌کاری که به یک نمودار لینک شده، ابتدا بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند یا نه. اگر بله، می‌توانید مسیر کتاب‌کار را با دنبال کردن مراحل زیر دریافت کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.  
2. اسلاید اول را با ایندکس صفر مبنا دسترسی پیدا کنید.  
3. بررسی کنید که اولین شکل یک نمودار باشد.  
4. نوع منبع دادهٔ نمودار را بخوانید.  
5. اگر منبع یک کتاب‌کار خارجی بود، مسیر آن را بخوانید.

این مثال `externalWorkbook.pptx` را باز می‌کند که در مثال قبلی ایجاد شده و اولین شکل در اولین اسلاید را بررسی می‌کند. اگر این شکل یک نمودار لینک‌شده به کتاب‌کار خارجی باشد، مثال [ExternalWorkbookPath](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/externalworkbookpath/) را در کنسول چاپ می‌کند. سپس یک نسخهٔ کپی از ارائه را در `Result.pptx` ذخیره می‌کند.

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

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همانند تغییر محتوای کتاب‌کارهای داخلی ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این مثال به `presentation.pptx` که باید یک نمودار به عنوان اولین شکل در اولین اسلاید داشته باشد و یک کتاب‌کار خارجی قابل دسترسی نیاز دارد. مقدار پشتیبانی‑شدهٔ اولین نقطه داده در اولین سری به 100 تنظیم می‌شود و ارائه در `presentation_out.pptx` ذخیره می‌شود. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی لینک‌شده را به‌روزرسانی کند، بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی از یک کپی استفاده کنید.

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

### **بازیابی کتاب‌کار از حافظه‌نهان نمودار**

اگر یک نمودار از کتاب‌کار خارجی که گم شده یا در دسترس نیست استفاده می‌کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/) ایجاد کنید، [SpreadsheetOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/spreadsheetoptions/) آن را پیکربندی کنید و [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) را به `true` تنظیم کنید.

مثال زیر در C# `presentation.pptx` را باز می‌کند که اولین شکل در اولین اسلاید باید یک نمودار با ارجاع به کتاب‌کار خارجی غیرفعال باشد و داده‌های بازیابی‌شده را از طریق [IChart.ChartData](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/chartdata/) و [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/chartdataworkbook/) دسترسی می‌یابد:

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

    // داده‌های کتاب‌کار بازیابی‌شده را اینجا بخوانید یا تغییر دهید.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) پرتاب می‌کند. بازیابی را فقط زمانی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ قابل قبول باشد، زیرا ممکن است کش شامل تغییرات اعمال‌شده به کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نشود.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به یک کتاب‌کار خارجی یا داخلی لینک شده است؟**  
بله. یک نمودار دارای یک [data source type](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/datasourcetype/) و یک [path to an external workbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/externalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی مشخص شود، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی لینک داشته باشد.

**آیا می‌توانم از کتاب‌کارهای موجود در منابع/اشتراک‌های شبکه استفاده کنم؟**  
بله، چنین کتاب‌کارهایی می‌توانند به عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای از راه دور از طریق Aspose.Slides پشتیبانی نمی‌شود—فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره‌سازی ارائه فایل XLSX خارجی را بازنویسی می‌کند؟**  
ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/externalworkbookpath/) را ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبانی‌شده از سلول می‌تواند فایل XLSX محلی لینک‌شده را نیز به‌روز کند. اگر کتاب‌کار اصلی باید دست‌نخورده بماند، از یک کپی استفاده کنید.

**در صورتی که فایل خارجی با رمز عبور محافظت شده باشد، چه باید کرد؟**  
Aspose.Slides هنگام لینک کردن رمز عبوری قبول نمی‌کند. یک روش معمول این است که قبل از لینک کردن محافظت را حذف کنید یا یک کپی رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/net/)) تهیه کنید و به آن لینک دهید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی ارجاع دهند؟**  
بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌های هر نمودار بازتاب خواهد یافت.
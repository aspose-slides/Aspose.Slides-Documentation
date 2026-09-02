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
description: "Aspose.Slides برای .NET را کشف کنید: به‌راحتی کتاب‌کارهای نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهبود بخشید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به‌عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به‌عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چطور یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی پیوست‌شده به یک نمودار را بازیابی کنید و داده‌های نمودار را هنگامی که کتاب‌کار در دسترس است، ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**
Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که به شما امکان خواندن و نوشتن کتاب‌کارهای داده نمودار (حاوی داده‌های نمودار ویرایش‌شده با Aspose.Cells) را می‌دهد. **Note** این که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این کد C# یک عملیات نمونه را نشان می‌دهد:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب‌کار**
زمانی که یک کتاب‌کار توکار را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعه‌های سری و دسته‌بندی اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شکست متد [IChart.ValidateChartLayout](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/validatechartlayout/) با خطای out-of-range شود. قبل از نوشتن کتاب‌کار به‌روز شده به نمودار، سری‌ها و دسته‌بندی‌های موجود را پاک کنید.

```csharp
// پس از تغییر جریان کتاب‌کار (مثلاً با استفاده از Aspose.Cells)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// مراجع داده‌های موجود را پاک کنید.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

پاک‌سازی مجموعه‌ها اطمینان می‌دهد که ساختار داده‌های نمودار با کتاب‌کار جدید سازگار است و `ValidateChartLayout` بدون خطا تکمیل می‌شود.

## **تنظیم یک سلول کتاب‌کار به‌عنوان برچسب داده نمودار**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.
1. یک نمودار حبابی با برخی داده‌ها اضافه کنید.
1. به سری‌های نمودار دسترسی پیدا کنید.
1. سلول کتاب‌کار را به‌عنوان برچسب داده تنظیم کنید.
1. ارائه را ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک سلول کتاب‌کار را به‌عنوان برچسب داده نمودار تنظیم کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// یک نمونه از کلاس Presentation که فایل ارائه را نشان می‌دهد ایجاد می‌کند

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **مدیریت کاربرگ‌ها**
این کد C# عملی را نمایش می‌دهد که در آن ویژگی [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) برای دسترسی به مجموعه کاربرگ‌ها استفاده می‌شود:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **مشخص کردن نوع منبع داده**
این کد C# نشان می‌دهد چگونه برای یک منبع داده یک نوع مشخص کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **تشخیص قالب‌های کتاب‌کار توکار پشتیبانی‌نشده**
Aspose.Slides از قالب کتاب‌کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها توکار شود، پشتیبانی نمی‌کند. می‌توانید از ویژگی `EmbeddedWorkbookType` در [IChartData](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/) همراه با enumeration [WorkbookType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/workbooktype/) برای تشخیص قالب‌های پشتیبانی‌نشده استفاده کنید و آن نمودارها را نادیده بگیرید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // کتاب‌کار توکار در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue;
        }

        // در اینجا می‌توانید داده‌های کتاب‌کار نمودار را بخوانید یا اصلاح کنید.
    }
}
```

## **کتاب‌کار خارجی**

{{% alert color="info" %}} 
در [Aspose.Slides 19.4](https://docs.aspose.com/slides/fa/net/aspose-slides-for-net-19-4-release-notes/)، ما پشتیبانی از کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها را پیاده‌سازی کردیم.
{{% /alert %}} 

### **ایجاد یک کتاب‌کار خارجی**
با استفاده از متدهای **`ReadWorkbookStream`** و **`SetExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را از ابتدا ایجاد کنید یا یک کتاب‌کار داخلی را به خارجی تبدیل کنید.

این کد C# فرآیند ایجاد کتاب‌کار خارجی را نشان می‌دهد:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **تنظیم یک کتاب‌کار خارجی**
با استفاده از متد **`SetExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به عنوان منبع داده به یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورت انتقال آن) استفاده شود.

در حالی که نمی‌توانید داده‌های موجود در کتاب‌کارهایی که در مکان‌های راه دور یا منابع ذخیره شده‌اند را ویرایش کنید، می‌توانید همچنان از این کتاب‌کارها به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی فراهم شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این کد C# نشان می‌دهد چگونه یک کتاب‌کار خارجی را تنظیم کنید:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// مسیر پوشه اسناد.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

پارامتر `ChartData` (در زیر متد `SetExternalWorkbook`) برای تعیین اینکه آیا کتاب‌کار اکسل بارگذاری شود یا نه استفاده می‌شود.

* وقتی مقدار `ChartData` به `false` تنظیم شود، تنها مسیر کتاب‌کار به‌روزرسانی می‌شود—داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شود. می‌توانید این تنظیم را زمانی که کتاب‌کار هدف وجود ندارد یا در دسترس نیست، به کار ببرید.
* وقتی مقدار `ChartData` به `true` تنظیم شود، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **دریافت مسیر کتاب‌کار منبع داده خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.
1. یک شی برای شکل نمودار ایجاد کنید.
1. یک شی برای نوع منبع (`ChartDataSourceType`) که نمایانگر منبع داده نمودار است ایجاد کنید.
1. شرط مرتبط را بر اساس اینکه نوع منبع همان نوع منبع داده کتاب‌کار خارجی باشد، مشخص کنید.

این کد C# عملیات را نشان می‌دهد:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // ارائه را ذخیره می‌کند
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **ویرایش داده‌های نمودار**
می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همانند تغییرات در محتوای کتاب‌کارهای داخلی ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این کد C# پیاده‌سازی فرایند توصیف‌شده را نشان می‌دهد:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **بازیابی کتاب‌کار از کش نمودار**
اگر یک نمودار از کتاب‌کار خارجی که موجود نیست یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک شی [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/) ایجاد کنید، [SpreadsheetOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/spreadsheetoptions/) آن را پیکربندی کنید و `ISpreadsheetOptions.RecoverWorkbookFromChartCache` را پیش از باز کردن ارائه به `true` تنظیم کنید.

مثال C# زیر یک ارائه را باز می‌کند که نمودار آن به کتاب‌کار خارجی غیرقابل دسترس ارجاع می‌دهد و داده‌های بازیابی‌شده را از طریق [IChart.ChartData](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/chartdata/) و [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/chartdataworkbook/) دسترسی می‌دهد:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Read or modify the recovered workbook data here.
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک `InvalidOperationException` پرتاب می‌کند. بازیابی را فقط زمانی فعال کنید که استفاده از داده‌های کش‌شده نمودار یک گزینهٔ قابل قبول باشد، زیرا ممکن است کش شامل تغییرات اعمال‌شده به کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم که آیا یک نمودار خاص به کتاب‌کار خارجی یا توکار پیوند دارد؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/datasourcetype/) و [path to an external workbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/externalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این کار برای جابجایی پروژه مفید است؛ اما باید توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهایی که در منابع/به‌اشتراک‌گذاری‌های شبکه‌ای قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای راه دور از طریق Aspose.Slides پشتیبانی نمی‌شود—فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/externalworkbookpath/) ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی خود هنگام ذخیرهٔ ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه کاری باید انجام دهم؟**

Aspose.Slides هنگام پیوند گرفتن رمز عبور قبول نمی‌کند. رویکرد معمول این است که قبل از استفاده حفاظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](/cells/net/)) تهیه کنید و به آن نسخه پیوند دهید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار منعکس می‌شود.
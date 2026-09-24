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
- ورک‌شیت
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
description: "Aspose.Slides برای .NET را کشف کنید: به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه کنید."
---
## **Overview**

این مقاله نحوه کار با کتاب‌کارهای نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه می‌توان داده‌های نمودار را از طریق جریان‌های کتاب‌کار خواند و نوشت، از سلول‌های کتاب‌کار به‌عنوان برچسب‌های داده نمودار استفاده کرد، به مجموعه‌های ورک‌شیت دسترسی داشت و نوع منبع داده برای مقادیر نمودار را تعیین کرد.

همچنین کار با کتاب‌کارهای خارجی به‌عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داده می‌شود، مسیر کتاب‌کار خارجی مرتبط با یک نمودار بازیابی می‌شود و داده‌های نمودار زمانی که کتاب‌کار در دسترس باشد، ویرایش می‌شود.

برای سلول‌های کتاب‌کاری که نشان‌دهنده داده‌های missing هستند، به [Control the Display of Empty Cells](/slides/fa/net/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر، و مقایسهٔ نمودار خطی برای حالت‌های نمایش موجود را ببینید.

## **Read and Write Chart Data from a Workbook**
Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که به شما امکان خواندن و نوشتن کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را می‌دهد. **توجه** داشته باشید که داده‌های نمودار باید به همان شیوه سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

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

### **Validate Chart Layout After Workbook Modification**

زمانی که یک کتاب‌کار توکار را با یک کتاب‌کار تغییر یافته جایگزین می‌کنید، نمودار مجموعه‌های سری و دسته‌بندی اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود که [IChart.ValidateChartLayout](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/validatechartlayout/) با خطای out‑of‑range شکست بخورد. قبل از نوشتن کتاب‌کار به‌روزشده به نمودار، سری‌ها و دسته‌ها را پاک کنید.

```csharp
// پس از تغییر جریان کتاب‌کار (مثلاً با استفاده از Aspose.Cells)
using var updatedWorkbook = chartData.ReadWorkbookStream();

// مراجع داده موجود را پاک کنید.
chartData.Series.Clear();
chartData.Categories.Clear();

updatedWorkbook.Position = 0;
chartData.WriteWorkbookStream(updatedWorkbook);

chart.ValidateChartLayout();
```

پاک‌سازی مجموعه‌ها اطمینان می‌دهد که ساختار دادهٔ نمودار با کتاب‌کار جدید سازگار است و امکان انجام `ValidateChartLayout` بدون خطا فراهم می‌شود.

## **Set a WorkBook Cell as a Chart Data Label**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار حبابی با داده‌های مختص به آن اضافه کنید.  
1. به سری‌های نمودار دسترسی پیدا کنید.  
1. سلول کتاب‌کار را به‌عنوان برچسب داده تنظیم کنید.  
1. ارائه را ذخیره کنید.

این کد C# نشان می‌دهد چگونه سلول کتاب‌کار را به‌عنوان برچسب دادهٔ نمودار تنظیم کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// نمونه‌ای از کلاس Presentation که یک فایل ارائه را نشان می‌دهد 

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

## **Manage Worksheets**

این کد C# نشان‌دهندهٔ عملیاتی است که در آن ویژگی [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) برای دسترسی به مجموعهٔ ورک‌شیت‌ها به‌کار گرفته می‌شود:

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

## **Specify the Data Source Type**

این کد C# نشان می‌دهد چگونه برای یک منبع داده نوعی را مشخص کنید:

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

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides از فرمت کتاب‌کار باینری اکسل (.xlsb) که ممکن است در برخی نمودارها توکار باشد، پشتیبانی نمی‌کند. می‌توانید با استفاده از ویژگی `EmbeddedWorkbookType` در [IChartData](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/workbooktype/) فرمت‌های نا‌پشتیبانی‌شده را شناسایی و از پردازش آن نمودارها صرف‌نظر کنید.

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

        // در اینجا داده‌های کتاب‌کار نمودار را بخوانید یا اصلاح کنید.
    }
}
```

## **External Workbook**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **Create an External Workbook**

با استفاده از متدهای **`ReadWorkbookStream`** و **`SetExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی از ابتدا ایجاد کنید یا یک کتاب‌کار داخلی را به‌صورت خارجی درآورید.

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

### **Set an External Workbook**
با استفاده از متد **`SetExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد همچنین برای به‌روزرسانی مسیر کتاب‌کار خارجی (اگر کتاب‌کار جابه‌جا شده باشد) به‌کار می‌رود.

اگرچه نمی‌توانید داده‌های موجود در کتاب‌کارهایی که در مکان‌های دوردست یا منابع ذخیره شده‌اند را ویرایش کنید، می‌توانید همچنان از این کتاب‌کارها به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این کد C# نشان می‌دهد چگونه یک کتاب‌کار خارجی تنظیم کنید:

```c#
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

پارامتر `ChartData` (درون متد `SetExternalWorkbook`) برای تعیین این که آیا کتاب‌کار اکسل بارگذاری شود یا نه، استفاده می‌شود.

* وقتی مقدار `ChartData` روی `false` تنظیم شود، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود — داده‌های نمودار بارگذاری یا به‌روزرسانی نمی‌شوند. این تنظیم می‌تواند زمانی مفید باشد که کتاب‌کار هدف موجود نباشد یا در دسترس نباشد.  
* وقتی مقدار `ChartData` روی `true` تنظیم شود، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

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

### **Get the External Data Source Workbook Path of a Chart**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک شیء برای شکل نمودار ایجاد کنید.  
1. یک شیء برای نوع منبع (`ChartDataSourceType`) که نشان‌دهندهٔ منبع دادهٔ نمودار است ایجاد کنید.  
1. شرط مربوطه را بر اساس اینکه نوع منبع همان نوع منبع کتاب‌کار خارجی باشد، مشخص کنید.

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

### **Edit Chart Data**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همانند تغییرات در محتویات کتاب‌کارهای داخلی ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنایی رخ می‌دهد.

این کد C# پیاده‌سازی فرآیند شرح داده‌شده را ارائه می‌دهد:

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

### **Recover a Workbook from the Chart Cache**

اگر یک نمودار از یک کتاب‌کار خارجی که موجود نیست یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش شده در ارائه بازسازی کند. یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/) ایجاد کنید، ویژگی‌های [SpreadsheetOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/spreadsheetoptions/) را تنظیم کنید و قبل از باز کردن ارائه مقدار `ISpreadsheetOptions.RecoverWorkbookFromChartCache` را روی `true` قرار دهید.

مثال C# زیر ارائه‌ای را که نمودار آن به کتاب‌کار خارجی ناموجود ارجاع می‌دهد باز می‌کند و از طریق [IChart.ChartData](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/chartdata/) و [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/chartdataworkbook/) به داده‌های بازیابی‌شده دسترسی می‌یابد:

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

اگر کتاب‌کار خارجی موجود نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک `InvalidOperationException` پرتاب می‌کند. بازیابی را تنها زمانی فعال کنید که استفاده از داده‌های کش شدهٔ نمودار گزینهٔ قابل‌قبولی باشد، زیرا ممکن است کش شامل تغییرات اعمال‌شده به کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **FAQ**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به کتاب‌کار خارجی یا توکار لینک شده است؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/datasourcetype/) و [path to an external workbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/externalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا اطمینان حاصل کنید که فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این کار برای قابلیت حمل پروژه مفید است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهایی که در منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای راه دور از Aspose.Slides پشتیبانی نمی‌شود — آنها تنها می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/externalworkbookpath/) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیرهٔ ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شده باشد، باید چه کار کنم؟**

Aspose.Slides هنگام لینک کردن رمز عبور را پذیرفته نمی‌کند. رویکرد معمول حذف محافظت از پیش یا تهیه یک کپی رمزگشایی‌شده (به‌عنوان مثال با استفاده از [Aspose.Cells](/cells/net/)) و لینک به آن کپی است.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همگی به یک فایل اشاره داشته باشند، به‌روزرسانی آن فایل در هر نمودار هنگام بارگذاری داده‌ها منعکس می‌شود.
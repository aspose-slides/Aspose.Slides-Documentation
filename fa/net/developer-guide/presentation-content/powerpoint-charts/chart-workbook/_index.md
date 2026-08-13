---
title: مدیریت کارنامه‌های نمودار در ارائه‌ها در .NET
linktitle: کارنامه نمودار
type: docs
weight: 70
url: /fa/net/chart-workbook/
keywords:
- کارنامه نمودار
- داده‌های نمودار
- سلول کارنامه
- برچسب داده
- برگه کاری
- منبع داده
- کارنامه خارجی
- داده خارجی
- کش نمودار
- بازیابی کارنامه
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides برای .NET را کشف کنید: به راحتی کارنامه‌های نمودار را در قالب‌های پاورپوینت و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با کارنامه‌های نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کارنامه بخوانید و بنویسید، از سلول‌های کارنامه به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های برگه‌های کاری دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کارنامه‌های خارجی به عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کارنامهٔ خارجی را ایجاد و تخصیص دهید، مسیر یک کارنامهٔ خارجی پیوند داده‌شده به یک نمودار را بازیابی کنید و داده‌های نمودار را زمانی که کارنامه در دسترس باشد ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کارنامه**
Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که به شما امکان می‌دهد داده‌های کارنامه نمودار (حاوی داده‌های نمودار ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **نکته** این است که داده‌های نمودار باید به همان روش سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

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

## **تنظیم یک سلول WorkBook به عنوان برچسب داده نمودار**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار حبابی با برخی داده‌ها اضافه کنید.  
1. به سری‌های نمودار دسترسی پیدا کنید.  
1. سلول کارنامه را به‌عنوان برچسب داده تنظیم کنید.  
1. ارائه را ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک سلول کارنامه را به‌عنوان برچسب دادهٔ نمودار تنظیم کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// یک نمونه از کلاس Presentation که نمایندهٔ فایل ارائه است را ایجاد می‌کند

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

## **مدیریت برگه‌های کاری**
این کد C# عملی را نشان می‌دهد که در آن ویژگی [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) برای دسترسی به مجموعهٔ برگه‌های کاری استفاده می‌شود:

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

## **شناسایی قالب‌های کارنامه تعبیه‌شدهٔ پشتیبانی‌نشده**
Aspose.Slides از قالب کارنامهٔ باینری Excel (.xlsb) که می‌تواند در برخی نمودارها تعبیه شود، پشتیبانی نمی‌کند. می‌توانید از ویژگی `EmbeddedWorkbookType` در [IChartData](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/) همراه با شمارش‌گر [WorkbookType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/workbooktype/) برای شناسایی قالب‌های پشتیبانی‌نشده استفاده کنید و آن نمودارها را نادیده بگیرید.

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
            // کارنامه تعبیه‌شده در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue;
        }

        // داده‌های کارنامهٔ نمودار را در اینجا بخوانید یا تغییر دهید.
    }
}
```

## **کارنامهٔ خارجی**
{{% alert color="info" %}} 
در [Aspose.Slides 19.4](https://docs.aspose.com/slides/fa/net/aspose-slides-for-net-19-4-release-notes/)، ما پشتیبانی از کارنامه‌های خارجی را به‌عنوان منبع داده برای نمودارها پیاده‌سازی کردیم.
{{% /alert %}} 

### **ایجاد یک کارنامهٔ خارجی**
با استفاده از متدهای **`ReadWorkbookStream`** و **`SetExternalWorkbook`** می‌توانید یا یک کارنامهٔ خارجی را از ابتدا ایجاد کنید یا یک کارنامهٔ داخلی را به‌صورت خارجی تبدیل کنید.

این کد C# فرآیند ایجاد کارنامهٔ خارجی را نشان می‌دهد:

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

### **تنظیم یک کارنامهٔ خارجی**
با استفاده از متد **`SetExternalWorkbook`** می‌توانید یک کارنامهٔ خارجی را به یک نمودار به‌عنوان منبع دادهٔ آن اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کارنامهٔ خارجی (در صورت انتقال آن) استفاده شود.

در حالی که نمی‌توانید داده‌های موجود در کارنامه‌های ذخیره‌شده در مکان‌های دوردست یا منابع را ویرایش کنید، همچنان می‌توانید از چنین کارنامه‌هایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای یک کارنامهٔ خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این کد C# نشان می‌دهد چگونه یک کارنامهٔ خارجی تنظیم کنید:

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

پارامتر `ChartData` (در زیر متد `SetExternalWorkbook`) برای تعیین این‌که آیا یک کارنامهٔ اکسل بارگذاری شود یا خیر، استفاده می‌شود. 

* وقتی مقدار `ChartData` به `false` تنظیم شود، فقط مسیر کارنامه به‌روز می‌شود—داده‌های نمودار بارگذاری یا به‌روز نمی‌شوند. می‌توانید این تنظیم را زمانی استفاده کنید که کارنامه هدف وجود نداشته باشد یا در دسترس نباشد.  
* وقتی مقدار `ChartData` به `true` تنظیم شود، داده‌های نمودار از کارنامه هدف به‌روز می‌شوند.

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

### **دریافت مسیر کارنامهٔ منبع دادهٔ خارجی یک نمودار**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. شیء برای شکل نمودار ایجاد کنید.  
1. شیء برای نوع منبع (`ChartDataSourceType`) که نمایانگر منبع دادهٔ نمودار است ایجاد کنید.  
1. شرایط مرتبط را بر اساس اینکه نوع منبع همان نوع منبع دادهٔ کارنامهٔ خارجی باشد، مشخص کنید.

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
می‌توانید داده‌های کارنامه‌های خارجی را همان‌گونه که داده‌های کارنامه‌های داخلی را ویرایش می‌کنید، تغییر دهید. وقتی یک کارنامهٔ خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این کد C# پیاده‌سازی فرآیند توصیف‌شده را نشان می‌دهد:

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

### **بازآوری یک کارنامه از کش نمودار**
اگر یک نمودار از کارنامهٔ خارجی استفاده کند که فقدان یا در دسترس نباشد، Aspose.Slides می‌تواند کارنامهٔ نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/) ایجاد کنید، [SpreadsheetOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/spreadsheetoptions/) آن را پیکربندی کنید و [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) را قبل از باز کردن ارائه به `true` تنظیم کنید.

مثال C# زیر ارائه‌ای را باز می‌کند که نمودار آن به یک کارنامهٔ خارجی ناموجود اشاره دارد و داده‌های بازیابی‌شده را از طریق [IChart.ChartData](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/chartdata/) و [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/chartdataworkbook/) دسترسی می‌دهد:

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

اگر کارنامهٔ خارجی در دسترس نباشد و بازآوری غیرفعال باشد، Aspose.Slides یک `InvalidOperationException` پرتاب می‌کند. بازآوری را فقط زمانی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ پذیرش‌پذیر باشد، زیرا کش ممکن است شامل تغییرات اعمال‌شده به کارنامهٔ خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **سوالات متداول**
**آیا می‌توانم تعیین کنم که آیا یک نمودار خاص به یک کارنامهٔ خارجی یا توکار پیوند دارد؟**  
بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/datasourcetype/) و [مسیر به یک کارنامهٔ خارجی](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/externalworkbookpath/) است؛ اگر منبع یک کارنامهٔ خارجی باشد، می‌توانید مسیر کامل را بخوانید تا اطمینان حاصل کنید که یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کارنامه‌های خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این برای قابلیت حمل پروژه مفید است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کارنامه‌هایی که در منابع/اشتراک‌های شبکه قرار دارند استفاده کنم؟**  
بله، چنین کارنامه‌هایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کارنامه‌های راه دور از Aspose.Slides پشتیبانی نمی‌شود—آن‌ها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**  
خیر. ارائه یک [پیوند به فایل خارجی](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/externalworkbookpath/) ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیرهٔ ارائه تغییر نمی‌کند.

**اگر فایل خارجی دارای رمز عبور باشد چه باید کنم؟**  
Aspose.Slides هنگام پیوند گرفتن رمز عبور را قبول نمی‌کند. رویکرد معمول این است که پیش از استفاده حفاظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (به‌عنوان مثال با استفاده از [Aspose.Cells](/cells/net/)) تهیه کنید و به آن نسخه پیوند دهید.

**آیا چندین نمودار می‌توانند به یک کارنامهٔ خارجی اشاره کنند؟**  
بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار در بارگذاری بعدی داده‌ها منعکس می‌شود.
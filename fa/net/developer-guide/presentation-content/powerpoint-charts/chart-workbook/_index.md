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
description: "Aspose.Slides برای .NET را کشف کنید: به سادگی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائهٔ خود را بهبود بخشید."
---
## **بررسی کلی**

این مقاله نحوه کار با کتاب‌کارهای نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه می‌توان داده‌های نمودار را از طریق جریان‌های کتاب‌کار خواند و نوشت، از سلول‌های کتاب‌کار به عنوان برچسب داده‌های نمودار استفاده کرد، به مجموعه‌های کاربرگ دسترسی یافت و نوع منبع داده برای مقادیر نمودار را مشخص کرد.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داده شود، مسیر کتاب‌کار خارجی مرتبط با یک نمودار بازیابی شود و داده‌های نمودار وقتی کتاب‌کار موجود باشد ویرایش گردد.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**
Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که به شما اجازه می‌دهد داده‌های کتاب‌کارهای نمودار (متضمن داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این کد C# یک عملیات نمونه را نشان می‌دهد:

```c#
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

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب دادهٔ نمودار**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.  
1. از طریق ایندکس، به اسلاید مورد نظر دسترسی پیدا کنید.  
1. یک نمودار حبابی (Bubble) با برخی داده‌ها اضافه کنید.  
1. به سری‌های نمودار دسترسی پیدا کنید.  
1. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.  
1. ارائه را ذخیره کنید.

این کد C# نحوه تنظیم سلول کتاب‌کار به عنوان برچسب دادهٔ نمودار را نشان می‌دهد:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// یک نمونه از کلاس Presentation می‌سازد که فایل ارائه را نشان می‌دهد
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

این کد C# عملی را نشان می‌دهد که در آن ویژگی [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) برای دسترسی به مجموعهٔ کاربرگ‌ها استفاده می‌شود:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **مشخص‌کردن نوع منبع داده**

این کد C# نحوهٔ مشخص‌کردن نوع برای منبع داده را نشان می‌دهد:

```c#
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

Aspose.Slides از قالب کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها توکار باشد، پشتیبانی نمی‌کند. می‌توانید با استفاده از ویژگی `EmbeddedWorkbookType` در [IChartData](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/) همراه با شمارش‌گر [WorkbookType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/workbooktype/) قالب‌های پشتیبانی‌نشده را شناسایی و آن نمودارها را نادیده بگیرید.

```csharp
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

        // در اینجا می‌توانید داده‌های کتاب‌کار نمودار را بخوانید یا تغییر دهید.
    }
}
```

## **کتاب‌کار خارجی**

{{% alert color="primary" %}} 
در [Aspose.Slides 19.4](https://docs.aspose.com/slides/fa/net/aspose-slides-for-net-19-4-release-notes/) پشتیبانی از کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها پیاده‌سازی شد.
{{% /alert %}} 

### **ایجاد یک کتاب‌کار خارجی**
با استفاده از متدهای **`ReadWorkbookStream`** و **`SetExternalWorkbook`** می‌توانید یا یک کتاب‌کار خارجی را از ابتدا ایجاد کنید یا یک کتاب‌کار داخلی را به‌صورت خارجی درآورید.

این کد C# فرآیند ایجاد کتاب‌کار خارجی را نشان می‌دهد:

```c#
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
با استفاده از متد **`SetExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به‌عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد همچنین می‌تواند مسیر کتاب‌کار خارجی را به‌روز کند (اگر کتاب‌کار جابه‌جا شده باشد).

در حالی که نمی‌توانید داده‌ها را در کتاب‌کارهایی که در مکان‌های راه دور یا منابع ذخیره شده‌اند، ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

این کد C# نشان می‌دهد چگونه یک کتاب‌کار خارجی تنظیم شود:

```c#
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

پارامتر `ChartData` (در زیر متد `SetExternalWorkbook`) برای مشخص کردن این که آیا یک کتاب‌کار Excel بارگذاری شود یا نه استفاده می‌شود.

* وقتی مقدار `ChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روز می‌شود—داده‌های نمودار بارگذاری یا به‌روز نمی‌شوند. این تنظیم وقتی مفید است که کتاب‌کار هدف موجود یا در دسترس نباشد.  
* وقتی مقدار `ChartData` برابر `true` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روز می‌شوند.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **به‌دست آوردن مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.  
1. از طریق ایندکس، به اسلاید دسترسی پیدا کنید.  
1. یک شیء برای شکل نمودار ایجاد کنید.  
1. یک شیء برای نوع منبع (`ChartDataSourceType`) که نمایانگر منبع دادهٔ نمودار است، ایجاد کنید.  
1. شرط مربوطه را بر پایهٔ هم‌خوانی نوع منبع با نوع منبع دادهٔ کتاب‌کار خارجی مشخص کنید.

این کد C# عملیات را نشان می‌دهد:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // نمایش را ذخیره می‌کند
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **ویرایش دادهٔ نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همانند کتاب‌کارهای داخلی ویرایش کنید. وقتی کتاب‌کار خارجی بارگذاری نشود، یک استثنا پرتاب می‌شود.

این کد C# پیاده‌سازی فرایند توضیح داده‌شده را ارائه می‌دهد:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **بازیابی کتاب‌کار از حافظهٔ کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی استفاده کند که گم شده یا در دسترس نباشد، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/) ایجاد کنید، ‎[SpreadsheetOptions](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/spreadsheetoptions/) آن را پیکربندی کنید و قبل از باز کردن ارائه مقدار ‎[ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) را بر روی `true` تنظیم کنید.

مثال زیر C# ارائه‌ای را باز می‌کند که نمودار آن به کتاب‌کار خارجی ناموجود اشاره دارد و داده‌های بازیابی‌شده را از طریق [IChart.ChartData](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichart/chartdata/) و [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/chartdataworkbook/) دسترسی می‌گیرد:

```csharp
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

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک `InvalidOperationException` پرتاب می‌کند. فقط زمانی بازیابی را فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ قابل قبول باشد، چون ممکن است کش تغییرات انجام‌شده در کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه را نداشته باشد.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم یک نمودار خاص به کتاب‌کار خارجی یا توکار پیوند دارد؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/datasourcetype/) و [path to an external workbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/externalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را خوانده و مطمئن شوید که فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این ویژگی برای قابل حمل بودن پروژه مفید است؛ هرچند توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهایی که در منابع شبکه/اشتراک‌ها قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای راه دور از طریق Aspose.Slides پشتیبانی نمی‌شود—فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/externalworkbookpath/) نگه می‌دارد و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیرهٔ ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شود چه کاری باید انجام دهم؟**

Aspose.Slides هنگام ایجاد پیوند رمز عبور را قبول نمی‌کند. روش معمول این است که پیش از استفاده محافظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](/cells/net/)) تهیه کنید و به آن نسخه پیوند دهید.

**آیا می‌توان چندین نمودار را به همان کتاب‌کار خارجی ارجاع داد؟**

بله. هر نمودار لینک خود را حفظ می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار دفعهٔ بعدی که داده‌ها بارگذاری شوند، منعکس می‌شود.
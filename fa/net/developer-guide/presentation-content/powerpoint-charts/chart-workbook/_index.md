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
- داده‌های خارجی
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides برای .NET را کشف کنید: به سادگی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **بررسی کلی**

این مقاله نحوه کار با کارکت‌های نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب کار خوانده و نوشت، از سلول‌های کتاب کار به‌عنوان برچسب‌های داده نمودار استفاده کرد، به مجموعه‌های کاربرگ دسترسی یافت و نوع منبع داده برای مقادیر نمودار را مشخص کرد.

همچنین کار با کتاب‌های کار خارجی به‌عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب کار خارجی را ایجاد و اختصاص داد، مسیر کتاب کار خارجی مرتبط با یک نمودار را دریافت کرد و داده‌های نمودار را زمانی که کتاب کار در دسترس است ویرایش کرد.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب کار**

Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/writeworkbookstream/) را ارائه می‌دهد که امکان خواندن و نوشتن کتاب کارهای داده‌های نمودار (شامل داده‌های نمودار ویرایش‌شده با Aspose.Cells) را فراهم می‌کند. **نکته** که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

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

## **تنظیم یک سلول کتاب کار به عنوان برچسب داده نمودار**
1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.
1. یک نمودار حبابی با برخی داده‌ها اضافه کنید.
1. به سری‌های نمودار دسترسی پیدا کنید.
1. سلول کتاب کار را به‌عنوان برچسب داده تنظیم کنید.
1. ارائه را ذخیره کنید.

این کد C# به شما نشان می‌دهد چگونه یک سلول کتاب کار را به عنوان برچسب داده نمودار تنظیم کنید:
```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// یک شی از کلاس Presentation که نمایانگر یک فایل ارائه است ایجاد می‌کند 
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

این کد C# یک عملیات را نشان می‌دهد که در آن ویژگی [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) برای دسترسی به مجموعه کاربرگ‌ها استفاده می‌شود:
``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **مشخص کردن نوع منبع داده**

این کد C# نحوه مشخص کردن نوع برای منبع داده را نشان می‌دهد:
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

## **تشخیص قالب‌های پشتیبانی‌نشده کتاب کار توکار**

Aspose.Slides از قالب کتاب کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها توکار باشد، پشتیبانی نمی‌کند. می‌توانید از ویژگی `EmbeddedWorkbookType` در [IChartData](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdata/) به همراه enumeration [WorkbookType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/workbooktype/) برای تشخیص قالب‌های پشتیبانی‌نشده استفاده کنید و آن نمودارها را نادیده بگیرید.
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
            // دفتر کار توکار در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue;
        }

        // داده‌های دفتر کار نمودار را در اینجا بخوانید یا تغییر دهید.
    }
}
```

## **کتاب کار خارجی**

{{% alert color="primary" %}} 
در [Aspose.Slides 19.4](https://docs.aspose.com/slides/fa/net/aspose-slides-for-net-19-4-release-notes/)، ما پشتیبانی از کتاب‌های کار خارجی به‌عنوان منبع داده برای نمودارها را پیاده‌سازی کردیم.
{{% /alert %}} 

### **ایجاد یک کتاب کار خارجی**
با استفاده از متدهای **`ReadWorkbookStream`** و **`SetExternalWorkbook`** می‌توانید یک کتاب کار خارجی را از ابتدا ایجاد کنید یا یک کتاب کار داخلی را به‌صورت خارجی تبدیل کنید.

این کد C# فرآیند ایجاد کتاب کار خارجی را نشان می‌دهد:
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

### **تنظیم یک کتاب کار خارجی**
با استفاده از متد **`SetExternalWorkbook`** می‌توانید یک کتاب کار خارجی را به عنوان منبع داده یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب کار خارجی استفاده شود (اگر کتاب کار جابجا شده باشد).

اگرچه نمی‌توانید داده‌های موجود در کتاب‌های کاری که در مکان‌ها یا منابع از راه دور ذخیره شده‌اند را ویرایش کنید، همچنان می‌توانید از این کتاب‌های کار به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای کتاب کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این کد C# نشان می‌دهد چگونه یک کتاب کار خارجی را تنظیم کنید:
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

پارامتر `ChartData` (در زیر متد `SetExternalWorkbook`) برای مشخص کردن این که آیا کتاب کار اکسل بارگذاری شود یا نه استفاده می‌شود. 

* هنگامی که مقدار `ChartData` به `false` تنظیم شود، فقط مسیر کتاب کار به‌روز می‌شود—داده‌های نمودار از کتاب کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند. می‌توانید از این تنظیم در شرایطی که کتاب کار هدف وجود نداشته یا در دسترس نباشد، استفاده کنید. 
* هنگامی که مقدار `ChartData` به `true` تنظیم شود، داده‌های نمودار از کتاب کار هدف به‌روزرسانی می‌شوند.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **دریافت مسیر کتاب کار منبع داده خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.
1. یک شی برای شکل نمودار ایجاد کنید.
1. یک شی برای نوع منبع (`ChartDataSourceType`) که نمایانگر منبع داده نمودار است، ایجاد کنید.
1. شرط مرتبط را بر اساس این‌که نوع منبع با نوع منبع داده کتاب کار خارجی یکسان باشد، مشخص کنید.

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
    
    // ارائه را ذخیره می‌کند
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های موجود در کتاب‌های کار خارجی را همانند تغییر محتویات کتاب‌های کار داخلی ویرایش کنید. هنگامی که یک کتاب کار خارجی قابل بارگذاری نباشد، یک استثنا صادر می‌شود.

این کد C# پیاده‌سازی فرآیند توصیف‌شده است:
```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به یک کتاب کار خارجی یا توکار لینک شده است؟**

بله. یک نمودار دارای یک [نوع منبع داده](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/datasourcetype/) و یک [مسیر به کتاب کار خارجی](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/externalworkbookpath/) است؛ اگر منبع یک کتاب کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا اطمینان حاصل کنید که از یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌های کار خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این برای قابلیت حمل پروژه مناسب است؛ اما لازم است بدانید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌های کاری که در منابع/به‌اشتراک‌گذاری‌های شبکه‌ای قرار دارند استفاده کنم؟**

بله، چنین کتاب‌های کاری می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. اما ویرایش کتاب‌های کاری از راه دور به‌صورت مستقیم از Aspose.Slides پشتیبانی نمی‌شود—آنها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/chartdata/externalworkbookpath/) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. خود فایل خارجی هنگام ذخیره ارائه تغییر نمی‌کند.

**در صورتی که فایل خارجی با رمز محافظت شده باشد، چه کاری باید انجام دهم؟**

Aspose.Slides هنگام لینک کردن از رمز عبور پشتیبانی نمی‌کند. یک رویکرد رایج این است که پیش از آن محافظت را حذف کنید یا یک نسخه رمزگشایی‌شده تهیه کنید (برای مثال با استفاده از [Aspose.Cells](/cells/net/)) و به آن نسخه لینک کنید.

**آیا می‌توان چندین نمودار به یک کتاب کار خارجی ارجاع داد؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار بازتاب خواهد یافت.
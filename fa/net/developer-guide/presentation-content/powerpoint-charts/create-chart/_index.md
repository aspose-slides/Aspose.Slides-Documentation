---
title: ایجاد یا به‌روزرسانی نمودارهای ارائه PowerPoint در .NET
linktitle: ایجاد یا به‌روزرسانی نمودارها
type: docs
weight: 10
url: /fa/net/create-chart/
keywords:
- افزودن نمودار
- ایجاد نمودار
- ویرایش نمودار
- تغییر نمودار
- به‌روزرسانی نمودار
- نمودار پراکنده
- نمودار دایره‌ای
- نمودار خطی
- نمودار درخت‌نقشه
- نمودار سهام
- نمودار جعبه‌ای و ویسکر
- نمودار قیفی
- نمودار خورشیدی
- نمودار هیستوگرام
- نمودار راداری
- نمودار چنددسته‌ای
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارها در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای .NET. افزودن، قالب‌بندی و ویرایش نمودارها با مثال‌های عملی کد در C#."
---
## **نمای کلی**

این مقاله راهنمای کاملی را در مورد چگونگی ایجاد و سفارشی‌سازی نمودارها با استفاده از Aspose.Slides برای .NET فراهم می‌کند. شما یاد می‌گیرید که چگونه به‌صورت برنامه‌نویسی یک نمودار را به اسلاید اضافه کنید، آن را با داده‌ها پر کنید و گزینه‌های قالب‌بندی مختلف را برای مطابقت با الزامات طراحی خود اعمال کنید. در طول مقاله، مثال‌های کد دقیق هر گام را نشان می‌دهند، از مقداردهی اولیه به ارائه و شی نمودار تا تنظیم سری‌ها، محورها و افسانه‌ها. با پیروی از این راهنما، درک محکمی از چگونگی یک‌پارچه‌سازی تولید دینامیک نمودار در برنامه‌های .NET خود به دست می‌آورید و فرآیند ایجاد ارائه‌های مبتنی بر داده را ساده می‌کنید.

## **ایجاد یک نمودار**

نمودارها به افراد کمک می‌کنند تا به سرعت داده‌ها را بصری‌سازی کنند و بینش‌هایی به دست آورند که ممکن است از یک جدول یا صفحه‌گسترده به‌راحتی آشکار نباشد.

**چرا نمودارها را ایجاد کنیم؟**

* تجمیع، فشرده‌سازی یا خلاصه‌سازی مقدار زیادی داده در یک اسلاید از یک ارائه؛  
* نمایش الگوها و روندهای داده؛  
* استنتاج جهت و شتاب داده‌ها در طول زمان یا نسبت به یک واحد اندازه‌گیری خاص؛  
* شناسایی نقاط دورافتاده، ناهنجاری‌ها، انحرافات، خطاها و داده‌های نامعقول؛  
* ارتباط یا ارائه داده‌های پیچیده.

در PowerPoint می‌توانید نمودارها را از طریق عملکرد *Insert* ایجاد کنید که قالب‌هایی برای طراحی انواع مختلف نمودارها فراهم می‌کند. با استفاده از Aspose.Slides می‌توانید هم نمودارهای معمولی (بر پایه انواع محبوب نمودار) و هم نمودارهای سفارشی ایجاد کنید.

{{% alert color="primary" %}} 
از شمارش‌گر [ChartType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/charttype/) تحت فضای نام [Aspose.Slides.Charts](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/) استفاده کنید. مقادیر این شمارش‌گر به انواع مختلف نمودارها مربوط می‌شوند.
{{% /alert %}} 

### **ایجاد نمودارهای ستونی خوشه‌ای**

این بخش توضیح می‌دهد چگونه با Aspose.Slides برای .NET نمودارهای ستونی خوشه‌ای ایجاد کنید. خواهید آموخت که چگونه یک ارائه را مقداردهی اولیه کنید، یک نمودار اضافه کنید و عناصر آن مانند عنوان، داده‌ها، سری‌ها، دسته‌ها و استایل را سفارشی کنید. مراحل زیر را دنبال کنید تا ببینید یک نمودار ستونی خوشه‌ای استاندارد چگونه تولید می‌شود:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شاخص آن، به یک اسلاید دسترسی پیدا کنید.  
1. یک نمودار با داده‌های اولیه اضافه کنید و نوع `ChartType.ClusteredColumn` را مشخص کنید.  
1. یک عنوان به نمودار اضافه کنید.  
1. به ورق داده‌های نمودار دسترسی پیدا کنید.  
1. تمام سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. یک رنگ پر برای سری‌های نمودار اعمال کنید.  
1. برچسب‌ها را به سری‌های نمودار اضافه کنید.  
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نحوه ایجاد یک نمودار ستونی خوشه‌ای را نشان می‌دهد:

```c#
// نمونه‌سازی کلاس Presentation.
using (Presentation presentation = new Presentation())
{
    // دسترسی به اولین اسلاید.
    ISlide slide = presentation.Slides[0];

    // افزودن یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض آن.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // تنظیم عنوان نمودار.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // تنظیم نمایش مقادیر برای اولین سری.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // تنظیم ایندکس ورق داده‌های نمودار.
    int worksheetIndex = 0;

    // دریافت کتاب‌کار داده‌های نمودار.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // حذف سری‌ها و دسته‌های پیش‌فرض ایجاد شده.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // افزودن سری‌های جدید.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // افزودن دسته‌های جدید.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // دریافت اولین سری نمودار.
    IChartSeries series = chart.ChartData.Series[0];

    // پرکردن داده‌های سری.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // تنظیم رنگ پر کردن برای سری.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // دریافت دومین سری نمودار.
    series = chart.ChartData.Series[1];

    // پرکردن داده‌های سری.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // تنظیم رنگ پر کردن برای سری.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // تنظیم اولین برچسب برای نمایش نام دسته.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // تنظیم سری برای نمایش مقدار در برچسب سوم.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // ذخیره ارائه به‌صورت فایل PPTX روی دیسک.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار ستونی خوشه‌ای](clustered_column_chart.png)

### **ایجاد نمودارهای پراکنده**

نمودارهای پراکنده (که به عنوان scatter plot یا نمودارهای x‑y نیز شناخته می‌شوند) معمولاً برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر استفاده می‌شوند.

از نمودار پراکنده زمانی استفاده کنید که:

* داده‌های عددی جفت‌شده داشته باشید.  
* دو متغیر داشته باشید که به‌خوبی با هم جفت می‌شوند.  
* بخواهید تعیین کنید آیا دو متغیر مرتبط هستند یا نه.  
* یک متغیر مستقل داشته باشید که برای یک متغیر وابسته مقادیر متعددی دارد.

این کد C# نشان می‌دهد چگونه یک نمودار پراکنده با مجموعه‌ای متفاوت از نشانگرها ایجاد کنید:

```c#
// نمونه‌سازی کلاس Presentation.
using (Presentation presentation = new Presentation())
{
    // دسترسی به اولین اسلاید.
    ISlide slide = presentation.Slides[0];

    // ایجاد نمودار پراکنده پیش‌فرض.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // تنظیم ایندکس ورق داده‌های نمودار.
    int worksheetIndex = 0;

    // دریافت کتاب‌کار داده‌های نمودار.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // حذف سری‌های پیش‌فرض.
    chart.ChartData.Series.Clear();

    // افزودن سری‌های جدید.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // دریافت اولین سری نمودار.
    IChartSeries series = chart.ChartData.Series[0];

    // افزودن یک نقطه جدید (1:3) به سری.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // افزودن یک نقطه جدید (2:10).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // تغییر نوع سری.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // تغییر نشانگر سری نمودار.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // دریافت دومین سری نمودار.
    series = chart.ChartData.Series[1];

    // افزودن یک نقطه جدید (5:2) به سری نمودار.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // افزودن یک نقطه جدید (3:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // افزودن یک نقطه جدید (2:2).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // افزودن یک نقطه جدید (5:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // تغییر نشانگر سری نمودار.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // ذخیره ارائه به‌صورت فایل PPTX روی دیسک.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار پراکنده](scatter_chart.png)

### **ایجاد نمودارهای دایره‌ای**

نمودارهای دایره‌ای بهترین استفاده را برای نشان دادن رابطه بخش‑به‑کل در داده‌ها دارند، به‌ویژه زمانی که داده‌ها شامل برچسب‌های طبقه‌ای با مقادیر عددی باشند. اگر داده‌های شما قسمت‌ها یا برچسب‌های زیادی داشته باشد، ممکن است بهتر باشد به‌جای آن از نمودار میله‌ای استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شاخص آن، به یک اسلاید دسترسی پیدا کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Pie` را مشخص کنید.  
1. به کتاب کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.  
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. نقاط جدید برای نمودار اضافه کنید و رنگ‌های سفارشی به بخش‌های نمودار دایره‌ای اعمال کنید.  
1. برچسب‌ها را برای سری‌ها تنظیم کنید.  
1. خطوط راهنما را برای برچسب‌های سری فعال کنید.  
1. زاویه چرخش را برای نمودار دایره‌ای تنظیم کنید.  
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار دایره‌ای ایجاد کنید:

```c#
// نمونه‌سازی کلاس Presentation.
using (Presentation presentation = new Presentation())
{
    // دسترسی به اولین اسلاید.
    ISlide slide = presentation.Slides[0];

    // اضافه‌کردن یک نمودار با داده‌های پیش‌فرض آن.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // تنظیم عنوان نمودار.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // تنظیم اولین سری برای نمایش مقادیر.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // تنظیم ایندکس ورق داده‌های نمودار.
    int worksheetIndex = 0;

    // دریافت کتاب‌کار داده‌های نمودار.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // حذف سری‌ها و دسته‌های پیش‌فرض تولید‌شده.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // افزودن دسته‌های جدید.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // افزودن سری‌های جدید.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // پرکردن داده‌های سری.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // تنظیم رنگ بخش.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // تنظیم حاشیه بخش.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // تنظیم حاشیه بخش.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // تنظیم حاشیه بخش.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // ایجاد برچسب‌های سفارشی برای هر دسته در سری جدید.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // تنظیم سری برای نمایش خطوط راهنما در نمودار.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // تنظیم زاویهٔ چرخش برای بخش‌های نمودار دایره‌ای.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // ذخیرهٔ ارائه به‌صورت فایل PPTX روی دیسک.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار دایره‌ای](pie_chart.png)

### **ایجاد نمودارهای خطی**

نمودارهای خطی (که به عنوان line graph نیز شناخته می‌شوند) بهترین استفاده را در مواقعی دارند که بخواهید تغییرات مقدار در طول زمان را نشان دهید. با استفاده از یک نمودار خطی می‌توانید مقدار زیادی داده را همزمان مقایسه کنید، تغییرات و روندها را در طول زمان ردیابی کنید، ناهنجاری‌ها را در سری داده‌ها برجسته کنید و غیره.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شاخص آن، به یک اسلاید دسترسی پیدا کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Line` را مشخص کنید.  
1. به کتاب کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.  
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نحوه ایجاد یک نمودار خطی را نشان می‌دهد:

```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

به‌صورت پیش‌فرض، نقاط در یک نمودار خطی با خطوط مستقیم پیوسته به‌هم وصل می‌شوند. اگر می‌خواهید نقاط با خط‌خط (dash) به‌هم وصل شوند، می‌توانید نوع dash دلخواه خود را به‌صورت زیر مشخص کنید:

```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

نتیجه:

![نمودار خطی](line_chart.png)

### **ایجاد نمودارهای درخت‌نقشه (Tree Map)**

نمودارهای درخت‌نقشه بهترین استفاده را برای داده‌های فروش دارند وقتی می‌خواهید اندازه نسبی دسته‌های داده را نشان دهید و به‌سرعت توجه را به آیتم‌های بزرگ‌سهم در هر دسته جلب کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شاخص آن، به یک اسلاید دسترسی پیدا کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Treemap` را مشخص کنید.  
1. به کتاب کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.  
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار درخت‌نقشه ایجاد کنید:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // شاخه 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // شاخه 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار درخت‌نقشه](treemap_chart.png)

### **ایجاد نمودارهای سهام (Stock)**

نمودارهای سهام برای نمایش داده‌های مالی مانند قیمت‌های باز، بالا، پایین و بسته استفاده می‌شوند و به تحلیل روندهای بازار و نوسان‌ها کمک می‌کنند. این نمودارها بینش‌های اساسی درباره عملکرد سهام ارائه می‌دهند و به سرمایه‌گذاران و تحلیل‌گران در اتخاذ تصمیمات آگاهانه کمک می‌کنند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شاخص آن، به یک اسلاید دسترسی پیدا کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.OpenHighLowClose` را مشخص کنید.  
1. به کتاب کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.  
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. قالب HiLowLines را مشخص کنید.  
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار سهام ایجاد کنید:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار سهام](stock_chart.png)

### **ایجاد نمودارهای جعبه‌ای و ویسکر (Box and Whisker)**

نمودارهای جعبه‌ای و ویسکر برای نمایش توزیع داده‌ها با خلاصه‌سازی معیارهای آماری کلیدی مانند میانه، چارک‌ها و نقاط دورافتاده استفاده می‌شوند. این نمودارها به ویژه در تحلیل‌های اکتشافی داده و مطالعات آماری برای درک سریع تغییرپذیری داده‌ها و شناسایی ناهنجاری‌ها مفید هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شاخص آن، به یک اسلاید دسترسی پیدا کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.BoxAndWhisker` را مشخص کنید.  
1. به کتاب کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.  
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار جعبه‌ای و ویسکر ایجاد کنید:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```

### **ایجاد نمودارهای قیفی (Funnel)**

نمودارهای قیفی برای تجسم فرآیندهایی که شامل مراحل متوالی هستند، به‌کار می‌روند؛ جایی که حجم داده‌ها با پیشرفت از یک گام به گام دیگر کاهش می‌یابد. این نمودارها برای تحلیل نرخ تبدیل، شناسایی گلوگاه‌ها و ردیابی کارایی فرآیندهای فروش یا بازاریابی بسیار مفیدند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شاخص آن، به یک اسلاید دسترسی پیدا کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Funnel` را مشخص کنید.  
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار قیفی ایجاد کنید:

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار قیفی](funnel_chart.png)

### **ایجاد نمودارهای خورشیدی (Sunburst)**

نمودارهای خورشیدی برای تجسم داده‌های سلسله‌مراتبی استفاده می‌شوند و سطوح را به‌صورت حلقه‌های متحدالمرکز نمایش می‌دهند. این نمودارها رابطه بخش‑به‑کل را نشان می‌دهند و برای ارائه دسته‌ها و زیرمجموعه‌های تو در تو در قالبی واضح و فشرده ایده‌آل‌اند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شاخص آن، به یک اسلاید دسترسی پیدا کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Sunburst` را مشخص کنید.  
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار خورشیدی ایجاد کنید:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // شاخه 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // شاخه 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار خورشیدی](sunburst_chart.png)

### **ایجاد نمودارهای هیستوگرام (Histogram)**

نمودارهای هیستوگرام برای نمایش توزیع داده‌های عددی با گروه‌بندی مقادیر در بازه‌ها یا سبدها (bins) استفاده می‌شوند. این نمودارها برای شناسایی الگوهای داده مانند فرکانس، قابلیت انحراف و پراکندگی و همچنین کشف نقاط دورافتاده در یک مجموعه داده مفیدند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شاخص آن، به یک اسلاید دسترسی پیدا کنید.  
1. یک نمودار با برخی داده‌ها اضافه کنید و نوع `ChartType.Histogram` را مشخص کنید.  
1. به کتاب کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.  
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار هیستوگرام ایجاد کنید:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار هیستوگرام](histogram_chart.png)

### **ایجاد نمودارهای راداری (Radar)**

نمودارهای راداری برای نمایش داده‌های چندمتغیره در قالب دو‑بعدی استفاده می‌شوند و امکان مقایسه همزمان چندین متغیر را فراهم می‌کنند. این نمودارها برای شناسایی الگوها، نقاط قوت و ضعف در میان مجموعه‌ای از معیارها یا ویژگی‌ها مفیدند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شاخص آن، به یک اسلاید دسترسی پیدا کنید.  
1. یک نمودار با برخی داده‌ها اضافه کنید و نوع `ChartType.Radar` را مشخص کنید.  
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار راداری ایجاد کنید:

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار راداری](radar_chart.png)

### **ایجاد نمودارهای چنددسته‌ای (Multi‑Category)**

نمودارهای چنددسته‌ای برای نمایش داده‌هایی که شامل بیش از یک گروه‌بندی طبقه‌ای هستند استفاده می‌شوند و امکان مقایسه مقادیر در چند بُعد را به‌صورت همزمان فراهم می‌کنند. این نمودارها زمانی مفیدند که بخواهید روندها و روابط در مجموعه داده‌های پیچیده و چندلایه را تحلیل کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شاخص آن، به یک اسلاید دسترسی پیدا کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.ClusteredColumn` را مشخص کنید.  
1. به کتاب کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.  
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار چنددسته‌ای ایجاد کنید:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // افزودن یک سری.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // ذخیره ارائه با نمودار.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار چنددسته‌ای](multi_category_chart.png)

### **ایجاد نمودارهای نقشه‌ای (Map)**

نمودارهای نقشه‌ای برای تجسم داده‌های جغرافیایی با نقشه‌برداری اطلاعات به مکان‌های خاص مانند کشورها، ایالت‌ها یا شهرها استفاده می‌شوند. این نمودارها برای تحلیل روندهای منطقه‌ای، داده‌های جمعیتی و توزیع‌های فضایی به‌صورت واضح و بصری مؤثرند.

این کد C# نشان می‌دهد چگونه یک نمودار نقشه‌ای ایجاد کنید:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار نقشه‌ای](map_chart.png)

### **ایجاد نمودارهای ترکیبی (Combination)**

یک نمودار ترکیبی (یا combo chart) دو یا چند نوع نمودار را در یک گراف یکپارچه می‌کند. این نمودار به شما امکان می‌دهد تا تفاوت‌ها یا روابط بین دو یا چند مجموعه داده را برجسته، مقایسه یا بررسی کنید.

![نمودار ترکیبی](combination_chart.png)

کد C# زیر نشان می‌دهد چگونه نمودار ترکیبی نشان داده‌شده در بالا را در یک ارائه PowerPoint ایجاد کنید:

```c#
private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // عنوان نمودار را تنظیم می‌کند
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // راهنما (Legend) نمودار را تنظیم می‌کند
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف می‌کند
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // دسته‌های جدید را اضافه می‌کند
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // افزودن سری اول
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // محور افقی را تنظیم می‌کند
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // محور عمودی را تنظیم می‌کند
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // رنگ خطوط شبکه اصلی (major) عمودی را تنظیم می‌کند
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // محور افقی ثانویه را تنظیم می‌کند
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // محور عمودی ثانویه را تنظیم می‌کند
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **به‌روزرسانی نمودارها**

Aspose.Slides برای .NET به شما امکان می‌دهد نمودارهای PowerPoint را با اصلاح داده‌های نمودار، قالب‌بندی و استایل به‌روز کنید. این قابلیت فرآیند نگه‌داری به‌روز ارائه‌ها با محتوای دینامیک را ساده می‌کند و اطمینان می‌دهد که نمودارها به‌درستی داده‌ها و استانداردهای بصری جاری را منعکس می‌کنند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) که نمایانگر ارائه حاوی نمودار است، ایجاد کنید.  
1. با استفاده از شاخص آن، به یک اسلاید دسترسی پیدا کنید.  
1. تمام اشکال را پیمایش کنید تا نمودار را پیدا کنید.  
1. به ورق داده‌های نمودار دسترسی پیدا کنید.  
1. سری‌های داده‌ای نمودار را با تغییر مقادیر سری‌ها اصلاح کنید.  
1. یک سری جدید اضافه کنید و داده‌های آن را پر کنید.  
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار را به‌روز کنید:

```c#
const string chartName = "My chart";

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // دسترسی به اولین اسلاید.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // تنظیم ایندکس ورق داده‌های نمودار.
            int worksheetIndex = 0;

            // دریافت کتاب‌کار داده‌های نمودار.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // تغییر نام دسته‌های نمودار.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // دریافت اولین سری نمودار.
            IChartSeries series = chart.ChartData.Series[0];

            // به‌روزرسانی داده‌های سری.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // در حال تغییر نام سری.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // دریافت دومین سری نمودار.
            series = chart.ChartData.Series[1];

            // به‌روزرسانی داده‌های سری.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // در حال تغییر نام سری.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // افزودن یک سری جدید.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // پرکردن داده‌های سری.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // ذخیره ارائه همراه با نمودار.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **تنظیم محدوده داده برای نمودار**

Aspose.Slides برای .NET انعطاف‌پذیری تعریف یک محدوده داده خاص از یک ورق کاری را به‌عنوان منبع برای داده‌های نمودار شما فراهم می‌کند. به این معنی که می‌توانید بخشی از ورق کاری خود را مستقیماً به نمودار نگاشت کنید و کنترل کنید که کدام سلول‌ها به سری‌ها و دسته‌های نمودار کمک می‌کنند. در نتیجه می‌توانید به‌راحتی نمودارهای خود را با آخرین تغییرات داده در ورق کاری همگام‌سازی کنید و اطمینان حاصل کنید که ارائه‌های PowerPoint شما اطلاعات جاری و دقیق را منعکس می‌نمایند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) که نمایانگر ارائه حاوی نمودار است، ایجاد کنید.  
1. با استفاده از شاخص آن، به یک اسلاید دسترسی پیدا کنید.  
1. تمام اشکال را پیمایش کنید تا نمودار را پیدا کنید.  
1. داده‌های نمودار را دسترسی پیدا کنید و محدوده را تنظیم کنید.  
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه محدوده داده برای یک نمودار تنظیم شود:

```c#
const string chartName = "My chart";

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PPTX است.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // دسترسی به اولین اسلاید.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **استفاده از نشانگرهای پیش‌فرض در نمودارها**

هنگامی که از نشانگرهای پیش‌فرض در نمودارها استفاده می‌کنید، به‌صورت خودکار به هر سری نمودار یک نماد نشانگر پیش‌فرض متفاوت اختصاص می‌یابد.

این کد C# نشان می‌دهد چگونه یک نشانگر سری نمودار به‌صورت خودکار تنظیم شود:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // پر کردن داده‌های سری.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **سؤال‌های متداول**

**کدام نوع نمودارها توسط Aspose.Slides برای .NET پشتیبانی می‌شوند؟**

Aspose.Slides برای .NET طیف وسیعی از انواع نمودارها را پشتیبانی می‌کند، از جمله میله‌ای، خطی، دایره‌ای، ناحیه‌ای، پراکنده، هیستوگرام، راداری و بسیاری دیگر. این انعطاف‌پذیری به شما اجازه می‌دهد تا مناسب‌ترین نوع نمودار را برای نیازهای تجسم داده خود انتخاب کنید.

**چگونه یک نمودار جدید به اسلاید اضافه کنم؟**

برای اضافه کردن یک نمودار، ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد می‌کنید، اسلاید موردنظر را با استفاده از شاخص آن بازیابی می‌کنید و سپس متد افزودن نمودار را صدا می‌زنید، نوع نمودار و داده‌های اولیه را مشخص می‌کنید. این فرآیند نمودار را مستقیماً در ارائه شما ادغام می‌کند.

**چگونه می‌توان داده‌های نمایش داده شده در یک نمودار را به‌روز کرد؟**

می‌توانید داده‌های یک نمودار را با دسترسی به کتاب کار داده‌های آن ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/))، پاک‌سازی سری‌ها و دسته‌های پیش‌فرض و سپس افزودن داده‌های سفارشی خود به‌روزرسانی کنید. این امکان را می‌دهد تا نمودار را برنامه‌نویسی و بازآفرینی کنید تا جدیدترین داده‌ها را منعکس کند.

**آیا امکان سفارشی‌سازی ظاهر نمودار وجود دارد؟**

بله، Aspose.Slides برای .NET گزینه‌های سفارشی‌سازی گسترده‌ای ارائه می‌دهد. می‌توانید رنگ‌ها، قلم‌ها، برچسب‌ها، افسانه‌ها و سایر عناصر قالب‌بندی را برای تنظیم ظاهر نمودار مطابق با الزامات طراحی خاص خود تغییر دهید.
---
title: ایجاد یا به روزرسانی نمودارهای ارائه PowerPoint در .NET
linktitle: ایجاد یا به روزرسانی نمودارها
type: docs
weight: 10
url: /fa/net/create-chart/
keywords:
- افزودن نمودار
- ایجاد نمودار
- ویرایش نمودار
- تغییر نمودار
- به روزرسانی نمودار
- نمودار پراکنده
- نمودار دایره‌ای
- نمودار خطی
- نمودار درخت نقشه‌ای
- نمودار سهام
- نمودار جعبه ای و ویسکر
- نمودار قیفی
- نمودار خورشیدگرد
- نمودار هیستوگرام
- نمودار رادار
- نمودار چند دسته‌ای
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارها در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای .NET. افزودن، قالب‌بندی و ویرایش نمودارها با مثال‌های کد عملی در C#."
---
## **بررسی کلی**

این مقاله راهنمای جامع ایجاد و سفارشی‌سازی نمودارها با Aspose.Slides برای .NET را ارائه می‌دهد. شما می‌آموزید چگونه به‌صورت برنامه‌نویسی یک نمودار را به اسلاید اضافه کنید، آن را با داده‌ها پر کنید و گزینه‌های قالب‌بندی مختلف را برای مطابقت با نیازهای طراحی خود اعمال کنید. در طول مقاله، مثال‌های کد دقیق هر مرحله را نشان می‌دهند؛ از مقداردهی اولیه ارائه و شیء نمودار تا پیکربندی سری‌ها، محورها و افسانه‌ها. با دنبال کردن این راهنما، درک جامعی از ادغام تولید دینامیک نمودار در برنامه‌های .NET خود به دست می‌آورید و فرآیند ایجاد ارائه‌های مبتنی بر داده را به‌صورت کارآمدی ساده می‌کنید.

## **ایجاد نمودار**

نمودارها به افراد کمک می‌کنند تا داده‌ها را به‌سرعت تجسم کنند و بینش‌هایی به‌دست آورند که ممکن است از جدول یا صفحه‌گسترده بلافاصله آشکار نباشد.

**چرا نمودارهایی ایجاد کنیم؟**

با استفاده از نمودارها می‌توانید:

* حجم زیادی از داده‌ها را در یک اسلاید جمع‌آوری، فشرده یا خلاصه کنید؛
* الگوها و روندهای داده را آشکار کنید؛
* جهت و شتاب داده‌ها را در طول زمان یا نسبت به یک واحد اندازه‌گیری خاص استنتاج کنید؛
* نقاط دورافتاده، انحرافات، خطاها و داده‌های نامعقول را شناسایی کنید؛
* داده‌های پیچیده را ارتباط برقرار کنید یا ارائه دهید.

در PowerPoint می‌توانید نمودارها را از طریق عملکرد *Insert* ایجاد کنید؛ این قابلیت الگوهایی برای طراحی انواع مختلف نمودارها فراهم می‌کند. با Aspose.Slides می‌توانید هم نمودارهای معمولی (بر پایه انواع محبوب) و هم نمودارهای سفارشی ایجاد کنید.

{{% alert color="info" %}} 
از شمارش‌گر [ChartType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/charttype/) در فضای نام [Aspose.Slides.Charts](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/) استفاده کنید. مقادیر این شمارش‌گر متناظر با انواع مختلف نمودار هستند. 
{{% /alert %}} 

### **ایجاد نمودارهای ستونی خوشه‌ای**

این بخش نحوه ایجاد نمودارهای ستونی خوشه‌ای با Aspose.Slides برای .NET را توضیح می‌دهد. شما یاد می‌گیرید چگونه یک ارائه را مقداردهی اولیه کنید، یک نمودار اضافه کنید و عناصر آن مانند عنوان، داده، سری، دسته‌بندی‌ها و استایل را سفارشی کنید. مراحل زیر را دنبال کنید تا ببینید یک نمودار ستونی خوشه‌ای استاندارد چگونه تولید می‌شود:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دهید.  
1. یک نمودار با داده‌ای اضافه کنید و نوع `ChartType.ClusteredColumn` را مشخص کنید.  
1. یک عنوان به نمودار اضافه کنید.  
1. به کاربرگ داده‌های نمودار دسترسی پیدا کنید.  
1. تمام سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. یک رنگ پر برای سری‌های نمودار اعمال کنید.  
1. برچسب‌ها را به سری‌های نمودار اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار ستونی خوشه‌ای ایجاد شود:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// ایجاد شیء از کلاس Presentation.
using (Presentation presentation = new Presentation())
{
    // دسترسی به اولین اسلاید.
    ISlide slide = presentation.Slides[0];

    // افزودن نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض آن.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // تنظیم عنوان نمودار.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // تنظیم ایندکس برگه داده‌های نمودار.
    int worksheetIndex = 0;

    // دریافت کتاب‌کار داده‌های نمودار.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // حذف سری‌ها و دسته‌بندی‌های پیش‌فرض تولید شده.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // افزودن سری‌های جدید.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // افزودن دسته‌بندی‌های جدید.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // دریافت اولین سری نمودار.
    IChartSeries series = chart.ChartData.Series[0];

    // پر کردن داده‌های سری.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // تنظیم رنگ پر برای سری.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // دریافت سری دوم نمودار.
    series = chart.ChartData.Series[1];

    // پر کردن داده‌های سری.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // تنظیم رنگ پر برای سری.
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

    // ذخیره ارائه در دیسک به صورت فایل PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![The Clustered Column chart](clustered_column_chart.png)

### **ایجاد نمودارهای پراکندگی**

نمودارهای پراکندگی (که به‌عنوان scatter plot یا نمودار x‑y نیز شناخته می‌شوند) معمولاً برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر استفاده می‌شوند.

از نمودار پراکندگی زمانی استفاده کنید که:

* داده‌های عددی جفت‌ شده داشته باشید.  
* دو متغیر که به‌خوبی با هم جفت می‌شوند داشته باشید.  
* بخواهید تعیین کنید آیا این دو متغیر مرتبط هستند یا خیر.  
* یک متغیر مستقل داشته باشید که مقادیر متعددی برای متغیر وابسته دارد.

این کد C# نشان می‌دهد چگونه یک نمودار پراکندگی با سری‌های علامت‌گذاری مختلف ایجاد شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// یک شیء از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // دسترسی به اولین اسلاید.
    ISlide slide = presentation.Slides[0];

    // ایجاد نمودار پراکندگی پیش‌فرض.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // تنظیم ایندکس برگه داده‌های نمودار.
    int worksheetIndex = 0;

    // دریافت کتاب‌کار داده‌های نمودار.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // حذف سری پیش‌فرض.
    chart.ChartData.Series.Clear();

    // افزودن سری‌های جدید.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // دریافت اولین سری نمودار.
    IChartSeries series = chart.ChartData.Series[0];

    // افزودن نقطهٔ جدید (1:3) به سری.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // افزودن نقطهٔ جدید (2:10).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // تغییر نوع سری.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // تغییر نشانگر سری نمودار.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // دریافت سری دوم نمودار.
    series = chart.ChartData.Series[1];

    // افزودن نقطهٔ جدید (5:2) به سری نمودار.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // افزودن نقطهٔ جدید (3:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // افزودن نقطهٔ جدید (2:2).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // افزودن نقطهٔ جدید (5:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // تغییر نشانگر سری نمودار.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // ذخیره ارائه در دیسک به صورت فایل PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![The Scatter chart](scatter_chart.png)

### **ایجاد نمودارهای دایره‌ای**

نمودارهای دایره‌ای بهترین گزینه برای نمایش رابطهٔ جزء‑به‑کل در داده‌ها هستند، به‌ویژه وقتی که داده‌ها شامل برچسب‌های دسته‌ای با مقادیر عددی باشند. اما اگر داده‌های شما شامل بخش‌ها یا برچسب‌های زیادی باشد، ممکن است بهتر باشد به جای آن از نمودار میله‌ای استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دهید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Pie` را مشخص کنید.  
1. به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.  
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. نقاط جدید برای نمودار اضافه کنید و رنگ‌های سفارشی به بخش‌های دایره‌ای اعمال کنید.  
1. برچسب‌ها را برای سری‌ها تنظیم کنید.  
1. خطوط راهنمای برچسب‌ها را فعال کنید.  
1. زاویهٔ چرخش برای نمودار دایره‌ای تنظیم شود.  
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار دایره‌ای ایجاد شود:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// یک شیء از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // دسترسی به اولین اسلاید.
    ISlide slide = presentation.Slides[0];

    // افزودن یک نمودار با داده‌های پیش‌فرض آن.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // تنظیم عنوان نمودار.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // تنظیم اولین سری برای نمایش مقادیر.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // تنظیم ایندکس برگه داده‌های نمودار.
    int worksheetIndex = 0;

    // دریافت کتاب‌کار داده‌های نمودار.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // حذف سری‌ها و دسته‌بندی‌های پیش‌فرض تولید شده.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // افزودن دسته‌بندی‌های جدید.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // افزودن سری‌های جدید.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // پر کردن داده‌های سری.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // تنظیم رنگ بخش.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // تنظیم حاشیهٔ بخش.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // تنظیم حاشیهٔ بخش.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // تنظیم حاشیهٔ بخش.
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

    // ذخیره ارائه در دیسک به صورت فایل PPTX.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![The Pie chart](pie_chart.png)

### **ایجاد نمودارهای خطی**

نمودارهای خطی (که به‌عنوان line graph نیز شناخته می‌شوند) بهترین گزینه برای موقعیت‌هایی هستند که می‌خواهید تغییرات مقدار در طول زمان را نشان دهید. با استفاده از یک نمودار خطی می‌توانید حجم زیادی از داده‌ها را به‌صورت همزمان مقایسه کنید، تغییرات و روندها را پیگیری کنید، ناهنجاری‌ها را در سری داده‌ها برجسته کنید و غیره.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دهید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Line` را مشخص کنید.  
1. به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.  
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار خطی ایجاد شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

به‌صورت پیش‌فرض، نقاط یک نمودار خطی با خطوط پیوستهٔ مستقیم به‌هم وصل می‌شوند. اگر می‌خواهید به‌جای آن خطوط نقطه‌دار باشند، می‌توانید نوع خط موردنظر را به‌صورت زیر مشخص کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;

using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    foreach (IChartSeries series in lineChart.ChartData.Series)
    {
        series.Format.Line.DashStyle = LineDashStyle.Dash;
    }
}
```

نتیجه:

![The Line chart](line_chart.png)

### **ایجاد نمودارهای درخت‌نقشه‌ای**

نمودارهای درخت‌نقشه‌ای بهترین گزینه برای داده‌های فروش هستند هنگامی که می‌خواهید اندازه نسبی دسته‌های داده‌ای را نشان دهید و به‌سرعت توجه را به مواردی که سهم بزرگ‌تری در هر دسته دارند جلب کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دهید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Treemap` را مشخص کنید.  
1. به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.  
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار درخت‌نقشه‌ای ایجاد شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

![The Treemap chart](treemap_chart.png)

### **ایجاد نمودارهای سهام**

نمودارهای سهام برای نمایش داده‌های مالی مانند قیمت‌های باز، بیشینه، کمینه و بسته‌شدن استفاده می‌شوند و به تحلیل روندهای بازار و نوسانات کمک می‌کنند. این نمودارها بینش‌های کلیدی دربارهٔ عملکرد سهام در اختیار سرمایه‌گذاران و تحلیل‌گران قرار می‌دهند تا تصمیمات آگاهانه بگیرند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دهید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.OpenHighLowClose` را مشخص کنید.  
1. به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.  
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. قالب خطوط HiLowLines را مشخص کنید.  
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار سهام ایجاد شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

![The Stock chart](stock_chart.png)

### **ایجاد نمودارهای جعبه‌ای و ویسکر**

نمودارهای جعبه‌ای و ویسکر برای نمایش توزیع داده‌ها با خلاصه‌سازی معیارهای آماری کلیدی مانند میانه، چارک‌ها و نقاط دورافتاده استفاده می‌شوند. این نمودارها در تحلیل اکتشافی داده‌ها و مطالعات آماری برای درک سریع تغییرپذیری داده‌ها و شناسایی ناهنجاری‌ها بسیار مفیدند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دهید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.BoxAndWhisker` را مشخص کنید.  
1. به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.  
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار جعبه‌ای و ویسکر ایجاد شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

### **ایجاد نمودارهای قیفی**

نمودارهای قیفی برای تجسم فرآیندهایی که شامل مراحل متوالی هستند و در هر مرحله حجم داده‌ها کاهش می‌یابد، به کار می‌روند. این نمودارها برای تحلیل نرخ تبدیل، شناسایی گلوگه‌ها و ردیابی کارایی فرآیندهای فروش یا بازاریابی بسیار مفیدند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دهید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Funnel` را مشخص کنید.  
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار قیفی ایجاد شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

![The Funnel chart](funnel_chart.png)

### **ایجاد نمودارهای خورشیدگرد**

نمودارهای خورشیدگرد برای تجسم داده‌های سلسله‌مراتبی استفاده می‌شوند؛ سطوح به‌صورت حلقه‌های هم‌مرکز نمایش داده می‌شوند. این نمودارها رابطهٔ جزء‑به‑کل را نشان می‌دهند و برای نمایش دسته‌ها و زیردسته‌های تو در تو به‌صورت واضح و فشرده مناسب‌اند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دهید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Sunburst` را مشخص کنید.  
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار خورشیدگرد ایجاد شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

![The Sunburst chart](sunburst_chart.png)

### **ایجاد نمودارهای هیستوگرام**

نمودارهای هیستوگرام برای نمایش توزیع داده‌های عددی با گروه‌بندی مقادیر در بازه‌ها یا سطل‌های مختلف استفاده می‌شوند. این نمودارها برای شناسایی الگوهای داده‌ای مانند فراوانی، کشیدگی و پراکندگی و همچنین برای کشف نقاط دورافتاده مفیدند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دهید.  
1. یک نمودار با داده‌ای اضافه کنید و نوع `ChartType.Histogram` را مشخص کنید.  
1. به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.  
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار هیستوگرام ایجاد شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

![The Histogram chart](histogram_chart.png)

### **ایجاد نمودارهای رادار**

نمودارهای رادار برای نمایش داده‌های چندمتغیره در قالب دو‑بعدی استفاده می‌شوند و امکان مقایسه همزمان چندین متغیر را فراهم می‌کنند. این نمودارها برای شناسایی الگوها، نقاط قوت و ضعف در میان معیارهای عملکرد یا ویژگی‌های مختلف مفید هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دهید.  
1. یک نمودار با داده‌ای اضافه کنید و نوع `ChartType.Radar` را مشخص کنید.  
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار رادار ایجاد شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![The Radar chart](radar_chart.png)

### **ایجاد نمودارهای چنددسته‌ای**

نمودارهای چنددسته‌ای برای نمایش داده‌هایی استفاده می‌شوند که شامل بیش از یک گروه‌بندی دسته‌ای هستند و امکان مقایسه مقادیر در چند بُعد به‌صورت همزمان را می‌دهند. این نمودارها هنگام تحلیل روندها و روابط در مجموعه داده‌های پیچیده و چندلایه بسیار مفیدند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.  
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دهید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.ClusteredColumn` را مشخص کنید.  
1. به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.  
1. سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید.  
1. سری‌ها و دسته‌بندی‌های جدید اضافه کنید.  
1. داده‌های جدید برای سری‌های نمودار اضافه کنید.  
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار چنددسته‌ای ایجاد شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

    // یک سری اضافه کنید.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // ارائه را به همراه نمودار ذخیره کنید.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![The multi category chart](multi_category_chart.png)

### **ایجاد نمودارهای نقشه‌ای**

نمودارهای نقشه‌ای برای تجسم داده‌های جغرافیایی با نقشه‌کردن اطلاعات بر روی مکان‌های خاصی مانند کشورها، ایالات یا شهرها استفاده می‌شوند. این نمودارها برای تحلیل روندهای منطقه‌ای، داده‌های جمعیت‌شناسی و توزیع‌های مکانی به‌صورت واضح و جذاب بصری مفیدند.

این کد C# نشان می‌دهد چگونه یک نمودار نقشه‌ای ایجاد شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![The Map chart](map_chart.png)

{{% alert color="info" %}} 
تصویر بالا نمایش‌دهندهٔ ارائهٔ ذخیره‌شده است که در PowerPoint باز شده است. Aspose.Slides داده‌های نمودار نقشه‌ای را به‌درستی می‌نویسد، اما خود نمودارهای نقشه‌ای را رسم نمی‌کند: هنگام رندر اسلاید حاوی این نمودار به تصویر یا تبدیل به PDF یا SVG، ناحیهٔ نمودار خالی می‌شود. سایر اشکال همان اسلاید تحت تأثیر قرار نمی‌گیرند. 
{{% /alert %}} 

### **ایجاد نمودارهای ترکیبی**

نمودار ترکیبی (یا combo chart) دو یا چند نوع نمودار را در یک گراف ترکیب می‌کند. این نمودار به شما اجازه می‌دهد تا تفاوت‌ها یا شباهت‌های بین دو یا چند مجموعه داده را برجسته، مقایسه یا بررسی کنید و روابط بین آن‌ها را شناسایی کنید.

![The combination chart](combination_chart.png)

کد C# زیر نشان می‌دهد چگونه نمودار ترکیبی نمایش داده شده در بالا را در یک ارائهٔ PowerPoint ایجاد کنید:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

    // تنظیم عنوان نمودار
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // تنظیم افسانهٔ نمودار
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // حذف سری‌ها و دسته‌بندی‌های پیش‌فرض تولید شده
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // افزودن دسته‌بندی‌های جدید
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // افزودن اولین سری
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
    // تنظیم محور افقی
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // تنظیم محور عمودی
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // تنظیم رنگ خطوط بزرگ شبکهٔ عمودی
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // تنظیم محور افقی ثانویه
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // تنظیم محور عمودی ثانویه
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

Aspose.Slides برای .NET امکان به‌روزرسانی نمودارهای PowerPoint را با تغییر داده‌های نمودار، قالب‌بندی و استایل فراهم می‌کند. این قابلیت فرآیند نگه‌داشتن ارائه‌ها را با محتوای دینامیک ساده‌سازی می‌کند و اطمینان می‌دهد که نمودارها به‌دقت داده‌ها و استانداردهای بصری فعلی را منعکس می‌کنند.

1. یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) که شامل نمودار است، ایجاد کنید.  
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دهید.  
1. تمام اشکال را پیمایش کنید تا نمودار را پیدا کنید.  
1. به کاربرگ داده‌های نمودار دسترسی پیدا کنید.  
1. سری‌های دادهٔ نمودار را با تغییر مقدارهای سری اصلاح کنید.  
1. یک سری جدید اضافه کنید و داده‌های آن را پر کنید.  
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار به‌روزرسانی شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است، ایجاد کنید.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // دسترسی به اولین اسلاید.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // ایندکس برگه داده‌های نمودار را تنظیم کنید.
            int worksheetIndex = 0;

            // کتاب‌کار داده‌های نمودار را دریافت کنید.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // نام‌های دسته‌بندی نمودار را تغییر دهید.
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

            // یک سری جدید اضافه کنید.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // داده‌های سری را پر کنید.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // ارائه را به همراه نمودار ذخیره کنید.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **تنظیم بازهٔ داده برای نمودار**

Aspose.Slides برای .NET انعطاف‌پذیری تعریف یک بازهٔ دادهٔ مشخص از یک کاربرگ را به‌عنوان منبع دادهٔ نمودار فراهم می‌کند. این به این معنی است که می‌توانید مستقیماً بخشی از کاربرگ را به نمودار نگاشت کنید و کنترل کنید کدام سلول‌ها به سری‌ها و دسته‌بندی‌های نمودار کمک می‌کنند. در نتیجه می‌توانید به‌راحتی نمودارهای خود را با آخرین تغییرات داده‌های کاربرگ همگام‌سازی کنید و اطمینان حاصل کنید که ارائه‌های PowerPoint شما اطلاعات دقیق و به‌روز را نشان می‌دهند.

1. یک شیء از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) که شامل نمودار است، ایجاد کنید.  
1. با استفاده از شماره ایندکس، به یک اسلاید ارجاع دهید.  
1. تمام اشکال را پیمایش کنید تا نمودار را پیدا کنید.  
1. به داده‌های نمودار دسترسی پیدا کنید و بازه را تنظیم کنید.  
1. ارائهٔ اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه بازهٔ دادهٔ یک نمودار تنظیم شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است، ایجاد کنید.
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

زمانی که از نشانگرهای پیش‌فرض در نمودارها استفاده می‌کنید، هر سری نمودار به‌طور خودکار یک نماد نشانگر پیش‌فرض متفاوت دریافت می‌کند.

این کد C# نشان می‌دهد چگونه نشانگر یک سری نمودار به‌صورت خودکار تنظیم شود:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

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

    // داده‌های سری را پر کنید.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **پرسش‌های متداول**

**کدام انواع نمودارها توسط Aspose.Slides برای .NET پشتیبانی می‌شوند؟**

Aspose.Slides برای .NET طیف وسیعی از انواع نمودارها از جمله نوار، خط، دایره‌ای، مساحت، پراکندگی، هیستوگرام، رادار و بسیاری دیگر را پشتیبانی می‌کند. این انعطاف‌پذیری به شما اجازه می‌دهد تا مناسب‌ترین نوع نمودار را برای نیازهای تجسم داده خود انتخاب کنید.

**چگونه یک نمودار جدید به اسلاید اضافه کنم؟**

برای افزودن نمودار، ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد می‌کنید، اسلاید موردنظر را با استفاده از ایندکس آن دریافت می‌کنید و سپس متد افزودن نمودار را صدا می‌زنید، نوع نمودار و داده‌های اولیه را مشخص می‌کنید. این فرآیند نمودار را به‌طور مستقیم در ارائه شما ادغام می‌کند.

**چگونه می‌توان داده‌های نمایش داده‌شده در یک نمودار را به‌روزرسانی کرد؟**

می‌توانید با دسترسی به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/))، سری‌ها و دسته‌بندی‌های پیش‌فرض را پاک کنید و سپس داده‌های سفارشی خود را اضافه کنید، داده‌های نمودار را به‌صورت برنامه‌ای تازه‌سازی کنید تا جدیدترین داده‌ها را منعکس کند.

**آیا امکان سفارشی‌سازی ظاهر نمودار وجود دارد؟**

بله، Aspose.Slides برای .NET گزینه‌های سفارشی‌سازی گسترده‌ای ارائه می‌دهد. می‌توانید رنگ‌ها، قلم‌ها، برچسب‌ها، افسانه‌ها و سایر عناصر قالب‌بندی را تغییر دهید تا ظاهر نمودار را مطابق نیازهای طراحی خود تنظیم کنید.
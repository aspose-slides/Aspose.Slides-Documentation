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
- نمودار درختی
- نمودار سهام
- نمودار جعبه‌ای
- نمودار قیفی
- نمودار خورشیدی
- نمودار هیستوگرام
- نمودار رادار
- نمودار چنددسته‌ای
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نمودارها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای .NET ایجاد و سفارشی‌سازی کنید. نمودارها را با مثال‌های عملی کد به زبان C# اضافه، قالب‌بندی و ویرایش کنید."
---
## **بررسی کلی**

این مقاله راهنمای جامعی برای ایجاد و سفارشی‌سازی نمودارها با استفاده از Aspose.Slides for .NET ارائه می‌دهد. شما یاد خواهید گرفت چگونه برنامه‌نویسی یک نمودار را به یک اسلاید اضافه کنید، آن را با داده‌ها پر کنید، و گزینه‌های فرمت‌بندی مختلفی را برای برآورده کردن نیازهای طراحی خاص خود اعمال کنید. در طول مقاله، مثال‌های کد مفصل هر گام را نشان می‌دهند، از مقداردهی اولیه ارائه و شی نمودار تا تنظیم سری‌ها، محورها و افسانه‌ها. با پیروی از این راهنما، درک جامعی از نحوه ادغام تولید دینامیک نمودار در برنامه‌های .NET خود به دست خواهید آورد و فرآیند ایجاد ارائه‌های مبتنی بر داده را ساده می‌کنید.

## **ایجاد یک نمودار**

نمودارها به افراد کمک می‌کنند تا به سرعت داده‌ها را تجسم کنند و بینش‌هایی به دست آورند که ممکن است از یک جدول یا صفحه‌گسترده به‌طور واضح نمایان نشود.

**چرا نمودارها را ایجاد کنیم؟**

با استفاده از نمودارها می‌توانید:

* مقادیر بزرگ داده را در یک اسلاید به‌صورت تجمیعی، فشرده یا خلاصه‌شده نمایش دهید؛
* الگوها و روندهای موجود در داده‌ها را آشکار کنید؛
* جهت و گشتاور داده‌ها را در طول زمان یا نسبت به واحد اندازه‌گیری خاصی استنتاج کنید؛
* داده‌های ناهماهنگ، انحرافی، خطاها و داده‌های بی‌معنی را شناسایی کنید؛
* داده‌های پیچیده را ارتباطی یا ارائه کنید.

در PowerPoint می‌توانید از عملکرد *Insert* برای ایجاد نمودارها استفاده کنید که قالب‌های متنوعی برای طراحی انواع مختلف نمودارها فراهم می‌کند. با استفاده از Aspose.Slides می‌توانید هر دو نمودارهای معمولی (بر پایه انواع محبوب نمودار) و نمودارهای سفارشی ایجاد کنید.

{{% alert color="info" %}} 
از enumeration [ChartType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/charttype/) در فضای نام [Aspose.Slides.Charts](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/) استفاده کنید. مقادیر این enumeration با انواع مختلف نمودار مطابقت دارند.
{{% /alert %}} 

### **ایجاد نمودارهای ستونی خوشه‌ای**

این بخش توضیح می‌دهد چگونه نمودارهای ستونی خوشه‌ای را با Aspose.Slides for .NET ایجاد کنید. شما یاد خواهید گرفت یک ارائه را مقداردهی اولیه کنید، یک نمودار اضافه کنید، و عناصر آن مانند عنوان، داده‌ها، سری‌ها، دسته‌ها و سبک‌دهی را سفارشی کنید. مراحل زیر را دنبال کنید تا ببینید یک نمودار ستونی خوشه‌ای استاندارد چگونه تولید می‌شود:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس آن، به یک اسلاید ارجاع بگیرید.
1. نموداری با برخی داده‌ها اضافه کنید و نوع `ChartType.ClusteredColumn` را مشخص کنید.
1. یک عنوان به نمودار اضافه کنید.
1. به صفحه‌کاری داده‌های نمودار دسترسی پیدا کنید.
1. تمام سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌های جدید اضافه کنید.
1. داده‌های جدید نمودار را برای سری نمودار اضافه کنید.
1. یک رنگ پر برای سری نمودار اعمال کنید.
1. برچسب‌ها را به سری نمودار اضافه کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان یک فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار ستونی خوشه‌ای ایجاد کنید:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // به اولین اسلاید دسترسی پیدا کنید.
    ISlide slide = presentation.Slides[0];

    // یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض آن اضافه کنید.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // عنوان نمودار را تنظیم کنید.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // اندیس برگه دادهٔ نمودار را تنظیم کنید.
    int worksheetIndex = 0;

    // کتاب‌کار دادهٔ نمودار را دریافت کنید.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف کنید.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // سری‌های جدید اضافه کنید.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // دسته‌های جدید اضافه کنید.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // اولین سری نمودار را دریافت کنید.
    IChartSeries series = chart.ChartData.Series[0];

    // داده‌های سری را پر کنید.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // رنگ پر را برای سری تنظیم کنید.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // سری دوم نمودار را دریافت کنید.
    series = chart.ChartData.Series[1];

    // داده‌های سری را پر کنید.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // رنگ پر را برای سری تنظیم کنید.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // برچسب اول را برای نمایش نام دسته تنظیم کنید.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // سری را تنظیم کنید تا مقدار را برای برچسب سوم نشان دهد.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // ارائه را به‌عنوان فایل PPTX در دیسک ذخیره کنید.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار ستونی خوشه‌ای](clustered_column_chart.png)

### **ایجاد نمودارهای پراکنده**

نمودارهای پراکنده (که به نام نمودارهای پراکندگی یا نمودارهای x‑y نیز شناخته می‌شوند) اغلب برای بررسی الگوها یا نشان دادن همبستگی بین دو متغیر استفاده می‌شوند.

از نمودار پراکنده زمانی استفاده کنید که:

* دارای داده‌های عددی جفت‌شده باشید.
* دو متغیر داشته باشید که به‌خوبی با هم جفت می‌شوند.
* بخواهید تعیین کنید آیا این دو متغیر مرتبط هستند یا نه.
* متغیری مستقل داشته باشید که برای متغیر وابسته مقادیر متعددی داشته باشد.

این کد C# نشان می‌دهد چگونه یک نمودار پراکنده با سری‌های مختلف علامت‌ها ایجاد کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // به اولین اسلاید دسترسی پیدا کنید.
    ISlide slide = presentation.Slides[0];

    // نمودار پراکتی پیش‌فرض را ایجاد کنید.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // اندیس برگه دادهٔ نمودار را تنظیم کنید.
    int worksheetIndex = 0;

    // کتاب‌کار دادهٔ نمودار را دریافت کنید.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // سری پیش‌فرض را حذف کنید.
    chart.ChartData.Series.Clear();

    // سری‌های جدید اضافه کنید.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // اولین سری نمودار را دریافت کنید.
    IChartSeries series = chart.ChartData.Series[0];

    // نقطه جدید (1:3) را به سری اضافه کنید.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // نقطه جدید (2:10) را اضافه کنید.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // نوع سری را تغییر دهید.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // نشانگر سری نمودار را تغییر دهید.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // سری دوم نمودار را دریافت کنید.
    series = chart.ChartData.Series[1];

    // نقطه جدید (5:2) را به سری نمودار اضافه کنید.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // نقطه جدید (3:1) را اضافه کنید.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // نقطه جدید (2:2) را اضافه کنید.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // نقطه جدید (5:1) را اضافه کنید.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // نشانگر سری نمودار را تغییر دهید.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // ارائه را به‌عنوان فایل PPTX در دیسک ذخیره کنید.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار پراکنده](scatter_chart.png)

### **ایجاد نمودارهای دایره‌ای**

نمودارهای دایره‌ای بهترین استفاده را برای نشان دادن رابطهٔ بخش‑به‑کل در داده‌ها دارند، به‌ویژه زمانی که داده‌ها شامل برچسب‌های دسته‌ای با مقادیر عددی باشند. با این حال، اگر داده‌های شما شامل بخش‌ها یا برچسب‌های زیادی باشد، ممکن است بهتر باشد به‌جای آن از نمودار میله‌ای استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس آن، به یک اسلاید ارجاع بگیرید.
1. نموداری با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Pie` را مشخص کنید.
1. به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌های جدید اضافه کنید.
1. داده‌های جدید نمودار را برای سری نمودار اضافه کنید.
1. نقاط جدید برای نمودار اضافه کنید و رنگ‌های سفارشی به بخش‌های نمودار دایره‌ای اعمال کنید.
1. برچسب‌ها را برای سری تنظیم کنید.
1. خطوط راهنما را برای برچسب‌های سری فعال کنید.
1. زاویهٔ چرخش برای نمودار دایره‌ای تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان یک فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار دایره‌ای ایجاد کنید:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    // به اولین اسلاید دسترسی پیدا کنید.
    ISlide slide = presentation.Slides[0];

    // یک نمودار با داده‌های پیش‌فرض آن اضافه کنید.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // عنوان نمودار را تنظیم کنید.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // اولین سری را برای نمایش مقادیر تنظیم کنید.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // اندیس برگه دادهٔ نمودار را تنظیم کنید.
    int worksheetIndex = 0;

    // کتاب‌کار دادهٔ نمودار را دریافت کنید.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف کنید.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // دسته‌های جدید اضافه کنید.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // سری‌های جدید اضافه کنید.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // داده‌های سری را پر کنید.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // رنگ بخش (سکتور) را تنظیم کنید.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // حاشیهٔ بخش را تنظیم کنید.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // حاشیهٔ بخش را تنظیم کنید.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // حاشیهٔ بخش را تنظیم کنید.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // برچسب‌های سفارشی برای هر دسته در سری جدید ایجاد کنید.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // سری را تنظیم کنید تا خطوط راهنما برای نمودار نشان داده شود.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // زاویهٔ چرخش بخش‌های نمودار دایره‌ای را تنظیم کنید.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // ارائه را به‌عنوان فایل PPTX در دیسک ذخیره کنید.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار دایره‌ای](pie_chart.png)

### **ایجاد نمودارهای خطی**

نمودارهای خطی (که به نام نمودارهای خطی نیز شناخته می‌شوند) بهترین استفاده را در موقعیت‌هایی دارند که بخواهید تغییرات مقدار را در طول زمان نشان دهید. با استفاده از نمودار خطی می‌توانید مقدار بالایی از داده‌ها را به‌طور همزمان مقایسه کنید، تغییرات و روندها را در طول زمان ردیابی کنید، ناهنجاری‌ها را در سری‌های داده برجسته کنید و موارد دیگر.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس آن، به یک اسلاید ارجاع بگیرید.
1. نموداری با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Line` را مشخص کنید.
1. به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌های جدید اضافه کنید.
1. داده‌های جدید نمودار را برای سری نمودار اضافه کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان یک فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار خطی ایجاد کنید:

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

به‌صورت پیش‌فرض نقاط در یک نمودار خطی با خطوط مستقیم متصل می‌شوند. اگر می‌خواهید نقاط با خط‌های نقطه‌دار متصل شوند، می‌توانید نوع dash مورد نظر خود را به‌صورت زیر مشخص کنید:

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

![نمودار خطی](line_chart.png)

### **ایجاد نمودارهای Tree Map**

نمودارهای Tree Map بهترین استفاده را برای داده‌های فروش دارند زمانی که بخواهید اندازهٔ نسبی دسته‌های داده را نشان دهید و به‌سرعت توجه را به آیتم‌های بزرگ‌سهم در هر دسته جلب کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس آن، به یک اسلاید ارجاع بگیرید.
1. نموداری با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Treemap` را مشخص کنید.
1. به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌های جدید اضافه کنید.
1. داده‌های جدید نمودار را برای سری نمودار اضافه کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان یک فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار Tree Map ایجاد کنید:

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

![نمودار Tree Map](treemap_chart.png)

### **ایجاد نمودارهای سهام**

نمودارهای سهام برای نمایش داده‌های مالی مانند قیمت‌های باز، بالا، پایین و بسته استفاده می‌شوند و به تجزیه و تحلیل روندهای بازار و نوسان کمک می‌کنند. این نمودارها بینش‌های اساسی دربارهٔ عملکرد سهام فراهم می‌آورند و به سرمایه‌گذاران و تحلیل‌گران در اتخاذ تصمیمات آگاهانه کمک می‌کنند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس آن، به یک اسلاید ارجاع بگیرید.
1. نموداری با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.OpenHighLowClose` را مشخص کنید.
1. به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌های جدید اضافه کنید.
1. داده‌های جدید نمودار را برای سری نمودار اضافه کنید.
1. قالب HiLowLines را مشخص کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان یک فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار سهام ایجاد کنید:

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

![نمودار سهام](stock_chart.png)

### **ایجاد نمودارهای Box and Whisker**

نمودارهای Box and Whisker برای نمایش توزیع داده‌ها با خلاصه‌سازی معیارهای آماری کلیدی مانند میانه، چارک‌ها و نقاط بیرون‌زدگی استفاده می‌شوند. این نمودارها به‌ویژه در تحلیل اکتشافی داده‌ها و مطالعات آماری برای درک سریع تغییرپذیری داده‌ها و شناسایی ناهنجاری‌ها مفید هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس آن، به یک اسلاید ارجاع بگیرید.
1. نموداری با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.BoxAndWhisker` را مشخص کنید.
1. به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌های جدید اضافه کنید.
1. داده‌های جدید نمودار را برای سری نمودار اضافه کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان یک فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار Box and Whisker ایجاد کنید:

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

نمودارهای قیفی برای تصویرسازی فرآیندهایی که شامل مراحل متوالی هستند استفاده می‌شوند؛ جایی که حجم داده‌ها با پیشرفت از یک گام به گام بعدی کاهش می‌یابد. این نمودارها به‌ویژه برای تجزیه و تحلیل نرخ تبدیل، شناسایی گلوگاه‌ها و ردیابی کارایی فرآیندهای فروش یا بازاریابی مفید هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس آن، به یک اسلاید ارجاع بگیرید.
1. نموداری با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Funnel` را مشخص کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان یک فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار قیفی ایجاد کنید:

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

![نمودار قیفی](funnel_chart.png)

### **ایجاد نمودارهای Sunburst**

نمودارهای Sunburst برای تصویرسازی داده‌های سلسله‌مراتبی استفاده می‌شوند و سطوح را به‌صورت حلقه‌های متحد مرکز نمایش می‌دهند. این نمودارها رابطهٔ بخش‑به‑کل را نشان می‌دهند و برای نمایش دسته‌ها و زیرمجموعه‌های تو در تو در قالبی واضح و فشرده ایده‌آل هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس آن، به یک اسلاید ارجاع بگیرید.
1. نموداری با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.Sunburst` را مشخص کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان یک فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار Sunburst ایجاد کنید:

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

![نمودار Sunburst](sunburst_chart.png)

### **ایجاد نمودارهای هیستوگرام**

نمودارهای هیستوگرام برای نمایش توزیع داده‌های عددی با گروه‌بندی مقادیر در بازه‌ها یا بن‌ها استفاده می‌شوند. این نمودارها به‌ویژه برای شناسایی الگوهای داده مانند فراوانی، انحراف و پراکندگی و برای کشف نقاط بیرون‌زدگی در یک مجموعه داده مفید هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس آن، به یک اسلاید ارجاع بگیرید.
1. نموداری با برخی داده‌ها اضافه کنید و نوع `ChartType.Histogram` را مشخص کنید.
1. به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌های جدید اضافه کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان یک فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار هیستوگرام ایجاد کنید:

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

![نمودار هیستوگرام](histogram_chart.png)

### **ایجاد نمودارهای رادار**

نمودارهای رادار برای نمایش داده‌های چندمتغیره در قالب دو‑بعدی استفاده می‌شوند و امکان مقایسهٔ همزمان چندین متغیر را فراهم می‌آورند. این نمودارها به‌ویژه برای شناسایی الگوها، نقاط قوت و ضعف در میان چندین معیار عملکرد یا ویژگی مفید هستند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس آن، به یک اسلاید ارجاع بگیرید.
1. نموداری با برخی داده‌ها اضافه کنید و نوع `ChartType.Radar` را مشخص کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان یک فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار رادار ایجاد کنید:

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

![نمودار رادار](radar_chart.png)

### **ایجاد نمودارهای چنددسته‌ای**

نمودارهای چنددسته‌ای برای نمایش داده‌هایی که شامل بیش از یک گروه‌بندی دسته‌ای هستند استفاده می‌شوند و به شما امکان می‌دهند مقادیر را به‌طور همزمان در چندین بُعد مقایسه کنید. این نمودارها به‌ویژه زمانی مفید هستند که نیاز به تحلیل روندها و روابط در مجموعه داده‌های پیچیده و چندلایه‌دار داشته باشید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از اندیس آن، به یک اسلاید ارجاع بگیرید.
1. نموداری با داده‌های پیش‌فرض اضافه کنید و نوع `ChartType.ClusteredColumn` را مشخص کنید.
1. به کتاب‌کار داده‌های نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/)) دسترسی پیدا کنید.
1. سری‌ها و دسته‌های پیش‌فرض را پاک کنید.
1. سری‌ها و دسته‌های جدید اضافه کنید.
1. داده‌های جدید نمودار را برای سری نمودار اضافه کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان یک فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار چنددسته‌ای ایجاد کنید:

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

    // ارائه را همراه با نمودار ذخیره کنید.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![نمودار چنددسته‌ای](multi_category_chart.png)

### **ایجاد نمودارهای نقشه**

نمودارهای نقشه برای تصویرسازی داده‌های جغرافیایی با انتساب اطلاعات به مکان‌های خاصی مانند کشورها، ایالات یا شهرها استفاده می‌شوند. این نمودارها به‌ویژه برای تجزیه و تحلیل روندهای منطقه‌ای، داده‌های دموگرافیک و توزیع‌های مکانی در قالبی واضح و بصری جذاب مفید هستند.

این کد C# نشان می‌دهد چگونه یک نمودار نقشه ایجاد کنید:

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

![نمودار نقشه](map_chart.png)

{{% alert color="info" %}} 
عکس بالا ارائهٔ ذخیره‌شده را که در PowerPoint باز شده نشان می‌دهد. Aspose.Slides به‌درستی نمودار نقشه و داده‌های آن را می‌نویسد، اما خود نمودارهای نقشه را رسم نمی‌کند: وقتی اسلاید حاوی آن به تصویر رندر می‌شود یا به PDF یا SVG تبدیل می‌شود، ناحیهٔ نمودار خالی می‌شود. سایر اشکال روی همان اسلاید تحت تأثیر قرار نمی‌گیرند.
{{% /alert %}} 

### **ایجاد نمودارهای ترکیبی**

نمودار ترکیبی (یا combo chart) دو یا چند نوع نمودار را در یک گراف ترکیب می‌کند. این نمودار به شما امکان می‌دهد تا تفاوت‌ها یا شباهت‌های بین دو یا چند مجموعه داده را برجسته، مقایسه یا بررسی کنید و روابط بین آن‌ها را شناسایی نمایید.

![نمودار ترکیبی](combination_chart.png)

کد C# زیر نشان می‌دهد چگونه نمودار ترکیبی نشان‌داده‌شده در بالا را در یک ارائهٔ PowerPoint ایجاد کنید:

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

    // عنوان نمودار را تنظیم می‌کند
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // افسانه (legend) نمودار را تنظیم می‌کند
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

    // اضافه‌کردن اولین سری
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

    // رنگ خطوط اصلی شبکه عمودی را تنظیم می‌کند
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

Aspose.Slides for .NET به شما امکان می‌دهد نمودارهای PowerPoint را با تغییر داده‌های نمودار، فرمت‌بندی و سبک‌دهی به‌روزرسانی کنید. این قابلیت فرآیند نگه‌داری به‌روز بودن ارائه‌ها با محتوای پویا را ساده می‌کند و اطمینان می‌دهد که نمودارها به‌درستی داده‌ها و استانداردهای بصری جاری را بازتاب می‌دهند.

1. نمونه‌ای از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) که شامل نمودار است، ایجاد کنید.
1. با استفاده از اندیس آن، به یک اسلاید ارجاع بگیرید.
1. در تمام اشکال مرور کنید تا نمودار را پیدا کنید.
1. به صفحه‌کاری داده‌های نمودار دسترسی پیدا کنید.
1. سری‌های دادهٔ نمودار را با تغییر مقادیر سری‌ها اصلاح کنید.
1. یک سری جدید اضافه کنید و داده‌های آن را پر کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان یک فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه یک نمودار را به‌روزرسانی کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است ایجاد کنید.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // به اولین اسلاید دسترسی پیدا کنید.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // اندیس برگه دادهٔ نمودار را تنظیم کنید.
            int worksheetIndex = 0;

            // کتاب‌کار دادهٔ نمودار را دریافت کنید.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // نام‌های دسته‌های نمودار را تغییر دهید.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // اولین سری نمودار را دریافت کنید.
            IChartSeries series = chart.ChartData.Series[0];

            // داده‌های سری را به‌روزرسانی کنید.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // اصلاح نام سری.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // سری دوم نمودار را دریافت کنید.
            series = chart.ChartData.Series[1];

            // داده‌های سری را به‌روزرسانی کنید.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // اصلاح نام سری.
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

    // ارائه را همراه با نمودار ذخیره کنید.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **تنظیم محدودهٔ داده برای یک نمودار**

Aspose.Slides for .NET انعطاف‌پذیری تعریف یک محدودهٔ دادهٔ خاص از یک صفحه‌کار به‌عنوان منبع دادهٔ نمودار شما را فراهم می‌کند. این به این معنی است که می‌توانید به‌طور مستقیم بخشی از صفحه‌کار خود را به نمودار نگاشت کنید و کنترل کنید که کدام سلول‌ها به سری‌ها و دسته‌های نمودار کمک می‌کنند. در نتیجه می‌توانید به‌راحتی نمودارهای خود را با آخرین تغییرات داده در صفحه‌کار همسان‌سازی کنید و اطمینان حاصل کنید که ارائه‌های PowerPoint شما اطلاعات به‌روز و دقیق را نمایش می‌دهند.

1. نمونه‌ای از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) که شامل نمودار است، ایجاد کنید.
1. با استفاده از اندیس آن، به یک اسلاید ارجاع بگیرید.
1. در تمام اشکال مرور کنید تا نمودار را پیدا کنید.
1. به دادهٔ نمودار دسترسی پیدا کنید و محدوده را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به‌عنوان یک فایل PPTX ذخیره کنید.

این کد C# نشان می‌دهد چگونه محدودهٔ دادهٔ یک نمودار را تنظیم کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

// یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است ایجاد کنید.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // به اولین اسلاید دسترسی پیدا کنید.
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

هنگامی که از نشانگرهای پیش‌فرض در نمودارها استفاده می‌کنید، هر سری نمودار به‌صورت خودکار یک نماد نشانگر پیش‌فرض متفاوت دریافت می‌کند.

این کد C# نشان می‌دهد چگونه نشانگر یک سری نمودار را به‌صورت خودکار تنظیم کنید:

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

### چه نوع نمودارهایی توسط Aspose.Slides for .NET پشتیبانی می‌شوند؟

Aspose.Slides for .NET طیف گسترده‌ای از انواع نمودارها از جمله میله‌ای، خطی، دایره‌ای، ناحیه‌ای، پراکنده، هیستوگرام، رادار و بسیاری دیگر را پشتیبانی می‌کند. این انعطاف‌پذیری به شما اجازه می‌دهد مناسب‌ترین نوع نمودار را برای نیازهای تجسم داده‌های خود انتخاب کنید.

### چگونه یک نمودار جدید به اسلاید اضافه کنم؟

برای افزودن یک نمودار، ابتدا یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد می‌کنید، اسلاید مورد نظر را با استفاده از اندیس آن دریافت می‌کنید، و سپس متد افزودن نمودار را صدا می‌زنید، نوع نمودار و داده‌های اولیه را مشخص می‌کنید. این فرآیند نمودار را مستقیماً در ارائهٔ شما ادغام می‌کند.

### چگونه می‌توان داده‌های نمایش‌داده‌شده در یک نمودار را به‌روزرسانی کرد؟

می‌توانید با دسترسی به کتاب‌کار دادهٔ نمودار ([IChartDataWorkbook](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/ichartdataworkbook/))، سری‌ها و دسته‌های پیش‌فرض را پاک کنید و سپس داده‌های سفارشی خود را اضافه کنید، دادهٔ نمودار را برنامه‌نویسی بروزرسانی کنید تا آخرین داده‌ها را منعکس کند.

### آیا امکان سفارشی‌سازی ظاهر نمودار وجود دارد؟

بله، Aspose.Slides for .NET گزینه‌های گسترده‌ای برای سفارشی‌سازی فراهم می‌کند. می‌توانید رنگ‌ها، قلم‌ها، برچسب‌ها، افسانه‌ها و سایر عناصر فرمت‌بندی را تغییر دهید تا ظاهر نمودار را مطابق با نیازهای طراحی خاص خود تنظیم کنید.
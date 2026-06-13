---
title: نحوه ایجاد نمودارها در ارائه‌ها در .NET
linktitle: ایجاد نمودار
type: docs
weight: 30
url: /fa/net/how-to-create-charts-in-a-presentation/
keywords:
- مهاجرت
- ایجاد نمودار
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه در ارائه‌های PowerPoint (PPT، PPTX) و ODP در .NET با استفاده از Aspose.Slides و هر دو API نمودار قدیمی و مدرن، نمودارها را ایجاد کنید."
---
{{% alert color="primary" %}} 

یک [API Aspose.Slides برای .NET](/slides/fa/net/) جدید منتشر شده است و اکنون این محصول واحد توانایی تولید اسناد PowerPoint از ابتدا و ویرایش اسناد موجود را پشتیبانی می‌کند.

{{% /alert %}} 
## **پشتیبانی از کدهای قدیمی**
برای استفاده از کدهای قدیمی که با نسخه‌های پیش از 13.x Aspose.Slides برای .NET توسعه یافته‌اند، باید تغییرات جزئی در کد خود اعمال کنید تا کد همچنان همانند قبل کار کند. تمام کلاس‌هایی که در Aspose.Slides قدیمی برای .NET تحت فضاهای نام Aspose.Slide و Aspose.Slides.Pptx وجود داشتند، اکنون در یک فضای نام Aspose.Slides واحد ترکیب شده‌اند. لطفاً به قطعه کد ساده زیر برای ایجاد یک نمودار عادی از ابتدا در ارائه با استفاده از API قدیمی Aspose.Slides نگاه کنید و مراحل ارتقا به API جدید ترکیبی را دنبال کنید.
## **رویکرد قدیمی Aspose.Slides برای .NET**
```c#
//نمونه‌سازی کلاس PresentationEx که نمایانگر فایل PPTX است
using (PresentationEx pres = new PresentationEx())
{
	//دسترسی به اولین اسلاید
	SlideEx sld = pres.Slides[0];

	//افزودن نمودار با داده‌های پیش‌فرض
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//تنظیم عنوان نمودار
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//تنظیم سری اول برای نمایش مقادیر
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//تنظیم اندیس برگه داده‌های نمودار 
	int defaultWorksheetIndex = 0;

	//دریافت برگه‌کار داده‌های نمودار
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//حذف سری‌ها و دسته‌بندی‌های پیش‌فرض تولید شده
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//افزودن سری‌های جدید
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//افزودن دسته‌بندی‌های جدید
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//دریافت اولین سری نمودار
	ChartSeriesEx series = chart.ChartData.Series[0];

	//اکنون در حال پر کردن داده‌های سری
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//تنظیم رنگ پر برای سری
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//دریافت سری دوم نمودار
	series = chart.ChartData.Series[1];

	//اکنون در حال پر کردن داده‌های سری
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//تنظیم رنگ پر برای سری
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//ایجاد برچسب‌های سفارشی برای هر یک از دسته‌بندی‌ها برای سری جدید

	//برچسب اول نام دسته‌بندی را نشان می‌دهد
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//نمایش نام سری برای برچسب دوم
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//نمایش مقدار برای برچسب سوم
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//نمایش مقدار و متن سفارشی
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//ذخیره ارائه با نمودار
	pres.Write(@"D:\AsposeChart.pptx");
}
```

## **رویکرد جدید Aspose.Slides برای .NET 13.x**
``` csharp
//نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است//نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
Presentation pres = new Presentation();

//دسترسی به اولین اسلاید
ISlide sld = pres.Slides[0];

// افزودن نمودار با داده‌های پیش‌فرض
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//تنظیم عنوان نمودار
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//تنظیم سری اول برای نمایش مقادیر
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//تنظیم اندیس برگه داده‌های نمودار
int defaultWorksheetIndex = 0;

//دریافت برگه‌کار داده‌های نمودار
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//حذف سری‌ها و دسته‌بندی‌های پیش‌فرض تولید شده
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//افزودن سری‌های جدید
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//افزودن دسته‌بندی‌های جدید
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//دریافت اولین سری نمودار
IChartSeries series = chart.ChartData.Series[0];

//اکنون در حال پر کردن داده‌های سری
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//تنظیم رنگ پر برای سری
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//دریافت سری دوم نمودار
series = chart.ChartData.Series[1];

//اکنون در حال پر کردن داده‌های سری
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//تنظیم رنگ پر برای سری
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//ایجاد برچسب‌های سفارشی برای هر یک از دسته‌بندی‌ها برای سری جدید

//برچسب اول نام دسته‌بندی را نشان می‌دهد
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//نمایش مقدار برای برچسب سوم
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//ذخیره ارائه با نمودار
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

لطفاً به قطعه کد ساده زیر برای ایجاد یک نمودار پراکنده از ابتدا در ارائه با استفاده از API قدیمی Aspose.Slides نگاه کنید و نحوه پیاده‌سازی آن با API جدید ترکیبی را مشاهده کنید.
## **رویکرد قدیمی Aspose.Slides برای .NET**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //ایجاد نمودار پیش‌فرض
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //دریافت اندیس برگه داده‌های پیش‌فرض نمودار
    int defaultWorksheetIndex = 0;

    //دسترسی به برگه داده‌های نمودار
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //حذف سری‌های دمو
    chart.ChartData.Series.Clear();

    //افزودن سری‌های جدید
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //دریافت اولین سری نمودار
    ChartSeriesEx series = chart.ChartData.Series[0];

    //افزودن نقطه جدید (1:3) در آن.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //افزودن نقطه جدید (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //ویرایش نوع سری
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //تغییر نشانگر سری نمودار
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //دریافت سری دوم نمودار
    series = chart.ChartData.Series[1];

    //افزودن نقطه جدید (5:2) در آن.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //افزودن نقطه جدید (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //افزودن نقطه جدید (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //افزودن نقطه جدید (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //تغییر نشانگر سری نمودار
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```

## **رویکرد جدید Aspose.Slides برای .NET 13.x**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//ایجاد نمودار پیش‌فرض
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//دریافت اندیس برگه داده‌های پیش‌فرض نمودار
int defaultWorksheetIndex = 0;

//دسترسی به برگه داده‌های نمودار
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//حذف سری‌های دمو
chart.ChartData.Series.Clear();

//افزودن سری‌های جدید
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//دریافت اولین سری نمودار
IChartSeries series = chart.ChartData.Series[0];

//افزودن نقطه جدید (1:3) در آن.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//افزودن نقطه جدید (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//ویرایش نوع سری
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//تغییر نشانگر سری نمودار
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//دریافت سری دوم نمودار
series = chart.ChartData.Series[1];

//افزودن نقطه جدید (5:2) در آن.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//افزودن نقطه جدید (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//افزودن نقطه جدید (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//افزودن نقطه جدید (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//تغییر نشانگر سری نمودار
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```
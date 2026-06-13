---
title: سفارشی‌سازی نمودارهای دایره‌ای در ارائه‌ها با .NET
linktitle: نمودار دایره‌ای
type: docs
url: /fa/net/pie-chart/
keywords:
- نمودار دایره‌ای
- مدیریت نمودار
- سفارشی‌سازی نمودار
- گزینه‌های نمودار
- تنظیمات نمودار
- گزینه‌های طرح
- رنگ برش
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بیاموزید چگونه نمودارهای دایره‌ای را در .NET با Aspose.Slides ایجاد و سفارشی کنید، قابل صادرات به PowerPoint، و روایت داده‌های خود را در ثانیه‌ها تقویت کنید."
---
## **بررسی کلی**

این مقاله نحوه کار با نمودارهای دایره‌ای در Aspose.Slides را توضیح می‌دهد. همچنین نشان می‌دهد چگونه گزینه‌های نمودار ثانوی برای نمودارهای Pie of Pie و Bar of Pie را پیکربندی کنید و چگونه رنگ‌گذاری خودکار برش‌ها را برای یک نمودار دایره‌ای استاندارد فعال کنید.

مثال‌ها بر گام‌های عملی سفارشی‌سازی نمودار متمرکز هستند، از جمله افزودن نمودار به اسلاید، تنظیم تنظیمات سری و برچسب، جایگزینی داده‌های پیش‌فرض نمودار با دسته‌ها و مقادیر سفارشی، و ذخیره ارائه به‌روز شده.

## **گزینه‌های نمودار ثانوی برای نمودارهای Pie of Pie و Bar of Pie**
Aspose.Slides for .NET اکنون پشتیبانی از گزینه‌های نمودار ثانوی برای نمودارهای Pie of Pie یا Bar of Pie را فراهم کرده است. در این بخش، با مثال نشان می‌دهیم چگونه این گزینه‌ها را با استفاده از Aspose.Slides مشخص کنیم. برای تعیین ویژگی‌ها، لطفاً مراحل زیر را دنبال کنید:

1. یک شیء کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. نمودار را به اسلاید اضافه کنید.
1. گزینه‌های نمودار ثانوی را مشخص کنید.
1. ارائه را در دیسک بنویسید.

در مثال زیر، ما ویژگی‌های مختلف نمودار Pie of Pie را تنظیم کرده‌ایم.

```c#
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation presentation = new Presentation();

// یک نمودار را به اسلاید اضافه کنید
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// ویژگی‌های مختلف را تنظیم کنید
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// ارائه را روی دیسک ذخیره کنید
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```




## **تنظیم رنگ‌های خودکار برش‌های نمودار دایره‌ای**
Aspose.Slides for .NET یک API ساده برای تنظیم رنگ‌های خودکار برش‌های نمودار دایره‌ای ارائه می‌دهد. کد نمونه ویژگی‌های مذکور را اعمال می‌کند.

1. یک نمونه از کلاس Presentation ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. نمودار را با داده‌های پیش‌فرض اضافه کنید.
1. عنوان نمودار را تنظیم کنید.
1. سری اول را به نمایش مقادیر تنظیم کنید.
1. اندیس شیت داده‌های نمودار را تنظیم کنید.
1. برگه کاری داده‌های نمودار را دریافت کنید.
1. سری‌ها و دسته‌های پیش‌فرض تولید شده را حذف کنید.
1. دسته‌های جدید اضافه کنید.
1. سری جدید اضافه کنید.

ارائه اصلاح شده را در یک فایل PPTX بنویسید.

```c#
// نمونه‌ای از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد کنید
using (Presentation presentation = new Presentation())
{
	// نمونه‌ای از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد کنید
	Presentation presentation = new Presentation();

	// دسترسی به اولین اسلاید
	ISlide slides = presentation.Slides[0];

	// اضافه کردن نمودار با داده‌های پیش‌فرض
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// تنظیم عنوان نمودار
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// سری اول را برای نمایش مقادیر تنظیم کنید
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// تنظیم اندیس شیت داده‌های نمودار
	int defaultWorksheetIndex = 0;

	// دریافت برگه کاری داده‌های نمودار
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// حذف سری‌ها و دسته‌های پیش‌فرض تولید شده
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// افزودن دسته‌های جدید
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// افزودن سری جدید
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// در حال پر کردن داده‌های سری
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **پرسش‌های متداول**

**آیا انواع 'Pie of Pie' و 'Bar of Pie' پشتیبانی می‌شوند؟**

بله، کتابخانه [پشتیبانی](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/charttype/) از یک نمودار ثانوی برای نمودارهای دایره‌ای، از جمله انواع 'Pie of Pie' و 'Bar of Pie' را دارد.

**آیا می‌توانم فقط نمودار را به‌عنوان تصویر (مثلاً PNG) استخراج کنم؟**

بله، می‌توانید [نمودار را به‌عنوان تصویر استخراج کنید](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/getimage/) (مانند PNG) بدون نیاز به استخراج کل ارائه.
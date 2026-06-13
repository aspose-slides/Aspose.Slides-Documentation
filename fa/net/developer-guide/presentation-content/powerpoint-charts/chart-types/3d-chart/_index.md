---
title: سفارشی‌سازی نمودارهای 3D در ارائه‌ها در .NET
linktitle: نمودار 3D
type: docs
url: /fa/net/3d-chart/
keywords:
- نمودار 3D
- چرخش
- عمق
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه نمودارهای 3‑بعدی را در Aspose.Slides برای .NET ایجاد و سفارشی کنید، با پشتیبانی از فایل‌های PPT و PPTX—امروز ارائه‌های خود را ارتقا دهید."
---
## **مروری کلی**

این مقاله توضیح می‌دهد چگونه یک نمودار 3D را در Aspose.Slides با پیکربندی تنظیمات `Rotation3D` مانند `RotationX`، `RotationY`، `DepthPercents` و `RightAngleAxes` سفارشی کنید. این مقاله گام به گام ایجاد یک ارائه، افزودن یک نمودار 3D با داده‌های پیش‌فرض، اعمال تنظیمات نمای 3D مورد نیاز و ذخیره ارائه اصلاح‌شده به صورت فایل PPTX را نشان می‌دهد.

## **تنظیم ویژگی‌های RotationX، RotationY و DepthPercents یک نمودار 3D**

Aspose.Slides برای .NET یک API ساده برای تنظیم این ویژگی‌ها فراهم می‌کند. مقاله زیر به شما نشان می‌دهد چگونه ویژگی‌های مختلفی مانند چرخش X، Y، **DepthPercents** و غیره را تنظیم کنید. کد نمونه تنظیم ویژگی‌های ذکر شده را اعمال می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. نموداری با داده‌های پیش‌فرض اضافه کنید.
4. ویژگی‌های Rotation3D را تنظیم کنید.
5. ارائهٔ اصلاح‌شده را در یک فایل PPTX بنویسید.

```c#
// ایجاد یک نمونه از کلاس Presentation
Presentation presentation = new Presentation();
           
// دسترسی به اولین اسلاید
ISlide slide = presentation.Slides[0];

// افزودن نمودار با داده‌های پیش‌فرض
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// تنظیم ایندکس برگه داده‌های نمودار
int defaultWorksheetIndex = 0;

// دریافت برگه کاری داده‌های نمودار
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// افزودن سری‌ها
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// افزودن دسته‌ها
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// تنظیم ویژگی‌های Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// انتخاب سری دوم نمودار
IChartSeries series = chart.ChartData.Series[1];

// اکنون در حال پر کردن داده‌های سری
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// تنظیم مقدار OverLap
series.ParentSeriesGroup.Overlap = 100;         

// نوشتن ارائه به دیسک
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**کدام انواع نمودار حالت 3D را در Aspose.Slides پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3D نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به‌اضافه انواع 3D مرتبط که از طریق شمارش‌گر [ChartType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/charttype/) در دسترس هستند. برای دریافت لیست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/charttype/) را در مرجع API نسخهٔ نصب شده‌تان بررسی کنید.

**آیا می‌توانم تصویر رستر از یک نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید یک نمودار را به تصویر صادر کنید با استفاده از [chart API](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/getimage/) یا [رندر کل اسلاید](/slides/fa/net/convert-powerpoint-to-png/) به قالب‌هایی مانند PNG یا JPEG. این وقتی مفید است که به پیش‌نمایشی دقیق پیکسل یا نیاز به تعبیه نمودار در اسناد، داشبوردها یا صفحات وب بدون نیاز به PowerPoint دارید.

**کارایی ساخت و رندر نمودارهای 3D بزرگ چقدر است؟**

عملکرد به حجم داده و پیچیدگی بصری بستگی دارد. برای بهترین نتایج، اثرات 3D را به حداقل برسانید، از استفادهٔ بافت‌های سنگین بر روی دیواره‌ها و نواحی نمودار خودداری کنید، در صورت امکان تعداد نقاط داده در هر سری را محدود کنید و خروجی را با اندازهٔ مناسب (رزولوشن و ابعاد) رندر کنید تا با نمایشگر هدف یا نیازهای چاپ مطابقت داشته باشد.
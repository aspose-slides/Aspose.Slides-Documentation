---
title: مدیریت نشانگرهای دادهٔ نمودار در ارائه‌ها در .NET
linktitle: نشانگر داده
type: docs
url: /fa/net/chart-data-marker/
keywords:
- نمودار
- نقطه داده
- نشانگر
- گزینه‌های نشانگر
- اندازه نشانگر
- نوع پر کردن
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه نشانگرهای دادهٔ نمودار را در Aspose.Slides برای .NET سفارشی کنید و با مثال‌های واضح کد C#، تأثیر ارائه را در فرمت‌های PPT و PPTX ارتقا دهید."
---
## **نمای کلی**

این مقاله نحوه کار با نشانگرهای دادهٔ نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه یک نمودار ایجاد کنید، به یک سری و نقاط دادهٔ آن دسترسی پیدا کنید، پر شدن تصویر را به نشانگرها در سطح نقطه داده اعمال کنید، اندازهٔ نشانگر را تنظیم کنید و ارائه به‌روزشده را ذخیره کنید. همچنین اشاره می‌کند که شکل‌های استاندارد نشانگر از طریق شمارش‌گر `MarkerStyleType` در دسترس هستند و ظاهر نشانگر هنگام صادرات نمودارها به فرمت‌های رستر یا SVG حفظ می‌شود.

## **تنظیم گزینه‌های نشانگر نمودار**
نشانگرها می‌توانند بر روی نقاط دادهٔ نمودار در یک سری خاص تنظیم شوند. برای تنظیم گزینه‌های نشانگر نمودار مراحل زیر را دنبال کنید:

- نمونه‌سازی کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation).
- ایجاد نمودار پیش‌فرض.
- تنظیم تصویر.
- دریافت اولین سری نمودار.
- اضافه کردن نقطه دادهٔ جدید.
- نوشتن ارائه به دیسک.

در مثال زیر، گزینه‌های نشانگر نمودار را سطح نقاط داده تنظیم کرده‌ایم.

```c#
// یک نمونه از کلاس Presentation ایجاد کنید
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// حذف سری آزمایشی
chart.ChartData.Series.Clear();

// اضافه کردن سری جدید
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// تنظیم تصویر
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// تنظیم تصویر
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// دست گرفتن اولین سری نمودار
IChartSeries series = chart.ChartData.Series[0];

// اضافه کردن نقطه جدید (1:3) در آنجا.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// تغییر نشانگر سری نمودار
series.Marker.Size = 15;

// نوشتن ارائه به دیسک
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **سوالات متداول**

**کدام شکل‌های نشانگر به صورت پیش‌فرض موجود است؟**

شکل‌های استاندارد (دایره، مربع، الماس، مثلث و غیره) در دسترس هستند؛ لیست توسط شمارش‌گر [MarkerStyleType](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/markerstyletype/) تعریف شده است. اگر به شکل غیر استاندارد نیاز دارید، از نشانگری با پر کردن تصویر برای شبیه‌سازی تصویر سفارشی استفاده کنید.

**آیا نشانگرها هنگام صادرات نمودار به تصویر یا SVG حفظ می‌شوند؟**

بله. هنگام رندر نمودارها به [raster formats](/slides/fa/net/convert-powerpoint-to-png/) یا ذخیرهٔ [shapes as SVG](/slides/fa/net/render-a-slide-as-an-svg-image/)، نشانگرها ظاهر و تنظیمات خود شامل اندازه، پر کننده و کانتور را حفظ می‌کنند.
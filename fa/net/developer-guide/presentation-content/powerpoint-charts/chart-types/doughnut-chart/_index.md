---
title: سفارشی‌سازی نمودارهای دونات در ارائه‌ها در .NET
linktitle: نمودار دونات
type: docs
weight: 30
url: /fa/net/doughnut-chart/
keywords:
- نمودار دونات
- فاصله مرکز
- اندازه سوراخ
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کشف کنید چگونه نمودارهای دونات را در Aspose.Slides برای .NET ایجاد و سفارشی کنید، با پشتیبانی از فرمت‌های PowerPoint برای ارائه‌های پویا."
---
## **بررسی کلی**

این مقاله نشان می‌دهد که چگونه با یک نمودار دونات در Aspose.Slides کار کنید با افزودن نمودار به یک اسلاید، تنظیم اندازه‌ی سوراخ مرکز آن و ذخیره ارائه. این مقاله بر تنظیم `DoughnutHoleSize` متمرکز است و گام‌های پایه مورد نیاز برای سفارشی‌سازی این نوع نمودار را در کد نشان می‌دهد.

همچنین شامل یک بخش پرسش‌های متداول کوتاه است که سناریوهای مرتبط با نمودارهای دونات را پوشش می‌دهد، مانند استفاده از چندین سری برای ایجاد چندین حلقه، کار با نمودارهای دونات منفجر شده، و خروجی گرفتن نمودار به صورت تصویر رستر یا SVG.

## **مشخص کردن فاصله مرکز در یک نمودار دونات**
برای مشخص کردن اندازه‌ی سوراخ در یک نمودار دونات. لطفاً مراحل زیر را دنبال کنید:

- یک شی از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
- نمودار دونات را به اسلاید اضافه کنید.
- اندازه‌ی سوراخ در نمودار دونات را مشخص کنید.
- ارائه را بر روی دیسک ذخیره کنید.

در مثال زیر، ما اندازه‌ی سوراخ در یک نمودار دونات را تنظیم کرده‌ایم.

```c#
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// ارائه را روی دیسک ذخیره کنید
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**آیا می‌توانم یک دونات چندسطحی با چندین حلقه ایجاد کنم؟**

بله. چندین سری را به یک نمودار دونات اضافه کنید—هر سری تبدیل به یک حلقه جداگانه می‌شود. ترتیب حلقه‌ها توسط ترتیب سری‌ها در مجموعه تعیین می‌شود.

**آیا دونات «منفجر شده» (قاشق‌های جدا شده) پشتیبانی می‌شود؟**

بله. یک نوع نمودار Exploded Doughnut [chart type](https://reference.aspose.com/slides/fa/net/aspose.slides.charts/charttype/) وجود دارد و خاصیت انفجار بر روی نقاط داده؛ می‌توانید قاشق‌های جداگانه را تفکیک کنید.

**چگونه می‌توانم یک تصویر از نمودار دونات (PNG/SVG) برای گزارش دریافت کنم؟**

یک نمودار یک شکل است؛ می‌توانید آن را به یک [raster image](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/getimage/) رندر کنید یا نمودار را به یک [SVG image](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/writeassvg/) صادر کنید.
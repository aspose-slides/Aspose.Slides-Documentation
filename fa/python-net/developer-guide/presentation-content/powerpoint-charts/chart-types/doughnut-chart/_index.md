---
title: سفارشی‌سازی نمودارهای دونات در ارائه‌ها با پایتون
linktitle: نمودار دونات
type: docs
weight: 30
url: /fa/python-net/doughnut-chart/
keywords:
- نمودار دونات
- فاصله مرکز
- اندازه سوراخ
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید نمودارهای دونات را در Aspose.Slides برای پایتون از طریق .NET ایجاد و سفارشی کنید، و فرمت‌های PowerPoint و OpenDocument را برای ارائه‌های پویا پشتیبانی می‌کند."
---
## **Overview**

این مقاله نشان می‌دهد چگونه در Aspose.Slides با افزودن نمودار دونات به اسلاید، تنظیم اندازهٔ سوراخ مرکزی و ذخیره ارائه کار کنیم. تمرکز بر تنظیم `doughnut_hole_size` است و مراحل پایه لازم برای سفارشی‌سازی این نوع نمودار را در کد نشان می‌دهد.

همچنین شامل یک بخش پرسش‑و‑پاسخ کوتاه دربارهٔ سناریوهای مرتبط با نمودار دونات، مانند استفاده از چندین سری برای ایجاد چندین حلقه، کار با نمودارهای دونات منفجره و صادرات نمودار به تصویر رستر یا SVG می‌باشد.

## **Specify Center Gap in Doughnut Chart**
برای مشخص کردن اندازهٔ سوراخ در یک نمودار دونات، مراحل زیر را دنبال کنید:

- یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) را نمونه‌سازی کنید.
- یک نمودار دونات به اسلاید اضافه کنید.
- اندازهٔ سوراخ در نمودار دونات را تعیین کنید.
- ارائه را در دیسک بنویسید.

در مثال زیر، اندازهٔ سوراخ در نمودار دونات تنظیم شده است.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# یک نمونه از کلاس Presentation ایجاد کنید
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # ارائه را در دیسک ذخیره کنید
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**آیا می‌توانم یک دونات چندسطحی با چند حلقه ایجاد کنم؟**

بله. می‌توانید چندین سری را به یک نمودار دونات اضافه کنید—هر سری تبدیل به یک حلقه جداگانه می‌شود. ترتیب حلقه‌ها توسط ترتیب سری‌ها در مجموعه تعیین می‌شود.

**آیا دونات «منفجره» (برش‌های جدا شده) پشتیبانی می‌شود؟**

بله. یک نوع نمودار [Exploded Doughnut](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/charttype/) وجود دارد و ویژگی انفجار بر نقاط داده؛ می‌توانید برش‌های جداگانه را جدا کنید.

**چگونه می‌توانم تصویری از نمودار دونات (PNG/SVG) برای گزارش دریافت کنم؟**

نمودار یک شکل است؛ می‌توانید آن را به یک [raster image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/get_image/) رندر کنید یا نمودار را به یک تصویر [SVG](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/write_as_svg/) صادر کنید.
---
title: سفارشی‌سازی نمودارهای دونات در ارائه‌ها با استفاده از پایتون از طریق جاوا
linktitle: نمودار دونات
type: docs
weight: 30
url: /fa/python-java/doughnut-chart/
keywords:
- نمودار دونات
- فاصله مرکزی
- اندازه سوراخ
- پاورپوینت
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "کشف کنید چگونه نمودارهای دونات را در Aspose.Slides برای پایتون از طریق جاوا ایجاد و سفارشی کنید و از فرمت‌های پاورپوینت برای ارائه‌های پویا پشتیبانی می‌کند."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه با یک نمودار دونات در Aspose.Slides کار کنید، با افزودن نمودار به اسلاید، تنظیم اندازهٔ سوراخ مرکزی و ذخیرهٔ ارائه. تمرکز بر روی متد [setDoughnutHoleSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) است و گام‌های پایهٔ لازم برای سفارشی‌سازی این نوع نمودار را در کد نشان می‌دهد.

همچنین یک بخش کوتاه FAQ شامل سناریوهای مرتبط با نمودار دونات، مانند استفاده از چندین سری برای ایجاد حلقه‌های متعدد، کار با نمودارهای دونات منفجر شده، و استخراج نمودار به تصویر رستری یا SVG را در بر می‌گیرد.

## **مشخص کردن فاصله مرکزی در نمودار دونات**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java امکان تعیین اندازهٔ سوراخ در یک نمودار دونات را فراهم می‌کند. این بخش نحوهٔ تعیین اندازهٔ سوراخ را با یک مثال نشان می‌دهد.
{{% /alert %}}

برای تعیین اندازهٔ سوراخ در یک نمودار دونات، مراحل زیر را دنبال کنید:

1. یک شیء [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.  
2. یک نمودار دونات به اسلاید اضافه کنید.  
3. اندازهٔ سوراخ در نمودار دونات را مشخص کنید.  
4. ارائه را بر روی دیسک بنویسید.

مثال زیر اندازهٔ سوراخ را در یک نمودار دونات تنظیم می‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# یک نمونه از کلاس Presentation ایجاد کنید.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # ارائه را روی دیسک بنویسید.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**آیا می‌توانم یک دونات چندسطحی با چند حلقه ایجاد کنم؟**

بله. چندین سری را به یک نمودار دونات اضافه کنید—هر سری تبدیل به یک حلقه جداگانه می‌شود. ترتیب حلقه‌ها توسط ترتیب سری‌ها در مجموعه تعیین می‌شود.

**آیا دونات «انفجار یافته» (قطعات جدا شده) پشتیبانی می‌شود؟**

بله. یک [نوع نمودار](https://reference.aspose.com/slides/fa/python-java/aspose.slides/charttype/) «دونات منفجر شده» وجود دارد و یک ویژگی انفجار برای نقاط داده وجود دارد؛ می‌توانید قطعات جداگانه را تفکیک کنید.

**چگونه می‌توانم یک تصویر از نمودار دونات (PNG/SVG) برای گزارش دریافت کنم؟**

یک نمودار یک [شکل](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) است؛ می‌توانید آن را به یک [تصویر رستری](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getImage) رندر کنید یا نمودار را به تصویر SVG صادرات کنید.
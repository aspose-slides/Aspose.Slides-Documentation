---
title: سفارشی‌سازی نمودارهای دونات در ارائه‌ها روی Android
linktitle: نمودار دونات
type: docs
weight: 30
url: /fa/androidjava/doughnut-chart/
keywords:
- نمودار دونات
- فاصله مرکزی
- اندازه سوراخ
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "کشف کنید چگونه نمودارهای دونات را در Aspose.Slides برای Android از طریق Java ایجاد و سفارشی کنید و از فرمت‌های PowerPoint برای ارائه‌های پویا پشتیبانی می‌کند."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه با نمودار دونات در Aspose.Slides کار کنیم؛ با اضافه کردن نمودار به یک اسلاید، تنظیم اندازهٔ سوراخ مرکزی آن و ذخیره‌سازی ارائه. این مقاله بر روش `setDoughnutHoleSize` تمرکز دارد و مراحل پایه‌ای مورد نیاز برای سفارشی‌سازی این نوع نمودار را در کد نشان می‌دهد.

همچنین شامل یک بخش سؤالات متداول کوتاه است که سناریوهای مرتبط با نمودار دونات را پوشش می‌دهد، مانند استفاده از چندین سری برای ایجاد چندین حلقه، کار با نمودارهای دونات منفجر شده، و خروجی نمودار به عنوان تصویر رستر یا SVG.

## **مشخص کردن فاصلهٔ مرکزی در نمودار دونات**
{{% alert color="primary" %}} 

Aspose.Slides برای Android از طریق Java اکنون از امکان مشخص کردن اندازهٔ سوراخ در یک نمودار دونات پشتیبانی می‌کند. در این موضوع، با مثال خواهیم دید چگونه اندازهٔ سوراخ در یک نمودار دونات را مشخص کنیم.

{{% /alert %}} 

برای مشخص کردن اندازهٔ سوراخ در یک نمودار دونات، لطفاً مراحل زیر را دنبال کنید:

1. یک شیء [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. نمودار دونات را به اسلاید اضافه کنید.
1. اندازهٔ سوراخ در نمودار دونات را مشخص کنید.
1. ارائه را بر روی دیسک بنویسید.

در مثال زیر، اندازهٔ سوراخ در نمودار دونات را تنظیم کرده‌ایم.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // ارائه را بر روی دیسک ذخیره کنید
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**آیا می‌توانم یک دونات چند سطحی با چندین حلقه ایجاد کنم؟**

بله. چندین سری را به یک نمودار دونات اضافه کنید؛ هر سری تبدیل به یک حلقه جداگانه می‌شود. ترتیب حلقه‌ها بر اساس ترتیب سری‌ها در مجموعه تعیین می‌شود.

**آیا دونات «منفجر» (قوش‌های جدا شده) پشتیبانی می‌شود؟**

بله. یک نوع نمودار Exploded Doughnut [chart type](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/) وجود دارد و یک ویژگی انفجار برای نقاط داده؛ می‌توانید قوش‌های فردی را جدا کنید.

**چگونه می‌توانم تصویر یک نمودار دونات (PNG/SVG) برای گزارش دریافت کنم؟**

یک نمودار یک شکل است؛ می‌توانید آن را به یک [raster image](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) رندر کنید یا نمودار را به یک [SVG image](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) صادر کنید.